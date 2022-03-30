using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Reservation : BaseModel<Reservation>
    {
        [JsonProperty(PropertyName = "date_reservation")]
        string dateReservation;

        public DateTime DateReservation
        {
            get => DateTime.Parse(dateReservation);
            set
            {
                if (this.dateReservation != value.ToString("yyyy-MM-dd"))
                {
                    this.dateReservation = value.ToString("yyyy-MM-dd");
                }
            }
        }

        [JsonProperty(PropertyName = "id_livre")]
        private int? idLivre;
        public int? IdLivre
        {
            get { return idLivre; }
            set
            {
                if (this.idLivre != value)
                {
                    this.idLivre = value;
                    //TODO persist ?
                }
            }
        }

        [JsonIgnore]
        private Livre livre;
        public Livre Livre
        {
            get
            {
                if (this.livre == null)
                {
                    livre = Livre.jDA.GetById(this.idLivre);
                }
                return livre;
            }
            set
            {
                if (this.idLivre != value?.Id)
                {
                    Livre?.RemoveReservation(this);
                    this.idLivre = value?.Id;
                    this.livre = null; //need to reset Livre get
                    Livre?.AddReservation(this);
                }
            }
        }

        [JsonProperty(PropertyName = "id_abonne")]
        private int idAbonne;
        public int IdAbonne
        {
            get { return idAbonne; }
            set
            {
                if (this.idAbonne != value)
                {
                    this.idAbonne = value;
                }
            }
        }

        [JsonIgnore]
        private Abonne abonne;
        public Abonne Abonne
        {
            get
            {
                if (this.abonne == null)
                {
                    abonne = Abonne.jDA.GetById(this.idAbonne);
                }
                return abonne;
            }
            set
            {
                if (this.idAbonne != value.Id)
                {
                    Abonne.RemoveReservation(this);
                    this.idAbonne = value.Id;
                    //this.categorie = null; //need to reset Livre get
                    Abonne.AddReservation(this);
                }
            }
        }

        [JsonProperty(PropertyName = "id_editeur")]
        private int? idEditeur;
        public int? IdEditeur
        {
            get { return idEditeur; }
            set
            {
                if (this.idEditeur != value)
                {
                    this.idEditeur = value;
                    //TODO persist ?
                }
            }
        }

        [JsonIgnore]
        private Editeur editeur;
        public Editeur Editeur
        {
            get
            {
                if (this.editeur == null)
                {
                    editeur = Editeur.jDA.GetById(this.idEditeur);
                }
                return editeur;
            }
            set
            {
                if (this.idEditeur != value?.Id)
                {
                    Editeur?.RemoveReservation(this);
                    this.idEditeur = value?.Id;
                    this.editeur = null; //need to reset Livre get
                    Editeur?.AddReservation(this);
                }
            }
        }

        [JsonIgnore]
        private List<Editeur> editeursList;
        public List<Editeur> EditeursList
        {
            get
            {
                if (this.editeursList == null)
                {
                    this.editeursList = Editeur.jDA.GetAll(item => item.IdReservation == this.Id);
                }
                return this.editeursList;
            }
        }
        public List<Editeur> AddEditeur(Editeur editeur)
        {
            if (this.EditeursList.Find(item => item.Id == editeur.Id) == null)
            {
                this.EditeursList.Add(editeur);
                if (editeur.Reservation.Id != this.Id)
                {
                    editeur.Reservation = this;
                }
            }
            return this.EditeursList;
        }

        public List<Editeur> RemoveEditeur(Editeur editeur)
        {
            int index = this.EditeursList.FindIndex(item => item.Id == editeur.Id);
            if (index >= 0)
            {
                this.EditeursList.RemoveAt(index);
                if (editeur.Reservation.Id == this.Id)
                {
                    editeur.Reservation = null;
                }
            }
            return this.EditeursList;
        }
    }
}
