using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entities
{
    [Table("Task")]
    public class Task
    {
        [Key]
        //[Required]
        public int TaskID { get; set; }
        [StringLength(20)]
        public string ParentID { get; set; }
        [StringLength(20)]
       // [Required]
        public string TaskName { get; set; }
        public int Priority { get; set; }

        public DateTime ?  SDate { get; set; }

        public DateTime ? EDate { get; set; }

        public bool IsTaskEnded { get; set; }

    }
}
