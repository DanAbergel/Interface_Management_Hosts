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

namespace WPF_PL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            
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
        private void poolCheck_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
