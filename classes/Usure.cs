using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Usure
    {
        int id;
        string etat;
        bool deleted;

        public Usure()
        {

        }

        public Usure(int id, string etat, bool deleted)
        {
            this.id = id;
            this.etat = etat;
            this.deleted = deleted;
        }

    }
}
