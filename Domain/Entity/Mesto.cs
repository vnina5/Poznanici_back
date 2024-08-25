﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Mesto : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int PttBroj { get; set; }

        public string Naziv { get; set; }

        public int? BrojStanovnika { get; set; }


        public Mesto(int pttBroj, string naziv, int? brojStanovnika = null)
        {
            PttBroj = pttBroj;
            Naziv = naziv;
            BrojStanovnika = brojStanovnika;
        }
    }
}
