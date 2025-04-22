using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exaples.EventExample;

namespace Exaples
{
    public delegate void DoorBellhanderlar(string username);
    public class DoorBell
    {
        public event DoorBellhanderlar Doorbell;
        public void PressDoorBell(string visitorName)
        {

            Console.WriteLine($"{visitorName} pressed the doorbell!");

            Doorbell.Invoke(visitorName);
        }

    }

    public class HomeOwner
    {
        public void OpenDoor(string username)
        {
            Console.WriteLine($"HomeOwner Opens a Door to {username}");
        }
    }

    public class DoorBellExample
    {
        public void Run()
        {

            var homeOwner = new HomeOwner();

            Console.Write("Enter visitor name: ");
            string visitorName = Console.ReadLine();
            var doorBell = new DoorBell();
            doorBell.Doorbell += homeOwner.OpenDoor;
            // Press the doorbell
            doorBell.PressDoorBell(visitorName);

        }
    }

}
