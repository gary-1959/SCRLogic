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
    /// Interaction logic for AssignmentSwitch.xaml
    /// </summary>
    public partial class AssignmentSwitch : UserControl
    {
        SimCircuit simcircuit { get; set; }
        public AssignmentSwitch()
        {
            InitializeComponent();
        }

        public void configureAS(SimCircuit sc)
        {
            simcircuit = sc;

            int[] positions = { 8, 9, 10, 11, 1, 2, 3, 4 };
            #region DECKS
            Deck1.DeckImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/ASSIGNMENT-DECK-1.png"));
            Deck2.DeckImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/ASSIGNMENT-DECK-2.png"));
            Deck3.DeckImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/ASSIGNMENT-DECK-3.png"));
            Deck4.DeckImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/SCRLogic;component/Resources/ASSIGNMENT-DECK-4.png"));
            foreach (int i in positions)
            {
                string lZ = i.ToString("D2");
                CircuitPoint cpA = Deck1.FindName("cp_" + lZ + "A") as CircuitPoint;
                CircuitPoint cpB = Deck1.FindName("cp_" + lZ + "B") as CircuitPoint;
                simcircuit.setNode(cpA, "DC", "S1-A" + i.ToString(), "A" + i.ToString(), "S1", "A" + i.ToString());
                simcircuit.setNode(cpB, "DC", "S1-A" + i.ToString(), "B" + i.ToString(), "S1", "B" + i.ToString());

                CircuitPoint cpC = Deck2.FindName("cp_" + lZ + "A") as CircuitPoint;
                CircuitPoint cpD = Deck2.FindName("cp_" + lZ + "B") as CircuitPoint;
                simcircuit.setNode(cpC, "DC", "S1-C" + i.ToString(), "C" + i.ToString(), "S1", "C" + i.ToString());
                simcircuit.setNode(cpD, "DC", "S1-C" + i.ToString(), "D" + i.ToString(), "S1", "D" + i.ToString());

                CircuitPoint cpE = Deck3.FindName("cp_" + lZ + "A") as CircuitPoint;
                CircuitPoint cpF = Deck3.FindName("cp_" + lZ + "B") as CircuitPoint;
                simcircuit.setNode(cpE, "DC", "S1-E" + i.ToString(), "E" + i.ToString(), "S1", "E" + i.ToString());
                simcircuit.setNode(cpF, "DC", "S1-E" + i.ToString(), "F" + i.ToString(), "S1", "F" + i.ToString());

                CircuitPoint cpG = Deck4.FindName("cp_" + lZ + "A") as CircuitPoint;
                CircuitPoint cpH = Deck4.FindName("cp_" + lZ + "B") as CircuitPoint;
                simcircuit.setNode(cpG, "DC", "S1-G" + i.ToString(), "G" + i.ToString(), "S1", "G" + i.ToString());
                simcircuit.setNode(cpH, "DC", "S1-G" + i.ToString(), "H" + i.ToString(), "S1", "H" + i.ToString());
            }
            #endregion

            List<Program.ImageButtonHandler> bList = new List<Program.ImageButtonHandler>();
            Program.ImageButtonHandler deck1 = new Program.ImageButtonHandler(Deck1Button, Deck1,
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-1-BUTTON.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-1-BUTTON-OVER.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-1-BUTTON-SELECTED.png");
            Program.ImageButtonHandler deck2 = new Program.ImageButtonHandler(Deck2Button, Deck2,
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-2-BUTTON.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-2-BUTTON-OVER.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-2-BUTTON-SELECTED.png");
            Program.ImageButtonHandler deck3 = new Program.ImageButtonHandler(Deck3Button, Deck3,
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-3-BUTTON.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-3-BUTTON-OVER.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-3-BUTTON-SELECTED.png");
            Program.ImageButtonHandler deck4 = new Program.ImageButtonHandler(Deck4Button, Deck4,
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-4-BUTTON.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-4-BUTTON-OVER.png",
                                       @"pack://application:,,,/SCRLogic;component/Resources/DECK-4-BUTTON-SELECTED.png");

            bList.Add(deck1);
            bList.Add(deck2);
            bList.Add(deck3);
            bList.Add(deck4);
            deck1.buttonGroup = bList;
            deck2.buttonGroup = bList;
            deck3.buttonGroup = bList;
            deck4.buttonGroup = bList;

            deck1.isSelected = true;
        }
    }
}
