using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.vues.panels
{
    internal class ExemplePanel : Panel
    {
        public Form1 mainForm;

        public ExemplePanel(Form1 inMainForm)
            {
                mainForm = inMainForm;
                //Change le panel id !!
                TabPage parent = mainForm.mainTab.TabPages[0];

                Label label = new Label();
                label.Text = "test";
                this.Controls.Add(label);

                Label label2 = new Label();
                label2.Top = 30;
                label2.Text = "test2";
                this.Controls.Add(label2);


                TextBox textBox = new TextBox();
                textBox.Top = 60;
                textBox.Text = "entrez votre email";
                this.Controls.Add((TextBox)textBox);

                Button button = new Button();
                button.Click += clicBt;

            }
            private void clicBt(object sender, EventArgs e)
            {

            }
        }
}
