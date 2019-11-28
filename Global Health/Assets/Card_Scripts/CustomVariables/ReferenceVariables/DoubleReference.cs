using System;

namespace PegTool.Variables.ReferenceVariables
{
    [Serializable]
    public class DoubleReference : AbstractVariableReference<DoubleVariable, double>
    {
        public static implicit operator double(DoubleReference reference)
        {
            return reference.Value;
        }
    }
}
