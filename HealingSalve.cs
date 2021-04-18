using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class HealingSalve : Artifact, IMagic
    {
        public enum Sizes { Small, Medium, Big };
        Sizes _size;
        Character _user;
        public HealingSalve(Character User, Sizes Size) : base(0, true)
        {

            _size = Size;
            _user = User;

        }
        public void SpellCast(Character target = null, uint force = 1) {
            if (this.IsRenewable())
            {
                if (target == null) target = _user;
                uint heal;
                if (_size == Sizes.Small) heal = 10;
                else if (_size == Sizes.Medium) heal = 25;
                else heal = 50;
                if (target.HP + heal > target.MaxHP) target.HP = target.MaxHP;
                else target.HP += heal;
            }
            else Console.WriteLine("This bottle is empty!");
        
        }
    }

}

