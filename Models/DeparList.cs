using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.Models
{
    public class DeparList
    {
        public int Id { get; set; }
        public string DeparName { get; set; }
        public int DispOrder { get; set; }
        public int Id_xf { get; set; }
    }
}
