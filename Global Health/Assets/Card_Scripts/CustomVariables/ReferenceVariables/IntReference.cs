using System;

namespace PegTool.Variables.ReferenceVariables
{
    [Serializable]
    public class IntReference : AbstractVariableReference<IntVariable, int>
    {
        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}
