using System;

namespace FarmSystem.Test1
{
    /*
     * Kleber de Paula Bueno
     * 31/03/2021
     * Change the current source code to make it as generic as possible.
     */
    public class Hen : Animal
    {
        //private string _id;
        private int _noOfLegs = 4;


        //public string Id
        //{
        //    get { return _id; }
        //    set
        //    {
        //        _id = value;
        //    }
        //}
        


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
            Console.WriteLine("Hen say CLUCKAAAAAWWWWK!");
        }

        public override void Run()
        {
            Console.WriteLine("Hen is running");
        }

        public override string ToString()
        {
            return "Hen";
        }
    }
}