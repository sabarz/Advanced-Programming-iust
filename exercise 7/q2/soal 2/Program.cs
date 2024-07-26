using System;

namespace soal_2
{
    interface IPersonality
    {
        public string NAME { get; set; }
        public int SCORE { get; set; }
        public string Personality();
    }
    class Bear : IPersonality
    {
        public Bear(string name, int i)
        {
            NAME = name;
            SCORE = i;
        }
        public string NAME { get; set; }
        public int SCORE { get; set; }
        public string Personality()
        {
            return NAME +" is Yellow Bear. He Loves Honey." + NAME + "'s rate is " + SCORE;
        }
    }

    class Donkey : IPersonality
    {
        public Donkey(string name, int i)
        {
            NAME = name;
            SCORE = i;
        }
        public string NAME { get; set; }
        public int SCORE { get; set; }
        public string Personality()
        {
            return NAME +" is a tired Donkey. He Always Grunts." + NAME + "'s rate is " + SCORE;
        }
    }

    class Tiger : IPersonality
    {
        public Tiger(string name, int i)
        {
            NAME = name;
            SCORE = i;
        }
        public string NAME { get; set; }
        public int SCORE { get; set; }
        public string Personality()
        {
            return NAME +" is a tiger.He is Smiling." + NAME + "'s rate is " + SCORE;
        }
    }

    class Pig : IPersonality
    {
        public Pig(string name, int i)
        {
            NAME = name;
            SCORE = i;
        }
        public string NAME { get; set; }
        public int SCORE { get; set; }
        public string Personality()
        {
            return NAME +" is a pig. He is cowarsd." + NAME + "'s rate is " + SCORE;
        }
    }

    class Kangaroo : IPersonality
    { 
        public Kangaroo(string name, int i)
        {
            NAME = name;
            SCORE = i;
        }
        public string NAME { get; set; }
        public int SCORE { get; set; }
        public string Personality()
        {
            return NAME +" is a Baby Kangaroo. He is triger's friend." + NAME + "'s rate is " + SCORE;
        }
    }

    class Friend<T> where T : IPersonality
    {
        T Animal;
        public Friend(T animal)
        {
            this.Animal = animal;
        }

        public static implicit operator Friend<T>(T animal)
        {
            return new Friend<T>(animal);
        }
        public string Personality()
        {
            return Animal.Personality();
        }
    }
    class Program
    {
        static void Main()
        {
            Friend<Bear> bear = new Bear("Pooh", 5);
            Friend<Tiger> tiger = new Tiger("Tiger", 3);
            Friend<Donkey> donkey = new Donkey("Eeyore", 1);
            Friend<Pig> pig = new Pig("piglet", 4);
            Friend<Kangaroo> kangaroo = new Kangaroo("Roo", 2);

            Console.WriteLine(bear.Personality());
            Console.WriteLine(tiger.Personality());
            Console.WriteLine(donkey.Personality());
            Console.WriteLine(pig.Personality());
            Console.WriteLine(kangaroo.Personality());
        }
    }
}

