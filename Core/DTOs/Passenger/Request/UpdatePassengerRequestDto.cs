using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Passenger.Request
{
    public class UpdatePassengerRequestDto : BaseRequestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
        public string DocumentNo { get; set; }
        public int DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
