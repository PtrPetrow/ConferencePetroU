using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationJuryModeratorPage.xaml
    /// </summary>
    public partial class RegistrationJuryModeratorPage : Page
    {
        public Model.Users NewUser { get; set; }
        public Model.Users CurrentUser { get; set; }
        public RegistrationJuryModeratorPage(Model.Users CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            Init();
        }

        private void Init()
        {
            NewUser = new Model.Users();
            List<Model.Roles> Roles = new List<Model.Roles>();
            var Sexes = Model.ConferentionOrganisationDBEntities.GetContext().Sexes.ToList();
            Roles.Insert(0, new Model.Roles() { Roles_Name = "Выберите роль" });
            Roles.Insert(1, new Model.Roles() { Roles_Name = "Жюри" });
            Roles.Insert(2, new Model.Roles() { Roles_Name = "Модератор" });
            Sexes.Insert(0, new Model.Sexes() { Sexes_Name = "Выберите пол" });
            RoleCB.ItemsSource = Roles;
            SexCB.ItemsSource = Sexes;
            RoleCB.SelectedIndex = 0;
            SexCB.SelectedIndex = 0;

            var User = Model.ConferentionOrganisationDBEntities.GetContext().Users.ToList();
            IdNumberTB.Text = (User.Last().User_Id + 1).ToString();

            EventCB.IsEnabled = false;
            EventCB.ItemsSource = Model.ConferentionOrganisationDBEntities.GetContext().Event_Chains.ToList();

            PhoneTB.Text = "+7(___)-___-__-__";
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string Fio = FioTB.Text;
                int SelectedSex = SexCB.SelectedIndex;
                int SelectedRole = RoleCB.SelectedIndex;
                string Email = EmailTB.Text;
                string Phone = PhoneTB.Text;
                string Direction = DirectionTB.Text;
                string Password;
                string ConfirmPassword;
                if (ShowPassword.IsChecked == true)
                {
                    Password = PasswordTBShow.Text;
                    ConfirmPassword = ConfirmPasswordTBShow.Text;
                }
                else
                {
                    Password = PasswordTB.Password;
                    ConfirmPassword = ConfirmPasswordTB.Password;
                }
                int? Event = null;
                if (AttachToEvent.IsChecked == true)
                {
                    Event = EventCB.SelectedIndex + 1;
                }
                if (string.IsNullOrEmpty(Fio)) { sb.AppendLine("Заполните ФИО!"); }
                if (string.IsNullOrEmpty(Email)) { sb.AppendLine("Заполните Email!"); }
                if (string.IsNullOrEmpty(Direction)) { sb.AppendLine("Заполните направление!"); }
                if (SelectedRole == 0) { sb.AppendLine("Выберите должность!"); }
                if (SelectedSex == 0) { sb.AppendLine("Выберите пол!"); }
                if (string.IsNullOrEmpty(Password)) { sb.AppendLine("Введите пароль!"); }
                else
                {
                    if (Password.Length < 6)
                    {
                        sb.AppendLine("Пароль меньше 6 символов!");
                    }
                    bool isSpecialChars = false;
                    bool isDigits = false;
                    foreach (var item in Password)
                    {
                        if (char.IsDigit(item))
                        {
                            isDigits = true;
                        }
                        if (char.IsSeparator(item) || char.IsPunctuation(item) || char.IsControl(item))
                        {
                            isSpecialChars = true;
                        }
                    }
                    if (!isSpecialChars) sb.AppendLine("Пароль не содержит спец.символ");
                    if (!isDigits) sb.AppendLine("Пароль не содержит цифр");
                    if (Password.ToUpper() == Password)
                    {
                        sb.AppendLine("Пароль не содержит строчных букв");
                    }
                    if (Password.ToLower() == Password)
                    {
                        sb.AppendLine("Пароль не содержит заглавных букв");
                    }
                }
                if (string.IsNullOrEmpty(NewUser.User_Phone)) { sb.AppendLine("Заполните номер телефона по формату!"); }
                else if (Password != ConfirmPassword) { sb.AppendLine("Пароли не совпадают!"); }
                if (string.IsNullOrEmpty(ConfirmPassword)) { sb.AppendLine("Подтвердите пароль!"); }
                var allName = Fio.Split(' ');
                if (allName.Length != 3)
                {
                    sb.AppendLine("ФИО введено неверно!");
                }
                if (sb.Length > 0) { MessageBox.Show(sb.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
                NewUser.User_Surname = allName[0];
                NewUser.User_Name = allName[1];
                NewUser.User_Patronym = allName[2];
                NewUser.User_Email = Email;
                NewUser.User_Birthday = null;
                NewUser.User_Country_Id = null;
                NewUser.User_Password = Password;
                NewUser.User_Sex_Id = SelectedSex;
                NewUser.User_Role_Id = SelectedRole;
                var DirectionList = Model.ConferentionOrganisationDBEntities.GetContext()
                    .Directions.Where(i => i.Directions_Name == Direction).FirstOrDefault();
                if (DirectionList == null)
                {
                    Model.Directions NewDirection = new Model.Directions() { Directions_Name = Direction };
                    Model.ConferentionOrganisationDBEntities.GetContext().Directions.Add(NewDirection);
                    Model.ConferentionOrganisationDBEntities.GetContext().SaveChanges();
                    NewUser.User_Direction_Id = NewDirection.Directions_Id;
                }
                else
                {
                    NewUser.User_Direction_Id = DirectionList.Directions_Id;
                }
                NewUser.User_Event_Chain_Id = Event;
                Model.ConferentionOrganisationDBEntities.GetContext().Users.Add(NewUser);
                Model.ConferentionOrganisationDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Регистрация успешна", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                Classes.Navigation.ActiveFrame.Navigate(new Pages.OrganisatorPage(CurrentUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.RegistrationJuryModeratorPage(CurrentUser));
        }

        private void RegisterImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetImage();
        }

        private void SetImage()
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Изображения (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
            string Path = "";
            if (Dialog.ShowDialog() == true)
            {
                Path = Dialog.FileName;
            }
            if (string.IsNullOrEmpty(Path))
            {
                return;
            }
            BitmapImage Image = new BitmapImage(new Uri(Path));
            RegisterImage.Source = Image;
            NewUser.User_Photo = File.ReadAllBytes(Path);
            NewUser.User_Photo_Name = Path.Split('\\').Last().ToString();
        }

        private void AttachToEvent_Unchecked(object sender, RoutedEventArgs e)
        {
            EventCB.IsEnabled = false;
        }

        private void AttachToEvent_Checked(object sender, RoutedEventArgs e)
        {
            EventCB.IsEnabled = true;
        }

        private bool CheckPhone(string Phone)
        {
            return !Regex.IsMatch(Phone, @"^\+7\(\d{3}\)-\d{3}-\d{2}-\d{2}$");
        }

        private void PhoneTB_LostFocus(object sender, RoutedEventArgs e)
        {
            string Input = (sender as TextBox).Text;

            if (CheckPhone(Input))
            {
                MessageBox.Show("Телефон не в формате +7(___)-___-__-__");
            }
            else
            {
                NewUser.User_Phone = Input;
            }
        }

        private void DirectionTB_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            FollowVariantsLB.Visibility = Visibility.Visible;
        }

        private void DirectionTB_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            FollowVariantsLB.Visibility = Visibility.Hidden;
        }

        private void DirectionTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = DirectionTB.Text.ToLower();
            var result = Model.ConferentionOrganisationDBEntities.GetContext().Directions.ToList()
                .Where(d => d.Directions_Name.ToLower().Contains(text)).ToList();
            FollowVariantsLB.ItemsSource = result;
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordTBShow.Text = PasswordTB.Password;
            ConfirmPasswordTBShow.Text = ConfirmPasswordTB.Password;
            PasswordTBShow.Visibility = Visibility.Visible;
            ConfirmPasswordTBShow.Visibility = Visibility.Visible;
            PasswordTB.Visibility = Visibility.Hidden;
            ConfirmPasswordTB.Visibility = Visibility.Hidden;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordTB.Password = PasswordTBShow.Text;
            ConfirmPasswordTB.Password = ConfirmPasswordTBShow.Text;
            PasswordTBShow.Visibility = Visibility.Hidden;
            ConfirmPasswordTBShow.Visibility = Visibility.Hidden;
            PasswordTB.Visibility = Visibility.Visible;
            ConfirmPasswordTB.Visibility = Visibility.Visible;
        }

        private void FollowVariantsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedDirection = FollowVariantsLB.SelectedItem as Model.Directions;
            if (SelectedDirection != null)
            {
                if (SelectedDirection.Directions_Name != null)
                {
                    DirectionTB.Text = SelectedDirection.Directions_Name;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.OrganisatorPage(CurrentUser));
        }
    }
}
