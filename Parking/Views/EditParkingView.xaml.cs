using Parking.PresentationLogic.ViewModels;
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

namespace Parking.Views
{
    /// <summary>
    /// Interaction logic for EditParkingView.xaml
    /// </summary>
    public partial class EditParkingView : Window
    {
        public EditParkingView(EditParkingViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
