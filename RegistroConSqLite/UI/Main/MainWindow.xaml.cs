using RegistroConSqLite.BLL;
using RegistroConSqLite.Entidades;
using RegistroConSqLite.UI.Consultar;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroConSqLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            PersonaId_Text.Text = "0";
            Nombre_Text.Text = string.Empty;
        }
        private bool Validar()
        {
            bool paso = true;

            if (PersonaId_Text.Text == string.Empty)
            {
                MessageBox.Show("Id Vacio", "Error");
                PersonaId_Text.Focus();
                paso = false;
            }

            if(Nombre_Text.Text == string.Empty)
            {
                MessageBox.Show("Nombre vacio","Error");
                Nombre_Text.Focus();
                paso = false;
            }

            return paso;
        }
        private Persona LlenaClase()
        {
            Persona p = new Persona();

            p.PersonaId = Convert.ToInt32(PersonaId_Text.Text);
            p.Nombre = Nombre_Text.Text;

            return p;
        }
        private void LlenaCampo(Persona p)
        {
            PersonaId_Text.Text = Convert.ToString(p.PersonaId);
            Nombre_Text.Text = p.Nombre;
        }
        private bool ExisteBase()
        {
            Persona p = PersonasBLL.Buscar((int)Convert.ToInt32(PersonaId_Text.Text));

            return (p != null);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int Id;
            int.TryParse(PersonaId_Text.Text, out Id);

            Persona p = new Persona();
            p = PersonasBLL.Buscar(Id);

            if(p != null)
            {
                LlenaCampo(p);
            }
            else
            {
                MessageBox.Show("No se Encontró");
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Persona p;

            if (!Validar())
            {
                return;
            }

            p = LlenaClase();

            if(PersonaId_Text.Text == "0")
            {
                paso = PersonasBLL.Guardar(p);
            }
            else
            {
                if (!ExisteBase())
                {
                    MessageBox.Show("No Existe en la database", "Error");
                    return;
                }
                paso = PersonasBLL.Modificar(p);
            }
            
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("Error al Guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int Id;
            int.TryParse(PersonaId_Text.Text, out Id);

            Limpiar();

            if (PersonasBLL.Eliminar(Id))
            {
                MessageBox.Show("Eliminado");
            }
            else
            {
                MessageBox.Show("Error al Eliminar");
            }
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            Consultar c = new Consultar();
        }
    }
}
