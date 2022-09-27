using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class KqzResultsByCity
    {
        public List<KqzLastYear>? LastYear { get; set; }
        public Dictionary<string, int> ThisYear { get; set; }
    }
}
