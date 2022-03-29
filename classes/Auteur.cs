using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Auteur : BaseModel<Auteur>
    {

        string prenom;
        string nom;

        public string Nom
        {
            get { return nom; }
            set
            {
                if (this.nom != value)
                {
                    this.nom = value;
                }
            }
        }

        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (this.prenom != value)
                {
                    this.prenom = value;
                }
            }
        }


    }
}
