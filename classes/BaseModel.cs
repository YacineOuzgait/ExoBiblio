using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBiblio.classes
{
    internal class BaseModel<T> where T : BaseModel<T>
    { 
        int id = 0;
        public int Id { get => id; set { 
            if (this.id != value)
                {
                    this.id = value;
                }
            } 
        }

        

        private bool deleted = false;

        public bool Deleted { get => deleted; set { 
               if(this.deleted != value)
                {
                    this.deleted = value;
                }
        } }

        //public static DAL.

    }
}
