using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishMonarchs.Models
{
    public class Monarchs
    {
        private IList<Monarch> _monarchs { get; set; }

        public Monarchs(IList<Monarch> monarchs)
        {
            _monarchs = monarchs;
        }


    }
}
