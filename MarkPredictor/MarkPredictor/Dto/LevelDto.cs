using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPredictor.Dto
{
    public class LevelDto
    {
        public long Id { get; set; }

        public string LevelName { get; set; }

        public double Average { get; set; }

        public IList<ModuleDto> Modules { get; set; }

        public static implicit operator Task(LevelDto v)
        {
            throw new NotImplementedException();
        }
    }
}
