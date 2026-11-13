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
using LoginWindow = RoomMi.ProyectoIntermodular.EnriqueyAdrian.Vista.Dialogos.Login.Login;

namespace RoomMi.ProyectoIntermodular.EnriqueyAdrian.Vista.Dialogos.RecuperarPassword
{
    /// <summary>
    /// Lógica de interacción para RecuperarPassword.xaml
    /// </summary>
    public partial class RecuperarPassword : MetroWindow
    {
        private LoginWindow _login;

        public RecuperarPassword(LoginWindow login)
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
