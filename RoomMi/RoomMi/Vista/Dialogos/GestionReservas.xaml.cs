using RoomMi.Servicios;
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
    /// Interaction logic for GestionReservas.xaml
    /// </summary>
    public partial class GestionReservas : Window
    {
        private readonly Func<MainWindow> _mainWindowFactory;
        private readonly Func<Login> _loginFactory;
        private readonly UsuarioSesion _usuarioSesion;

        public GestionReservas(Func<MainWindow> mainWindowFactory, Func<Login> loginFactory, UsuarioSesion usuarioSesion)
        {
            InitializeComponent();
            _mainWindowFactory = mainWindowFactory;
            _loginFactory = loginFactory;
            _usuarioSesion = usuarioSesion;
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = _mainWindowFactory();

            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            this.Close();
        }

        // Cerrar sesión y volver al Login
        private void bntLogOut(object sender, RoutedEventArgs e)
        {
            Login login = _loginFactory();

            Application.Current.MainWindow = login;
            login.Show();
            this.Close();
        }

        // Abrir menú desplegable de notificaciones
        private void btnNotificaciones_Click(object sender, RoutedEventArgs e)
        {
            btnNotificaciones.ContextMenu.IsOpen = true;
        }

        // Controles de ventana (Minimizar, Maximizar, Cerrar)
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState.Equals(WindowState.Maximized))
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            tbNombreUsuario.Text = _usuarioSesion.UsuarioActual?.Nombre;


        }

    }
}
