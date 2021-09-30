using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entity;
using Business;
namespace Semana05
{
    /// <summary>
    /// Interaction logic for ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }
        public BProducto bProducto = new BProducto();
        public ManProducto(Producto producto)
        {
            InitializeComponent();

            if (producto.idproducto > 0)
            {
                txtIdProducto.Text = producto.idproducto.ToString();
                txtNombreProducto.Text = producto.nombreProducto.ToString();
                txtIdProveedor.Text = producto.idProveedor.ToString();
                txtIdCategoria.Text = producto.idCategoria.ToString();
                txtCantidadPorUnidad.Text = producto.cantidadPorUnidad.ToString();
                txtPrecioUnidad.Text = producto.precioUnidad.ToString();
                txtUnidadesEnExistencia.Text = producto.unidadesEnExistencia.ToString();
                txtUnidadesEnPedido.Text = producto.unidadesEnPedido.ToString();
                txtNivelNuevoPedido.Text = producto.nivelNuevoPedido.ToString();
                chkSuspendido.IsChecked = producto.suspendido == 1;
                txtCategoriaProducto.Text = producto.categoriaProducto.ToString();
            }
            else
            {
                btnEliminar.IsEnabled = false;
                txtIdProducto.Text = producto.idproducto.ToString();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            Producto producto = new Producto()
            {
                idproducto = Convert.ToInt32(txtIdProducto.Text),
                nombreProducto = txtNombreProducto.Text,
                idProveedor = Convert.ToInt32(txtIdProveedor.Text),
                idCategoria = Convert.ToInt32(txtIdCategoria.Text),                cantidadPorUnidad = txtCantidadPorUnidad.Text,
                precioUnidad = Convert.ToDouble(txtPrecioUnidad.Text),
                unidadesEnExistencia = Convert.ToInt32(txtUnidadesEnExistencia.Text),
                unidadesEnPedido = Convert.ToInt32(txtUnidadesEnPedido.Text),
                nivelNuevoPedido = Convert.ToInt32(txtNivelNuevoPedido.Text),
                suspendido = chkSuspendido.IsChecked == true ? 1 : 0,
                categoriaProducto = txtCategoriaProducto.Text
            };

            if (producto.idproducto == 0)
            {
                try
                {
                    bProducto.Insertar(producto);
                    MessageBox.Show("Producto guardado correctamente");

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Producto actualizado correctamente");

                bProducto.Actualizar(producto);
            }

            this.Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BProducto bProducto = new BProducto();
                bProducto.Eliminar(int.Parse(txtIdProducto.Text));
                MessageBox.Show("Categoria eliminada correctamente");
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.ToString());

            }
        }
    }
}
