using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Auteur
    {
        int id;

        string prenom;
        string nom;

        public Auteur(int id, string prenom, string nom)
        {
            this.id = id;
            this.prenom = prenom;
            this.nom = nom;
        } 

    }
}
