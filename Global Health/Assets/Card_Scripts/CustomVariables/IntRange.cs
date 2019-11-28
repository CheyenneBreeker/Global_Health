using System;

namespace PegTool.Variables
{
    [Serializable]
    public class IntRange : AbstractRangeVariable<int>
    {
        public override int Center
        {
            get
            {
                return (this.minValue + this.maxValue) / 2;
            }
        }

        public override int GetRandomValue()
        {
            return UnityEngine.Random.Range(this.minValue, this.maxValue);
        }

        public override bool IsInRange(int valueToCheckIfIsInRange)
        {
            return (valueToCheckIfIsInRange > minValue && valueToCheckIfIsInRange < maxValue);
        }
    }
}
