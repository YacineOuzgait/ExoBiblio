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

        [JsonProperty(PropertyName = "id_categorie")]
        private int idCategorie;
        public int IdCategorie
        {
            get { return idCategorie; }
            set
            {
                if (this.idCategorie != value)
                {
                    this.idCategorie = value;
                    //TODO persist ?
                }
            }
        }

        [JsonIgnore]
        private Categorie categorie;
        public Categorie Categorie
        {
            get
            {
                if (this.categorie == null)
                {
                    categorie = Categorie.jDA.GetById(this.idCategorie);
                }
                return categorie;
            }
            set
            {
                if (this.idCategorie != value.Id)
                {
                    Categorie.RemoveCategorie(this);
                    this.idCategorie = value.Id;
                    //this.categorie = null; //need to reset Livre get
                    Categorie.AddCategorie(this);
                }
            }
        }

        //relation abonne.emprunts
        [JsonIgnore]
        private List<Emprunt> empruntsList;
        public List<Emprunt> EmpruntsList
        {
            get
            {
                if (this.empruntsList == null)
                {
                    this.empruntsList = Emprunt.jDA.GetAll(item => item.IdAbonne == this.Id);
                }
                return this.empruntsList;
            }
        }
        
        public List<Emprunt> AddEmprunt(Emprunt emprunt)
        {
            if (this.EmpruntsList.Find(item => item.Id == emprunt.Id) == null)
            {
                this.EmpruntsList.Add(emprunt);
                if (emprunt.Abonne.Id != this.Id)
                {
                    emprunt.Abonne = this;
                }
            }
            return this.EmpruntsList;
        }

        public List<Emprunt> RemoveEmprunt(Emprunt emprunt)
        {
            int index = this.EmpruntsList.FindIndex(item => item.Id == emprunt.Id);
            if (index >= 0)
            {
                this.EmpruntsList.RemoveAt(index);
                if (emprunt.Abonne.Id == this.Id)
                {
                    emprunt.Abonne = null;
                }
            }
            return this.EmpruntsList;
        }

        //relation abonne.reservations
        [JsonIgnore]
        private List<Reservation> reservationsList;
        public List<Reservation> ReservationsList
        {
            get
            {
                if (this.reservationsList == null)
                {
                    this.reservationsList = Reservation.jDA.GetAll(item => item.IdAbonne == this.Id);
                }
                return this.reservationsList;
            }
        }
        public List<Reservation> AddEmprunt(Reservation reservation)
        {
            if (this.ReservationsList.Find(item => item.Id == reservation.Id) == null)
            {
                this.ReservationsList.Add(reservation);
                if (reservation.Abonne.Id != this.Id)
                {
                    reservation.Abonne = this;
                }
            }
            return this.ReservationsList;
        }

        public List<Reservation> RemoveEmprunt(Reservation reservation)
        {
            int index = this.ReservationsList.FindIndex(item => item.Id == reservation.Id);
            if (index >= 0)
            {
                this.ReservationsList.RemoveAt(index);
                if (reservation.Abonne.Id == this.Id)
                {
                    reservation.Abonne = null;
                }
            }
            return this.ReservationsList;
        }

    }








}
