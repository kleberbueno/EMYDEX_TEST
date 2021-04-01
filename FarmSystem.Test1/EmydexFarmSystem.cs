using System;
using System.Collections.Generic;

namespace FarmSystem.Test1
{
    /*
     * Kleber de Paula Bueno
     * 31/03/2021
     * Change the current source code to make it as generic as possible.
     * Hold all animals entered by first time. So the animal queue is used for further activities
     * Added a validation to check if animal is milkable. So it can produce milk
     * Added a new event to be fired whenever Farm is empty
     */
    public class EmydexFarmSystem
    {
        private List<Animal> farmAnimalsList = new List<Animal>();
        public delegate void FarmEmptyEventHandler( EventArgs e);
        public event FarmEmptyEventHandler FarmEmpty;

        public List<Animal> FarmAnimalsList { get => farmAnimalsList; }

        public void Enter(Animal animal)
        {
          
            farmAnimalsList.Add(animal);
            AnimalEntered(animal);
        }


        private void AnimalEntered(Animal animal)
        {
            Console.WriteLine(animal.ToString() + " has entered the farm");
        }


        public void ShowFarmAnimals()
        {
            if (farmAnimalsList.Count == 0)
            {
                Console.WriteLine("There are no animals in the farm");
                return;
            }

            foreach (Animal animal in farmAnimalsList)
            {
                AnimalEntered(animal);
            }


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
            //in order to keep FIFO(First in First out) requirement, the animal should be release in order it entered the farm queue
            //so as it is not possible remove an item while it is iterating in a foreach loop, I had to make reverse order iteration of List and
            //remove from the Last item to the first one in Reversed order. So it kept original order(FIFO)
            farmAnimalsList.Reverse();
            for (int idx = farmAnimalsList.Count - 1; idx >= 0; idx--)
            {
                ReleaseAnimal(farmAnimalsList[idx]);
                farmAnimalsList.RemoveAt(idx);
            }
           
            if (farmAnimalsList.Count == 0)
                OnFarmEmpty(new EventArgs());
        }


        private void ReleaseAnimal(Animal animal)
        {
            Console.WriteLine(animal.ToString() + " has left the farm");
        }


        public void OnFarmEmpty(EventArgs e)
        {
            if (FarmEmpty != null)
                FarmEmpty( e);
        }



   
    }
}