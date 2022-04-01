using ExoBiblio.vues.composants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.vues.panels
{
    internal class AbonnePanel : Panel
    {
        public Form1 mainForm;
        public Button button;
        public AbonnePanel(Form1 inMainForm)
        {
            mainForm = inMainForm;
            TabPage parent = mainForm.mainTab.TabPages[0];
            //informations panel
            this.Size = new Size(parent.Width, parent.Height);
            this.BackColor = Color.AntiqueWhite;


            int selectedAbonneId = 0;


            //Bouton retour
            this.button = new Button();
            this.button.Top = 40;
            this.button.Width = 120;
            this.button.Text = "retour";
            this.button.Click += delegate (object sender, EventArgs e) { goToAbonneProfil(sender, e); };
            this.Controls.Add(button);

        }

        private void goToAbonneProfil(object sender, EventArgs e)
        {
            mainForm.ChangePanel(1, "rechercheAbonne");
        }

    }
}
