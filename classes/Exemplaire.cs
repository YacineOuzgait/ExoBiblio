using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExoBiblio.classes
{
    internal class Exemplaire : BaseModel<Exemplaire>
    {
        [JsonProperty(PropertyName = "date_achat")]
        string dateAchat;
        string emplacement;
        

        public DateTime DateAchat
        {
            get => DateTime.Parse(dateAchat);
            set
            {
                if (this.dateAchat != value.ToString("yyyy-MM-dd"))
                {
                    this.dateAchat = value.ToString("yyyy-MM-dd");
                }
            }
        }

        public string Emplacement
        {
            get => emplacement;
            set
            {
                if (this.emplacement != value)
                {
                    this.emplacement = value;
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
                    Livre?.RemoveExemplaire(this);
                    this.idLivre = value?.Id;
                    this.livre = null; //need to reset Livre get
                    Livre?.AddExemplaire(this);
                }
            }
        }

        [JsonProperty(PropertyName = "id_usure")]
        private int idUsure;
        public int IdUsure
        {
            get { return idUsure; }
            set
            {
                if (this.idUsure != value)
                {
                    this.idUsure = value;
                }
            }
        }

        [JsonIgnore]
        private Usure usure;
        public Usure Usure
        {
            get
            {
                if (this.usure == null)
                {
                    usure = Usure.jDA.GetById(this.idUsure);
                }
                return usure;
            }
            set
            {
                if (this.idUsure != value?.Id)
                {
                    Usure?.RemoveExemplaire(this);
                    this.idUsure = value?.Id;
                    this.usure = null; //need to reset Usure get
                    Usure?.AddExemplaire(this);
                }
            }
        }

        [JsonProperty(PropertyName = "id_editeur")]
        private int idEditeur;
        public int IdEditeur
        {
            get { return idEditeur; }
            set
            {
                if (this.idEditeur != value)
                {
                    this.idEditeur = value;
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
                    Editeur?.RemoveExemplaire(this);
                    this.idEditeur = value?.Id;
                    this.editeur = null; //need to reset Editeur get
                    Editeur?.AddExemplaire(this);
                }
            }
        }
    }
}
