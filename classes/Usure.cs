using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Usure : BaseModel<Usure>
    {
        string etat;

        public string Etat
        {
            get { return etat; }
            set
            {
                if (this.etat != value)
                {
                    this.etat = value;
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

    }
}
