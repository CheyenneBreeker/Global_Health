using UnityEngine;
using UnityEngine.UI;
using PegTool.Variables;
using System.Collections.Generic;

namespace PegTool.Units.Weapons
{
    [System.Serializable]
    public class Weapon
    {
        public string weaponName;
        [MinMaxRange(float.MinValue, float.MaxValue)]
        public FloatRange damageRange;
        public float weaponRange;
        public float minimumRange;
        public float attackSpeed;
        public bool isRanged;
        public CanTargetTypes canAttackTypes;
        public int numberOfAdditional;
        public float multiTargetDamageMultiplier;
        public float multiTargetRange;
        public GameObject rangedProjectile;
        public bool usesProjectile;
        public bool dealsAoeDamage;
        public float AoeRange;
        public float AoeDamageMultiplier;
        public AoeDamageSpreadMode aoeDamageSpreadMode;
        public AnimationCurve aoeSpreadCurve;
        public List<AnimationClip> attackAnimation;
        public List<AnimationClip> critAnimation;
        public List<AudioClip> attackSound;
        public List<AudioClip> critSound;
        public float critChance;
        public float critDamageMultiplier;
        [Multiline]
        public string weaponFlavorText;

        public Vector3 projectileSpawnOffset;

        public float cooldown = 0;
        
        public Weapon(ScriptableWeapon weapon)
        {
            this.weaponName =           weapon.weaponName;
            this.damageRange =          weapon.damageRange;
            if (weapon.hasMinimumRange)
                this.minimumRange =     weapon.minimumRange;
            else
                this.minimumRange =     0;
            this.weaponRange =          weapon.weaponRange;
            this.attackSpeed =          1 / weapon.attacksSpeed;//codewise we want to time between attacks, not the attacks per second.
            this.canAttackTypes =       weapon.canAttackTypes;
            this.isRanged =             weapon.isRanged;
            if (weapon.hasMultiTarget && weapon.isRanged)
            {
                this.numberOfAdditional = System.Math.Abs(weapon.numberOfAdditional);
                this.multiTargetRange = weapon.multiTargetRange;
                this.multiTargetDamageMultiplier = weapon.multiTargetDamageMultiplier;
            }
            else
            {
                this.multiTargetDamageMultiplier = 0;
                this.multiTargetRange = 0;
                this.numberOfAdditional = 0;
            }

            this.usesProjectile =       weapon.usesProjectile;
            if (usesProjectile)
                this.rangedProjectile = weapon.rangedProjectile;
            else
                this.rangedProjectile = null;

            this.dealsAoeDamage =       weapon.dealsAoeDamage;
            if (dealsAoeDamage)
            {
                this.AoeRange =         weapon.aoeRange;
                this.AoeDamageMultiplier = weapon.aoeDamageMultiplier;
                this.aoeDamageSpreadMode = weapon.aoeDamageSpreadMode;
                if (this.aoeDamageSpreadMode == AoeDamageSpreadMode.CurveEditor)
                    this.aoeSpreadCurve = weapon.aoeSpreadCurve;
                else
                    this.aoeSpreadCurve = null;
            }
            else
            {
                this.AoeRange =             0;
                this.AoeDamageMultiplier =  0;
                this.aoeDamageSpreadMode =  AoeDamageSpreadMode.Linear;//if a unit gets AoE, he will default to linear
                this.aoeSpreadCurve =       null;
            }
            this.attackAnimation =      weapon.attackAnimation;
            this.critAnimation =        weapon.critAnimation;
            this.critChance =           weapon.critChance;
            this.critDamageMultiplier = weapon.critDamageMultiplier;
            this.weaponFlavorText =     weapon.weaponFlavorText;
            this.attackSound =          weapon.attackSound;
            this.critSound =            weapon.critSound;
        }

        public float CalculateSplashDamage(float mainAttackDamage, float enemyDistance)
        {
            float multipliedDamage = mainAttackDamage * AoeDamageMultiplier;
            if (multipliedDamage <= 0)
                return 0;

            switch (this.aoeDamageSpreadMode)
            {
                case AoeDamageSpreadMode.Constant:
                    return multipliedDamage;
                case AoeDamageSpreadMode.CurveEditor:
                    return multipliedDamage * (1 - aoeSpreadCurve.Evaluate(enemyDistance / this.AoeRange));
                case AoeDamageSpreadMode.Linear:
                    return Mathf.Lerp(multipliedDamage, 0, 1 - (enemyDistance / this.AoeRange));
                default:
                    Debug.LogError("A new AoEDamageSpreadMode must have been added. Please add support for it.");
                    return 0;

            }
        }
    }
}