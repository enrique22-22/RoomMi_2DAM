using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;
using RoomMi.Vista.Dialogos;

namespace RoomMi.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para RecuperarPassword.xaml
    /// </summary>
    public partial class RecuperarPassword : MetroWindow
    {
        private Login _login;

        public RecuperarPassword(Login login)
        {
            InitializeComponent();
            _login = login; 
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreoElectronico.Text))
            {

                this.ShowMessageAsync("Error de confirmación de contraseña",
                "Por favor, introduce la misma contraseña.");
            }
            else
            {
                _login.Show();
                Close();
            }

        }

        private void CambioInicioSesion_Click(object sender, RoutedEventArgs e)
        {
            _login.Show();
            Close();
        }
    }
}
