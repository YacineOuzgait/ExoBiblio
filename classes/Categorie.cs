using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class Categorie : BaseModel<Categorie>
    {
        private string titre;

        public string Titre { 
            get { return titre; }
            set 
            {
                if (this.titre != value)
                {
                    this.titre = value;
                }
            } 
        }

        //relation categorie.abonnes
        [JsonIgnore]
        private List<Abonne> abonnesList;
        public List<Abonne> AbonnesList
        {
            get
            {
                if (this.abonnesList == null)
                {
                    this.abonnesList = Abonne.jDA.GetAll(item => item.IdCategorie == this.Id);
                }
                return this.abonnesList;
            }
        }
        public List<Abonne> AddAbonne(Abonne abonne)
        {
            if (this.AbonnesList.Find(item => item.Id == abonne.Id) == null)
            {
                this.AbonnesList.Add(abonne);
                if (abonne.Categorie.Id != this.Id)
                {
                    abonne.Categorie = this;
                }
            }
            return this.AbonnesList;
        }

        public List<Abonne> RemoveAbonne(Abonne abonne)
        {
            int index = this.AbonnesList.FindIndex(item => item.Id == abonne.Id);
            if (index >= 0)
            {
                this.AbonnesList.RemoveAt(index);
                if (abonne.Categorie.Id == this.Id)
                {
                    abonne.Categorie = null;
                }
            }
            return this.AbonnesList;
        }



    }


}
