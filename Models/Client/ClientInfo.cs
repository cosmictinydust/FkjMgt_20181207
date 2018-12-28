using System;
using System.ComponentModel.DataAnnotations;

namespace FkjMgt_20181207.Models.Client
{
    public class ClientInfo
    {
        [Key]
        public int ClientID { get; set; }
        public string LinkMan { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAdress { get; set; }
    }
}
