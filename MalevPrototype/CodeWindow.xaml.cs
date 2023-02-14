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
using System.Windows.Threading;

namespace MalevPrototype
{
    /// <summary>
    /// Логика взаимодействия для CodeWindow.xaml
    /// </summary>
    public partial class CodeWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        int codec;

        int scetc;

        public CodeWindow(int code, int schet)
        {
            InitializeComponent();

            codec = code;
            scetc = schet;
            scetc++;
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler(Timer_Trick);
            timer.Start();
        }

        private void tboxCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tboxCode.Text.Length == 5)
            {
                if (Convert.ToInt32(tboxCode.Text) == codec)
                {
                    FrameClass.frame.Navigate(new AdminPage());

                    Close();
                }

                else
                {
                    MessageBox.Show("Код неверный!");

                    FrameClass.frame.Navigate(new AutoPage(scetc));

                    Close();
                }
            }
        }

        private void Timer_Trick(object sender, EventArgs e)
        {
            scetc++;

            Close();
        }
    }
}
