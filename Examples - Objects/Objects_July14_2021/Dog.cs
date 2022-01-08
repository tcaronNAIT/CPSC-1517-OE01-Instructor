namespace Objects_July14_2021
{
    class Dog
    {
        private int Age = 0;
        private string Name = "DOG";
        private string Colour = "Black";

        private static bool GoodDog = true;

        public Dog(string name, int age, string colour)
        {
            Age = age;
            Name = name;
            Colour = colour;
        }

        public Dog()
        {

        }

        public Dog(string name)
        {
            Name = name;
        }

        public int GetAge()
        {
            return this.Age;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetColour()
        {
            return this.Colour;
        }

        public void SetAge(int age)
        {
            this.Age = age;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetColour(string colour)
        {
            this.Colour = colour;
        }

        public void TakeWalk()
        {

        }

        public string Bark()
        {
            return "woof";
        }

        public void TailWag()
        {

        }
    }
}
