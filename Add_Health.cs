using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Add_Health : Spell
    {
        private uint _heal;
        private Wizard _caster;
        private Wizard Caster
        {
            get
            {
                return _caster;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Caster must not be null!");
                }
                if (value.State == Character.States.Dead)
                {
                    throw new ArgumentException("Caster must not be dead!");
                }
                _caster = value;
            }
        }
        public Add_Health(Wizard caster, uint manaCost = 2) : base(manaCost, true, false)
        {
            Caster = caster;
        }
        public override void Use(Character target = null, uint force = 1)
        {
            if (target == null)
            {
                target = Caster;
            }
            if (target.State == Character.States.Dead)
            {
                throw new ArgumentException("Your target is dead!");
            }
            CheckForce(force);
            CheckMana(Caster, ManaCost * force);
            CheckVerbal(Caster);
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
    }
}
