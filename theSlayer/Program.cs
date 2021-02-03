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

        private Room trapRoom = new Room("Thee marches forward into the darkness without a glimpse of fear...\n" +
            "*SHING*\n" +
            "???\n" +
            "Thou cannot determine what was the cause of the noise... \n" +
            "*TUD*\n" +
            "Thou hits the ground... Thine body feels chilly... Thee feels tired... thee needs a little rest...\n" +
            "*SIGH*\n" +
            "It is now dead silent... Thou has fallen asleep... with thine other half of the body resting beside thee...\n", RoomType.TRAP);

        private Room flintRoom = new Room("Thee looks around the chamber...thou sees a pile of rocks blocking the enormous gate...\n" +
            "*RUMBLE*\n" +
            "Rocks most unstable start falling down from the top of the pile...\n" +
            "*Click* *click*... \n" +
            "Creating sparks left and right...\n", RoomType.FLINT);

        private Room oilRoom = new Room("Thee looks around the chamber... but cannot seem to find anything special about the room...\n" +
            "*BUBLE*\n" +
            "???\n" +
            "Thou moves over to one of the corners... and there thee finds a puddle of an unknown black substance flowing out of the crack in the chamber...\n", RoomType.OIL);

        private Room fountain = new Room("Thee comes closer to the structure that looks like different chalices were stacked on each other... Thou looks inside... There is nothing in there...  \n" +
            "*Groan *...\n" +
            "*Scream*\n" +
            "Thee looks up looking for the origin of somebody’ agony... but instead gets blinded by the thin light rays coming through the small spaces... Thee waits till thine eyes adapt..." +
            " and looks up again... thou sees some sort of a complex mechanism... with further inspection thee sees a rope under heavy tension...\n", RoomType.FOUNTAIN);

        private Room stickRoom = new Room("Thee looks around the chamber… and sees a garden of some sort...  " +
            "a withered one that is... The ground was drained of life... craking beneath thine feet... " +
            "no sign of grass or vegetation could be seen... only the withered trunk of an ancient tree... " +
            "menacingly gazing at thee...\n", RoomType.STICK);

        private Room emptyRoom = new Room("Thee looks around the chamber... but cannot seem to find anything special about the room...\n", RoomType.EMPTY);

        private Room wall = new Room("", RoomType.WALL);

        private Map map = new Map();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.start();
        }

        private void start()
        {
            Console.SetCursorPosition((Console.BufferWidth - 22) / 2, 13);
            flicker((Console.BufferWidth - 22) / 2);
            Thread.Sleep(500);

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
            mainMeny();
        }

        public void mainMeny()
        {
            string[] title = new string[] {
                "MMMMMMMMMMM   MA     AM    AMMMMMMMV        AMMMMMMMMV  A           AMMMMMMA  YMMA     AMMY  AMMMMMMMV YMMMMMMMA   ",
                "Y  TMMMT  Y  MV       VM  AMMMMMMMV        AMMMMMMMMV   MA         AMMMMMMMMA  VMMA   AMNV  AMMMMMMMV   MMMMMMMMA  ",
                "    MMM      MA       AM  MMV             AMMV          MMA        MMMV  VMMM   VMMA AMMV   MMV         MMV   VMM  ",
                "    MMM      MMA     AMM  MMA             VMMA          MMM        MMMA  AMMM    VMMMMMV    MMA         MMA   AMM  ",
                "    MMM      MMMMMMMMMMM  MMMMMMMA         VMMMMMMMMA   MMM        MMMMMMMMMM     VMMMV     MMMMMMMA    NMMMMMMMV  ",
                "    MMM      MMMMMMMMMMM  MMMMMMMV          VMMMMMMMMA  MMM        MMMMMMMMMM      MMM      MMMMMMMV    NMMMMMMV   ",
                "    MMM      MMV     VMM  MMV                      VMMA MMV        MMMV  VMMM      MMM      MMV         NNNY VMA   ",
                "    MMM      MV       VM  MMA              A       AMMV MMA        MMM    MMM      MMM      MMA         NNN   VMA  ",
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
                Thread.Sleep(50);
            }
            Console.SetCursorPosition((Console.BufferWidth - 26) / 2, Console.CursorTop + 6);
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
                "Thou stands up once again, wobbling this time... Deciding on what to do now...\n");
            choiceList();
        }

        public void choiceList()
        {
            currentRoom();
            Console.Write(
                " Actions\n" +
                "---------------------------------\n\n" +
                " 1. Inspect\n" +
                " 2. Interact\n" +
                " 3. Craft\n" +
                " 4. Move\n" +
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

                       if (inventory.canLeave() && getRoom().getType() == RoomType.FLINT)
                    {
                        door();
                    }
                    else if (getRoom().getType() == RoomType.FLINT || getRoom().getType() == RoomType.OIL || getRoom().getType() == RoomType.STICK)
                    {
                        pickUp();
                    }
                    else if (inventory.hasTorch() && getRoom().getType() == RoomType.FOUNTAIN && !inventory.canLeave())
                    {
                        burnTheRope();
                    }
                 
                    else
                    {
                        Console.WriteLine(
                            "There is nothing else you can do as of right now\n");
                        flicker(0);

                    }
                    choiceList();
                    break;
                case "3":
                case "c":
                case "craft":
                    craft();
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
        public void pickUp()
        {
            Console.Write(
                "Do you want to pick up the material in the room?" +
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
        public void burnTheRope()
        {
            inventory.openExit();
            type("Thou looks again at the complex mechanism... thou sees the cable under tension… thou looks at thy torch... " +
                "thou decide to give it a try... thou starts to climb the multilevelled fountain and reached the rope...  " +
                "thou moved thy torch closer to the cable… it burst into flames… exploding under its own tension...  " +
                "Gears started moving again...\n" +
                "*Groan*... *Scream*... *Screech!!!*...\n" +
                "And then dead silence..." +
                "Foutain started working again… bringing the bloodred liquid and filling its chalices… " +
                "thou weak and exhausted climbs down and starts consuming the substance... " +
                "thine body begins healing and recovering at a tremendous speed... and with recovery came a scorching feeling... " +
                "a feeling so familiar yet so new... after draining the chalices thou stands up more energetic than ever...\n");
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    type("*Inhale* \n" +
                        "Thou pulls back one of thy legs... \n" +
                        "*Boom*\n" +
                        "Thou is out ... or so thou thought... thou finds thy self in an open room... " +
                        "with a watchdog... a giant one that is ... hundreds of times bigger than thee..." +
                        " yet thou are not the one to cower in fear but the beast... finally after a while the flustered beast " +
                        "comes to its senses and charges at thee… however watchdogs courage was futile… in single movement " +
                        "thou smashed the beast against the opposite wall… the hound let out a final howl letting them know..." +
                        " the age of extinction has begun!\n");
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
                Console.Clear();
                type("\nThee observers thine acquired materials… thinking of making something to help thee escape..." +
                    " however, thou can only make a fire on a stick so thou decide to do just so...  make a torch..." +
                    " thine torch beams with blue hot light brightening the space around thee... \n" +
                    "Maybe thou can make use of it?\n");
            }
            else
            {
                Console.WriteLine("\nThere is nothing new thou can make at this moment \n");
                flicker(0);
            }
        }

        public void walkWhere()
        {
            currentRoom();
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                death();
            }
            walkWhere();
        }
        public void itemCollect()
        {
            switch (getRoom().getType())
            {
                case RoomType.OIL:
                    type("Thee kneeled by the puddle... puzzled... how would thee be able to store the black liquid... " +
                        "Thou looked down at thine ravaged robes...  \n" +
                        "*POP*\n" +
                        "a bubble popped in the liquid leaving a stain on the already" +
                        " demolished clothes… and suddenly, it came to thou...  the answer...  thee took the bottom of thine clothing and " +
                        "with all remaining might tore it apart... then thee took the ripped off the strip... drenched it in the substance... " +
                        "and after thee bandaged the strip around thine arm.\n");
                    inventory.collectOil();
                    break;

                case RoomType.FLINT:
                    type("Thee approached the pile of rocks... kneeled down...  " +
                        "picked up two rocks and slammed them against each other... yet no sparks emerged... " +
                        "thee began examining the rocks once again until thee saw some peculiar stones... " +
                        "they gave a different impression... thee slammed them against each other... (embers sparked...)\n");
                    inventory.collectFlint();
                    break;

                case RoomType.STICK:
                    type("Thee stood in the centre of the ‘garden’ by the withered tree... " +
                         "thee grasped one of the branches believing that it would easily crack under thine pressure..." +
                         " it did not... the mightly tree was long dead yet such strength was embedded in the wood..." +
                         " thee had to hang himself on the tiny branch and only then... did it give in... \n");
                    inventory.collectStick();
                    break;

                default:
                    Console.WriteLine("Nothing here");
                    break;
            }
            choiceList();
        }
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
            Console.ReadLine();
        }

        public void unknownCommand()
        {
            Console.WriteLine("Unknown command\n");
            flicker(0);
        }

        public void currentRoom()
        {
            Console.Clear();
            Console.Write("Thou stands in the ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(getRoom().getType());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" room\n" +
                              "=================================\n");
        }
        public void death()
        {
            type(getRoom().getDesc());
            inventory.reset();
            player.reset();



            Console.Write(
                "Does thou want to reawaken again?" +
                "(Yes/No)" +
                "\n\nAnswer: ");
            string answer = Console.ReadLine().ToLower().Trim();
            Console.Clear();

            switch (answer)
            {
                case "yes":
                case "ye":
                case "y":
                    mainMeny();
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
        public void exit()
        {
            DateTime now = DateTime.Now;
            int second = now.Second;
            int pastSecond = second;
            int timer = 6;
            string message = "Application closing in: ";
            int lenght = message.Length;

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


    }
}