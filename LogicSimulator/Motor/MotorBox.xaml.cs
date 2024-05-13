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
    /// Interaction logic for MotorBox.xaml
    /// </summary>
    public partial class MotorBox : UserControl
    {

        public string boxName { get; set; }


        public MotorBox()
        {
            InitializeComponent();

        }

        public void configureBox(string label1, MCCCan can, string sw, MCCCan swcan)
        {
            // close lockout switch
            NetElement lockout = Program.simMain.getElementByLocationAndNettag("MCC", "S" + label1 + "-LOCKOUT");
            SwitchSPST ls = lockout.simElement as SwitchSPST;
            //ls.setPosition(1);

            // link airflow to blower
            NetElement airflow = Program.simMain.getElementByLocationAndNettag("MCC", "S" + label1 + "-AIRFLOW");
            can.canContactor.mainContacts.Add(new Program.SwitchContact(Program.simMain, airflow, true));

            // link aux switch to can contactor
            if (sw != null)
            {
                NetElement pswitch = Program.simMain.getElementByLocationAndNettag("MCC", sw);
                swcan.canContactor.mainContacts.Add(new Program.SwitchContact(Program.simMain, pswitch, true));
            }


            Label1.Content = label1;
            #region MOTOR
            can.simCan.setNode(TB08A, "CAN", "RMOT-1", "1", "TB", "H");
            TB08A.IsACVoltage = true;
            can.simCan.setNode(TB08B, "CAN", "RMOT-1", "1", "TB", "H");
            TB08B.IsACVoltage = true;
            can.simCan.setNode(TB09A, "CAN", "RMOT-2", "3", "TB", "J");
            TB09A.IsACVoltage = true;
            can.simCan.setNode(TB09B, "CAN", "RMOT-2", "3", "TB", "J");
            TB09B.IsACVoltage = true;
            can.simCan.setNode(TB10A, "CAN", "RMOT-3", "5", "TB", "K");
            TB10A.IsACVoltage = true;
            can.simCan.setNode(TB10B, "CAN", "RMOT-3", "5", "TB", "K");
            TB10B.IsACVoltage = true;
            #endregion
            #region LOCKOUT AIRFLOW
            Program.simMain.setNode(TB01A, "MCC", "S" + label1 + "-AIRFLOW", "2", "TB", "C");
            TB01A.IsACVoltage = true;
            Program.simMain.setNode(TB01B, "MCC", "S" + label1 + "-AIRFLOW", "2", "TB", "C");
            TB01B.IsACVoltage = true;
            Program.simMain.setNode(TB02A, "MCC", "S" + label1 + "-LOCKOUT", "1", "TB", "B");
            TB02A.IsACVoltage = true;
            Program.simMain.setNode(TB02B, "MCC", "S" + label1 + "-LOCKOUT", "1", "TB", "B");
            TB02B.IsACVoltage = true;
            Program.simMain.setNode(TB03A, "MCC", "S" + label1 + "-LOCKOUT", "2", "TB", "A");
            TB03A.IsACVoltage = true;
            Program.simMain.setNode(TB03B, "MCC", "S" + label1 + "-LOCKOUT", "2", "TB", "A");
            TB03B.IsACVoltage = true;

            #endregion
            #region FIELD
            Program.simMain.setNode(TB04A, "MCC", "R" + label1 + "F", "1", "TB", "D");
            Program.simMain.setNode(TB04B, "MCC", "R" + label1 + "F", "1", "TB", "D");
            Program.simMain.setNode(TB05A, "MCC", "R" + label1 + "F", "1", "TB", "E");
            Program.simMain.setNode(TB05B, "MCC", "R" + label1 + "F", "1", "TB", "E");
            Program.simMain.setNode(TB06A, "MCC", "R" + label1 + "F", "1", "TB", "F");
            Program.simMain.setNode(TB06B, "MCC", "R" + label1 + "F", "1", "TB", "F");
            Program.simMain.setNode(TB07A, "MCC", "R" + label1 + "F", "1", "TB", "G");
            Program.simMain.setNode(TB07B, "MCC", "R" + label1 + "F", "1", "TB", "G");

            Program.simMain.setNode(TB14A, "MCC", "R" + label1 + "F", "2", "TB", "P");
            Program.simMain.setNode(TB14B, "MCC", "R" + label1 + "F", "2", "TB", "P");
            Program.simMain.setNode(TB15A, "MCC", "R" + label1 + "F", "2", "TB", "R");
            Program.simMain.setNode(TB15B, "MCC", "R" + label1 + "F", "2", "TB", "R");
            Program.simMain.setNode(TB16A, "MCC", "R" + label1 + "F", "2", "TB", "S");
            Program.simMain.setNode(TB16B, "MCC", "R" + label1 + "F", "2", "TB", "S");
            Program.simMain.setNode(TB17A, "MCC", "R" + label1 + "F", "2", "TB", "T");
            Program.simMain.setNode(TB17B, "MCC", "R" + label1 + "F", "2", "TB", "T");
            #endregion
            #region SWITCH
            if (sw != null)
            {
                Program.simMain.setNode(TB11A, "MCC", sw, "1", "TB", "L");
                Program.simMain.setNode(TB11B, "MCC", sw, "1", "TB", "L");
                Program.simMain.setNode(TB12A, "MCC", sw, "2", "TB", "M");
                Program.simMain.setNode(TB12B, "MCC", sw, "2", "TB", "M");
            }

            #endregion
            Program.simMain.setNode(TB18A, "*", "GND", "1", "TB", "V");
            Program.simMain.setNode(TB18B, "*", "GND", "1", "TB", "V");
            Program.simMain.setNode(TB19A, "*", "GND", "1", "TB", "W");
            Program.simMain.setNode(TB19B, "*", "GND", "1", "TB", "W");
            Program.simMain.setNode(TB20A, "*", "GND", "1", "TB", "X");
            Program.simMain.setNode(TB20B, "*", "GND", "1", "TB", "X");

        }

    }
}
