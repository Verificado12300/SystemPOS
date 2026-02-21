namespace SistemaPOS.Utils
{
    /// <summary>
    /// Helper para normalizar nombres de unidades de medida y formatear
    /// headers/labels de UI de forma homogénea en todo el sistema.
    /// Solo afecta textos visuales — no toca cálculos ni SQL.
    /// </summary>
    public static class UiUnitsHelper
    {
        /// <summary>
        /// Normaliza el símbolo de unidad base para display uniforme.
        /// Ej: "Kilogramo" → "kg", "Litro" → "L", "" → "unid."
        /// </summary>
        public static string NormalizeUnit(string rawSymbol)
        {
            if (string.IsNullOrWhiteSpace(rawSymbol)) return "unid.";

            switch (rawSymbol.Trim().ToLowerInvariant())
            {
                case "kilogramo":
                case "kilogramos":
                    return "kg";
                case "litro":
                case "litros":
                    return "L";
                case "unidad":
                case "unidades":
                case "und":
                    return "und";
                case "gramo":
                case "gramos":
                case "g":
                    return "g";
                case "mililitro":
                case "mililitros":
                case "ml":
                    return "mL";
                default:
                    return rawSymbol.Trim();
            }
        }

        /// <summary>
        /// Formatea el header de una columna de cantidad.
        /// Ej: "Entrada" + "kg" → "Entrada (kg)"
        /// </summary>
        public static string FormatQtyHeader(string baseLabel, string unit)
        {
            string u = NormalizeUnit(unit);
            return $"{baseLabel} ({u})";
        }

        /// <summary>
        /// Formatea un label de costo por unidad.
        /// Ej: "Costo unitario" + "kg" → "Costo unitario (S/ por kg)"
        /// </summary>
        public static string FormatMoneyPerUnit(string label, string unit)
        {
            string u = NormalizeUnit(unit);
            return $"{label} (S/ por {u})";
        }
    }
}
