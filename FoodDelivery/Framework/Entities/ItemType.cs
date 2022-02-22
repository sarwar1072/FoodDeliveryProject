using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Entities
{
    public class ItemType : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
