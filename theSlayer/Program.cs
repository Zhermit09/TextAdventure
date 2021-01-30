﻿using System;
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
        }

        public void mainMeny()
        {
            Console.WriteLine(
                "The Slayer" +
                "\nPress 'Enter' to begin");
            Console.ReadLine();
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

        //Smoll Methods
        public Room getRoom()
        {
            Room room = rooms[player.y(), player.x()];
            return room;
        }
        public void unknownCommand()
        {
            Console.WriteLine("Unknown command" +
                "\nPress 'Enter' to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}