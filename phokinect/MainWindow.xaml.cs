using Microsoft.Kinect;
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

namespace phokinect
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnrq_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnwebcam_Click(object sender, RoutedEventArgs e)
        {
            Webcam  myWebcam= new Webcam();
            myWebcam.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (KinectSensor.KinectSensors.Count != 0)
            {
                lblerror.Visibility = Visibility.Hidden;
            }
            else
            {
                lblerror.Visibility = Visibility.Visible;
                lblerror.Content = "Le Capteur Kinect n'est pas connecté ! Veuillez-la connecter !";
                btnskeleton.IsEnabled = false;
                btnwebcam.IsEnabled = false;

            }
        }
    }
}
