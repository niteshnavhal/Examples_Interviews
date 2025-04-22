using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaples
{
    internal class AbstractExample
    {
        abstract class Animal
        {
            public abstract void makeSund();
        }

        class Dog : Animal
        {
            public override void makeSund()
            {
                Console.WriteLine("Dog barks");
            }

        }

        class Cat : Animal
        {
            public override void makeSund()
            {
                Console.WriteLine("Cat meows");
            }
        }
        public void Run()
        { 
            Animal dog = new Dog();
            dog.makeSund();

            Animal cat = new Cat();
            cat.makeSund();
        }
    }
}
