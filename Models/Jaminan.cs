using System;
using System.Collections.Generic;

namespace RentalKendaraan_NIM.Models
{
    public partial class Jaminan
    {
        public int IdJaminan { get; set; }
        public string NamaJaminan { get; set; }

        public Peminjaman Peminjaman { get; set; }
    }
}
