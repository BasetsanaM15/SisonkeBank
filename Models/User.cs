using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisonkeBank.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string? Email { get; set; }

        public string? Password { get; set; }

        
        public decimal Balance { get; set; } = 0;
    }
}