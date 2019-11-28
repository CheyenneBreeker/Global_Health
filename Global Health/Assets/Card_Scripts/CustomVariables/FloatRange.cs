using System;
using UnityEngine;

namespace PegTool.Variables
{
    [Serializable]
    public class FloatRange : AbstractRangeVariable<float>
    {
        public FloatRange(float min, float max)
        {
            this.minValue = min;
            this.maxValue = max;
        }

        public override float Center
        {
            get
            {
                return (this.minValue + this.maxValue) / 2;
            }
        }

        public override float GetRandomValue()
        {
            return UnityEngine.Random.Range(this.minValue, this.maxValue);
        }

        /// <summary>
        /// Returns the string using rounded values
        /// </summary>
        /// <returns>minValue - maxValue</returns>
        public virtual string ToRoundString()
        {
            return string.Format("{0} - {1}", Mathf.RoundToInt(this.minValue), Mathf.RoundToInt(this.maxValue));
        }

        /// <summary>
        /// Returns the string using ceiled values
        /// </summary>
        /// <returns>minValue - maxValue</returns>
        public virtual string ToCeilingString()
        {
            return string.Format("{0} - {1}", Mathf.CeilToInt(this.minValue), Mathf.CeilToInt(this.maxValue));
        }

        /// <summary>
        /// Returns the string using floored values
        /// </summary>
        /// <returns>minValue - maxValue</returns>
        public virtual string ToFloorString()
        {
            return string.Format("{0} - {1}", Mathf.FloorToInt(this.minValue), Mathf.FloorToInt(this.maxValue));
        }

        public override bool IsInRange(float valueToCheckIfIsInRange)
        {
            return (valueToCheckIfIsInRange > minValue && valueToCheckIfIsInRange < maxValue);
        }
    }
}
