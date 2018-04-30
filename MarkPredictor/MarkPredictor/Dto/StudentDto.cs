using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Dto
{
    public class StudentDto
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public long CourseId { get; set; }
    }
}
