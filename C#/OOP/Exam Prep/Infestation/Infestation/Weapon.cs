using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Weapon : SupplementBase , ISupplement
    {
        private const int WeapPower = 10;
        private const int WeapAggression = 3;
        private const int WeapHealth = 0;

        public Weapon()
            : base(0, 0, 0)
        {
            
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if(otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = Weapon.WeapPower;
                this.AggressionEffect = Weapon.WeapAggression;
                this.HealthEffect = Weapon.WeapHealth;
            }
        }
    }
}
