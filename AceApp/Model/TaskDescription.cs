using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AceApp.Model
{
    public class TaskDescription
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int TaskId { get; set; }

        public Image TaskImage { get; set; }
        public string Description { get; set; }
    }
}