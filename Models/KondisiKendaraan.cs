using System;
using System.Collections.Generic;

namespace RentalKendaraan_NIM.Models
{
    public partial class KondisiKendaraan
    {
        public int IdKondisi { get; set; }
        public string NamaKondisi { get; set; }

        public Pengembalian IdKondisiNavigation { get; set; }
    }
}
