using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BCategoria
    {
        private DCategoria DCategoria = null;

        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias = null;
            try
            {
                DCategoria = new DCategoria();
                categorias = DCategoria.Listar(new Categoria { IdCategoria = IdCategoria });
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return categorias;
        }

        public bool Insertar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Insertar(categoria);
            }
            catch (Exception )
            {

                result = false ;
            }
            return result;
        }

        public bool Insertar2(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                int id = DCategoria.GetMaxId();
                categoria.IdCategoria = id + 1;
                Console.WriteLine(categoria.IdCategoria);
                DCategoria.Insertar2(categoria);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.ToString());
                result = false;
            }
            return result;
        }
        public bool Actualizar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Actualizar(categoria);
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
                DCategoria = new DCategoria();
                DCategoria.Eliminar(IdCategoria);
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }
    }
}
