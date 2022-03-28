using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Categorie
    {
        private int id;
        private string titre;

        public string Titre { get => titre; set => titre = value; }

        public Categorie()
        {

        }
        public Categorie(string titre)
        {

        }

        public Categorie(int id, string titre)
        {

        }
    }
}
