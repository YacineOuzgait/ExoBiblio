using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExoBiblio.classes
{
    internal class Emprunt : BaseModel<Emprunt>
    {
        [JsonProperty(PropertyName = "date_sortie")]
        string dateSortie;
        [JsonProperty(PropertyName = "date_retour")]
        string dateRetour;

        public DateTime DateSortie
        {
            get => DateTime.Parse(dateSortie);
            set
            {
                if (this.dateSortie != value.ToString("yyyy-MM-dd"))
                {
                    this.dateSortie = value.ToString("yyyy-MM-dd");
                }
            }
        }

        public DateTime DateRetour
        {
            get => DateTime.Parse(dateRetour);
            set
            {
                if (this.dateRetour != value.ToString("yyyy-MM-dd"))
                {
                    this.dateRetour = value.ToString("yyyy-MM-dd");
                }
            }
        }

        [JsonProperty(PropertyName = "id_exemplaire")]
        private int idExemplaire;
        public int IdExemplaire
        {
            get { return idExemplaire; }
            set
            {
                if (this.idExemplaire != value)
                {
                    this.idExemplaire = value;
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
                if (this.idExemplaire != value.Id)
                {
                    Exemplaire.RemoveEmprunt(this);
                    this.idExemplaire = value.Id;
                    //this.categorie = null; //need to reset Livre get
                    Exemplaire.AddEmprunt(this);
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
                    Abonne.RemoveEmprunt(this);
                    this.idAbonne = value.Id;
                    //this.categorie = null; //need to reset Livre get
                    Abonne.AddEmprunt(this);
                }
            }
        }



    }
}
