using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Models
{
    [Table("Devices")]
    public class AppSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public string Key { get; set; } 
        public string Value { get; set; } 
    }
}