﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        [StringLength(500)]
        public string AboutContent1 { get; set; }
        [StringLength(500)]
        public string AboutContent2 { get; set; }
        [StringLength(150)]
        public string Image1 { get; set; }
        [StringLength(150)]
        public string Image2 { get; set; }


    }
}
