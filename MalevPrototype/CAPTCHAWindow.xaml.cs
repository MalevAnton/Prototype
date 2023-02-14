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

namespace MalevPrototype
{
    /// <summary>
    /// Логика взаимодействия для CAPTCHAWindow.xaml
    /// </summary>
    public partial class CAPTCHAWindow : Window
    {
        int ch = 0;

        int schet;

        string ca = "";

        public CAPTCHAWindow(int schet, int ch)
        {
            InitializeComponent();

            this.schet = schet;

            this.ch = ch;

            string[] capcha = new string[10];

            string[] capc = new string[10];

            Random random = new Random();

            int count = random.Next(7, 10);

            for (int i = 0; ca.Length < count; i++)
            {
                if (random.Next(1, 3) == 1)
                {
                    capcha[i] = Convert.ToString(random.Next(0, 9)) + (char)(random.Next('A', 'Z'));

                    ca = ca + capcha[i];
                }
                else
                {
                    capcha[i] = Convert.ToString(random.Next(0, 9)) + (char)(random.Next('a', 'z'));

                    ca = ca + capcha[i];
                }
                capc[i] = capcha[i];
            }

            int shar = random.Next(1, 3);

            if (shar == 1)
            {
                TextBlock te = new TextBlock()
                {

                    Text = Convert.ToString(ca.ToString()),

                    Margin = new Thickness(20),

                    Padding = new Thickness(40),

                    FontSize = random.Next(13, 18),

                    FontStyle = FontStyles.Italic,
                };

                canvas.Children.Add(te);
            }

            else if (shar == 2)
            {
                TextBlock te = new TextBlock()
                {
                    Text = Convert.ToString(ca.ToString()),

                    Margin = new Thickness(20),

                    Padding = new Thickness(40),

                    FontSize = random.Next(13, 18),

                    FontStyle = FontStyles.Italic,

                    FontWeight = FontWeights.Bold,
                };

                canvas.Children.Add(te);
            }

            else if (shar == 3)
            {
                TextBlock te = new TextBlock()
                {

                    Text = Convert.ToString(ca.ToString()),

                    Margin = new Thickness(20),

                    Padding = new Thickness(40),

                    FontSize = random.Next(13, 18),

                    FontWeight = FontWeights.Bold,
                };

                canvas.Children.Add(te);
            }

            Line l1 = new Line()
            {
                X1 = random.Next(225),

                Y1 = random.Next(125),

                Stroke = Brushes.Violet,

                StrokeThickness = random.Next(2, 7),
            };

            canvas.Children.Add(l1);

            Line l2 = new Line()
            {
                X1 = random.Next(225),

                Y1 = random.Next(125),

                Stroke = Brushes.SpringGreen,

                StrokeThickness = random.Next(2, 7),
            };

            canvas.Children.Add(l2);

            Line l3 = new Line()
            {
                X1 = random.Next(-325, 0),

                Y1 = random.Next(10, 70),

                Stroke = Brushes.SteelBlue,

                StrokeThickness = random.Next(2, 7),
            };

            canvas.Children.Add(l3);

            Line l4 = new Line()
            {
                X1 = random.Next(355, 399),

                Y1 = random.Next(40, 100),

                Stroke = Brushes.Tan,

                StrokeThickness = random.Next(2, 7),
            };

            canvas.Children.Add(l4);

            Line l5 = new Line()
            {
                X1 = random.Next(-225, 0),

                Y1 = random.Next(125),

                Stroke = Brushes.Tomato,

                Fill = Brushes.Tomato,

                StrokeThickness = random.Next(2, 7),
            };

            canvas1.Children.Add(l5);
        }

        private void captchaCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (captchaCode.Text == ca)
            {
                FrameClass.frame.Navigate(new AdminPage());

                Close();
            }

            else
            {
                if (ch == 0)
                {
                    ch++;

                    MessageBox.Show("Код неверный!");

                    MessageBox.Show("Повторите попытку!");

                    Close();

                    CAPTCHAWindow captchaWindow = new CAPTCHAWindow(schet, ch);

                    captchaWindow.ShowDialog();

                }

                else if (ch == 1)
                {
                    MessageBox.Show("Код неверный!");

                    MessageBox.Show("Не удалось произвести вход!");

                    FrameClass.frame.Navigate(new AutoPage(schet));

                    Close();
                }

                Close();
            }
        }
    }
}
