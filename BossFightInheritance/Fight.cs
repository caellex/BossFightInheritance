using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFightInheritance
{
    internal class Fight
    {
        int _currentFighterID = 0;
        private bool IsFighting = false;

        List<Character> characters = new List<Character>();

        public Fight()
        {
            characters = new List<Character>()
            {
                new Hero(100, 20, 40, "Hero"),
                new Boss(400, RandomStr(), 10, "Boss")
            };
        }
        private int RandomStr()
        {
            Random rnd = new Random();

            int randStr = rnd.Next(0, 30);
            return randStr;
        }
        private void NextFighter()
        {
            _currentFighterID = (_currentFighterID + 1) % 2;
        }

        private int GetDefenderId()
        {
            return (_currentFighterID + 1) % 2;
        }

        public void FightYourTurn()
        {
            while (IsFighting)
            {
                Character attacker = characters[_currentFighterID];
                Character defender = characters[GetDefenderId()];
                CheckStamina(attacker);
                defender.TakeDamage(attacker.Strength);
                PrintActions(attacker, defender);

                IsDead(defender,attacker);

                attacker.UseStamina(10);
                NextFighter();
                Console.WriteLine($"Stamina remaining: {attacker.Stamina}");
                Thread.Sleep(1000);
            }
        }

        private void IsDead(Character defender, Character attacker)
        {
            if (defender.Health <= 0)
            {
                IsFighting = false;
                HasWon(attacker);
            }


        }

        private void CheckStamina(Character attacker)
        {
            if(attacker.Stamina <= 0)
            {
                Console.WriteLine();
                attacker.PrintName();
                Console.Write(" has no stamina left and has to skip the turn to Recharge.\n");
                attacker.Recharge();
                SkipTurn();
            }
        }

        public void StartFight()
        {
            IsFighting = true;
        }

        private void PrintActions(Character attacker, Character defender)
        {
            Console.WriteLine();
            attacker.PrintName();
            Console.Write($" dealt {attacker.Strength}dmg to ");
            defender.PrintName();
            Console.Write($"({defender.Health}hp)\n");
        }

        private void HasWon(Character winner)
        {
            Console.WriteLine();
            winner.PrintName();
            Console.Write($" won with {winner.Health}HP remaining!");
            Console.ReadKey();
        }

        private void SkipTurn()
        {
            NextFighter();
            FightYourTurn();
        }
    }
}

