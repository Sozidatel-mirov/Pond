using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pond
{
    internal class Fish
    {
        float weight { get; set; }
        int age { get; set; }
        public int maxAge { get; set; }
        Diet diet { get; set; }
        int daysWithoutFood { get; set; }

        public Fish(float weight, int age, int maxAge, int daysWithoutFood, Diet diet)
        {
            this.weight = weight;
            this.age = age;
            this.maxAge = maxAge;
            this.daysWithoutFood = daysWithoutFood;
            this.diet = diet;
        }

        public void Eat(Pond pond)
        {
            Random randomfish = new Random();
            Random randomfishH = new Random();
            if (diet.isEatFish && diet.isEatFood) 
            {
                float firstWeight = weight;
                if(weight < firstWeight + diet.persentMassFood * 100)
                {

                    int randomNumberFish = randomfishH.Next(0, pond.fishes.Count - 1);
                    if (pond.fishes[randomNumberFish].weight < firstWeight * diet.persentMassPrey)
                    {
                        weight += pond.fishes[randomNumberFish].weight;
                        pond.fishes[randomNumberFish].Death(pond);
                    }

                    if (pond.nowFoodBiomass >= diet.persentMassFood * weight)
                    {
                        pond.nowFoodBiomass -= diet.persentMassFood * weight;
                        pond.nowBiomassFish += diet.persentMassFood * weight;
                        weight += diet.persentMassFood * weight;
                        
                    }
                    else if (pond.nowFoodBiomass > 0)
                    {
                        weight += pond.nowFoodBiomass;
                        pond.nowFoodBiomass = 0;
                    }
                }
            }
            else if(diet.isEatFish)
            {
                float firstWeight = weight;
                if (weight < firstWeight + diet.persentMassFood * 100)
                {
                    int randomNumberFish = randomfishH.Next(0, pond.fishes.Count - 1);
                    if (pond.fishes[randomNumberFish].weight < firstWeight * diet.persentMassPrey)
                    {
                        weight += pond.fishes[randomNumberFish].weight;
                        pond.fishes[randomNumberFish].Death(pond);
                    }
                }
            }
            else if(diet.isEatFood)
            {
                float firstWeight = weight;
                if (weight < firstWeight + diet.persentMassFood * 100)
                {
                    if (pond.nowFoodBiomass >= diet.persentMassFood * weight)
                    {
                        pond.nowFoodBiomass -= diet.persentMassFood * weight;
                        pond.nowBiomassFish += diet.persentMassFood * weight;
                        weight += diet.persentMassFood * weight;
                        
                    }
                    else if(pond.nowFoodBiomass > 0)
                    {
                        weight += pond.nowFoodBiomass;
                        pond.nowFoodBiomass = 0;
                    }
                }
            }
        }

        public void Death(Pond pond)
        {
            try
            {
                pond.crucians.Remove((Crucian)this);
            }
            catch { }
            try
            {
                pond.perches.Remove((Perch)this);
            }
            catch { }
            try
            {
                pond.pikes.Remove((Pike)this);
            }
            catch { }
        }
    }
}
