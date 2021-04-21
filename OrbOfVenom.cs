using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class OrbOfVenom : Artifact
    {
        private Character _user;
        private bool _isUsed = false;
        const uint Power = 20;
        public OrbOfVenom(Character user) : base(Power, true)
        {
            this._user = user;
        }
        public override void Use(Character target, uint force = 0)
        {
            if (target.State == Character.States.Normal | target.State == Character.States.Weak)
            {
                target.HP -= (int)Power;
                target.State = Character.States.Poisoned;
                this._isUsed = true;
            }
            else
            {
                throw new ArgumentException("Orb of Venom can only be used on characters in normal or weak state");
            }
        }
        public void Renew ()
        {
            this._isUsed = false;
        }
    }
}
