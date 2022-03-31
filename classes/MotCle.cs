using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class MotCle :BaseModel<MotCle>
    {
        string mot;

        public string Mot
        {
            get { return mot; }
            set
            {
                if (this.mot != value)
                {
                    this.mot = value;
                }
            }
        }

        [JsonIgnore]
        private List<int> idLivreList;
        public List<int> IdLivreList
        {
            get
            {
                if (this.idLivreList == null)
                {

                    List<dynamic> ids = jDA.LoadJsonData("motcle_livre").FindAll(item => item.id_motcle == this.Id);
                    idLivreList = new();
                    ids.ForEach(item =>
                    {
                        idLivreList.Add((int)item.id_livre);
                    });
                }
                return this.idLivreList;
            }
        }

        [JsonIgnore]
        private List<Livre> livreList;
        public List<Livre> LivreList
        {
            get
            {
                if (this.livreList == null)
                {
                    this.livreList = Livre.jDA.GetAll(item => this.IdLivreList.Contains(item.Id));
                }
                return this.livreList;
            }
        }

        public List<Livre> AddLivre(Livre livre)
        {
            if (this.LivreList.Find(item => item.Id == livre.Id) == null)
            {
                this.IdLivreList.Add(livre.Id);
                this.LivreList.Add(livre);
                livre.AddMotCle(this);
                //TODO persist 
            }
            return this.LivreList;
        }

        public List<Livre> RemoveLivre(Livre livre)
        {
            int index = this.LivreList.FindIndex(item => item.Id == livre.Id);
            if (index >= 0)
            {
                this.IdLivreList.Remove(livre.Id);
                this.LivreList.RemoveAt(index);
                livre.RemoveMotCle(this);
                //TODO persist
            }
            return this.LivreList;
        }

    }
}
