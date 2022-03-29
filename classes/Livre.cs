using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
  internal class Livre : BaseModel<Livre>
    {
        
        string titre;
        string isbn;

        public string Titre
        { 
            get
            { return titre; } 
            set
            {
                if (this.titre != value)
                {
                    this.titre = value;
                }
            }
                }
        public string Isbn
        {
            get
            { return isbn; }
            set
            {
                if (this.isbn != value)
                {
                    this.isbn = value;
                }
            }
        }
    }
}