using System;
using System.Collections.Generic;
using System.IO;
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

namespace ConferentionOrganisationProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        private int CountAuthTries { get; set; }
        private string CaptchaText { get; set; }
        public Authorization()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            CaptchaLabel.Visibility = Visibility.Collapsed;
            CaptchaAnswerTB.Visibility = Visibility.Collapsed;
            CaptchaImage.Visibility = Visibility.Collapsed;
            string Data = Decode();
            if (!string.IsNullOrEmpty(Data))
            {
                LoginTB.Text = Data.Split(':')[0];
                PasswordPB.Password = Data.Split(':')[1];
            }
        }

        [Obsolete]
        private BitmapSource GenerateCaptcha()
        {
            CaptchaText = "";
            List<char> Words = new List<char>("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray());
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                CaptchaText += Words[rnd.Next(Words.Count)];
            }
            var Visual = new DrawingVisual();
            int Width = 200;
            int Height = 80;
            using (var DrawContext = Visual.RenderOpen())
            {
                int X = 10;
                var Font = new Typeface(new FontFamily("Calibri"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
                foreach (var i in CaptchaText)
                {
                    DrawContext.PushTransform(new TranslateTransform(X, -rnd.Next(5, 10)));
                    var FormatedText = new FormattedText(i.ToString(),
                        System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                        Font, 72, new SolidColorBrush(Colors.DarkGreen));
                    DrawContext.DrawText(FormatedText, new Point(X, 10));
                    DrawContext.Pop();
                    X += 17;
                }
                for (int i = 0; i < 100; i++)
                {
                    Pen pen = new Pen();
                    DrawContext.DrawEllipse(Brushes.BlueViolet, pen, new Point(rnd.Next(Width), rnd.Next(Height)), 1.2, 1.2);
                }
            }
            var BitmapImage = new RenderTargetBitmap(Width, Height, 62, 62, PixelFormats.Pbgra32);
            BitmapImage.Render(Visual);
            return BitmapImage;
        }

        [Obsolete]
        private async void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                string Login = LoginTB.Text;
                string Password = PasswordPB.Password;
                string CaptchaAnswer = CaptchaAnswerTB.Text;
                if (string.IsNullOrEmpty(Login))
                {
                    errors.AppendLine("Заполните поле логина");
                }
                if (!int.TryParse(Login, out var res))
                {
                    errors.AppendLine("Логин это id");
                }
                if (string.IsNullOrEmpty(Password))
                {
                    errors.AppendLine("Заполните поле пароля");
                }
                if (CountAuthTries >= 3 && string.IsNullOrEmpty(CaptchaAnswer))
                {
                    errors.AppendLine("Каптча не решена");
                }
                else if (CountAuthTries >= 3 && CaptchaAnswer != CaptchaText)
                {
                    errors.AppendLine("Каптча решена неправильно");
                    CaptchaAnswerTB.Text = "";
                    CaptchaImage.Source = GenerateCaptcha();
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int LoginToInt = Convert.ToInt32(Login);
                var user = Model.ConferentionOrganisationDBEntities.GetContext().Users
                    .Where(d => d.User_Id == LoginToInt && d.User_Password == Password).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("Неправильный логин/пароль", "Ошибка!", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    CountAuthTries++;
                    if (CountAuthTries >= 1)
                    {
                        CaptchaLabel.Visibility = Visibility.Visible;
                        CaptchaAnswerTB.Visibility = Visibility.Visible;
                        CaptchaImage.Visibility = Visibility.Visible;
                        CaptchaImage.Source = GenerateCaptcha();
                        CaptchaAnswerTB.Text = "";
                        AuthButton.IsEnabled = false;
                        await Task.Delay(1000);
                        AuthButton.IsEnabled = true;
                    }
                    return;
                }
                CaptchaLabel.Visibility = Visibility.Collapsed;
                CaptchaAnswerTB.Visibility = Visibility.Collapsed;
                CaptchaImage.Visibility = Visibility.Collapsed;
                CountAuthTries = 0;
                Encode(user);
                MessageBox.Show("Успешный вход", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                if (user.Roles != null)
                {
                    switch (user.Roles.Roles_Name)
                    {
                        case "Жюри":
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.NotOrgPage(user.Roles.Roles_Name));
                            break;
                        case "Модератор":
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.NotOrgPage(user.Roles.Roles_Name));
                            break;
                        case "Участник":
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.NotOrgPage(user.Roles.Roles_Name));
                            break;
                        case "Организатор":
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.OrganisatorPage(user));
                            break;

                    }
                }
                else
                {
                    switch (user.User_Role_Id)
                    {
                        case 1:
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.NotOrgPage(1));
                            break;
                        case 2:
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.NotOrgPage(2));
                            break;
                        case 4:
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.NotOrgPage(4));
                            break;
                        case 3:
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.OrganisatorPage(user));
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.ListViewFrame());
        }

        private void Encode(Model.Users User)
        {
            string Token = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{User.User_Id}:{User.User_Password}"));
            Token = Token.Remove(Token.Length - 1, 1);
            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\"));
            using (StreamWriter sw = new StreamWriter(path + @"\token.txt"))
            {
                sw.WriteLine(Token);
            }
        }

        private string Decode()
        {
            string Token = "";
            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\"));
            if (File.Exists(path + @"\token.txt"))
            {
                using (StreamReader sr = new StreamReader(path + @"\token.txt"))
                {
                    Token = sr.ReadLine();
                }
            }
            return !string.IsNullOrEmpty(Token) ? System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Token + "=")) : null;
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.RegisterFrame());
        }
    }
}
