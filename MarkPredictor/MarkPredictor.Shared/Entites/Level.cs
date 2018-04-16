using System;
using System.Collections.Generic;
using System.Text;

namespace MarkPredictor.Shared.Entites
{
    public class Level
    {
        public long Id { get; set; }

        public string LevelName { get; set; }

        public ICollection<Module> Modules { get; set; }
    }
}
