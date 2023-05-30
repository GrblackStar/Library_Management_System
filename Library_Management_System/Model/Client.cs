using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Model
{
    public class Client : BaseModel
    {
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

    }
}
