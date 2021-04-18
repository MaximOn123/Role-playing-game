using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Add_Health : Spell
    {
        private uint _heal;
        private Wizard _caster;
        public Add_Health(Wizard caster, uint manaCost = 2) : base(manaCost, true, false)
        {
            _caster = caster;
        }
        public override void Use(Character target = null, uint force = 1)
        {
            if (target == null)
            {
                target = _caster;
            }
            if (target.State != Character.States.Dead)
            {
                CheckForce(force);
                CheckMana(_caster, ManaCost * force);
                CheckVerbal(_caster);
                _heal = ManaCost * force / 2;
                _caster.MP -= (int)(ManaCost * force);
                if (target.HP + _heal > target.MaxHP)
                {
                    target.HP = (int)target.MaxHP;
                }
                else
                {
                    target.HP += (int)_heal;
                }
            }
            else
            {
                throw new ArgumentException("Your target is dead!");
            }
        }
    }
}
