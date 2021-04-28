using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Zhabius : Artifact
    {
        private Character _user;
        public Zhabius(Character user) : base(0, false)
        {
            _user = user;
        }
        public override void Use(Character target = null, uint force = 1)
        {
            if (target == null)
            {
                target = _user;
            }
            if (target.State != Character.States.Poisoned)
            {
                throw new ArgumentException("This Character is not poisoned!");
            }
            target.State = Character.States.Normal;
            target.NormalizeState();
        }
    }
}
