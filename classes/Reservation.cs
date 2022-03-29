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
    }
}
