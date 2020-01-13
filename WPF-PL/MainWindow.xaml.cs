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
        public MainWindow()
        {
            
            InitializeComponent();
            SystemCommands.MaximizeWindow(this);

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

        private void updateGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void addGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {
            clientGrid.Visibility = Visibility.Hidden;
            addGuestRequestGrid.Visibility = Visibility.Visible;
            for (int i = 0; i < 10; ++i)
            {
                ComboBoxItem newItem1 = new ComboBoxItem();
                ComboBoxItem newItem2 = new ComboBoxItem();
                newItem1.Content =  i;
                newItem2.Content = i;
                comboboxAdults.Items.Add(newItem1);
                comboboxChildren.Items.Add(newItem2);
            }
             guestRequest = new GuestRequest();
           //this.addGuestRequestGrid.DataContext = guestRequest;
        }

        private void deleteGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            clientGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }

        private void returnButton_Click2(object sender, RoutedEventArgs e)
        {
            addGuestRequestGrid.Visibility = Visibility.Hidden;
            clientGrid.Visibility = Visibility.Visible;
        }
       
      

        private void SendGuestRequest_Click(object sender, RoutedEventArgs e)
        {
            guestRequest.client.PrivateName = PrivateNameTxtBox.Text;
            guestRequest.client.FamilyName = FamilyNameTxtBox.Text;
            bl.addGuestRequest(guestRequest);
        }

        private void returnButton_Click3(object sender, RoutedEventArgs e)
        {
            addHostingUnitGrid.Visibility = Visibility.Hidden;
            clientGrid.Visibility = Visibility.Visible;
        }

        private void updateHosting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void returnButton_Click4(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }
    }
}
