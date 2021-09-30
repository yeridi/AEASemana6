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
    /// Interaction logic for ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        public int ID { get; set; }
        public ManCategoria(int id)
        {
            InitializeComponent();
            ID = id;
            txtId.IsEnabled = false;

            if (ID > 0)
            {
                BCategoria bCategoria = new BCategoria();
                List<Categoria> categorias = bCategoria.Listar(ID);

                if (categorias.Count > 0)
                {
                    txtId.Text = categorias[0].IdCategoria.ToString();
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }

            }
            else
            {
                btnEliminar.IsEnabled = false;

            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string id = txtId.Text;
            BCategoria bCategoria = new BCategoria();

            if (id.Length == 0)
            {
                Categoria categoria = new Categoria() { NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text };
                try
                {
                    
                    bCategoria.Insertar2(categoria);
                    MessageBox.Show("Categoria guardada correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
            else
            {
                Categoria categoria = new Categoria() {IdCategoria = int.Parse(txtId.Text) ,NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text };
                try
                {
                    bCategoria.Actualizar(categoria);
                    MessageBox.Show("Categoria actualizada correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.ToString());
                }

            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BCategoria bCategoria = new BCategoria();
                bCategoria.Eliminar(int.Parse(txtId.Text));
                MessageBox.Show("Categoria eliminada correctamente");
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.ToString());

            }
        }

        private void btnGuardar2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
