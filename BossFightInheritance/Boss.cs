using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFightInheritance
{
    internal class Boss : Character
    {
        private int _fightID = 1;
        public Boss(int hp, int str, int stam, string name) : base(hp, str, stam, name)
        {
            PrintName();
            Console.Write($" is ready to fight with {hp}HP, {str} Strength and {stam} Stamina\n\n");
        }

        public override void Recharge()
        {
            if (GetStamina() <= 0)
            {
                SetBossStamina();
                Thread.Sleep(1500);
            }
        }

        public override void PrintName()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Boss");
            Console.ResetColor();
        }
    }
}
