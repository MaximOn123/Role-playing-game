using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;

namespace Role_playing_game
{
    public class Character : IComparable
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
        public Thread ArmorThread;
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
                if (value == null)
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
            set
            {
                this._state = value;
                if (this.State == States.Paralized | this.State == States.Dead)
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
            set
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
            set
            {
                bool? isThreadSuspended;
                if (this.ArmorThread != null)
                {
                    isThreadSuspended = this.ArmorThread.ThreadState == ThreadState.Suspended;
                }
                else
                {
                    isThreadSuspended = null;
                }
                if (isThreadSuspended == null | isThreadSuspended == false)
                {
                    if (value <= 0)
                    {
                        this._hp = 0;
                        this.State = States.Dead;
                    }
                    else if (value > this.MaxHP)
                    {
                        this._hp = (uint)this.MaxHP;
                    }
                    else
                    {
                        this._hp = (uint)value;
                    }
                    this.NormalizeState();
                }
            }
        }
        public int MaxHP
        {
            get
            {
                return (int)this._maxHP;
            }
            protected set
            {
                if (value >= int.MaxValue)
                {
                    throw new ArgumentException("Max HP exceeds maximum allowable value");
                }
                else if (value < 0)
                {
                    throw new ArgumentException("Max HP must be non-negative");
                }
                this._maxHP = (uint)value;
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
            this.MaxHP = 100;
            this.HP = 100;
        }
        public void NormalizeState()
        {
            if (this.State == States.Weak & (double)this.HP / this.MaxHP >= 0.1)
            {
                this.State = States.Normal;
            }
            else if (this.State == States.Normal & (double)this.HP / this.MaxHP < 0.1)
            {
                this.State = States.Weak;
            }
        }
        override public string ToString()
        {
            string str = "Name: " + Name + "\nRace: " + Race.ToString() + "\nSex: " + Sex.ToString() + "\nAge: " + Age.ToString() +
                "\nState: " + State.ToString() + "\nHP: " + HP.ToString() + "\nMax HP: " + MaxHP.ToString() + "\nXP: " + XP.ToString() +
                "\nCan move: " + CanMove.ToString() + "\nCan speak: " + CanSpeak.ToString() + "\n";
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
        private ArrayList _inventory = new ArrayList();
        public void addart(Artifact o)
        {
            if (!_inventory.Contains(o))
            {
                _inventory.Add(o);
            }
            else
            {
                throw new ArgumentException("Such an artifact already exists");
            }
        }
        public void useart(Artifact o, Character target = null, uint ar =0)
        {
            if (!_inventory.Contains(o))
            {
             throw new ArgumentException("The character does not have such an aretifact"); 
            }
            o.Use(target,ar);
            if (o.IsRenewable() == false)
            {
                _inventory.Remove(o);
            }
        }
        public void removalart(Artifact o)
        {
            if (!_inventory.Contains(o))
            {
                 throw new ArgumentException("The character does not have such an aretifact");   
            }
            _inventory.Remove(o);
        }
        public void broadcastart(Artifact o, Character ch)
        {
            if (!_inventory.Contains(o))
            {
                throw new ArgumentException("There is no such artifact in the bag");
            }
            ch.addart(o);
            removalart(o);
        }
    }
    public class Wizard : Character
    {
        private uint _mp;
        private uint _maxMP;
        public int MP
        {
            get
            {
                return (int)this._mp;
            }
            set
            {
                if (value > this.MaxMP)
                {
                    this._mp = (uint)this.MaxMP;
                }
                else if (value < 0)
                {
                    throw new ArgumentException("Mana can not be negative");
                }
                else
                {
                    this._mp = (uint)value;
                }
            }
        }
        public int MaxMP
        {
            get
            {
                return (int)this._maxMP;
            }
            protected set
            {
                if (value >= int.MaxValue)
                {
                    throw new ArgumentException("Max MP exceeds maximum allowable value");
                }
                else if (value < 0)
                {
                    throw new ArgumentException("Max MP must be non-negative");
                }
                this._maxMP = (uint)value;
            }
        }
        public Wizard(string name, Races race, Sexes sex) : base(name, race, sex)
        {
            this.MaxMP = 100;
            this.MP = 100;
        }
        override public string ToString()
        {
            string str = base.ToString() + "Max MP: " + MaxMP.ToString() + "\nMP: " + MP.ToString() + "\n";
            return str;
        }
        private ArrayList _spell = new ArrayList();
        public void pronounce(Spell o,Character ar=null ,uint a=1)
        {
            if (!_spell.Contains(o))
            {
            throw new ArgumentException("This spell is not learned");
            }
            o.Use(force:a, character:ar);
        }
        public void pronounce(Spell o, uint a = 1)
        {
            if (!_spell.Contains(o))
            {
                throw new ArgumentException("This spell is not learned");
                
            }
            o.Use(force: a);
        }
        public void pronounce(Spell o)
        {
            if (!_spell.Contains(o))
            {
            throw new ArgumentException("This spell is not learned"); 
            }
            o.Use();
        }
        public void toforget(Spell o)
        {
            if (!_spell.Contains(o))
            {
            throw new ArgumentException("This spell is not learned"); 
            }
            _spell.Remove(o);
        }
        public void tolearn(Spell o)
        {
              if (_spell.Contains(o))
              {
              throw new ArgumentException("This spell is already learned"); 
              }
             _spell.Add(o);
        }
    }
}
