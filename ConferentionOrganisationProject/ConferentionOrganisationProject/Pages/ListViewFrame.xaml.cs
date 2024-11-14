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
    /// Логика взаимодействия для ListViewFrame.xaml
    /// </summary>
    public partial class ListViewFrame : Page
    {
        public ListViewFrame()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var _ = Model.ConferentionOrganisationDBEntities.GetContext().Directions.ToList();
            _.Insert(0, new Model.Directions() { Directions_Name = "Все направления"});
            DirectionComboBox.ItemsSource = _;
            DirectionComboBox.SelectedIndex = 0;
            Update();


        }
        private void Update()
        {
            List<Model.Event> _allEvents = Model.ConferentionOrganisationDBEntities.GetContext().Event.ToList();
            if (DirectionComboBox.SelectedIndex != 0)
            {
                _allEvents = _allEvents.Where(d => d.Event_Direction_Id == DirectionComboBox.SelectedIndex).ToList();
            }
            if (!String.IsNullOrEmpty(DatePickerElement.SelectedDate.ToString()))
            {
                _allEvents = _allEvents.Where(d => d.Event_Date == DatePickerElement.SelectedDate).ToList();
            }
            EventsListView.ItemsSource = _allEvents;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.Authorization());
        }

        private void DirectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void DatePickerElement_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
