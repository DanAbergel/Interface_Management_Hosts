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
        Order order;
        List<HostingUnit> list;
        string str="";
        int size = 0;
        int verifyifAddOrUpdate = 0;
        public MainWindow()
        {
            InitializeComponent();
            SystemCommands.MaximizeWindow(this);
            IBL bl = BL.BLFactory.GetBL();


            jacuzziCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.Criterion));
            poolCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.Criterion));
            gardenCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.Criterion));
            attractionsCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.Criterion));

            jacuzziUpdateCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.Criterion));
            poolUpdateCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.Criterion));
            gardenUpdateCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.Criterion));
            attractionsUpdateCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.Criterion));

            comboboxArea.ItemsSource = Enum.GetValues(typeof(BE.BE.Area));
            comboboxAreaUpdate.ItemsSource = Enum.GetValues(typeof(BE.BE.Area));
            comboboxAreaHostingUnit.ItemsSource = Enum.GetValues(typeof(BE.BE.Area));
            comboboxAreaUpdateHostingUnit.ItemsSource = Enum.GetValues(typeof(BE.BE.Area));

            comboboxType.ItemsSource = Enum.GetValues(typeof(BE.BE.theType));
            comboboxTypeUpdate.ItemsSource = Enum.GetValues(typeof(BE.BE.theType));
        }



        /// <summary>
        /// bouttons de la premiere page
        /// </summary>
        /// <param name="buttomsOfMainGrid"></param>
        /// <param name="e"></param>
       
       
        //fonction du boutton proprietaire
        private void Proprietaire(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }
        //fonction du boutton administarteur
        private void Administrateur(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Hidden;
            administrateurGrid.Visibility = Visibility.Visible;
        } 
        private void Client(object sender, RoutedEventArgs e)
        {
            mainGrid.Visibility = Visibility.Hidden;
            addGuestRequestGrid.Visibility = Visibility.Visible;
            guestRequest = new GuestRequest();
            addGuestRequestGrid.DataContext = guestRequest;
        }
        //fonction du boutton de sortie du programme
        private void fermeture(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// bouttons de la page proprietaire
        /// </summary>
        /// <param name="buttomsOfProprietaireGrid"></param>
        /// <param name="e"></param>
        //fonction du boutton updateHostingUnit
        private void updateHosting_Click(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            updateHostingUnitGrid.Visibility = Visibility.Visible;
            hostingUnit = new HostingUnit();
            updateHostingUnitGrid.DataContext = hostingUnit;
        }
        //fonction du boutton addHostingUnit
        private void addHostingUnit(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            addHostingUnitGrid.Visibility = Visibility.Visible;
            hostingUnit = new HostingUnit();
            addHostingUnitGrid.DataContext = hostingUnit;

        }
        //fonction du boutton deleteHostingUnit
        private void deleteHostingUnit(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }
        //fonction du boutton return dans le grid proprietaire 
        private void returnFromProprietaireT(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }



        /// <summary>
        ///  bouttons de la page addGuestRequest
        /// </summary>
        /// <param name="buttomsOgAddGuestRequestGrid"></param>
        /// <param name="e"></param>
        //fonction du boutton return dans le grid addGuestRequest
        private void returnFromAddGuestRequest(object sender, RoutedEventArgs e)
        {
            addGuestRequestGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }
        //fonction du boutton send dans la page addGuestRequest
        private void SendGuestRequest_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < selection.Items.Count; i++)
                selection.Items.RemoveAt(i);
            
            if (verifyifAddOrUpdate == 0)
            { 
                guestRequest.area = (BE.BE.Area)comboboxArea.SelectedValue;
                guestRequest.Pool = (BE.BE.Criterion)poolCombobox.SelectedValue;
                guestRequest.Garden = (BE.BE.Criterion)gardenCombobox.SelectedValue;
                guestRequest.ChildrenAttractions = (BE.BE.Criterion)attractionsCombobox.SelectedValue;
                guestRequest.Jacuzzi = (BE.BE.Criterion)jacuzziCombobox.SelectedValue;
                guestRequest.type = (BE.BE.theType)comboboxType.SelectedValue;
                bl.addGuestRequest(guestRequest);
                MessageBox.Show("your guest request was added", "Succesful add request", MessageBoxButton.OK, MessageBoxImage.Information);
            addGuestRequestGrid.Visibility = Visibility.Hidden;
                verifyifAddOrUpdate += 1;
            }
            else
            {
                guestRequest.area = (BE.BE.Area)comboboxAreaUpdate.SelectedValue;
                guestRequest.Pool = (BE.BE.Criterion)poolUpdateCombobox.SelectedValue;
                guestRequest.Garden = (BE.BE.Criterion)gardenUpdateCombobox.SelectedValue;
                guestRequest.ChildrenAttractions = (BE.BE.Criterion)attractionsUpdateCombobox.SelectedValue;
                guestRequest.Jacuzzi = (BE.BE.Criterion)jacuzziUpdateCombobox.SelectedValue;
                guestRequest.type = (BE.BE.theType)comboboxTypeUpdate.SelectedValue;
                bl.updateGuestRequest(guestRequest);
                MessageBox.Show("your guest request was updated", "Succesful update request", MessageBoxButton.OK, MessageBoxImage.Information);
                updateGuestRequestGrid.Visibility = Visibility.Hidden;
            }
            //ferme la page add ou update
            addOrderGrid.Visibility = Visibility.Visible;
            //initialise le combobox selection
             list = bl.getHostingUnits(guestRequest);
            
            foreach (HostingUnit hostingUnit in list)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = hostingUnit.HostingUnitName;
                selection.Items.Add(item);
            }
            order = new Order();
           
           
        }


        /// <summary>
        /// bouttons de la page updateGuestRequest
        /// </summary>
        /// <param name="buttomOfUpdateGuestRequest"></param>
        /// <param name="e"></param>
        //fonction du boutton return dans le grid updateGuestRequest
        private void returnFromUpdateGuestrequest_Click(object sender, RoutedEventArgs e)
        {
            updateGuestRequestGrid.Visibility = Visibility.Hidden;
            addOrderGrid.Visibility = Visibility.Visible;
        }
      



        /// <summary>
        /// bouttons de la page deleteGuestRequest
        /// </summary>
        /// <param name="buttomOfDeleteGuestRequest"></param>
        /// <param name="e"></param>
        //fonction du boutton delete dans le grid deleteGuestRequest
        private void DeleteguestRequest_Click(object sender, RoutedEventArgs e)
        {
            bl.deleteGuestRequest(guestRequest.guestRequestKey);
        }



        /// <summary>
        /// bouttons de la page addHostingUnit
        /// </summary>
        /// <param name="buttomsOfAddHostingUnit"></param>
        /// <param name="e"></param>
        //fonction du boutton send dans la page addHostingUnit
        private void SendHostingUnit_Click(object sender, RoutedEventArgs e)
        {
           
            hostingUnit.area = (BE.BE.Area)comboboxAreaHostingUnit.SelectedValue;
            bl.addHostingUnit(hostingUnit);
            MessageBox.Show("your hosting unit was added", "add HostingUnit", MessageBoxButton.OK, MessageBoxImage.Information);
            addHostingUnitGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }
        //fonction du boutton return dans le grid addHostingUnit
        private void returnFromAddHostingUnit(object sender, RoutedEventArgs e)
        {
            addHostingUnitGrid.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// bouttons de la page updateHostingUnit
        /// </summary>
        /// <param name="buttomsOfupdateHostingUnit"></param>
        /// <param name="e"></param>
        //fonction du boutton return dans le grid addHostingUnit
        private void returnFromUpdateHostingUnit(object sender, RoutedEventArgs e)
        {
            updateHostingUnitGrid.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }
        //fonction du boutton send dans la page updateHostingUnit
        private void SendHostingUnitUpdate_Click(object sender, RoutedEventArgs e)
        {
            bl.uptadeHostingUnit(hostingUnit);
        }




        /// <summary>
        /// bouttons de la page deleteHostingUnit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //fonction du boutton delete dans le grid deleteGuestRequest
        private void DeleteHosting_Click_1(object sender, RoutedEventArgs e)
        {
            bl.deleteHostingUnit(hostingUnit.HostingUnitKey);
        }
       
     







         /// <summary>
         /// fonctions de la page addOrder
         /// </summary>
         /// <param name="AddOrderGrid"></param>
         /// <param name="e"></param>

        private void addOrder(object sender, RoutedEventArgs e)//ok
        {
            bl.addOrder(order);
            MessageBox.Show("Your reservation has been sent to the Host!!!", "Reservation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            addOrderGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }

         private void selection_SelectionChanged(object sender, SelectionChangedEventArgs e)//bon
        {
            if (selection.Items.Count>0) {
                string name = "";
                name = ((ComboBoxItem)selection.SelectedItem).Content.ToString();
                foreach (HostingUnit hosting in list)
                    if (hosting.HostingUnitName == name)
                        contentRectangle.Text = hosting.ToString(); }
        }

        private void deleteGuestRequest(object sender, RoutedEventArgs e)//ok
        {

            MessageBoxResult result = MessageBox.Show("are you sure to delete?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                bl.deleteGuestRequest(guestRequest.guestRequestKey);
                MessageBox.Show("your request has been deleted", "successfull delete", MessageBoxButton.OK, MessageBoxImage.Information);
                addOrderGrid.Visibility = Visibility.Hidden;
                mainGrid.Visibility = Visibility.Visible;
            }
            verifyifAddOrUpdate = 0;
        }
        private void updateGuestRequest(object sender, RoutedEventArgs e)//bon
        {
            addOrderGrid.Visibility = Visibility.Hidden;
            updateGuestRequestGrid.Visibility = Visibility.Visible;
            updateGuestRequestGrid.DataContext = guestRequest;
           
        }
       

        













        private void returnFromAdministrateur(object sender, RoutedEventArgs e)
        {
            administrateurGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }

       
       
        
        

       

       
    }
}
