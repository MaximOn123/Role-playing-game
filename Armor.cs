using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Armor : Spell
    {
        const uint ArmorManaCost = 50;
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
                _caster = value;
            }
        }
        public Armor(Wizard caster) : base(ArmorManaCost, true, false)
        {
            Caster = caster;
        }
        public override void SpellCast(Character target = null, uint force = 1)
        {
            if (target == null)
            {
                target = Caster;
            }
            CheckMana(Caster, ManaCost * force);
            CheckVerbal(Caster);
            Caster.MP -= (int)(ManaCost * force);
        }
    }
}
