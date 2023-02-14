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
using System.Windows.Threading;

namespace MalevPrototype
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();

        int schet = 0;

        int ch = 0;

        int time = 0;

        string login = "Anton";

        string password = "Anton";

        public AutoPage(int schet)
        {
            InitializeComponent();

            this.schet = schet;

            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += new EventHandler(Timer_Trick);

            if (schet == 1)
            {
                btnAuto.IsEnabled = false;

                btnCode.Visibility = Visibility.Visible;

                label.Visibility = Visibility.Visible;

                labelTime.Visibility = Visibility.Visible;

                timer.Start();
            }

            else if (schet == 2)
            {
                btnCode.IsEnabled = false;

                btnCode.Visibility = Visibility.Visible;

                btnCode.IsEnabled = false;

            }

            else
            {
                btnAuto.IsEnabled = true;
            }
        }

        private void Timer_Trick(object sender, EventArgs e)
        {
            if (time != 0)
            {
                time--;

                labelTime.Content = time.ToString();
            }

            else
            {
                btnCode.IsEnabled = true;
            }
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            int code = random.Next(10000, 90000);

            if (tboxLogin.Text == login)
            {
                if (pbPassword.Password == password)
                {
                    MessageBox.Show(code.ToString());

                    MessageBoxResult res = MessageBoxResult.OK;

                    switch (res)
                    {
                        case MessageBoxResult.OK:

                            CodeWindow codeWindow = new CodeWindow(code, schet);

                            codeWindow.ShowDialog();

                            schet++;

                            if (schet == 1)
                            {
                                btnAuto.IsEnabled = false;

                                btnCode.Visibility = Visibility.Visible;

                                label.Visibility = Visibility.Visible;

                                labelTime.Visibility = Visibility.Visible;

                                timer.Start();
                            }

                            else if (schet == 2)
                            {
                                btnAuto.IsEnabled = false;

                                btnAuto.Visibility = Visibility.Visible;

                                btnAuto.IsEnabled = false;

                                CAPTCHAWindow captchaWindow = new CAPTCHAWindow(schet, ch);

                                captchaWindow.ShowDialog();
                            }

                            else
                            {
                                btnAuto.IsEnabled = true;
                            }

                            break;
                    }
                }

                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }

            else
            {
                MessageBox.Show("Неверный логин!");
            }
        }

        private void btnCode_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            int code = random.Next(10000, 90000);

            if (tboxLogin.Text == login)
            {
                if (pbPassword.Password == password)
                {
                    MessageBox.Show(code.ToString());

                    MessageBoxResult res = MessageBoxResult.OK;

                    switch (res)
                    {
                        case MessageBoxResult.OK:

                            CodeWindow codeWindow = new CodeWindow(code, schet);

                            codeWindow.ShowDialog();

                            schet++;

                            if (AdminPage.scet > 1)
                            {
                                FrameClass.frame.Navigate(new AdminPage());
                            }
                            else
                            {
                                if (schet == 1)
                                {
                                    btnAuto.IsEnabled = false;

                                    btnCode.Visibility = Visibility.Visible;

                                    label.Visibility = Visibility.Visible;

                                    labelTime.Visibility = Visibility.Visible;

                                    timer.Start();
                                }

                                else if (schet == 2)
                                {
                                    btnAuto.IsEnabled = false;

                                    btnCode.Visibility = Visibility.Visible;

                                    btnCode.IsEnabled = false;

                                    FrameClass.frame.Navigate(new AutoPage(schet));

                                    CAPTCHAWindow captchaWindow = new CAPTCHAWindow(schet, ch);

                                    captchaWindow.ShowDialog();

                                    break;

                                }

                                else
                                {
                                    btnAuto.IsEnabled = true;
                                }


                            }

                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Неверный логин!");
            }
        }
    }
}
