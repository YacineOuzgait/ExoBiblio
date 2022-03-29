using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class MotCle :BaseModel<MotCle>
    {
        string mot;

        public string Mot
        {
            get { return mot; }
            set
            {
                if (this.mot != value)
                {
                    this.mot = value;
                }
            }
        }

    }
}
