using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.Models.Client
{
    public class ClientListDataset
    {
        public IEnumerable<ClientListDetail> clientListDetails { get; set; }
        public IEnumerable<ClientListTotal> clientListTotals { get; set; }
    }
}
