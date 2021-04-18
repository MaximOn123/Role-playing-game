using System;
using System.Collections.Generic;
using System.Text;


namespace Role_playing_game
{
    interface IMagic
    {
        void Use(Character character = null, uint force = 1);
    }
}
