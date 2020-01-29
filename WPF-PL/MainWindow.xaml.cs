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
using System.ComponentModel;//for background worker class
using BE;
using BL;
using System.Collections.ObjectModel;
using System.Xml;
using System.IO;
using System.Data;


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
        Host host;
        List<HostingUnit> list;
        string str = "";
        bool entry;
        //int size = 0;
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
            typeHostingCombobox.ItemsSource = Enum.GetValues(typeof(BE.BE.theType));
            typeHostingComboboxUpdate.ItemsSource = Enum.GetValues(typeof(BE.BE.theType));

            // comboBoxArea.ItemsSource = Enum.GetValues(typeof(BE.BE.Area));

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
            guestRequest.EntryDate = guestRequest.ReleaseDate = DateTime.Today;
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
        //fonction du boutton updateHostingUnit


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
            //the bool entry2 is for dont access to the func of selectionchanged
            entry = false;
            selectionForDeleteOrUpdate.Items.Clear();
            entry = true;//for dont entry in selection function
        }



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
            typeHostingCombobox.SelectedValue = BE.BE.theType.Hotel;
            comboboxAreaHostingUnit.SelectedValue = BE.BE.Area.Center;
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
            try
            {
                //size = selection.Items.Count;
                //for (int i = 0; i < size; i++)
                //    selection.Items.RemoveAt(i);
                selection.Items.Clear();
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
                reserved.IsEnabled = false;

                //initialise le combobox selection
                list = bl.getHostingUnits(guestRequest);
                foreach (HostingUnit hostingUnit in list)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = hostingUnit.HostingUnitName;
                    selection.Items.Add(item);
                }
                if (list.Count == 0)
                {
                    selection.IsEnabled = false;
                    contentRectangle.Text = "We don't have any HostingUnit compatible with your request.";
                }
                else
                {
                    selection.IsEnabled = true;
                    contentRectangle.Text = "";
                }
            }
            catch (Exception message)
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

        //private void returnguest(object sender , RoutedEventArgs e)
        //{
        //    deleteGuestRequestGrid.Visibility = Visibility.Hidden;
        //    addOrderGrid.Visibility = Visibility.Visible;
        //}

        //private void returnFromDeleteHostingUnit(object sender , RoutedEventArgs e)
        //{
        //    deleteHostingUnitGrid.Visibility = Visibility.Hidden;
        //    mainGrid.Visibility = Visibility.Visible;
        //}




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
            order = new Order();
            order.guestRequest = guestRequest;
            order.hostingUnitReserved = hostingUnit;
            bl.addOrder(order);


            //preparation pour envoyer le mail
            str = "";//initialize the string
            str += "Hello Mr" + order.guestRequest.client.FamilyName;
            str += "\nWe have received your message concerning your reservation of " + order.OrderDate;
            str += "\nhere are the details of your reservation:\n";
            str += order.ToString();
            MessageBox.Show("Your reservation has been sent to the Host!!!\nYou will get a mail to confirm your reservation.", "Reservation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            MailMessage mail = new MailMessage();
            mail.To.Add(guestRequest.client.MailAddress);
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
                reserved.IsEnabled = true;
            }
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
            try
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
            catch (Exception message)
            {
                MessageBox.Show(message.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void selectionForDeleteOrUpdateSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (entry)
            {
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
            MessageBoxResult result = MessageBox.Show("Are you sure to delete your HostingUnit?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                bl.deleteHostingUnit(hostingUnit.HostingUnitKey);
                MessageBox.Show("Your hostingUnit was deleted!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Identification.Visibility = Visibility.Hidden;
            mainGrid.Visibility = Visibility.Visible;
        }


        private void UpdateHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            updateHostingUnitGrid.DataContext = hostingUnit;
            Identification.Visibility = Visibility.Hidden;
            updateHostingUnitGrid.Visibility = Visibility.Visible;
            // for (int i = 0; i < selectionForDeleteOrUpdate.Items.Count; i++)
            //   selectionForDeleteOrUpdate.Items.RemoveAt(i);
            comboboxAreaUpdateHostingUnit.SelectedValue = hostingUnit.area;
            typeHostingComboboxUpdate.SelectedValue = hostingUnit.type;
        }



        private void SendHostingUnitUpdate_Click(object sender, RoutedEventArgs e)
        {
            hostingUnit.area = (BE.BE.Area)comboboxAreaUpdateHostingUnit.SelectedValue;
            hostingUnit.type = (BE.BE.theType)typeHostingComboboxUpdate.SelectedValue;
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

        private void listorder_Click(object sender, RoutedEventArgs e)
        {


            orderlst.ItemsSource = bl.getAllOrders();
            administrateurGrid.Visibility = Visibility.Hidden;
            getlistOrder.Visibility = Visibility.Visible;
        }

        private void Button_Click17(object sender, RoutedEventArgs e)
        {
            getlistOrder.Visibility = Visibility.Hidden;
            administrateurGrid.Visibility = Visibility.Visible;
        }

        private void listhosting_Click(object sender, RoutedEventArgs e)
        {

            hosting.ItemsSource = bl.getAllHostingUnits();
            //DataSet dataSet = new DataSet();
            //dataSet.ReadXml(@"hostingXml.xml");
            //hosting.ItemsSource = dataSet.Tables[0].DefaultView;
            //hosting.ItemsSource = bl.getAllHostingUnits();
            administrateurGrid.Visibility = Visibility.Hidden;
            getlisthosting.Visibility = Visibility.Visible;
        }

        private void Button_Click15(object sender, RoutedEventArgs e)
        {
            getlisthosting.Visibility = Visibility.Hidden;
            administrateurGrid.Visibility = Visibility.Visible;
        }
        private void Button_Click16(object sender, RoutedEventArgs e)
        {
            getlistrequest.Visibility = Visibility.Hidden;
            administrateurGrid.Visibility = Visibility.Visible;
        }

        private void listrequest_Click(object sender, RoutedEventArgs e)
        {
            guestrequest.ItemsSource = bl.getAllGuestRequest();
            //DataSet dataSet = new DataSet();
            //dataSet.ReadXml(@"guestXml.xml");
            //this.guestrequest.ItemsSource = dataSet.Tables[0].DefaultView;
            administrateurGrid.Visibility = Visibility.Hidden;
            getlistrequest.Visibility = Visibility.Visible;
        }
    }
}
