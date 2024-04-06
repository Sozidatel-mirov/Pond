using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pond
{
    internal class Pond
    {
        public float maxBiomassFish { get; set; }
        public float nowBiomassFish { get; set; }
        public float quantityFish { get; set; }
        public float quantityCrucian { get; set; }
        public float quantityPike { get; set; }
        public float quantityPerch { get; set; }
        public float maxFoodBiomass { get; set; }
        public float nowFoodBiomass {  get; set; }
        public float foodGrowth { get; set; }
        public List<Crucian> crucians { get; set; } = new List<Crucian> { };
        public List<Pike> pikes { get; set; } = new List<Pike> { };
        public List<Perch> perches { get; set; } = new List<Perch> { };
        public List<Fish> fishes { get; set; } = new List<Fish> { };

        public Pond(float maxBiomassFish, float nowBiomassFish, float quantityFish, float quantityCrucian, float quantityPike, float quantityPerch, float maxFoodBiomass, float nowFoodBiomass, float foodGrowth)
        {
            this.maxBiomassFish = maxBiomassFish;
            this.nowBiomassFish = nowBiomassFish;
            this.quantityFish = quantityFish;
            this.quantityCrucian = quantityCrucian;
            this.quantityPike = quantityPike;
            this.quantityPerch = quantityPerch;
            this.maxFoodBiomass = maxFoodBiomass;
            this.nowFoodBiomass = nowFoodBiomass;
            this.foodGrowth = foodGrowth;
        }
        
        override
        public string ToString()
        {
            return $"Общая биомасса рыбы: {nowBiomassFish}\nОбщее количество рыбы: {quantityFish} " +
                $"\nКоличество карасей: {quantityCrucian} \nКоличество щук: {quantityPike} " +
                $"\nКоличество окуней: {quantityPerch} \nКоличество корма: {nowFoodBiomass}";
        }
    }
}
