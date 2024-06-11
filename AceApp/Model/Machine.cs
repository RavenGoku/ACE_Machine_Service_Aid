using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceApp.Model
{
    public class Machine
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string MachineName { get; set; }
        public string Password { get; set; }
    }
}