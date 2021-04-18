using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Clarity : Artifact
    {
        public enum Sizes { Small, Medium, Big }
        private Sizes _size;
        private Wizard _user;
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
        public Clarity(Wizard user, Sizes size) : base(0, false)
        {
            _user = user;
            _size = size;
        }
        public override void Use(Character target = null, uint force = 1)
        {
            if (!IsEmpty)
            {
                IsEmpty = true;
                if (target == null)
                {
                    target = _user;
                }
                if (target is Wizard)
                {
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
                else
                {
                    throw new ArgumentException("You are not smart enough to use it!");
                }
            }
            else
            {
                throw new ArgumentException("This bottle is empty!");
            }
        }
    }
}
