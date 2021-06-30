﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
     public class FavoriteList
    {
        [Key]           
        public int Id { get; set; }

        public int Count { get; set; }
        
        //relations
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUserChange IdentityUserChange { get; set; }

        
    }
}