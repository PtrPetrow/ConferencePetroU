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
    /// Логика взаимодействия для NotOrgPage.xaml
    /// </summary>
    public partial class NotOrgPage : Page
    {
        public NotOrgPage(string role)
        {
            InitializeComponent();
            if (role == "Жюри")
            {
                this.Title = "Окно " + role;
            }
            else
            {
                this.Title = "Окно " + role + "а";
            }
        }
        public NotOrgPage(int role)
        {
            InitializeComponent();
            switch (role)
            {
                case 1:
                    this.Title = "Окно жюри";
                    break;
                case 2:
                    this.Title = "Окно модератора";
                    break;
                case 3:
                    this.Title = "Окно организатора";
                    break;
                case 4:
                    this.Title = "Окно участника";
                    break;
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
