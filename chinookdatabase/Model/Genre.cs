﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BasicEntityFrameworkDataAccess.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}
