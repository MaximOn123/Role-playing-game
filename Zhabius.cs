using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Zhabius: Artifact,IMagic
    {
        Character _user;
        public Zhabius(Character user) : base(0, true)
        {
            _user = user;
        }
        public void SpellCast(Character target = null, uint force = 1) {
            if (IsRenewable())
            {
                if (target == null) target = _user;
                if (target.State != Character.States.Poisoned) Console.WriteLine("This Character is not poisoned!");
                else
                {
                    target.State = Character.States.Normal;
                    _renewable = false;
                }
            }
            else Console.WriteLine("This Flask is empty!");
        
        }
        



    }
}
