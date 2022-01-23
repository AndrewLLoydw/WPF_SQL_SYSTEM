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
using WPF_SQL_SYSTEM.Data;
using WPF_SQL_SYSTEM.Models;
using WPF_SQL_SYSTEM.Services;

namespace WPF_SQL_SYSTEM.Views
{
    /// <summary>
    /// Interaction logic for CreateErrand.xaml
    /// </summary>
    public partial class CreateErrand : UserControl
    {
        public CreateErrand()
        {
            InitializeComponent();

            cbCustomers.SelectedValuePath = "Key";
            cbCustomers.DisplayMemberPath = "Value";

            ClearTb();
            PopCustomers();
        }

        private readonly ICustomerService customerservice = new CustomerService();
        private readonly IErrandService errandService = new ErrandService();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbErrandTitle.Text) && !string.IsNullOrEmpty(tbErrandDescription.Text))
            {
                if (errandService.CreateErrand((int)cbCustomers.SelectedValue, tbErrandTitle.Text, tbErrandDescription.Text))
                    ClearTb();

                else tbErrandError.Text = "Ett fel har inträffat, försök igen";
            }
        }

        private void ClearTb()
        {
            tbErrandTitle.Text = "";
            tbErrandDescription.Text = "";
            tbErrandError.Text = "";
        }


        private void PopCustomers()
        {
            cbCustomers.Items.Clear();
            foreach (var customer in customerservice.GetAllCustomers())
                cbCustomers.Items.Add(new KeyValuePair<int, string>(customer.Id, customer.Email));
        }


    }
}
