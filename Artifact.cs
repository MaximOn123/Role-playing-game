using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    abstract class Artifact
    {
        public uint _power;
        public bool _renewable;
        public Artifact(uint Power, bool isRenewable) {
            _power = Power;
            _renewable = isRenewable;      
        }
        public bool IsRenewable() {
            return _renewable;
        
        }
    }
}
