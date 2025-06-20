﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HouseBrokerMVP.Core.Model;

namespace HouseBrokerMVP.Core.Entities
{
    public class PropertyType : DateTimeModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
