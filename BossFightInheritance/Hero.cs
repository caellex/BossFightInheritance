using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFightInheritance
{
    internal class Hero : Character
    {
        private int _fightID = 0;
        public Hero(int hp, int str, int stam, string name) : base(hp, str, stam, name)
        {
            PrintName();
            Console.Write($" is ready to fight with {hp}HP, {str} Strength and {stam} Stamina\n");
        }

        public override void Recharge()
        {
            if (GetStamina() <= 0)
            {
                SetHeroStamina();
                Thread.Sleep(1500);
            }
        }

        public override void PrintName()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Hero");
            Console.ResetColor();
        }
    }
}
