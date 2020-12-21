using System.Collections.Generic;

namespace EnglishMonarchs.Models
{
    public class Monarchs
    {
        private IList<Monarch> _monarchs { get; set; }

        public Monarchs(IList<Monarch> monarchs)
        {
            _monarchs = monarchs;
        }

        public int Count()
        {
            return _monarchs.Count;
        }

        public Monarch GetMonarch(int index)
        {
            return _monarchs[index];
        }

    }
}
