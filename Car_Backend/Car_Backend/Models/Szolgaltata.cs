using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Car_Backend.Models
{
    public partial class Szolgaltata
    {
        public Szolgaltata()
        {
            Megrendelos = new HashSet<Megrendelo>();
        }

        public int SzolgId { get; set; }
        public string SzolgNev { get; set; }
        public string SzolgIdotartam { get; set; }
        public int SzolgAr { get; set; }

        [JsonIgnore]
        public virtual ICollection<Megrendelo> Megrendelos { get; set; }
    }
}
