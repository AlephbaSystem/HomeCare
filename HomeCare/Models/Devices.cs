using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Models
{
    [Table("Devices")]
    public class Devices
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public string Name { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [NotNull]
        public bool Selected { get; set; } = false;
        public Devices()
        {
        }
    }
}