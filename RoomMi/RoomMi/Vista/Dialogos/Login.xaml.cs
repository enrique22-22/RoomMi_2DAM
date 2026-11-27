using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using RoomMi.Modelos;
using RoomMi.Servicios;
using RoomMi.Servicios.Interfaces;
using RoomMi.Vista.Dialogos;
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


namespace RoomMi.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {

        private readonly Func<MainWindow> _mainWindowFactory;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly UsuarioSesion _usuarioSesion;
        public Login(Func<MainWindow> mainWindowFactory, IUsuarioServicio usuarioServicio, UsuarioSesion usuarioSesion)
        {
            InitializeComponent();
            _mainWindowFactory = mainWindowFactory;
            _usuarioServicio = usuarioServicio;
            _usuarioSesion = usuarioSesion;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtLoginCorreo.Text;
            string pasasword = passContraseñaLogin.Password;
            Usuario? usuario;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pasasword))
            {

                await this.ShowMessageAsync("Error de inicio de sesión",
                    "Por favor, ingrese un nombre de usuario y una contraseña.");

            }
            else { 
                usuario = await _usuarioServicio.LoginAsync(username, pasasword);
                if (usuario != null)

                {
                    _usuarioSesion.UsuarioActual = usuario;
                    MainWindow mainWindow = _mainWindowFactory();
                    Application.Current.MainWindow = mainWindow;
                    mainWindow.Show();
                    Close();

                }
                else
                {
                    await this.ShowMessageAsync("Error de inicio de sesión",
                        "Nombre de usuario o contraseña incorrectos.");
                }
            }
        }

        private void bntRecupPassword(object sender, RoutedEventArgs e)
        {
            RecuperarPassword recuperar = new RecuperarPassword(this);

            recuperar.Show();

            this.Hide();
        }
    }
}
