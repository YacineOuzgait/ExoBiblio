using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Theme :  BaseModel<Theme>
    {
        
        string titre;

        public string Titre
        {
            get { return titre; }
            set
            {
                if (this.titre != value)
                {
                    this.titre = value;
                }
            }
        }

    }
}
