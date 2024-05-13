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
    /// Interaction logic for PotAssembly.xaml
    /// </summary>
    public partial class PotAssembly : UserControl
    {
        public event EventHandler PotSelectionChanged;
        public delegate void PotSelectionChangedHandler(EventArgs e);
        public void OnPotSelectionChanged(EventArgs e)
        {
            EventHandler handler = PotSelectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public PotAssembly()
        {
            InitializeComponent();

            List<Program.ImageButtonHandler> bList = new List<Program.ImageButtonHandler>();
            Program.ImageButtonHandler front = new Program.ImageButtonHandler(FrontButtonImage, FrontPotWires,
                                       @"pack://application:,,,/SCRLogic;component/Resources/FRONT-BUTTON.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/FRONT-BUTTON-OVER.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/FRONT-BUTTON-SELECTED.png");

            Program.ImageButtonHandler rear = new Program.ImageButtonHandler(RearButtonImage, RearPotWires,
                                       @"pack://application:,,,/SCRLogic;component/Resources/REAR-BUTTON.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/REAR-BUTTON-OVER.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/REAR-BUTTON-SELECTED.png");

            bList.Add(front);
            bList.Add(rear);
            front.buttonGroup = bList;
            rear.buttonGroup = bList;

            rear.isSelected = true;
        }
    }
}
