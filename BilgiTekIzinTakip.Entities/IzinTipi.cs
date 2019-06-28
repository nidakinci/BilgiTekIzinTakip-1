﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiTekIzinTakip.Entities
{  
    [Table("IzinTipi")]
    public class IzinTipi:MyEntityBase
    {

        [DisplayName("İzin Türü"), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string IzinTuru { get; set; }

        public virtual Izinler Izinler  { get; set; }



    }
}