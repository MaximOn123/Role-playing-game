using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class EyeOfSkadi:Artifact,IMagic
    {
        Character _user;
        public EyeOfSkadi(Character user): base(0,true) {
            _user = user;
        }
        public void SpellCast(Character target, uint force = 1) {
            if (IsRenewable())
            {
                if (target.State == Character.States.Dead) Console.WriteLine("He is dead,he can't move anyway!");
                else
                {
                    target.State = Character.States.Paralized;
                    _renewable = false;
                }
            }
            else Console.WriteLine("This artfiact broke down!");
            
            
        
        
        
        
        }

    }
}
