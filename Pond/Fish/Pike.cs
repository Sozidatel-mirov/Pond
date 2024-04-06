using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pond
{
    internal class Pike : Fish
    {
        private int id
        {
            get { return id; }
            set { id = value; }
        }
        public Pike(float weight, int age, int maxAge, int daysWithoutFood, Diet diet)
            : base(weight, age, maxAge, daysWithoutFood, diet)
        {
        }
    }
}
