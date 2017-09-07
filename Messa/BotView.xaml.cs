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
using Messa.Core;
using Messa.ViewModels;

namespace Messa
{
    /// <summary>
    /// Interaction logic for BotView.xaml
    /// </summary>
    public partial class BotView : UserControl
    {
        public BotView(Account account)
        {
            InitializeComponent();
            DataContext = new BotViewModel(account);
        }
    }
}
