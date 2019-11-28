using UnityEngine;
namespace PegTool.Variables
{
    [CreateAssetMenu(fileName = "NewFloatRangeVariable", menuName = "ReferenceVariables/FloatRangeVariable")]
    public class FloatRangeVariable : AbstractVariable<FloatRange>
    {
        public override void ApplyChange(FloatRange amount)
        {
            Value.minValue += amount.minValue;
            Value.maxValue += amount.maxValue;
        }

        public override void ApplyChange(AbstractVariable<FloatRange> amount)
        {
            Value.minValue += amount.Value.minValue;
            Value.maxValue += amount.Value.maxValue;
        }
    }
}
