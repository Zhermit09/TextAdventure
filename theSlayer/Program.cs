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
            Console.SetCursorPosition((Console.BufferWidth - 22) / 2, 13);
            Console.WriteLine("Press 'Enter' to start");
            Console.ReadLine();
            Console.Clear();
            mainMeny();
        }

        public void mainMeny()
        {

            type("In the former age... when ancient behemoths still roamed the surface off the earth... before the time HEAVENS and HELL " +
                "got separated from our place of dwelling. In an era of LEGENDARY BEASTS’ warfare for the supreme as an existence, " +
                "whose battles were shacking the land beneath our feet!... Shattering the mountains turning them to dust. " +
                "Wherever those leviathans appeared, wastelands were erupting!... Leaving the ground without a single drop of " +
                "nourishment, unsuitable... for any... type of life to exist. Yet, the wicked thrived in those environments, " +
                "clashing with each other, feeding on themselves and thus grew stronger. Whilst...the feeble humans were not " +
                "even worth mentioning, they were insufficient... needy... and weak... . " +
                "They never had a chance against those at the apex of the world.\n\n" +

                "Until thee was born... a human yet, feared by the ugly beasts. Alone butchering untold amounts of its foes. " +
                "The folk acknowledged the strength of the champion and started worshipping thee, " +
                "naming their warrior 'The Slayer'!!! Hoping that the fighter will be their everlasting guardian. And yet... " +
                "their 'hero' had no concern for the people's safety, thou charged into battle with ever scorching rage, " +
                "again and again... growing stronger with each foe thee slew.\n\n" +

                "Thou was not immortal and had fallen in battle countless times, nonetheless, " +
                "slayer's soul never left our world. Angels and demons both fearing the slayer, " +
                "both not allowing the unrestrained soul to enter their realm... in horror...imagining the aftermath of " +
                "letting thou into their domain... . The slayer was cursed by the gods yet not wanted by the devil, "+
                "making him the ideal war machine... . The abominations at a loss... anxious..." +
                "fearing that they all will be devoured by the slayer, they banded together and by sacrificing their own " +
                "Sealed the slayer in the depths of the earth.\n" +
                "And there he remained...Or so they say... .\n");

            Console.Clear();

            string[] title = new string[] {
                "WMMMMMMMMMW   MA     AM    AMMMMMMMV        AMMMMMMMMV  ML          AMMMMMMA  WMMM     MMMW  AMMMMMMMV  AMMMMMMMA ",
                "Y  TMMMT  Y  MV       VM  AMMMMMMMV        MMMMMMMMMV   MML        AMMMMMMMMA  VMMM   MMNV  AMMMMMMMV   MMMMMMMMMA ",
                "    MMM      MA       AM  MMMV             MMV          MMM        MMMV  VMMM   VMMM MMMV   MMV         MMM    MMM ",
                "    MMM      MMA     AMM  MMMA             MMA          MMM        MMMA  AMMM    VMMMMMV    MMA         MMM    MMM ",
                "    MMM      MMMMMMMMMMM  MMMMMMMA         MMMMMMMMMA   MMM        MMMMMMMMMM     VMMMV     MMMMMMMA    MMMMMMMMMV ",
                "    MMM      MMMMMMMMMMM  MMMMMMMV          VMMMMMMMMA  MMM        MMMMMMMMMM      MMM      MMMMMMMV    MMMMMMMNV  ",
                "    MMM      MMV     VMM  MMMV                     VMMA MMM        MMMV  VMMM      MMM      MMA         MMMY VMA   ",
                "    MMM      MV       VM  MMMA             A       AMMV MMML       MMM    MMM      MMM      MMV         MMM   VMA  ",
                "    MMM      MA       AM  VMMMMMMMA        VMMMMMMMMMV  MMMMMMMMA  VMM    MMV      MMM      VMMMMMMMA   MMM    VMA ",
                "  AWMMMWA     MV     VM    VMMMMMMMA        VMMMMMMMV   UMMMMMMMMA  VW    WV     AWMMMWA     VMMMMMMMA  UWU     VMA"
        };
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (Console.BufferWidth < 120)
            {
                Console.BufferWidth = 120;
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition((Console.BufferWidth - 116) / 2, i + 4);
                Console.Write(title[i]);
            }
            Console.WriteLine("\n\n\n\n\n");
            Console.SetCursorPosition((Console.BufferWidth - 26) / 2, Console.CursorTop);
            flicker((Console.BufferWidth - 26) / 2);
            Console.Clear();


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
                    type(getRoom().getDesc() + "\n");
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
                    Console.Write("Press 'Enter' to continue                   " +
                        "                                                      ");
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