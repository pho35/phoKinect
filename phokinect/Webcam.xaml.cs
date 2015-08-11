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
using Microsoft.Kinect;
using System.Windows.Media.Imaging;

namespace phokinect
{
    /// <summary>
    /// Logique d'interaction pour Webcam.xaml
    /// </summary>
    public partial class Webcam : Window
    {
        public Webcam()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KinectSensor myKinectSensor;
            if (KinectSensor.KinectSensors.Count != 0)
            {
                if (KinectSensor.KinectSensors[0].Status == KinectStatus.Connected){
                    myKinectSensor = KinectSensor.KinectSensors[0];
                    myKinectSensor.ColorFrameReady += myKinectSensor_ColorFrameReady;
                    myKinectSensor.ColorStream.Enable(ColorImageFormat.RgbResolution1280x960Fps12);
                }
                else
                {
                    MessageBox.Show("Le capteur Kinect n'est pas prêt !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Le Capteur Kinect n'est pas connecté ! Veuillez-la connecter !","Erreur",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                this.Close();
            }

        }

        void myKinectSensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame es = e.OpenColorImageFrame())
            {
                if (!(es == null))
                {
                    byte[] bits = new byte[es.PixelDataLength];
                    es.CopyPixelDataTo(bits);
                    image1.Source = BitmapSource.Create(es.Width, es.Height, 96, 96, PixelFormats.Bgr32, null, bits, es.Width * es.BytesPerPixel);
                }
            }
        }
    }
}
