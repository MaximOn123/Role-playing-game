using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Dagon : Artifact,IMagic
    {
        Wizard _user;

        public Dagon(Wizard user) : base(user.MaxMP, true) {
            _user = user;

        }
        public void SpellCast(Character target, uint force = 1) {
            if (IsRenewable())
            {
                if (target.HP - force < 0)
                {
                    target.HP = 0;
                    target.State = Character.States.Dead;
                    _power -= force;


                }
                else
                {
                    target.HP -= force;
                    _power -= force;
                }
                if (_power <= 0) _renewable = false;


            }
            else Console.WriteLine("This artifact has used all of it's power!");
        
        
        
        
        }
    }
}
