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
    /// Логика взаимодействия для OrganisatorPage.xaml
    /// </summary>
    public partial class OrganisatorPage : Page
    {
        Model.Users CurrentUser { get; set; }
        public OrganisatorPage(Model.Users User)
        {
            InitializeComponent();
            CurrentUser = User;
            DataContext = CurrentUser;
            OnStart();
        }
        private void OnStart()
        {
            int CurrentHours = DateTime.Now.Hour;
            string Hello = "";
            if (CurrentHours >= 9 && CurrentHours < 11)
            {
                Hello = "Доброе утро!";
            }
            else if (CurrentHours >= 11 && CurrentHours < 18)
            {
                Hello = "Доброго дня!";
            }
            else if (CurrentHours >= 18 && CurrentHours < 24)
            {
                Hello = "Доброго вечера!";
            }
            HelloText.Text = Hello;

            if (CurrentUser.Sexes.Sexes_Name == "Женский")
            {
                GenderText.Text = "Ms";
            } 
            else if(CurrentUser.Sexes.Sexes_Name == "Мужской")
            {
                GenderText.Text = "Mrs";
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.Authorization());
        }

        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ParticipantsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void JuriesButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RegJuryModButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.RegistrationJuryModeratorPage(CurrentUser));
        }
    }
}
