using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class OrbofVenom : Artifact,IMagic
    {
        Character _user;
        public OrbofVenom(Character user) : base(10, true) {
            _user = user;
        }
        public void SpellCast(Character target, uint force = 0) {
            if (target.State != Character.States.Dead)
            {
                if (target.HP - _power < 0)
                {
                    target.HP = 0;
                    target.State = Character.States.Dead;

                }
                else target.HP -= _power;
            }
            else Console.WriteLine("Have some respect for the dead!");
        
        }
    }
}
