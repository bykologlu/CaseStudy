using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Passenger : IEntity
    {
        public string UniquePassengerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Gender { get; set; }
        public string DocumentNo { get; set; }
        public byte DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
