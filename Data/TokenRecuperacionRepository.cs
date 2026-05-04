using System;
using System.Data.SQLite;

namespace SistemaPOS.Data
{
    public static class TokenRecuperacionRepository
    {
        public static string GenerarToken(int usuarioID)
        {
            string codigo = new Random().Next(100000, 999999).ToString();
            string ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string expira = DateTime.Now.AddMinutes(15).ToString("yyyy-MM-dd HH:mm:ss");

            using (var conn = DatabaseConnection.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                using (var cmd = new SQLiteCommand(
                    "UPDATE TokensRecuperacion SET Usado=1 WHERE UsuarioID=@uid AND Usado=0", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@uid", usuarioID);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SQLiteCommand(@"
                    INSERT INTO TokensRecuperacion (UsuarioID, Token, FechaCreacion, FechaExpiracion, Usado)
                    VALUES (@uid, @token, @creacion, @expiracion, 0)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@uid", usuarioID);
                    cmd.Parameters.AddWithValue("@token", codigo);
                    cmd.Parameters.AddWithValue("@creacion", ahora);
                    cmd.Parameters.AddWithValue("@expiracion", expira);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }

            return codigo;
        }

        public static (bool Valido, int UsuarioID) ValidarToken(string codigo)
        {
            string ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(@"
                SELECT UsuarioID FROM TokensRecuperacion
                WHERE Token=@token AND Usado=0 AND FechaExpiracion > @ahora
                ORDER BY TokenID DESC LIMIT 1", conn))
            {
                cmd.Parameters.AddWithValue("@token", codigo);
                cmd.Parameters.AddWithValue("@ahora", ahora);
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return (true, Convert.ToInt32(result));
                return (false, 0);
            }
        }

        public static void MarcarUsado(string codigo)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(
                "UPDATE TokensRecuperacion SET Usado=1 WHERE Token=@token", conn))
            {
                cmd.Parameters.AddWithValue("@token", codigo);
                cmd.ExecuteNonQuery();
            }
        }

        public static (bool TieneEmail, string EmailMascarado, int UsuarioID, string NombreCompleto)
            BuscarPorCorreo(string correo)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(@"
                SELECT UsuarioID, NombreCompleto, Email
                FROM Usuarios
                WHERE LOWER(Email)=LOWER(@correo) AND Activo=1 LIMIT 1", conn))
            {
                cmd.Parameters.AddWithValue("@correo", correo.Trim());
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return (false, null, 0, null);

                    int uid = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string email = reader.IsDBNull(2) ? null : reader.GetString(2);

                    string mascara = MascararEmail(email);
                    return (true, mascara, uid, nombre);
                }
            }
        }

        public static string ObtenerEmailPorUsuarioID(int usuarioID)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SQLiteCommand(
                "SELECT Email FROM Usuarios WHERE UsuarioID=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", usuarioID);
                var result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value ? null : result.ToString();
            }
        }

        private static string MascararEmail(string email)
        {
            int at = email.IndexOf('@');
            if (at <= 1) return "****" + email.Substring(at);
            int visible = Math.Max(1, Math.Min(3, at - 1));
            return email.Substring(0, visible) + new string('*', at - visible) + email.Substring(at);
        }
    }
}
