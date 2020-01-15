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
using System.Windows.Shapes;
using BE;

namespace WPF_PL
{
    /// <summary>
    /// Logique d'interaction pour GUESTrequest.xaml
    /// </summary>
    public partial class GUESTrequest : Window
    {
        GuestRequest guestRequest;
        public GUESTrequest()
        {
            InitializeComponent();

            //initialisation du guestRequest
            guestRequest = new GuestRequest();
            guestRequest.SubArea = "yedid";

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

        private void SendGuestRequest_Click(object sender, RoutedEventArgs e)
        {
            GuestRequest guestReques = guestRequest;
        }
    }
}
