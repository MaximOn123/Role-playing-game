using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Character : IComparable
    {
        public enum States { Normal, Weak, Sick, Poisoned, Paralized, Dead }
        public enum Races { Human, Gnome, Elf, Orс, Goblin }
        public enum Sexes { Male, Female }
        private string _name;
        private States _state;
        private bool _canSpeak;
        private bool _canMove;
        private Races _race;
        private Sexes _sex;
        private uint _age;
        private uint _hp;
        private uint _maxHP;
        private uint _xp;
        public uint ID { get; private set; }
        private static uint NextID = 1;
        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (this._name == null)
                {
                    throw new ArgumentNullException("Name must not be null");
                }
                this._name = value;
            }
        }
        public States State
        {
            get
            {
                return this._state;
            }
            protected set
            {
                this._state = value;
                if (this.State == States.Paralized)
                {
                    this.CanMove = false;
                }
                else
                {
                    this.NormalizeState();
                }
            }
        }
        public bool CanSpeak
        {
            get
            {
                return this._canSpeak;
            }
            protected set
            {
                this._canSpeak = value;
            }
        }
        public bool CanMove
        {
            get
            {
                return this._canMove;
            }
            protected set
            {
                this._canMove = value;
            }
        }
        public Races Race
        {
            get
            {
                return this._race;
            }
            private set
            {
                this._race = value;
            }
        }
        public Sexes Sex
        {
            get
            {
                return this._sex;
            }
            private set
            {
                this._sex = value;
            }
        }
        public int Age
        {
            get
            {
                return (int)this._age;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be non-negative");
                }
                this._age = (uint)value;
            }
        }
        public int HP
        {
            get
            {
                return (int)this._hp;
            }
            protected set
            {
                if (value <= 0)
                {
                    this._hp = 0;
                    this.State = States.Dead;
                }
                else
                {
                    this._hp = (uint)value;
                }
                this.NormalizeState();
            }
        }
        public uint MaxHP
        {
            get
            {
                return this._maxHP;
            }
            protected set
            {
                if (value >= int.MaxValue)
                {
                    throw new ArgumentException("Max HP exceeds maximum allowable value");
                }
                this._maxHP = value;
                this.NormalizeState();
            }
        }
        public uint XP
        {
            get
            {
                return this._xp;
            }
            protected set
            {
                this._xp = value;
            }
        }
        public Character(string name, Races race, Sexes sex)
        {
            this.Name = name;
            this.Race = race;
            this.Sex = sex;
            this.ID = NextID;
            NextID++;
            this.CanSpeak = true;
            this.CanMove = true;
            this.State = States.Normal;
        }
        private void NormalizeState() // Насчет normal или weak в заклинаниях можно не парится, все фиксится этим методом
        {
            if (this.State == States.Weak && (double)this.HP / this.MaxHP >= 10)
            {
                this.State = States.Normal;
            }
            else if (this.State == States.Normal && (double)this.HP / this.MaxHP < 10)
            {
                this.State = States.Weak;
            }
        }
        override public string ToString()
        {
            string str = "Name: " + Name + "\nRace: " + Race.ToString() + "\nSex: " + Sex.ToString() + "\nAge: " + Age.ToString() +
                "\nState: " + State.ToString() + "\nHP: " + HP.ToString() + "\nMax HP: " + MaxHP.ToString() + "\nXP: " + XP.ToString() +
                "\nCan move: " + CanMove.ToString() + "\nCan speak: " + CanSpeak.ToString();
            return str;
        }
        public int CompareTo(object obj)
        {
            if (!(obj is Character))
            {
                throw new ArgumentException("Object must be a Character");
            }
            Character other = (Character)obj;
            if (this.XP > other.XP)
            {
                return 1;
            }
            if (this.XP < other.XP)
            {
                return -1;
            }
            return 0;
        }
    }
    class Wizard : Character
    {
        private uint _mp;
        private uint _maxMP;
        public int MP
        {
            get
            {
                return (int)this._mp;
            }
            protected set
            {
                this._mp = (uint)value;
            }
        }
        public uint MaxMP
        {
            get
            {
                return this._maxMP;
            }
            protected set
            {
                if (value >= int.MaxValue)
                {
                    this._maxMP = value;
                }
            }
        }
        /* public void HealSpell(Character other) ------- примерный макет заклинания
        {
           // Character other = other1 as Character;
            uint hpDifference = other.MaxHP - (uint)other.HP;
            if (this.MP / 2 > hpDifference)
            {
                other.HP = (int)other.MaxHP;
                this.MP -= (int)hpDifference * 2;
            }
            else
            {
                other.HP += this.MP / 2;
                this.MP = 0;
            }
        }*/
        public Wizard(string name, Races race, Sexes sex) : base(name, race, sex)
        {

        }
    }
}
