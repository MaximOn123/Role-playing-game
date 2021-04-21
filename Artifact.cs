using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    abstract class Artifact : IMagic
    {
        public uint _power;
        public bool _renewable;
        public Artifact(uint power, bool isRenewable)
        {
            _power = power;
            _renewable = isRenewable;
        }
        public bool IsRenewable()
        {
            return _renewable;
        }
        public abstract void Use(Character character = null, uint force = 1);
    }
}
