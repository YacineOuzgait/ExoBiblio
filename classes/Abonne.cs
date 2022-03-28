using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Abonne
    {
        int id;
        string nom;
        string prenom;
        string adresse;
        DateTime date_adhesion;
        string matricule;
        string telephone;
        DateTime date_naissance;
        string email;
        string passeword;
        bool deleted;

        public Abonne(int id, string nom, string prenom, string adresse, DateTime date_adhesion, string matricule, string telephone, DateTime date_naissance, string email, string passeword, bool deleted)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.date_adhesion = date_adhesion;
            this.matricule = matricule;
            this.telephone = telephone;
            this.date_naissance = date_naissance;
            this.email = email;
            this.passeword = passeword;
            this.deleted = deleted;
        }

    }
}
