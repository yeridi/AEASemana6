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
using Business;
using Entity;
namespace Semana05
{
    /// <summary>
    /// Interaction logic for ListaProducto.xaml
    /// </summary>
    public partial class ListaProducto : Window
    {
        public ListaProducto()
        {
            InitializeComponent();
        }

        private void Cargar()
        {
            BProducto bProducto = null;
            try
            {
                bProducto = new BProducto();
                dgvProducto.ItemsSource = bProducto.Listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Comunicarse con el administrador: " + ex.ToString());
            }
            
        }

        private void dgvProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Producto)dgvProducto.SelectedItem;
            if (item == null) return;
            ManProducto manProducto = new ManProducto(item);
            manProducto.ShowDialog();
            Cargar();
        }

        private void btnConsulta_Click(object sender, RoutedEventArgs e)
        {
            Cargar();

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto();
            producto.idproducto = 0;
            ManProducto manProducto = new ManProducto(producto);
            manProducto.ShowDialog();
            Cargar();
        }
    }
}
