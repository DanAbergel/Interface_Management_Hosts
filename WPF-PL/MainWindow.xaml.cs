﻿using System;
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
        public MainWindow()
        {

           

            InitializeComponent();


            SystemCommands.MaximizeWindow(this);
            IBL bl = BL.BLFactory.GetBL();

            



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
            
        }

        private void addGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {
            clientGrid.Visibility = Visibility.Hidden;
            addGuestRequestGrid.Visibility = Visibility.Visible;

            //initialisation du guestRequest
            guestRequest = new GuestRequest();
           
            this.addGuestRequestGrid.DataContext = guestRequest;


            //initialisation des combobox
            for (int i = 0; i < 10; ++i)
            {
                ComboBoxItem newItem1 = new ComboBoxItem();
                ComboBoxItem newItem2 = new ComboBoxItem();
                newItem1.Content = i;
                newItem2.Content = i;
                comboboxAdults.Items.Add(newItem1);
                comboboxChildren.Items.Add(newItem2);
            }


        }

        private void deleteGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void returnFromGuest(object sender, RoutedEventArgs e)
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
    }
}
