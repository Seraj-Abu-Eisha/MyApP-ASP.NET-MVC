// <copyright file="Item.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyApP.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Item : ItemBase
    {
        public override int Id { get; set; }

        public override string Name { get; set; } = null!;

        public override double Price { get; set; }

        public override int? SerialNumberId { get; set; }

        public override SerialNumber? serialNumber { get; set; }

        public override int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public override Category? category { get; set; }
    }
}