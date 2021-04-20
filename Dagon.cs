using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Dagon : Artifact, IMagic
    {
        Wizard _user;
        const uint MaxPower = 200;
        private int Power
        {
            get
            {
                return (int)this._power;
            }
            set
            {
                if (value > MaxPower)
                {
                    this._power = MaxPower;
                }
                else if (value < 0)
                {
                    throw new ArgumentException("Power must be non-negative");
                }
                else
                {
                    this._power = (uint)value;
                }
            }
        }
        public Dagon(Wizard user) : base(MaxPower, true)
        {
            _user = user;
        }
        public override void Use(Character target, uint force = 1)
        {
            if (Power != 0)
            {
                Power -= (int)force;
                target.HP -= (int)force;
            }
            else
            {
                throw new ArgumentException("This artifact has used all of it's power!");
            }
        }
        public void Renew(uint power)
        {
            Power += (int)power;
        }
    }
}
