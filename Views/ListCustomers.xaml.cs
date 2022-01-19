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
using WPF_SQL_SYSTEM.Services;

namespace WPF_SQL_SYSTEM.Views
{
    /// <summary>
    /// Interaction logic for ListCustomers.xaml
    /// </summary>
    public partial class ListCustomers : UserControl
    {

        private readonly ICustomerService customerService = new CustomerService();

        public ListCustomers()
        {
            InitializeComponent();

            lvCustomers.Items.Clear();
            foreach (var customer in customerService.GetAllCustomers())
            {
                lvCustomers.Items.Add(customer);
            }
        }
    }
}
