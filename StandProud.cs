using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class StandProud: Spell,IMagic
    {
        Wizard Caster;

        StandProud(Wizard caster) : base(85, false, true)
        {
            Caster = caster;

        }
        public override void SpellCast(Character target = null, uint force = 1)
        {

            if (target == null)
            {
                target = Caster;
            }
            try
            {
                CheckMana(Caster, minM);
                CheckAction(Caster);
            }
            catch (Exception) { }
            if (target.State == Character.States.Paralized)
            {
                Caster.MP -= minM;
                target.HP = 1;
                target.State = Character.States.Weak;
                target.CanMove = true;
            }
            else
                Console.WriteLine("The target is not Paralyzed!");
         
        }
    }
}
