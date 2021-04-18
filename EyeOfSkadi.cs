using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class EyeOfSkadi : Artifact
    {
        Character _user;
        private bool _isUsed = false;
        public EyeOfSkadi(Character user) : base(0, false)
        {
            _user = user;
        }
        public override void Use(Character target, uint force = 0)
        {
            if (!_isUsed)
            {

                if (target.State == Character.States.Dead)
                {
                    throw new ArgumentException("Target must not be dead");
                }
                target.State = Character.States.Paralized;
                _isUsed = true;
            }
            else
            {
                throw new ArgumentException("This artifact has already been used");
            }
        }
    }
}
