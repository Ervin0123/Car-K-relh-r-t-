using System;
using System.Collections.Generic;

#nullable disable

namespace Car_Backend.Models
{
    public partial class EladoAuto
    {
        public int EladoId { get; set; }
        public string EladoRendszam { get; set; }
        public int EladoAr { get; set; }
        public int EladoKilometer { get; set; }
        public int EladoEvjarat { get; set; }
        public string EladoKep { get; set; }
        public string EladoUzemanyag { get; set; }
        public int EladoTeljesitmeny { get; set; }
    }
}
