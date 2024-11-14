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

namespace ConferentionOrganisationProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterFrame.xaml
    /// </summary>
    public partial class RegisterFrame : Page
    {
        public RegisterFrame()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var RoleList = Model.ConferentionOrganisationDBEntities.GetContext().Roles.ToList();
            RoleList.Insert(0, new Model.Roles() { Roles_Name = "Выберите роль" });
            RoleTB.ItemsSource = RoleList;
            RoleTB.SelectedIndex = 0;
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(LoginTB.Text))
                {
                    sb.AppendLine("Поле Логин пустое!");
                }
                if (string.IsNullOrEmpty(PasswordPB.Password))
                {
                    sb.AppendLine("Поле Пароль пустое!");
                }
                if (string.IsNullOrEmpty(NameTB.Text))
                {
                    sb.AppendLine("Поле Имя пустое!");
                }
                if (RoleTB.SelectedIndex == 0)
                {
                    sb.AppendLine("Выберите роль!");
                }
                if (sb.Length > 0)
                {
                    MessageBox.Show(sb.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var selectedRole = RoleTB.SelectedItem as Model.Roles;
                var newUser = new Model.Users()
                {
                    User_Name = NameTB.Text,
                    User_Email = LoginTB.Text,
                    User_Password = PasswordPB.Password,
                    User_Role_Id = Model.ConferentionOrganisationDBEntities.GetContext().Roles
                    .Where(d => d.Roles_Id == selectedRole.Roles_Id).FirstOrDefault().Roles_Id
                };
                Model.ConferentionOrganisationDBEntities.GetContext().Users.Add(newUser);
                Model.ConferentionOrganisationDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешная регистрация!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Navigation.ActiveFrame.CanGoBack)
            {
                Classes.Navigation.ActiveFrame.GoBack();
            }
        }
    }
}