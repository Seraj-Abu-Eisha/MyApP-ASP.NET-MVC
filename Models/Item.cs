﻿namespace MyApP.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int? SerialNumberId { get; set; }
        public SerialNumber? serialNumber { get; set; }

    }
}