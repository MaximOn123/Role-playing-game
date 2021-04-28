using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Dagon : Artifact, IMagic
    {
        Character _user;
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
                    throw new ArgumentException("Not enough power!");
                }
                else
                {
                    this._power = (uint)value;
                }
            }
        }
        public Dagon(Character user) : base(MaxPower, true)
        {
            _user = user;
        }
        public override void Use(Character target, uint force = 1)
        {
            if (Power == 0)
            {
                throw new ArgumentException("This artifact has used all of it's power!");
                
            }
            Power -= (int)force;
            target.HP -= (int)force;
        }
        public void Renew(uint power)
        {
            Power += (int)power;
        }
    }
}
