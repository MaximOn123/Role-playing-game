using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Add_Health : Spell, IMagic
    {
        private uint heal;
        private Wizard Caster;
        private void CheckForce(uint force)
        {
            if (force < 1 || force > 4)
                throw new ArgumentException("Force entered incorrectly(1-4)!");
        }
        Add_Health(Wizard caster, uint mana) : base(mana, true, false)
        {
            Caster = caster;

        }

        public override void SpellCast(Character target = null, uint force = 1)
        {

            if (target == null)
            {
                target = Caster;
            }
            if (target.State != Character.States.Dead)
            {
                try
                {
                    CheckForce(force);
                    CheckMana(Caster, minM * force);
                    CheckVerbal(Caster);
                }
                catch (Exception) { }
                heal = minM * force / 2;
                if (target.HP + heal > target.MaxHP)
                {
                    Caster.MP -= minM * force;
                    target.HP = target.MaxHP;
                }
                else
                {
                    Caster.MP -= minM * force;
                    target.HP += heal;


                }
            }
            else Console.WriteLine("Your target is Dead!");
        }
    }
}
