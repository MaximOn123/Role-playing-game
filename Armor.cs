using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Role_playing_game
{
    class Armor : Spell
    {
        const uint ArmorManaCost = 50;
        const uint ArmorDuration = 5000;
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
        private static void Invulnerability(object info)
        {
            Thread.Sleep((info as ArmorInfo).Time);
        }
        public override void SpellCast(Character target = null, uint force = 1)
        {
            if (target == null)
            {
                target = Caster;
            }
            CheckForce(force);
            CheckMana(Caster, ManaCost * force);
            CheckVerbal(Caster);
            Caster.MP -= (int)(ManaCost * force);
            target.ArmorThread = new Thread(Invulnerability);
            target.ArmorThread.Start(new ArmorInfo(ArmorDuration * force));
        }
    }
    class ArmorInfo
    {
        private uint _time;
        public int Time
        {
            get
            {
                return (int)_time;
            }
            set
            {
                _time = (uint)value;
            }
        }
        public ArmorInfo (uint time)
        {
            _time = time;
        }
    }
}
