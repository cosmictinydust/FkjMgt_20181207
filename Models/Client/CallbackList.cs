using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.Models.Client
{
    public class CallbackList
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public string DataType { get; set; }
        public DateTime RecordDate { get; set; }
        public string MemoInfo { get; set; }
    }
}
