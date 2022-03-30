using Newtonsoft.Json;
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

        [JsonIgnore]
        private List<Exemplaire> exemplairesList;
        public List<Exemplaire> ExemplairesList
        {
            get
            {
                if (this.exemplairesList == null)
                {
                    this.exemplairesList = Exemplaire.jDA.GetAll(item => item.IdUsure == this.Id);
                }
                return this.exemplairesList;
            }
        }
        public List<Exemplaire> AddExemplaire(Exemplaire exemplaire)
        {
            if (this.ExemplairesList.Find(item => item.Id == exemplaire.Id) == null)
            {
                this.ExemplairesList.Add(exemplaire);
                if (exemplaire.Usure.Id != this.Id)
                {
                    exemplaire.Usure = this;
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
                if (exemplaire.Usure.Id == this.Id)
                {
                    exemplaire.Usure = null;
                }
            }
            return this.ExemplairesList;
        }

    }
}
