using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class HealingSalve : Artifact
    {
        public enum Sizes { Small, Medium, Big };
        private Sizes _size;
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
        public HealingSalve(Character User, Sizes Size) : base(0, false)
        {
            _size = Size;
            _user = User;
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
                uint heal;
                if (_size == Sizes.Small)
                {
                    heal = 10;
                }
                else if (_size == Sizes.Medium)
                {
                    heal = 25;
                }
                else
                {
                    heal = 50;
                }
                target.HP += (int)heal;
            }
            else
            {
                throw new ArgumentException("Salve must not be empty!");
            }
        }
    }

}

