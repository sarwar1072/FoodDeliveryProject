﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Entities
{
    public class Item : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int ItemTypeId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ItemType ItemType { get; set; }
    }
}
