using System;

namespace FarmSystem.Test1
{
    /*
     * Kleber de Paula Bueno
     * 31/03/2021
     * Change the current source code to make it as generic as possible.
     */
    public class Sheep : Animal
    {
       
        private int _noOfLegs =4;



        public override int NoOfLegs
        {
            get
            {
                return _noOfLegs;
            }
            set
            {
                _noOfLegs = value;
            }
        }


        public override void Talk()
        {
            Console.WriteLine("Sheep says baa!");
        }
        
        public override void Run()
        {
            Console.WriteLine("Sheep is running");
        }

        public override string ToString()
        {
            return "Sheep";
        }
    }

}