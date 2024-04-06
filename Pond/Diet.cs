using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pond
{
    public class Diet
    {
        public bool isEatFood {  get; set; }
        public bool isEatFish {  get; set; }
        public float persentMassPrey { get; set; }
        public float persentMassFood { get; set; }

        public Diet (bool isEatFood, bool isEatFish, float persentMassPrey, float persentMassFood)
        {
            this.isEatFood = isEatFood;
            this.isEatFish = isEatFish;
            this.persentMassPrey = persentMassPrey;
            this.persentMassFood = persentMassFood;
        }
    }
}
