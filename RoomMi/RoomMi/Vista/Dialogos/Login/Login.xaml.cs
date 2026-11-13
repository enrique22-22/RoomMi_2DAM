using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using RecuperarPasswordWindow = RoomMi.ProyectoIntermodular.EnriqueyAdrian.Vista.Dialogos.RecuperarPassword.RecuperarPassword;


namespace RoomMi.ProyectoIntermodular.EnriqueyAdrian.Vista.Dialogos.Login
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {

        private MainWindow _mainWindow;
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoginCorreo.Text) || string.IsNullOrEmpty(passContraseñaLogin.Password))
            {

                this.ShowMessageAsync("Error de inicio de sesión",
                    "Por favor, ingrese un nombre de usuario y una contraseña.");

            }
            else
            {

                Application.Current.MainWindow = _mainWindow;
                _mainWindow.Show();
                Close();

            }

        }

        private void bntRecupPassword(object sender, RoutedEventArgs e)
        {
            RecuperarPasswordWindow recuperar = new RecuperarPasswordWindow(this);

            recuperar.Show();

            this.Hide();
        }
    }
}
