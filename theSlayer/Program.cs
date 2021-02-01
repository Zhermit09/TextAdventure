using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace theSlayer
{
    class Program
    {
        private Inventory inventory = new Inventory();
        private Player player = new Player();

        private Room darkRoom = new Room("Dark room", RoomType.DARK);
        private Room flintRoom = new Room("Flint room", RoomType.FLINT);
        private Room oilRoom = new Room("Oil room", RoomType.OIL);
        private Room fountain = new Room("Fountain", RoomType.FOUNTAIN);
        private Room stickRoom = new Room("Stick room", RoomType.STICK);
        private Room emptyRoom = new Room("Emty room", RoomType.EMPTY);
        private Room wall = new Room("It's a wall", RoomType.WALL);

        private Map map = new Map();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.start();
        }

        private void start()
        {
            Console.ForegroundColor = ConsoleColor.White;
            mainMeny();
        }

        public void mainMeny()
        {
            string[] title = new string[] {
                " MMMMMMMMM   MM       MM   MMMMMMMMM        MMMMMMMMMM  MM          MMMMMMMM   MMM     MMM   MMMMMMMMM  MMMMMMMMMM ",
                "MMMMMMMMMMM  MMM     MMM  MMMMMMMMM        MMMMMMMMMM   MMM        MMMMMMMMMM   MMM   MMN   MMMMMMMMM   MMMMMMMMMMM",
                "V   MMM   V  MMM     MMM  MMM              MMM          MMM        MMM    MMM    MMM MMM    MMM         MMM     MMM",
                "    MMM      MMM     MMM  MMM              MMM          MMM        MMM    MMM     MMMMM     MMM         MMM     MMM",
                "    MMM      MMMMMMMMMMM  MMMMMMMMM        MMMMMMMMMM   MMM        MMMMMMMMMM      MMM      MMMMMMMMM   MMMMMMMMMMM",
                "    MMM      MMMMMMMMMMM  MMMMMMMMM         MMMMMMMMMM  MMM        MMMMMMMMMM      MMM      MMMMMMMMM   MMMMMMMNMM ",
                "    MMM      MMMM   MMMM  MMM                      MMMM MMM        MMM    MMM      MMM      MMM         MMM  MMM   ",
                "    MMM      MMM     MMM  MMM                      MMMM MMM        MMM    MMM      MMM      MMM         MMM   MMM  ",
                "    MMM      MMM     MMM  MMMMMMMMM        MMMMMMMMMMM  MMMMMMMMM  MMM    MMM      MMM      MMMMMMMMM   MMM    MMN ",
                "     M       MM       MM   MMMMMMMMM        MMMMMMMMM   MMMMMMMMMM  MM    MM        M        MMMMMMMMM  MMM     MMM"
        };

            if (Console.BufferWidth < 120)
            {
                Console.BufferWidth = 120;
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition((Console.BufferWidth - 116) / 2, i + 1);
                Console.Write(title[i]);
            }
            Console.WriteLine("\n\n\n\n\n");
            Console.SetCursorPosition((Console.BufferWidth - 26) / 2, Console.CursorTop);
            flicker((Console.BufferWidth - 26) / 2);
            Console.Clear();

            Console.WriteLine("INSERT STROY HERE");
            choiceList();
        }

        public void choiceList()
        {
            Console.Clear();
            Console.Write(
                "Decisions:\n" +
                " 1. Actions \n" +
                " 2. Move\n" +
                "\nYour choice: ");
            string choice = Console.ReadLine().ToLower();
            Console.Clear();

            switch (choice)
            {
                case "1":
                case "a":
                case "actions":
                    if (inventory.hasTorch() && getRoom().getType() == RoomType.FOUNTAIN && !inventory.canLeave())
                    { burnTheRope(); }

                    else if (inventory.canLeave() && getRoom().getType() == RoomType.FLINT)
                    { door(); }

                    else
                    {
                        Console.WriteLine(
                            "There is nothing you can do as of right now" +
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
                case "/map":
                    cheat();
                    break;

                default:
                    unknownCommand();
                    choiceList();
                    break;
            }
        }

        public void burnTheRope()
        {
            inventory.openExit();
            Console.WriteLine(
                "Look up and burn the rope" +
                "\nPress 'Enter' to continue");
            Console.ReadLine();
        }

        public void door()
        {
            Console.Write(
                "Are you willing to leave?" +
                "(Yes/No)" +
                "\n\nAnswer: ");
            string answer = Console.ReadLine().ToLower();
            Console.Clear();

            switch (answer)
            {
                case "yes":
                case "ye":
                case "y":
                    leave();
                    break;

                case "no":
                case "n":
                case "nah":
                    choiceList();
                    break;

                default:
                    unknownCommand();
                    door();
                    break;
            }
        }

        public void walkWhere()
        {
            Console.Write(
                "Walk: \n" +
            " 1. Forwrads\n" +
            " 2. Left\n" +
            " 3. Right\n" +
            " 4. Backwards\n\n" +
            "Walk where: ");
            string yourChoice = Console.ReadLine().ToLower();
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
                    player.setY(player.move(player.y(), -1, map.getMapY() - 1, map.getSymbol(player.y() - 1, player.x())));
                    type(getRoom().getDesc()+"\n");
                    break;

                case "2":
                case "l":
                case "left":
                    player.setX(player.move(player.x(), -1, map.getMapX() - 1, map.getSymbol(player.y(), player.x() - 1)));
                    Console.WriteLine(getRoom().getDesc());
                    break;

                case "3":
                case "r":
                case "right":
                    player.setX(player.move(player.x(), 1, map.getMapX() - 1, map.getSymbol(player.y(), player.x() + 1)));
                    Console.WriteLine(getRoom().getDesc());
                    break;

                case "4":
                case "b":
                case "backwards":
                    player.setY(player.move(player.y(), 1, map.getMapY() - 1, map.getSymbol(player.y() + 1, player.x())));
                    Console.WriteLine(getRoom().getDesc());
                    break;

                default:
                    unknownCommand();
                    walkWhere();
                    break;
            }
            itemCollect();
        }

        public void itemCollect()
        {
            switch (getRoom().getType())
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

                default:
                    Console.WriteLine("Other room");
                    break;
            }

            //Move to craft option
            if (inventory.hasOil() && inventory.hasFlint() && inventory.hasStick())
            {
                inventory.craftTourch();
                Console.WriteLine("crafted tourch " + inventory.hasTorch());
            }
            else
            { Console.WriteLine("nothing to craft"); }

            //Mark
            Console.ReadLine();
            choiceList();
        }

        public void leave()
        {
            DateTime now = DateTime.Now;
            int second = now.Second;
            int pastSecond = second;
            int timer = 6;
            string message = "Application closing in: ";
            int lenght = message.Length;

            Console.WriteLine("\nYou have succesfully escaped the chamber..." +
                "\nFor now...." +
                "\n\nPress 'Enter' to exit the application");
            Console.ReadLine();

            Console.Write(message);
            while (timer >= 0)
            {
                now = DateTime.Now;
                second = now.Second;
                if (second > pastSecond)
                {
                    timer--;
                    Console.Write(timer + " ");
                    Console.SetCursorPosition(lenght, Console.CursorTop);
                }
                pastSecond = second;
            }
            Environment.Exit(0);
        }

        //different Methods
        public Room getRoom()
        {
            Room room = null;
            switch (map.getSymbol(player.y(), player.x()))
            {
                case "#":
                    room = darkRoom;
                    break;

                case "¤":
                    room = flintRoom;
                    break;

                case "&":
                    room = oilRoom;
                    break;

                case "§":
                    room = fountain;
                    break;

                case "/":
                    room = stickRoom;
                    break;

                case "-":
                    room = emptyRoom;
                    break;
                case "@":
                    room = wall;
                    break;

                default:
                    Console.WriteLine("Can't identify the room");
                    Console.ReadLine();
                    break;
            }
            return room;
        }
        public void cheat()
        {
            Console.WriteLine("Cheating are we~?");
            for (int y = 0; y < map.getMapY(); y++)
            {
                for (int x = 0; x < map.getMapX(); x++)
                {
                    if (map.getSymbol(y, x) != "@")
                    {
                        map.cheatMap(x, y, player.x(), player.y());

                    }
                }
            }
            Console.WriteLine("\n");
            Console.ReadLine();
        }

        public void unknownCommand()
        {
            Console.WriteLine("Unknown command" +
                "\nPress 'Enter' to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public void type(string text)
        {
            Console.WriteLine("Press 'Space' to skip\n");
            for (int i = 0; i < text.Length; i++)
            {
                if (Console.KeyAvailable == false || Console.ReadKey().Key != ConsoleKey.Spacebar)
                {
                    Thread.Sleep(80);
                }
                else
                {
                    break;
                }
                Console.Write(text[i]);
            }
            Console.Clear();
            Console.WriteLine("Press 'Space' to skip\n");
            Console.WriteLine(text);
            flicker(0);
        }

        public void flicker(int x)
        {

            int top = Console.CursorTop;
            int color = 0;

            while (true)
            {
                if (Console.KeyAvailable == false)
                {
                    if (color == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        color++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        color = 0;
                    }
                    Console.Write("Press 'Enter' to continue                   ");
                    Console.SetCursorPosition(x, top);
                    Thread.Sleep(800);
                }
                else if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

            }
        }
    }
}