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

    }
}
