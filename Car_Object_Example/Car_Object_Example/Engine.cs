using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Object_Example
{
    internal class Engine
    {
        //Size (double) must be greater then or equal to 0.5
        //Horsepower (int) must be greater than 0
        //Cylinders (int) must be greater than or equal to 4 AND less than or equal to 10 AND
        // must be divisible by 2 OR can be 0

        //Private Member Fields
        private double _size;
        private int _horsepower;
        private int _cylinders;

        //Public Properties (Gets and Sets)
        public double Size
        {
            get { return _size; }
            private set
            {
                if(value >= 0.5)
                {
                    _size = value;
                }
                else
                {
                    throw new Exception("Invalid engine size");
                }
            }
        }

        public int HorsePower
        {
            get { return _horsepower; }
            private set
            {
                if (value >= 0)
                {
                    _horsepower = value;
                }
                else
                {
                    throw new Exception("Invalid engine horsepower");
                }
            }
        }

        public int Cylinders
        {
            get { return _cylinders; }
            private set
            {
                if (value >= 4 && value <= 10 && value % 2 == 0 || value == 0)
                {
                    _cylinders = value;
                }
                else
                {
                    throw new Exception("Invalid engine cylinders");
                }
            }
        }

        //Add greedy constructor
        public Engine(double size, int horsePower, int cylinders)
        {
            Size = size;
            HorsePower = horsePower;
            Cylinders = cylinders;
        }

        public override string ToString()
        {
            return $"{Cylinders} cylinder, {Size:0.0}L, {HorsePower} bph";
        }
    }
}
