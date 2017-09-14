using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_rpgGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //player stats
            int playerHealth = 100;
            int playerStamina = 100;
            int killed = 0;
            //attack styles
            int[] chop = new int[2];
            chop[0] = 50; //first number == attack damage
            chop[1] = 80; //second number == stamina drain
            int[] slash = new int[2];
            slash[0] = 30;
            slash[1] = 40;
            int[] stab = new int[2];
            stab[0] = 20;
            stab[1] = 20;
            int[] guard = new int[2];
            guard[0] = 0;
            guard[1] = -40;
            int[] heal = new int[3];
            guard[0] = 0;
            guard[1] = 30;
            guard[2] = 30; //heal amount

            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine("Hello and welcome " + playerName + "!");
            Console.WriteLine("This is a simple RPG game where you attack monsters and try to survive for long as possible");
            Console.WriteLine("You heal 10 health points and 30 stamina points every turn");
            Console.WriteLine(" ");
            while (playerHealth > 0) //game ends when player died
            {
                //monster stats
                int[] monster = new int[2];
                monster[0] = 100;
                monster[1] = 30;

                Console.WriteLine("You encountered a monster!");
                Console.WriteLine("Monster has an attack value of " + monster[1] + " and a HP of " + monster[0]);

                while (monster[0] > 0 && playerHealth > 0) {
                    Console.WriteLine(" ");
                    Console.WriteLine("Your Attack Options:");
                    Console.WriteLine("Chop: " + chop[0] + " Damage " + chop[1] + " Stamina Drain");
                    Console.WriteLine("Slash: " + slash[0] + " Damage " + slash[1] + " Stamina Drain");
                    Console.WriteLine("Stab: " + stab[0] + " Damage " + stab[1] + " Stamina Drain");
                    Console.WriteLine("Guard: " + guard[0] + " Damage " + guard[1] + " Stamina Drain");
                    Console.WriteLine("Heal: " + heal[2] + " HP gain " + heal[1] + " Stamina Drain");
                    Console.WriteLine(" ");
                    Console.WriteLine("Your Stats:");
                    Console.WriteLine(playerHealth + " HP " + playerStamina + " Stamina");
                    Console.WriteLine(" ");
                    string playerAction = Console.ReadLine();
                    if (playerAction == "Chop" && playerStamina >= chop[1]) //checks what action the player does
                    {
                        playerStamina -= chop[1];
                        monster[0] -= chop[0];
                    }
                    else if (playerAction == "Slash" && playerStamina >= slash[1])
                    {
                        playerStamina -= slash[1];
                        monster[0] -= slash[0];
                    }
                    else if (playerAction == "Stab" && playerStamina >= stab[1])
                    {
                        playerStamina -= stab[1];
                        monster[0] -= stab[0];
                    }
                    else if (playerAction == "Guard")
                    {
                        playerStamina -= guard[1];
                        monster[0] -= guard[0];
                    }
                    else if (playerAction == "Heal")
                    {
                        playerStamina -= heal[1];
                        playerHealth += heal[2];
                    }
                    else //if player writes something invalid
                    {
                        Console.WriteLine("Bad action!");
                        Console.WriteLine(" ");
                    }
                    playerHealth -= monster[1];
                    playerStamina += 20;
                    playerHealth += 10;
                    if (monster[0] > 0 && playerHealth > 0)
                    {
                        Console.WriteLine("The monster has " + monster[0] + " HP left");
                        Console.WriteLine("The monster attacks you for " + monster[1] + " damage!");
                    }
                    Console.WriteLine(" ");
                }
                // monster loops end. that means the player killed a monster. yay!
                killed += 1;
            }
            Console.WriteLine("Oops! You died");
            Console.WriteLine("You killed " + killed + " monsters");
            Console.ReadLine();
        }
    }
}
