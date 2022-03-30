using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int? idExemplaire
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
                    Exemplaire?.RemoveExemplaire(this);
                    this.idExemplaire = value?.Id;
                    this.exemplaire = null; //need to reset Livre get
                    Exemplaire?.AddExemplaire(this);
                }
            }
        }


        [JsonProperty(PropertyName = "id_reservation")]
        private int? idReservation;
        public int? idReservation
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
                    Reservation?.RemoveReservation(this);
                    this.idReservation = value?.Id;
                    this.reservation = null; //need to reset Livre get
                    Reservation?.AddReservation(this);
                }
            }
        }
    }


}
