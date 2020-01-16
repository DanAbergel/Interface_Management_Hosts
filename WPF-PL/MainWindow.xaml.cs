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
using System.Net.Mail;
using BE;
using BL;
namespace WPF_PL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    { 
        IBL bl = BL.BLFactory.GetBL();
        GuestRequest guestRequest;
        HostingUnit hostingUnit;
        ComboBoxItem newItem;
        public MainWindow()
        {
            InitializeComponent();
            SystemCommands.MaximizeWindow(this);
            IBL bl = BL.BLFactory.GetBL();
            guestRequest = new GuestRequest();
           //initialiser les combobox area
            for (int i = 0; i < 4; i++)
            { 
                 newItem = new ComboBoxItem();//add guestRequest combobox
                newItem.Content = (BE.BE.Area)i;
                comboboxArea.Items.Add(newItem);

                newItem = new ComboBoxItem();//update guestRequest Combobox
                newItem.Content = (BE.BE.Area)i;
                comboboxAreaUpdate.Items.Add(newItem);

                newItem = new ComboBoxItem();//add HostingUnit combobox
                newItem.Content = (BE.BE.Area)i;
                comboboxAreaHostingUnit.Items.Add(newItem);

                newItem = new ComboBoxItem();//update HostingUnit combobox
                newItem.Content = (BE.BE.Area)i;
                comboboxAreaUpdateHostingUnit.Items.Add(newItem);
            } 
            //initialiser le combox adults et children
            for (int i = 0; i < 10; i++)
            {
                newItem = new ComboBoxItem();//add adults to combobox guestRequest
                newItem.Content = i;
                comboboxAdults.Items.Add(newItem);

                newItem = new ComboBoxItem();//update adults to update guestRequest
                newItem.Content = i;
                comboboxAdultsUpdate.Items.Add(newItem);


                newItem = new ComboBoxItem();//add adults to combobox guestRequest
                newItem.Content = i;
                comboboxAdultsHosting.Items.Add(newItem);

                newItem = new ComboBoxItem();//update adults to update guestRequest
                newItem.Content = i;
                comboboxAdultsHostingUpdate.Items.Add(newItem);


                newItem = new ComboBoxItem();//add children to combobox guestRequest
                newItem.Content = i;
                comboboxChildren.Items.Add(newItem);

                newItem = new ComboBoxItem();//update children to update guestRequest
                newItem.Content = i;
                comboboxChildrenUpdate.Items.Add(newItem);

                newItem = new ComboBoxItem();//add children to combobox guestRequest
                newItem.Content = i;
                comboboxChildrenHosting.Items.Add(newItem);

                newItem = new ComboBoxItem();//update children to update guestRequest
                newItem.Content = i;
                comboboxChildrenHostingUpdate.Items.Add(newItem);
            }
            //initialiser le combobox des selections
            for(int i=0;i<3;i++)
            {
                newItem = new ComboBoxItem();//add guestRequest
                newItem.Content = (BE.BE.Criterion)i;
                jacuzziCombobox.Items.Add(newItem);

                newItem = new ComboBoxItem();//update guestRequest
                newItem.Content = (BE.BE.Criterion)i;
                jacuzziUpdateCombobox.Items.Add(newItem);


                newItem = new ComboBoxItem();//add guestRequest
                newItem.Content = (BE.BE.Criterion)i;
                poolCombobox.Items.Add(newItem);

                newItem = new ComboBoxItem();//update guestRequest
                newItem.Content = (BE.BE.Criterion)i;
                poolUpdateCombobox.Items.Add(newItem);


                newItem = new ComboBoxItem();//add guestRequest
                newItem.Content = (BE.BE.Criterion)i;
                gardenCombobox.Items.Add(newItem);

                newItem = new ComboBoxItem();//update guestRequest
                newItem.Content = (BE.BE.Criterion)i;
                gardenUpdateCombobox.Items.Add(newItem);


                newItem = new ComboBoxItem();//add guestRequest
                newItem.Content = (BE.BE.Criterion)i;
                attractionsCombobox.Items.Add(newItem);

                newItem = new ComboBoxItem();//update guestRequest
                newItem.Content = (BE.BE.Criterion)i;
                attractionsUpdateCombobox.Items.Add(newItem);
            }
        }
     
