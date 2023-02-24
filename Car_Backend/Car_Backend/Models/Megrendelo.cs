using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Car_Backend.Models
{
    public partial class Megrendelo
    {
        public int MegrendId { get; set; }
        public string MegrendNev { get; set; }
        public string MegrendEmail { get; set; }
        public int MegrendTel { get; set; }
        public string MegrendRendszam { get; set; }
        public int SzolgId { get; set; }
        public string MegrendMegjegyzes { get; set; }
        public DateTime? MegrendIdopont { get; set; }

        [JsonIgnore]
        public virtual Szolgaltata Szolg { get; set; }
    }
}
