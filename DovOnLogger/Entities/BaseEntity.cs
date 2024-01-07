using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovOnLogger.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string LogLevel { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
