using System;
using System.Collections.Generic;

namespace FarmSystem.Test1
{
    /*
     * Kleber de Paula Bueno
     * 31/03/2021
     * Change the current source code to make it as generic as possible.
     */
    public class EmydexFarmSystem
    {
        private List<Animal> farmAnimalsList = new List<Animal>();
        public delegate void FarmEmptyEventHandler(object source, EventArgs e,string message);
        public event FarmEmptyEventHandler FarmEmpty;

        public List<Animal> FarmAnimalsList { get => farmAnimalsList; }

        public void Enter(Animal animal)
        {
            //TODO Modify the code so that we can display the type of animal (cow, sheep etc) 
            //Hold all the animals so it is available for future activities
            Console.WriteLine(animal.ToString() + " has entered the Emydex farm");
            farmAnimalsList.Add(animal);
        }

        //TEST 2
        public void MakeNoise()
        {
            if (farmAnimalsList.Count == 0)
            {
                Console.WriteLine("There are no animals in the farm");
                return;
            }

            foreach (Animal animal in farmAnimalsList)
            {
                animal.Talk();
            }
 
            
        }

        //TEST 3
        public void MilkAnimals()
        {
            if (farmAnimalsList.Count == 0)
            {
                Console.WriteLine("There are no animals in the farm");
                return;
            }

            foreach (Animal animal in farmAnimalsList)
            {
                if (animal is Test2.IMilkableAnimal)
                {
                    ((Test2.IMilkableAnimal)animal).ProduceMilk();
                }
            }
        }

        //TEST 4
        public void ReleaseAllAnimals()
        {
            foreach (Animal animal in farmAnimalsList)
            {
                ReleaseAnimal(animal);
            }
            farmAnimalsList.Clear();
            if (farmAnimalsList.Count == 0)
                OnFarmEmpty(new EventArgs(), "Emydex Farm is now empty");
        }


        private void ReleaseAnimal(Animal animal)
        {
            Console.WriteLine(animal.ToString() + " has left the Emydex farm");
        }


        public void OnFarmEmpty(EventArgs e,string message)
        {
            if (FarmEmpty != null)
                FarmEmpty(this, e,message);
        }

    }
}