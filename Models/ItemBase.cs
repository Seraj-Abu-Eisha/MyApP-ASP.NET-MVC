// <copyright file="Item.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyApP.Models
{
    public abstract class ItemBase
    {
        public abstract Category? category { get; set; }
        public abstract int CategoryId { get; set; }
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract double Price { get; set; }
        public abstract SerialNumber? serialNumber { get; set; }
        public abstract int? SerialNumberId { get; set; }
    }
}