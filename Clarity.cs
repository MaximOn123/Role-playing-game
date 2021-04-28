using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Clarity : Artifact
    {
        public enum Sizes { Small, Medium, Big }
        private Sizes _size;
        private Character _user;
        public Clarity(Character user, Sizes size) : base(0, false)
        {
            _user = user;
            _size = size;
        }
        public override void Use(Character target = null, uint force = 1)
        {
            if (target == null)
            {
                target = _user;
            }
            if (!(target is Wizard))
            {
                throw new ArgumentException("Calrity target must be a wizard");
            }
            uint mana;
            if (_size == Sizes.Small)
            {
                mana = 10;
            }
            else if (_size == Sizes.Medium)
            {
                mana = 25;
            }
            else
            {
                mana = 50;
            }
            (target as Wizard).MP += (int)mana;
        }
    }
}
