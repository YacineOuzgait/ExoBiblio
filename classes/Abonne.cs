using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Abonne : BaseModel
    {
        
        string nom;
        string prenom;
        string adresse;
        DateTime date_adhesion;
        string matricule;
        string telephone;
        DateTime date_naissance;
        string email;
        string password;

        public Abonne() : base()
        {

        }
        



        //Controles back dans les setters
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public DateTime Date_adhesion { get => date_adhesion; set => date_adhesion = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public DateTime Date_naissance { get => date_naissance; set => date_naissance = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }



        /***********************  ANCIEN CONSTRUCTEUR ******************************/
        //public Abonne(int id,string nom, string prenom, string adresse, DateTime date_adhesion, string matricule, string telephone, DateTime date_naissance, string email, string password,bool deleted) : base(id, deleted)
        //{
        //    this.Nom = nom;
        //    this.Prenom = prenom;
        //    this.Adresse = adresse;
        //    this.Date_adhesion = date_adhesion;
        //    this.Matricule = matricule;
        //    this.Telephone = telephone;
        //    this.Date_naissance = date_naissance;
        //    this.Email = email;
        //    this.Password = password;
        //}
    }
}
