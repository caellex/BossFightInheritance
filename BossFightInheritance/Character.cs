using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFightInheritance
{
    internal abstract class Character
    {
        public string Name {  get; private set; }
        private int _health;
        private int _strength;
        private int _stamina;

        public int Health
        {
            get {  return _health; }
            private set { _health = value; }
        }

        public int Strength
        {
            get { return _strength; }
            private set { _strength = value; }
        }

        public int Stamina
        {
            get { return _stamina; }
            private set { _stamina = value; }
        }

        public abstract void Recharge();
        public abstract void PrintName();

        protected Character(int hp, int str, int stam, string name)
        {
            Health = hp;
            Strength = str;
            Stamina = stam;
            Name = name;
        }

        public void SetHeroStamina()
        {
            _stamina = 40;

        }

        public void SetBossStamina()
        {
            _stamina = 10;

        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void UseStamina(int stamina)
        {
            Stamina -= stamina;
        }

        public int GetStamina()
        {
            return _stamina;
        }
        public int GetHealth()
        {
            return _health;
        }
    }
}
