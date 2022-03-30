using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExoBiblio.classes
{
    internal class Editeur : BaseModel<Editeur>
    {
        
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


        [JsonProperty(PropertyName = "id_exemplaire")]
        private int? idExemplaire;
        public int? IdExemplaire
        {
            get { return idExemplaire; }
            set
            {
                if (this.idExemplaire != value)
                {
                    this.idExemplaire = value;
                    //TODO persist ?
                }
            }
        }

        [JsonIgnore]
        private Exemplaire exemplaire;
        public Exemplaire Exemplaire
        {
            get
            {
                if (this.exemplaire == null)
                {
                    exemplaire = Exemplaire.jDA.GetById(this.idExemplaire);
                }
                return exemplaire;
            }
            set
            {
                if (this.idExemplaire != value?.Id)
                {
                    Exemplaire?.RemoveEditeur(this);
                    this.idExemplaire = value?.Id;
                    this.exemplaire = null; //need to reset Livre get
                    Exemplaire?.AddEditeur(this);
                }
            }
        }

        [JsonIgnore]
        private List<Exemplaire> exemplairesList;
        public List<Exemplaire> ExemplairesList
        {
            get
            {
                if (this.exemplairesList == null)
                {
                    this.exemplairesList = Exemplaire.jDA.GetAll(item => item.IdEditeur == this.Id);
                }
                return this.exemplairesList;
            }
        }
        public List<Exemplaire> AddExemplaire(Exemplaire exemplaire)
        {
            if (this.ExemplairesList.Find(item => item.Id == exemplaire.Id) == null)
            {
                this.ExemplairesList.Add(exemplaire);
                if (exemplaire.Editeur.Id != this.Id)
                {
                    exemplaire.Editeur = this;
                }
            }
            return this.ExemplairesList;
        }

        public List<Exemplaire> RemoveExemplaire(Exemplaire exemplaire)
        {
            int index = this.ExemplairesList.FindIndex(item => item.Id == exemplaire.Id);
            if (index >= 0)
            {
                this.ExemplairesList.RemoveAt(index);
                if (exemplaire.Editeur.Id == this.Id)
                {
                    exemplaire.Editeur = null;
                }
            }
            return this.ExemplairesList;
        }


        [JsonProperty(PropertyName = "id_reservation")]
        private int? idReservation;
        public int? IdReservation
        {
            get { return idReservation; }
            set
            {
                if (this.idReservation != value)
                {
                    this.idReservation = value;
                    //TODO persist ?
                }
            }
        }

        [JsonIgnore]
        private Reservation reservation;
        public Reservation Reservation
        {
            get
            {
                if (this.reservation == null)
                {
                    reservation = Reservation.jDA.GetById(this.idReservation);
                }
                return reservation;
            }
            set
            {
                if (this.idReservation != value?.Id)
                {
                    Reservation?.RemoveEditeur(this);
                    this.idReservation = value?.Id;
                    this.reservation = null; //need to reset Livre get
                    Reservation?.AddEditeur(this);
                }
            }
        }

        [JsonIgnore]
        private List<Reservation> reservationsList;
        public List<Reservation> ReservationsList
        {
            get
            {
                if (this.reservationsList == null)
                {
                    this.reservationsList = Reservation.jDA.GetAll(item => item.IdEditeur == this.Id);
                }
                return this.reservationsList;
            }
        }
        public List<Reservation> AddReservation(Reservation reservation)
        {
            if (this.ReservationsList.Find(item => item.Id == reservation.Id) == null)
            {
                this.ReservationsList.Add(reservation);
                if (reservation.Editeur.Id != this.Id)
                {
                    reservation.Editeur = this;
                }
            }
            return this.ReservationsList;
        }

        public List<Reservation> RemoveReservation(Reservation reservation)
        {
            int index = this.ReservationsList.FindIndex(item => item.Id == reservation.Id);
            if (index >= 0)
            {
                this.ReservationsList.RemoveAt(index);
                if (reservation.Editeur.Id == this.Id)
                {
                    reservation.Editeur = null;
                }
            }
            return this.ReservationsList;
        }
    }


}
