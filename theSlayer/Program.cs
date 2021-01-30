using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theSlayer
{
    class Program
    {

        private Inventory inventory = new Inventory();
        private Player player = new Player();
        private Room[,] rooms = new Room[,]
    {
                    {new Room("NW", "Dark room", RoomType.DARK),new Room("N", "Flint room", RoomType.FLINT),new Room("NE", "Dark room", RoomType.DARK)},
                    {new Room("W", "Oil room", RoomType.OIL), new Room("C", "Fountain", RoomType.FOUNTAIN),new Room("E", "Stick room", RoomType.STICK) },
                    {new Room("SW", "Dark room", RoomType.DARK),new Room("S", "Emty room", RoomType.EMPTY),new Room("SE", "Dark room", RoomType.DARK)}
    };

        static void Main(string[] args)
        {
            Program program = new Program();
            program.start();
        }

        private void start()
        {
            Console.ForegroundColor = ConsoleColor.White;
            mainMeny();
            Console.ReadLine();
        }

        public void mainMeny()
        {
            Console.WriteLine("The Slayer");
            Console.WriteLine("Press 'Enter' to begin");
            Console.ReadLine();
            Console.Clear();
            choiceList();
        }

        public void choiceList()
        {
            string[] listC = new string[]
        {
        "Decisions:\n",
        "1. Actions \n",
        "2. Move\n",
        "\nYour choice: " };
            //do i need it?
            Console.Clear();
            Console.Write(listC[0] + listC[1] + listC[2] + listC[3]);
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "1":
                case "a":
                case "actions":
                    Console.Clear();
                    //Mark (fix this hell)
                    Room room = rooms[player.y(), player.x()];
                    if (inventory.hasTorch() && room.getID() == "C" && !inventory.canLeave())
                    {
                        Console.WriteLine("Look up and burn the rope" +
                            "\nPress 'Enter' to continue");
                        inventory.openExit();
                        Console.ReadLine();
                    }
                    else if (inventory.canLeave()&& room.getID() == "N")
                    {
                        Console.Clear();
                        Console.Write("Are you willing to leave?"+
                            "\nYES or NO?"+
                            "\nAnswer: ");
                        string answer = Console.ReadLine().ToLower();
                        switch (answer)
                        {
                            case "yes":
                            case "ye":
                            case "y":
                                escaped();
                                break;
                            case "no":
                            case "n":
                            case "nah":
                                choiceList();
                                break;
                                //make a method of this default
                            default:
                                Console.WriteLine("Unknown comand");
                                Console.WriteLine("Press 'Enter' to continue");
                                Console.ReadLine();
                                Console.Clear();
                                choiceList();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nothing as of right now" +
                        "\nPress 'Enter' to continue");
                        Console.ReadLine();
                    }
                    choiceList();
                    break;

                case "2":
                case "m":
                case "move":
                    walkWhere();
                    break;
                default:
                    Console.WriteLine("Unknown comand");
                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadLine();
                    Console.Clear();
                    choiceList();
                    break;
            }
        }

        public void walkWhere()
        {

            string yourChoice;
            string[] walk = new string[]
            { "Walk: \n"+
            "1. Forwrads\n"+
            "2. Left\n"+
            "3. Right\n"+
            "4. Backwards\n\n"+
            "Your choice: " };
            Console.Clear();

            Console.WriteLine("X: " + player.x() + "Y: " + player.y() + "\n\n");
            Console.WriteLine("crafted tourch " + inventory.hasTorch() + "\n");
            Console.Write(walk[0]);

            yourChoice = Console.ReadLine().ToLower();
            Console.Clear();
            movementSwitch(yourChoice);
        }
        public void movementSwitch(string choice)
        {

            switch (choice)
            {
                case "1":
                case "f":
                case "forwrads":
                    player.setY(player.move(player.y(), -1));
                    break;
                case "2":
                case "l":
                case "left":
                    player.setX(player.move(player.x(), -1));
                    break;
                case "3":
                case "r":
                case "right":
                    player.setX(player.move(player.x(), 1));
                    break;
                case "4":
                case "b":
                case "backwards":
                    player.setY(player.move(player.y(), 1));
                    break;
                default:
                    Console.WriteLine("Unknown comand");
                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadLine();
                    Console.Clear();
                    walkWhere();
                    break;
            }

            roomIdentification();
        }
        public void roomIdentification()
        {
            Room room = rooms[player.y(), player.x()];
            itemCollect(room);
            string Desc = rooms[player.y(), player.x()].getDesc();
            Console.WriteLine("Room: " + room.getID() + " " + Desc);
            choiceList();
        }
        public class Room
        {
            private string id;
            private RoomType type;
            private string description;

            public Room(string id, string description, RoomType type)
            {
                this.id = id;
                this.description = description;
                this.type = type;
            }
            public string getID()
            {
                return id;
            }
            public string getDesc()
            {
                return description;
            }

            public RoomType getType()
            {
                return type;
            }
        }

        public enum RoomType
        {
            FLINT, EMPTY, STICK, OIL, DARK, FOUNTAIN
        }

        private class Player
        {
            private int currentPossionX = 1;
            private int currentPossionY = 2;


            public int x()
            {
                return currentPossionX;
            }

            public void setX(int x)
            {
                this.currentPossionX = x;
            }

            public int y()
            {
                return currentPossionY;
            }

            public void setY(int y)
            {
                this.currentPossionY = y;
            }
            public int move(int cord, int move)
            {
                cord += move;
                if (cord > 2 || cord < 0)
                {
                    cord -= move;
                    Console.WriteLine("\nThat is a wall" +
                        "\nPress 'Enter' to continue");
                    Console.ReadLine();
                }
                return cord;
            }
        }
        private class Inventory
        {
            private bool oil = false;
            private bool flint = false;
            private bool stick = false;
            private bool torch = true;
            private bool exitKey = false;


            public void collectOil()
            {
                oil = true;
            }
            public void collectFlint()
            {
                flint = true;
            }
            public void collectStick()
            {
                stick = true;
            }
            public void craftTourch()
            {
                torch = true;
            }
            public void openExit()
            {
                exitKey = true;
            }


            public bool hasOil()
            {
                return oil;
            }
            public bool hasFlint()
            {
                return flint;
            }
            public bool hasStick()
            {
                return stick;
            }
            public bool hasTorch()
            {
                return torch;
            }
            public bool canLeave()
            {
                return exitKey;
            }
        }

        public void itemCollect(Room room)
        {

            switch (room.getType())
            {
                case RoomType.OIL:
                    Console.WriteLine("oil");
                    inventory.collectOil();
                    break;
                case RoomType.FLINT:
                    Console.WriteLine("flint");
                    inventory.collectFlint();
                    break;
                case RoomType.STICK:
                    Console.WriteLine("stick");
                    inventory.collectStick();
                    break;
                case RoomType.FOUNTAIN:
                    Console.WriteLine("Fountain");
                    break;
                default:
                    Console.WriteLine("Other room");
                    break;
            }


            Console.WriteLine(inventory.hasOil() + " " + inventory.hasFlint() + " " + inventory.hasStick());


            if (inventory.hasOil() && inventory.hasFlint() && inventory.hasStick())
            {
                inventory.craftTourch();
                Console.WriteLine("crafted tourch " + inventory.hasTorch());
            }
            else
            {
                Console.WriteLine("nothing to craft");
            }
            Console.ReadLine();
        }
        public void escaped()
        {
            DateTime now = DateTime.Now;
            int second = now.Second;
            int pastSecond = second;
            int minute = now.Minute;
            int timer = 6;
            string message = "Application closing in: ";
            int lenght = message.Length;

            Console.Clear();
            Console.WriteLine("You have succesfully escaped the chamber...For now...." +
             "\n\nPress 'Enter' to close down the application");
            Console.ReadLine();
            Console.Clear();
            Console.Write(message);
            while (timer >= 0)
            {
                now = DateTime.Now;
                second = now.Second;
                if (second > pastSecond)
                {
                    timer--;
                    Console.Write(timer + " ");
                    Console.SetCursorPosition(lenght,Console.CursorTop);
                }
                pastSecond = second;
            }
            Environment.Exit(0);
        }
    }
}