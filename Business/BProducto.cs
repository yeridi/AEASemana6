using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BProducto
    {
        private DProducto dProducto = new DProducto();

        public List<Producto> Listar()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                productos = dProducto.Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return productos;
        }

        public bool Insertar(Producto producto)
        {
            bool result = true;
            try
            {
                dProducto.Insertar(producto);
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }

        
        public bool Actualizar(Producto producto)
        {
            bool result = true;
            try
            {
                dProducto.Actualizar(producto);
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }

        public bool Eliminar(int IdCategoria)
        {
            bool result = true;
            try
            {
                dProducto.Eliminar(IdCategoria);
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }
    }
}
