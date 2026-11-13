using RoomMi.Vista.Dialogos;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoomMi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly Func<Login> _loginFactory;
        public MainWindow(Func<Login> loginFactory)
        {
            InitializeComponent();
            _loginFactory = loginFactory;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Applicaction.Current.Shutdown();

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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void btnNotificaciones_Click(object sender, RoutedEventArgs e)
        {
            btnNotificaciones.ContextMenu.IsOpen = true;
        }

        private void bntLogOut(object sender, RoutedEventArgs e)
        {
            Login login = _loginFactory();

            Application.Current.MainWindow = login;

            login.Show();
            this.Close();
        }
    }
}