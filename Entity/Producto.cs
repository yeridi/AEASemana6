using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public int idproducto { get; set; }
        public string nombreProducto { get; set; }
        public int idProveedor { get; set; }
        public int idCategoria { get; set; }
        public string cantidadPorUnidad { get; set; }
        public double precioUnidad { get; set; }
        public int unidadesEnExistencia { get; set; }
        public int unidadesEnPedido { get; set; }
        public int nivelNuevoPedido { get; set; }
        public int suspendido { get; set; }
        public string categoriaProducto { get; set; }
    }
}
