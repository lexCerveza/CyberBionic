using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001Task3Relatives
{
    class Relative
    {
        public string Name { get; private set; }
        public int BirthDate { get; private set; }
        public MyCollection<Relative> Relatives { get; private set; }

        public Relative(string name, int birthDate, MyCollection<Relative> relatives)
        {
            Name = name;
            BirthDate = birthDate;
            Relatives = relatives;
        }

        public override string ToString()
        {
            return Name + " , " + BirthDate;
        }
    }
}
