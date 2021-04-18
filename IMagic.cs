using System;
using System.Collections.Generic;
using System.Text;


namespace Role_playing_game
{
    interface IMagic
    {
        void SpellCast(Character character = null, uint force = 1);
    }
}
