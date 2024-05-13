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

namespace SharpCircuit
{
    /// <summary>
    /// Interaction logic for MCCTabControl.xaml
    /// </summary>
    public partial class MCCTabControl : UserControl
    {

        public MCCTabControl()
        {
            InitializeComponent();

            Program.ScrollZoomHandler szOpen = new Program.ScrollZoomHandler(scrollViewerClosed, sliderClosed, gridClosed, scaleTransformClosed, 0.25);

            
        }

        public void configureMCC()
        {
            MCCControl.configureMCC();
        }

    }
}
