using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Category
    {
        private int id;
        private string titre;

        public string Titre { get => titre; set => titre = value; }

        public Category()
        {

        }
        public Category(string titre)
        {

        }

        public Category(int id, string titre)
        {

        }
    }
}
