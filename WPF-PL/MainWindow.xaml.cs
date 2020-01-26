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
        Host host;
        Order order;
        List<HostingUnit> list;
        string str="";
        int verifyifAddOrUpdate = 0;
        public MainWindow()
        {
            InitializeComponent();
            SystemCommands.MaximizeWindow(this);

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
            typeHostingCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.theType));
            typeHostingComboboxUpdate.ItemsSource = Enum.GetValues(typeof(BE.BE.theType));
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
            guestRequest.EntryDate =guestRequest.ReleaseDate= DateTime.Today;
            addGuestRequestGrid.DataContext = guestRequest;
            contentRectangle.Text = "";
            comboboxArea.SelectedValue = BE.BE.Area.Center;//value per default
            comboboxType.SelectedValue = BE.BE.theType.Hotel;//value per default
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
        //fonction du boutton identify dans le hostingunitgrid
        private void Identify(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            Identification.Visibility = Visibility.Visible;
            host = new Host();
            Identification.DataContext = host;
            DeleteHostingUnit.IsEnabled = false;
            UpdateHostingUnit.IsEnabled = false;
            selectionForDeleteOrUpdate.IsEnabled = false;
            identifyButton.IsEnabled = true;
        }
        //fonction du boutton addHostingUnit
        private void addHostingUnit(object sender, RoutedEventArgs e)
        {
            proprietaireGrid.Visibility = Visibility.Hidden;
            addHostingUnitGrid.Visibility = Visibility.Visible;
            hostingUnit = new HostingUnit();
            typeHostingCombobox.SelectedValue = BE.BE.theType.Hotel;
            comboboxAreaHostingUnit.SelectedValue = BE.BE.Area.Center;
            addHostingUnitGrid.DataContext = hostingUnit;

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
            try
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
                    comboboxAreaUpdate.SelectedValue = guestRequest.area;
                    comboboxTypeUpdate.SelectedValue = guestRequest.type;
                }
                else//it's an update guestRequest
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
                if (list.Count == 0) {
                    selection.IsEnabled = false;
                    contentRectangle.Text = "We don't have any HostingUnit compatible with your request.";
                }
                else
                {
                    selection.IsEnabled = true;
                    contentRectangle.Text = "";
                }
            }
            catch(Exception message)
            {
                MessageBox.Show(message.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
        /// bouttons de la page addHostingUnit
        /// </summary>
        /// <param name="buttomsOfAddHostingUnit"></param>
        /// <param name="e"></param>
        //fonction du boutton send dans la page addHostingUnit
        private void SendHostingUnit_Click(object sender, RoutedEventArgs e)
        {
           
            hostingUnit.area = (BE.BE.Area)comboboxAreaHostingUnit.SelectedValue;
            hostingUnit.type = (BE.BE.theType)typeHostingCombobox.SelectedValue;
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
         /// fonctions de la page addOrder
         /// </summary>
         /// <param name="AddOrderGrid"></param>
         /// <param name="e"></param>

        private void addOrder(object sender, RoutedEventArgs e)//ok
        {
            contentRectangle.Text = "";
            verifyifAddOrUpdate = 0;
            order = new Order();
            order.guestRequest = guestRequest;
            order.hostingUnitReserved = hostingUnit;
            bl.calculateTotalPriceWithComission(order);
            bl.addOrder(order);


            //preparation pour envoyer le mail
            str = "";//initialize the string
            str += "Hello Mr " + order.guestRequest.client.FamilyName;
            str += "\nWe have received your message concerning your reservation of " + order.OrderDate;
            str += "\nhere are the details of your reservation:\n";
            str += order.ToString();
            MessageBox.Show("Your reservation has been sent to the Host!!!\nYou will get a mail to confirm your reservation.", "Reservation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            MailMessage mail = new MailMessage();
            mail.To.Add("danabergel1995@gmail.com");
            mail.From = new MailAddress("danabergelCsharp@gmail.com");
            mail.Subject = "Information about reservation hosting";
            mail.Body = str;
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("danabergelCsharp@gmail.com", "dan170895");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception in Mail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            addOrderGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }
        private void selection_SelectionChanged(object sender, SelectionChangedEventArgs e)//bon
        {
            if (selection.Items.Count > 0)
            {
                hostingUnit = new HostingUnit();
                string name = "";
                name = ((ComboBoxItem)selection.SelectedItem).Content.ToString();
                foreach (HostingUnit hosting in list)
                    if (hosting.HostingUnitName == name)
                    {
                        contentRectangle.Text = hosting.ToString();
                        hostingUnit = hosting;//for reservation
                    }
            }
            reserved.IsEnabled = true;//enable the button which reserved the hosting unit
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




        private void IdentifyForContinue(object sender, RoutedEventArgs e)
        {
            if (PrivateNameIdentify.Text == "" || FamilyNameIdentify.Text == "" || MailIdentify.Text == "")
                MessageBox.Show("ERROR!\nYou didn't fill all the fields.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                list = new List<HostingUnit>();
                list = (from hostingUnit in bl.getAllHostingUnits()
                        where hostingUnit.Owner.PrivateName == host.PrivateName
                        && hostingUnit.Owner.FamilyName == host.FamilyName
                        && hostingUnit.Owner.MailAddress == host.MailAddress
                        select hostingUnit).ToList();
                if (list.Count > 0)
                {
                    DeleteHostingUnit.IsEnabled = true;
                    UpdateHostingUnit.IsEnabled = true;
                    selectionForDeleteOrUpdate.IsEnabled = true;
                    //for (int i = 0; i < selectionForDeleteOrUpdate.Items.Count; i++)
                    //    selectionForDeleteOrUpdate.Items.RemoveAt(i);
                    foreach (HostingUnit hostingUnit in list)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = hostingUnit.HostingUnitName;
                        selectionForDeleteOrUpdate.Items.Add(item);
                    }
                    identifyButton.IsEnabled = false;
                }
                
            }
        }

        private void selectionForDeleteOrUpdateSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectionForDeleteOrUpdate.Items.Count > 0)
            {
                //hostingUnit = new HostingUnit();
                string name = "";
                name = ((ComboBoxItem)selectionForDeleteOrUpdate.SelectedItem).Content.ToString();
                foreach (HostingUnit hosting in list)
                    if (hosting.HostingUnitName == name)
                    {
                        hostingUnit = hosting;
                    }
            }
        }

        private void DeleteHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result=MessageBox.Show("Are you sure to delete your HostingUnit?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result==MessageBoxResult.Yes)
                bl.deleteHostingUnit(hostingUnit.HostingUnitKey);
            MessageBox.Show("Your hostingUnit was deleted!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            Identification.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }


        private void UpdateHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            updateHostingUnitGrid.DataContext = hostingUnit;
            Identification.Visibility = Visibility.Hidden;
            updateHostingUnitGrid.Visibility = Visibility.Visible;
            for (int i = 0; i < selectionForDeleteOrUpdate.Items.Count; i++)
                selectionForDeleteOrUpdate.Items.RemoveAt(i);
            comboboxAreaUpdateHostingUnit.SelectedValue=hostingUnit.area;
            typeHostingComboboxUpdate.SelectedValue=hostingUnit.type;
        }

        private void returnFromUpdateHostingUnit(object sender, RoutedEventArgs e)
        {
            updateHostingUnitGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }

        private void SendHostingUnitUpdate_Click(object sender, RoutedEventArgs e)
        {
            hostingUnit.area =(BE.BE.Area) comboboxAreaUpdateHostingUnit.SelectedValue;
            hostingUnit.type=(BE.BE.theType)typeHostingComboboxUpdate.SelectedValue;
            bl.uptadeHostingUnit(hostingUnit);
            MessageBox.Show("Your hostingUnit was updated!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            updateHostingUnitGrid.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Identification.Visibility = Visibility.Hidden;
            proprietaireGrid.Visibility = Visibility.Visible;
        }
    }
}
