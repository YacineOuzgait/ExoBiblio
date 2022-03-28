using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    public class Livre
    {
        int id;
        string titre;
        string isbn;
        bool deleted;

        public Livre(int id, string titre, string isbn, bool deleted)
        {
            this.id = id;
            this.titre = titre;
            this.isbn = isbn;
            this.deleted = deleted;
        }

    }
}
