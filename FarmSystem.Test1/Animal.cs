using System;


namespace FarmSystem.Test1
{
    /*
     * Kleber de Paula Bueno
     * 31/03/2021
     * Abstract Animal is lowest level class. Any other "sub type" of Animal will be derivated from this.
     */
    public abstract class Animal
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }

        }

        public abstract int NoOfLegs
        {
            get;
            set;
        }

        public abstract void Talk();



        public abstract void Run();

        public override abstract string ToString();

    }
}
