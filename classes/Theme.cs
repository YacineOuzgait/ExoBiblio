using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Theme
    {
        int id;
        string titre;
        bool deleted;

        public Theme(int id, string titre, bool deleted)
        {
            this.id = id;
            this.titre = titre;
            this.deleted = deleted;
        }

    }
}
