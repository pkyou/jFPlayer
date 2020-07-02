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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaElement myPlayer = new MediaElement();

        public MainWindow()
        {
            InitializeComponent();

            myPlayer.Margin = new Thickness(1, 1, 1, 1);
            myPlayer.Width = ActualWidth;
            myPlayer.Height = ActualHeight;

            myPlayer.LoadedBehavior = MediaState.Manual;
            var mp4_path = AppDomain.CurrentDomain.BaseDirectory + "video.mp4";
            myPlayer.Source = new Uri(mp4_path, UriKind.RelativeOrAbsolute);

            (Content as Grid).Children.Add(myPlayer);
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
            myPlayer.Play();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            myPlayer.Width = ActualWidth;
            myPlayer.Height = ActualHeight;
        }

    }
}
