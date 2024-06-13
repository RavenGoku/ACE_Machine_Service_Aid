using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceApp.Model
{
    public class MachineTaskBox
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int MachineId { get; set; }

        public string BoxTitle { get; set; }
    }
}