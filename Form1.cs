using ExoBiblio.vues.panels;
using System.Diagnostics;

namespace ExoBiblio
{
    public partial class Form1 : Form
    {
        public TabPage currentTabPage;
        public Panel? currentPanel;
        public int optionId = 0;
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine("form1 init");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainTab.Size = new Size(this.Width, this.Height);


/*
            Panel bornePanel = new BornePanel();
            mainTab.TabPages[0].Controls.Add(BornePanel);
            Panel accueilPanel = new AccueilPanel();
            mainTab.TabPages[1].Controls.Add(AccueilPanel);
            Panel stockPanel = new StockPanel();
            mainTab.TabPages[2].Controls.Add(StockPanel);
            Panel livrePanel = new LivrePanel();
            mainTab.TabPages[3].Controls.Add(LivrePanel);
*/

            /**** TESTS ****/


            Panel rechercheAbonnePanel = new RechercheAbonnePanel(this);
            currentTabPage = mainTab.TabPages[1];
            currentTabPage.Controls.Add(rechercheAbonnePanel);


        }

        public void ChangePanel(int panelId, string pageName = "", int optionId = 0)
        {
            // code qui decharge le onglet/page actuelle
            //mettre 
            currentTabPage.Controls.Clear();
            
            switch (panelId)
            {
                case 0:

                    break;
                case 1:
                    switch (pageName)
                    {
                        case "abonne":
                            currentPanel = new AbonnePanel(this);
                            break;

                        case "rechercheAbonne":
                            currentPanel = new RechercheAbonnePanel(this);
                            break;

                        case "emprunts":
                            currentPanel = new ExemplePanel(this);
                            break;

                        case "registre":
                            currentPanel = new ExemplePanel(this);
                            break;

                        case "reservationsAbonne":
                            currentPanel = new ExemplePanel(this);
                            break;

                        case "empruntsAbonne":
                            currentPanel = new ExemplePanel(this);
                            break;

                        default:
                            Debug.WriteLine("erreur la page n existe pas !");
                            break;
                    }

                    break;
                case 2:

                    break;
                case 3:

                    break;
                default:
                    Debug.WriteLine("erreur l onglet n existe pas !");
                    break;
            }

            //code qui charge le nouvel onglet/page
            mainTab.TabPages[panelId].Controls.Add(currentPanel);


        }
    }
}