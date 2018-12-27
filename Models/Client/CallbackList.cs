using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FkjMgt_20181207.Models.Client
{
    public class CallbackList
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public string DataType { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-DD}")]
        public DateTime RecordDate { get; set; }
        public string MemoInfo { get; set; }
    }
}
