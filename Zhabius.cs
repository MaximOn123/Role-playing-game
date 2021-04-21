using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Zhabius : Artifact
    {
        private Character _user;
        private bool _isEmpty = false;
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            private set
            {
                _isEmpty = value;
            }
        }
        public Zhabius(Character user) : base(0, false)
        {
            _user = user;
        }
        public override void Use(Character target = null, uint force = 1)
        {
            if (!this._isEmpty)
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
                this._isEmpty = true;
            }
            else
            {
                throw new ArgumentException("This bottle is empty!");
            }
        }
    }
}