       //fonction du boutton Client
        private void Client(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility =Visibility.Hidden;
            clientGrid.Visibility = Visibility.Visible;
        }
        //fonction du boutton proprietaire
        private void Proprietaire(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }
        //fonction du boutton administarteur
        private void buttonAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Hidden;
            administrateurGrid.Visibility = Visibility.Visible;
        }
        //fonction du boutton updateGuestRequest
        private void updateGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {
            clientGrid.Visibility = Visibility.Hidden;
            updateGuestRequestGrid.Visibility = Visibility.Visible;
        }

        private void addGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {
            clientGrid.Visibility = Visibility.Hidden;
            addGuestRequestGrid.Visibility = Visibility.Visible;
            this.addGuestRequestGrid.DataContext = guestRequest;
        }

        private void deleteGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {
            clientGrid.Visibility = Visibility.Hidden;
            deleteGuestRequestGrid.Visibility = Visibility.Visible;
        }

        private void returnFromGuest(object sender, RoutedEventArgs e)
        {
            clientGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }

        private void returnFromAddGuestRequest(object sender, RoutedEventArgs e)
        {
            addGuestRequestGrid.Visibility = Visibility.Hidden;
            clientGrid.Visibility = Visibility.Visible;
        }

        private void SendGuestRequest_Click(object sender, RoutedEventArgs e)
        {
          
            bl.addGuestRequest(guestRequest);
            MessageBox.Show("your guest request was added","Succesful request",MessageBoxButton.OK,MessageBoxImage.Information );
            addGuestRequestGrid.Visibility = Visibility.Hidden;
            clientGrid.Visibility = Visibility.Visible;
        }

        private void returnButton_Click3(object sender, RoutedEventArgs e)
        {
            addHostingUnitGrid.Visibility = Visibility.Hidden;
            clientGrid.Visibility = Visibility.Visible;
        }

        private void updateHosting_Click(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            updateHostingUnitGrid.Visibility = Visibility.Visible;
        }

        private void returnButton_Click4(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }

        private void deleteHosting_Click(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            deleteHostingUnitGrid.Visibility = Visibility.Visible;
        }

        private void DeleteHosting_Click_1(object sender, RoutedEventArgs e)
        {
            //bl.deleteHostingUnit();
        }

        private void return6(object sender, RoutedEventArgs e)
        {
            deleteHostingUnitGrid.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }

        private void returnButton5_Click(object sender, RoutedEventArgs e)
        {
            updateHostingUnitGrid.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }

        private void SendHostingUnitUpdate_Click(object sender, RoutedEventArgs e)
        {
            //bl.uptadeHostingUnit();
        }

        private void DeleteguestRequest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            deleteGuestRequestGrid.Visibility = Visibility.Hidden;
            clientGrid.Visibility = Visibility.Visible;
        }

        private void addHosting_Click(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            addHostingUnitGrid.Visibility = Visibility.Visible;
        }

        private void returnButton3_Click(object sender, RoutedEventArgs e)
        {
            addHostingUnitGrid.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }

        private void returnFromUpdateGuestRequest_Click(object sender, RoutedEventArgs e)
        {
            updateGuestRequestGrid.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }

        private void SendGuestRequestUpdate_Click(object sender, RoutedEventArgs e)
        {
           // bl.updateGuestRequest();
        }

        private void returnFromUpdateGuestrequest_Click(object sender, RoutedEventArgs e)
        {
            updateGuestRequestGrid.Visibility = Visibility.Hidden;
            clientGrid.Visibility = Visibility.Visible;
        }
    }
}
