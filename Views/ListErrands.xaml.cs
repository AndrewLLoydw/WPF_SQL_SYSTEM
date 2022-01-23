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
    /// Interaction logic for ListErrands.xaml
    /// </summary>
    public partial class ListErrands : UserControl
    {

        private readonly IErrandService errandService = new ErrandService();

        public ListErrands()
        {
            InitializeComponent();

            lvCustomerErrands.Items.Clear();
            foreach (var errand in errandService.GetAllErrands())
            {
                lvCustomerErrands.Items.Add(errand);
            }
        }
    }
}
