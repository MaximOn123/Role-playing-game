using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Antidote : Spell
    {
        const uint AntidoteManaCost = 30;
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
                    throw new ArgumentNullException("Caster must not be null!");
                }
                if (value.State == Character.States.Dead)
                {
                    throw new ArgumentException("Caster must not be dead!");
                }
                _caster = value;
            }
        }
        public Antidote(Wizard caster) : base(AntidoteManaCost, true, true)
        {
            Caster = caster;

        }
        public override void Use(Character target = null, uint force = 1)
        {
            CheckMana(Caster, ManaCost);
            CheckAction(Caster);
            CheckVerbal(Caster);
            if (target == null)
            {
                target = Caster;
            }
            if (target.State == Character.States.Poisoned)
            {
                Caster.MP -= (int)ManaCost;
                target.State = Character.States.Normal;
                target.NormalizeState();
            }
            else
            {
                Console.WriteLine("The target is not poisoned!");
            }
        }
    }
}
