using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.vues.composants
{
    internal class RechercheAbonneComponent : Panel
    {
        
        public RechercheAbonneComponent(Size parentSize)
        {
            int margin = 20;
            this.Width = parentSize.Width ;
            this.Width = (Width / 2) -margin*2;
            this.Height = parentSize.Height;
            this.Left = margin;
            this.Top = 20;
            this.BackColor = Color.AliceBlue;



            Label label = new Label();
            label.Top = 10;
            label.Width = 200;
            label.Text = "Rechercher un abonné";
            this.Controls.Add(label);

            TextBox textBox = new TextBox();
            textBox.Top = 10;
            textBox.Left = label.Width +10;
            textBox.Width = 200;
            textBox.Text = "entrez un nom";
            this.Controls.Add((TextBox)textBox);

            Button button = new Button();
            button.Top = 40;
            button.Width = 120;
            button.Text = "Rechercher";
            button.Click += clicBt;
            this.Controls.Add(button);

        }

        private void clicBt(object sender, EventArgs e)
        {

        }
    }
}
