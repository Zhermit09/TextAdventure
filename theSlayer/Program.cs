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

        private Room trapRoom = new Room("Trap room", RoomType.TRAP);
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
            Thread.Sleep(500);
            mainMeny();
        }

        public void mainMeny()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            type("In the former age... when ancient behemoths still roamed the surface off the earth... before the time HEAVENS and HELL " +
                "got separated from our place of dwelling. In an era of LEGENDARY BEASTS’ warfare for the supreme as an existence, " +
                "whose battles were shacking the land beneath our feet... Shattering the mountains turning them to dust. " +
                "Wherever those leviathans appeared, wastelands were erupting... Leaving the ground without a single drop of " +
                "nourishment, unsuitable... for any... type of life to exist. Yet, the wicked thrived in those environments, " +
                "clashing with each other, feeding on themselves and thus grew stronger. Whilst...the feeble humans were not " +
                "even worth mentioning, they were insufficient... needy... and weak... . " +
                "They never had a chance against those at the apex of the world.\n\n" +

                "Until thee was born... a human yet, feared by the ugly beasts. Alone butchering untold amounts of its foes. " +
                "The folk acknowledged the strength of the champion and started worshipping thee, " +
                "naming their warrior 'THE SLAYER' Hoping that the fighter will be their everlasting guardian. And yet... " +
                "their 'hero' had no concern for the people's safety, thou charged into battle with ever scorching rage, " +
                "again and again... growing stronger with each foe thee slew.\n\n" +

                "Thou was not immortal and had fallen in battle countless times, nonetheless, " +
                "slayer's soul never left our world. Angels and demons both fearing the slayer, " +
                "both not allowing the unrestrained soul to enter their realm... in horror...imagining the aftermath of " +
                "letting thou into their domain... . The slayer was cursed by the gods yet not wanted by the devil, " +
                "making him the ideal war machine... . The abominations at a loss... anxious..." +
                "fearing that they all will be devoured by the slayer, they banded together and by sacrificing their own kin" +
                "sealed the slayer in the depths of the earth.\n" +
                "And there thee remained...Or so they say... .\n");

            string[] title = new string[] {
                "MMMMMMMMMMM   MA     AM    AMMMMMMMV        AMMMMMMMMV  ML          AMMMMMMA  YMMA     AMMY  AMMMMMMMV YMMMMMMMA   ",
                "Y  TMMMT  Y  MV       VM  AMMMMMMMV        AMMMMMMMMV   MML        AMMMMMMMMA  VMMA   AMNV  AMMMMMMMV   MMMMMMMMA  ",
                "    MMM      MA       AM  MMV             AMMV          MMM        MMMV  VMMM   VMMA AMMV   MMV         MMV   VMM  ",
                "    MMM      MMA     AMM  MMA             VMMA          MMM        MMMA  AMMM    VMMMMMV    MMA         MMA   AMM  ",
                "    MMM      MMMMMMMMMMM  MMMMMMMA         VMMMMMMMMA   MMM        MMMMMMMMMM     VMMMV     MMMMMMMA    NMMMMMMMV  ",
                "    MMM      MMMMMMMMMMM  MMMMMMMV          VMMMMMMMMA  MMM        MMMMMMMMMM      MMM      MMMMMMMV    NMMMMMMV   ",
                "    MMM      MMV     VMM  MMV                      VMMA MMM        MMMV  VMMM      MMM      MMV         NNNY VMA   ",
                "    MMM      MV       VM  MMA              A       AMMV MMML       MMM    MMM      MMM      MMA         NNN   VMA  ",
                "    MMM      MA       AM  VMMMMMMMA        VMMMMMMMMMV  MMMMMMMMA  VMM    MMV      MMM      VMMMMMMMA   NNN    VMA ",
                "  AWMMMWA     MV     VM    VMMMMMMMA        VMMMMMMMV   UMMMMMMMMA  VW    WV     AWMMMWA     VMMMMMMMA AWWA    AWWA"
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
            Console.ForegroundColor = ConsoleColor.Green;
            type("*Rumble*....... *RUMBLE!*...............*RUMBLE!!!!!!!!!!!!!!!!!!!*\n" +
                "“Ughhh…...”\n" +
                "*drip * .....*drop * .....*SPLASH!!!!!!!!!!!*\n" +
                "\nThou is awake, yet cannot even lift the eyelids... Thou is considered to be alive by definition... " +
                "but in reality, thou is nothing but a breathing corpse. Being chained in the void, in this deserted room... " +
                "all alone... without a purpose... Thy abdomen was in continual agony... Yet the breathing corpse could not comprehend the origin of the torment...\n" +
                "\n*Grrrrrrrrrrrrrrowl*... \n\nYet again that bothersome sound of the stomach breaking the dead silence of this empty chamber. " +
                "Thine limbs were shackled to the floor of the chamber... so, there thee was...laying flat on the cold and now wet floor. " +
                "Thine tongue was dangling outside of thine jaw all dried up now... As a result of the earth quaking thine tongue was now rubbing the wet floor. ...WET? " +
                "The tongue began manoeuvring around the wet floor collecting all the liquid until thou could make something similar to taking a sip. " +
                "Thine eye swung open now burning with the forgotten light, the light...the will... to continue to exist. " +
                "Thee rose from the floor... transferring all thine weight forward, thou briskly shoot ahead.\n" +
                "\n*BOOM~*...*Clank~*\n\n" +
                "Thee was now flying to the source of the liquid with the remaining of the chains dangling around thine limbs... with the chamber behind thee collapsing into nothingness.\n" +
                "\n*sip * ...*Sip * ....*SIP * ...*Heavy Breathing~*\n\n" +
                "After draining the pond, thine eyes were glaring at the rays of light coming from the end of the hallway.\n" +
                "The only light thee remembers to have ever seen... Thou stands up once again, wobbling this time... Deciding on what to do now...\n");
            choiceList();
        }

        public void choiceList()
        {
            Console.Clear();
            Console.WriteLine("Thou stands in the " + getRoom().getType() + " room\n" +
                              "=================================\n");
            Console.Write(
                "Actions\n" +
                "---------------------------------\n\n" +
                "1. Inspect\n" +
                "2. Interact\n" +
                "3. Craft\n" +
                "4. Move\n" +
                "\nYour choice: ");
            string choice = Console.ReadLine().ToLower().Trim();
            Console.Clear();

            switch (choice)
            {
                case "1":
                case "ins":
                case "inspect":
                    type(getRoom().getDesc() + "\n");
                    choiceList();
                    break;

                case "2":
                case "int":
                case "interact":
                    
                    if (inventory.hasTorch() && getRoom().getType() == RoomType.FOUNTAIN && !inventory.canLeave())
                    {
                        burnTheRope();
                    }

                    else if (inventory.canLeave() && getRoom().getType() == RoomType.FLINT)
                    {
                        door();
                    }
                    else if (getRoom().getType() == RoomType.FLINT|| getRoom().getType() == RoomType.OIL|| getRoom().getType() == RoomType.STICK)
                    {
                        pickUp();
                    }

                    else
                    {
                        Console.WriteLine(
                            "There is nothing else you can do as of right now" +
                            "\nPress 'Enter' to continue");
                        Console.ReadLine();
                        
                    }
                    choiceList();
                    break;
                case "3":
                case "c":
                case "craft":
                    craft();
                    Console.ReadLine();
                    choiceList();
                    break;
                case "4":
                case "m":
                case "move":
                    walkWhere();
                    break;
                case "/map":
                    cheat();
                    choiceList();
                    break;

                default:
                    unknownCommand();
                    choiceList();
                    break;
            }
        }
        //fix
        public void pickUp()
        {
            Console.Write(
                "Do you want to pick up the item in the room?" +
                "(Yes/No)" +
                "\n\nAnswer: ");
            string answer = Console.ReadLine().ToLower().Trim();
            Console.Clear();
            switch (answer)
            {
                case "yes":
                case "ye":
                case "y":
                    itemCollect();
                    break;

                case "no":
                case "n":
                case "nah":
                    break;

                default:
                    unknownCommand();
                    pickUp();
                    break;
            }
        }

        public void craft()
        {
            Console.WriteLine("                       RECIPE:                         \n" +
                              " _________     _________     _________       _________ \n" +
                              "|  Stick  |   |   Oil   |   |  Flint  |     |  Torch  |\n" +
                              "|    1    | + |    1    | + |    1    | --> |    1    |\n" +
                              "|_________|   |_________|   |_________|     |_________|");
            if (inventory.hasOil() && inventory.hasFlint() && inventory.hasStick() && inventory.hasTorch() != true)
            {
                inventory.craftTorch();
                Console.WriteLine("\nThou have successfully  made a torch!!!");
            }
            else
            { Console.WriteLine("\nThere is nothing new thou can make at this moment"); }
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
            string answer = Console.ReadLine().ToLower().Trim();
            Console.Clear();

            switch (answer)
            {
                case "yes":
                case "ye":
                case "y":
                    exit();
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
            Console.Clear();
            Console.WriteLine("Thou stands in the " + getRoom().getType() + " room\n" +
                              "=================================\n");
            Console.Write(
            "Try Moving: \n" +
            "---------------------------------\n\n" +
            " 1. Up\n" +
            " 2. Left\n" +
            " 3. Right\n" +
            " 4. Down\n" +
            " 5. Back (Previous menu)\n\n" +
            "Your choice: ");
            string yourChoice = Console.ReadLine().ToLower().Trim();
            Console.Clear();
            movementSwitch(yourChoice);
          
        }
        public void movementSwitch(string choice)
        {
            switch (choice)
            {
                case "1":
                case "u":
                case "up":
                    player.setY(player.move(player.y(), -1, map.getMapY() - 1, map.getSymbol(player.y() - 1, player.x())));
                    break;

                case "2":
                case "l":
                case "left":
                    player.setX(player.move(player.x(), -1, map.getMapX() - 1, map.getSymbol(player.y(), player.x() - 1)));
                    break;

                case "3":
                case "r":
                case "right":
                    player.setX(player.move(player.x(), 1, map.getMapX() - 1, map.getSymbol(player.y(), player.x() + 1)));
                    break;

                case "4":
                case "d":
                case "down":
                    player.setY(player.move(player.y(), 1, map.getMapY() - 1, map.getSymbol(player.y() + 1, player.x())));
                    break;

                case "5":
                case "b":
                case "back":
                    choiceList();
                    break;

                default:
                    unknownCommand();
                    walkWhere();
                    break;
            }
            if (getRoom().getType() == RoomType.TRAP)
            {
                death();
            }
            Console.WriteLine("You moved");
            Console.ReadLine();
            walkWhere();
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


            //Mark
            Console.ReadLine();
            choiceList();
        }

        public void exit()
        {
            DateTime now = DateTime.Now;
            int second = now.Second;
            int pastSecond = second;
            int timer = 6;
            string message = "Application closing in: ";
            int lenght = message.Length;

     /*       Console.WriteLine("\nYou have succesfully escaped the chamber..." +
                "\nFor now...." +
                "\n\nPress 'Enter' to exit the application");
            Console.ReadLine();*/

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
                    room = trapRoom;
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
            Console.WriteLine("\n\nCheating are we~?");
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

        public void death()
        {
            inventory.reset();
            player.reset();
            Console.WriteLine("U ded");
            flicker(0);
            Console.Clear();
            Console.Write(
                "Does thee want to try again?" +
                "(Yes/No)" +
                "\n\nAnswer: ");
            string answer = Console.ReadLine().ToLower().Trim();
            Console.Clear();

            switch (answer)
            {
                case "yes":
                case "ye":
                case "y":
                    start();
                    break;

                case "no":
                case "n":
                case "nah":
                    exit();
                    break;

                default:
                    unknownCommand();
                    death();
                    break;
            }

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
                    Console.Write("Press 'Enter' to continue                   \n" +
                        "                                                        ");
                    Console.SetCursorPosition(x, top);
                    Thread.Sleep(800);
                }
                else if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    break;
                }

            }
        }
    }
}