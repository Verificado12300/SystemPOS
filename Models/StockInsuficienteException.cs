using System;

namespace SistemaPOS.Models
{
    /// <summary>
    /// Excepción lanzada cuando el stock disponible es insuficiente para completar una operación.
    /// Permite distinguirla del resto de errores y mostrar un diálogo visual específico.
    /// </summary>
    public class StockInsuficienteException : Exception
    {
        public int     ProductoID         { get; }
        public decimal CantidadSolicitada { get; }

        public StockInsuficienteException(int productoID, decimal cantidadSolicitada)
            : base($"Stock insuficiente para ProductoID {productoID}.")
        {
            ProductoID         = productoID;
            CantidadSolicitada = cantidadSolicitada;
        }
    }
}
