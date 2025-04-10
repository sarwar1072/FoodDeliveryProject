﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Entities
{
    public class Cart : IEntity<Guid>
    {
        public Cart()
        {
            Items = new List<CartItem>();
            CreatedDate = DateTime.Now;
            IsActive = true;
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<CartItem> Items { get; private set; }

        public bool IsActive { get; set; }
    }
}
