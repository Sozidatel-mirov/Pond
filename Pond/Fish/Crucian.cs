using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pond
{
    internal class Crucian : Fish
    {
        public Crucian(float weight, int age, int maxAge, int daysWithoutFood, Diet diet)
            : base(weight, age, maxAge, daysWithoutFood, diet)
        {
        }
    }
}
