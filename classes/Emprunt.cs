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
        public int idExemplaire
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

        [JsonProperty(PropertyName = "id_abonne")]
        private int idAbonne;
        public int idAbonne
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



    }
}
