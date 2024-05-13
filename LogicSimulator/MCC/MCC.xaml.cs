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
    /// Interaction logic for MCC.xaml
    /// </summary>
    public partial class MCC : UserControl
    {
        public SimCircuit simcircuit { get; set; }
        public MCC()
        {
            InitializeComponent();
        }

        public void configureMCC()
        {
            A1.configureCan(@"Resources\CANCON-1.CSV", "A1", "RT", "BLOWER");
            A2.configureCan(@"Resources\CANCON-1.CSV", "A2", "DWA", "BLOWER");
            A3.configureCan(@"Resources\CANCON-1.CSV", "A3", "DWB", "BLOWER");

            B1.configureCan(@"Resources\CANCON-1.CSV", "B1", "MP1A", "BLOWER");
            B2.configureCan(@"Resources\CANCON-1.CSV", "B2", "MP1B", "BLOWER");
            B3.configureCan(@"Resources\CANCON-1.CSV", "B3", "MP1", "ROD OILER");
            B4.configureCan(@"Resources\CANCON-1.CSV", "B4", "MP1", "CHAIN OILER");
            B5.configureCan(@"Resources\CANCON-1.CSV", "B5", "SUPERCHARGE", "PUMP No.1");

            C1.configureCan(@"Resources\CANCON-1.CSV", "C1", "MP2A", "BLOWER");
            C2.configureCan(@"Resources\CANCON-1.CSV", "C2", "MP2B", "BLOWER");
            C3.configureCan(@"Resources\CANCON-1.CSV", "C3", "MP2", "ROD OILER");
            C4.configureCan(@"Resources\CANCON-1.CSV", "C4", "MP2", "CHAIN OILER");
            C5.configureCan(@"Resources\CANCON-1.CSV", "C5", "SUPERCHARGE", "PUMP No.2");

            A1.simCan.startTimer();
            A2.simCan.startTimer();
            A3.simCan.startTimer();

            B1.simCan.startTimer();
            B2.simCan.startTimer();
            B3.simCan.startTimer();
            B4.simCan.startTimer();
            B5.simCan.startTimer();

            C1.simCan.startTimer();
            C2.simCan.startTimer();
            C3.simCan.startTimer();
            C4.simCan.startTimer();
            C5.simCan.startTimer();

        }
    }
}
