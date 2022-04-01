using ExoBiblio.vues.composants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.vues.panels
{
    internal class RechercheAbonnePanel : Panel
    {
        public Form1 mainForm;
        public Button button;
        public RechercheAbonnePanel(Form1 inMainForm)
        {
            mainForm = inMainForm;
            TabPage parent = mainForm.mainTab.TabPages[1];
            
            //informations panel
            this.Size = new Size(parent.Width, parent.Height);
            this.BackColor = Color.AntiqueWhite;


            int selectedAbonneId = 0;

            //composants panel
            this.button = new Button();
            this.button.Top = 40;
            this.button.Width = 120;
            this.button.Text = "fiche abonne";
            this.button.Click += delegate (object sender, EventArgs e) { gotToAbonneProfil(sender, e, selectedAbonneId); };             
            this.Controls.Add(button);

            RechercheAbonneComponent rechercheAbonneComponent = new RechercheAbonneComponent(this.Size);
            this.Controls.Add(rechercheAbonneComponent);
        }
        private void gotToAbonneProfil(object sender, EventArgs e, int abonneId)
        {
            mainForm.ChangePanel(1, "abonne", abonneId);
        }

    }
}
