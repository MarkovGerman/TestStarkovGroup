﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;


namespace Importer.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public int ParentID { get; set; }
        public int? ManagerID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
