namespace ExoBiblio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Panel bornePanel = new BornePanel();
            mainTab.TabPages[0].Controls.Add(BornePanel);
            Panel accueilPanel = new AccueilPanel();
            mainTab.TabPages[1].Controls.Add(AccueilPanel);
            Panel stockPanel = new StockPanel();
            mainTab.TabPages[2].Controls.Add(StockPanel);
            Panel livrePanel = new LivrePanel();
            mainTab.TabPages[3].Controls.Add(LivrePanel);

            /**** TESTS ****/
            //classes.Abonne abonne = new classes.Abonne() { Adresse = "" };
        }
    }
}