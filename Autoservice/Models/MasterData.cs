using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoservice.Models
{
    public class MasterData
    {
        public IEnumerable<Master> Masters { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }
}
