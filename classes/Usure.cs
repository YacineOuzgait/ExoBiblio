using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Usure : BaseModel<Usure>
    {
        string etat;

        public string Etat
        {
            get { return etat; }
            set
            {
                if (this.etat != value)
                {
                    this.etat = value;
                }
            }
        }

    }
}
