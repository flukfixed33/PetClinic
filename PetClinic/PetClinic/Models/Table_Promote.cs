﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Table_Promote
    {
        public int Promote_ID { get; set; }
        [Display(Name ="ชื่อหัวข้อประชาสัมพันธ์")]

        public string Promote_Name { get; set; }
        [Display(Name = "รูปภาพประชาสัมพันธ์")]

        public string Promote_Pic { get; set; }
        [Display(Name = "รายละเอียดประชาสัมพันธ์")]
        [DataType(DataType.MultilineText)]

        public string Promote_Des { get; set; }
    }
}
