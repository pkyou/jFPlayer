using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaElement myPlayer = new MediaElement();
        DispatcherTimer timer = new DispatcherTimer();
        Dictionary<int, byte[]> keyValuePairs = new Dictionary<int, byte[]>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeKeyValuePairs();
            myPlayer.Margin = new Thickness(1, 1, 1, 1);
            myPlayer.Width = ActualWidth;
            myPlayer.Height = ActualHeight;
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;

            myPlayer.LoadedBehavior = MediaState.Manual;
            var mp4_path = AppDomain.CurrentDomain.BaseDirectory + "video.mp4";
            myPlayer.Source = new Uri(mp4_path, UriKind.RelativeOrAbsolute);

            (Content as Grid).Children.Add(myPlayer);
        }

        private void InitializeKeyValuePairs()
        {
            keyValuePairs[5] = new byte[] { 0x01, 0x05 };

            keyValuePairs[10] = new byte[] { 0x02, 0x10 };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(myPlayer.Position.TotalSeconds < 6 && myPlayer.Position.TotalSeconds > 4)
            {
                SendMessage(5);
            }
            if (myPlayer.Position.TotalSeconds < 11 && myPlayer.Position.TotalSeconds > 9)
            {
                SendMessage(10);
            }
        }

        private void SendMessage(int symbol)
        {
            if (!keyValuePairs.Keys.Contains(symbol))
            {
                return;
            }

            byte[] data = keyValuePairs[symbol];
            SerialPort port1 = new SerialPort()
            {
                PortName = "COM1",
                BaudRate = 115200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One
            };
            
            SerialPortManage manage = new SerialPortManage();

            if (manage.OpenPort(port1))
            {
                manage.SendDataPacket(data);

                manage.ClosePort();
            }
            keyValuePairs.Remove(symbol);
        }

        void myContent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (FullScreenHelper.IsFullscreen(this))
                FullScreenHelper.ExitFullscreen(this);
            else
                FullScreenHelper.GoFullscreen(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            myPlayer.Play();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            myPlayer.Width = ActualWidth;
            myPlayer.Height = ActualHeight;
        }

    }
}
