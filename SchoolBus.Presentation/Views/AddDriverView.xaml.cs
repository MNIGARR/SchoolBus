using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SchoolBus.Presentation.ViewModels;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolBus.Presentation.Views
{
    /// <summary>
    /// Interaction logic for AddDriverView.xaml
    /// </summary>
    public partial class AddDriverView : UserControl
    {
        public AddDriverView()
        {
            InitializeComponent();
        }

        public static implicit operator Window(AddDriverView v)
        {
            throw new NotImplementedException();
        }
    }
}
