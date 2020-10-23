using System;
using System.Collections.Generic;

namespace RentalKendaraan_NIM.Models
{
    public partial class Gender
    {
        public int IdGender { get; set; }
        public string NamaGender { get; set; }

        public Customer IdGenderNavigation { get; set; }
    }
}
