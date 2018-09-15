using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleLib
{
    public class Pipeline
    {
        public string Do(List<string> files)
        {
            var result = files.Where(f => !f.StartsWith("."))
                .OrderBy(f => f)
                .ToList()
                .middle()
                .plural('s')
                .ToUpper()
                .puts();

            
            return result;

        }
    }
}

