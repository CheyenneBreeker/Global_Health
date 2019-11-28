using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PegTool.Variables;
using System;

namespace PegTool.Units.Weapons
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Units/Weapon")]
    public class ScriptableWeapon : ScriptableObject
    {
#if UNITY_EDITOR
        //public List<Behaviors.UseWeaponsBehavior> PrefabsThatUseThisWeapon = new List<Behaviors.UseWeaponsBehavior>();
#endif
        public string weaponName;
        [MinMaxRange(0f, 500f)]
        public FloatRange damageRange;
        public float attacksSpeed;
        public float weaponRange;
        public bool hasMinimumRange;
        public float minimumRange;
        public CanTargetTypes canAttackTypes;
        public bool isRanged;
        public bool hasMultiTarget;
        public int numberOfAdditional;
        public float multiTargetDamageMultiplier;
        public float multiTargetRange;
        public GameObject rangedProjectile;
        public bool usesProjectile;
        public bool dealsAoeDamage;
        public float aoeRange;
        public float aoeDamageMultiplier;
        public AoeDamageSpreadMode aoeDamageSpreadMode;
        public AnimationCurve aoeSpreadCurve;
        public List<AnimationClip> attackAnimation;
        public List<AnimationClip> critAnimation;
        public List<AudioClip> attackSound;
        public List<AudioClip> critSound;
        [Range(0, 1)]
        public float critChance;
        public float critDamageMultiplier;
        [Multiline]
        public string weaponFlavorText;
        [Range(0, 1)]
        public List<float> AreaOfEffectTesters;
    }

    public enum AoeDamageSpreadMode
    {
        Constant,
        CurveEditor,
        Linear
    }
    [Flags]
    public enum CanTargetTypes
    {
        None = 0,
        Ground = 1,
        Air = 2
    }
}
