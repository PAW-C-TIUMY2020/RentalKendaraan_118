using System;
using System.Collections.Generic;

namespace RentalKendaraan_NIM.Models
{
    public partial class JenisKendaraan
    {
        public int IdJenisKendaraan { get; set; }
        public string NamaJenisKendaraan { get; set; }

        public Kendaraan Kendaraan { get; set; }
    }
}
