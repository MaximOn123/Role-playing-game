using System;
using System.Collections.Generic;
using System.Text;

namespace Role_playing_game
{
    class Cure : Spell,IMagic
    {
        Wizard Caster;
        Cure(Wizard caster) : base(20, false, true)
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
            if (target.State == Character.States.Sick)
            {
                Caster.MP -= minM;
                target.State = Character.States.Weak;
            }
            else 
                Console.WriteLine("The target is not Sick!");
            
            
        }
    }
}
