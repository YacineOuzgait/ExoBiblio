using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Abonne : BaseModel<Abonne>
    {

        string nom;
        string prenom;
        string adresse;
        [JsonProperty(PropertyName = "date_adhesion")]
        string dateAdhesion;
        string matricule;
        string telephone;
        [JsonProperty(PropertyName = "date_naissance")]
        string dateNaissance;
        string email;
        string password;
    
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

        public string Adresse { get => adresse;
            set
            {
                if(this.adresse != value)
                {
                    this.adresse = value;
                }
            }    
        }
        public DateTime DateAdhesion { get => DateTime.Parse(dateAdhesion);
            set
            {
                if(this.dateAdhesion != value.ToString("yyyy-MM-dd"))
                {
                    this.dateAdhesion = value.ToString("yyyy-MM-dd");
                }
            } 
        }

        public string Matricule
        {
            get => matricule;
            set
            {
                if (this.matricule != value)
                {
                    this.matricule = value;
                }
            }
        }

        public string Telephone
        {
            get => telephone;
            set
            {
                if (this.telephone != value)
                {
                    this.telephone = value;
                }
            }
        }

        public DateTime DateNaissance
        {
            get => DateTime.Parse(dateNaissance);
            set
            {
                if (this.dateNaissance != value.ToString("yyyy-MM-dd"))
                {
                    this.dateNaissance = value.ToString("yyyy-MM-dd");
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                }
            }
        }
    }








}
