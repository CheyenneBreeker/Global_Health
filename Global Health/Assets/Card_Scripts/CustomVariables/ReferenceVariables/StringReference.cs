using System;

namespace PegTool.Variables.ReferenceVariables
{
    [Serializable]
    public class StringReference : AbstractVariableReference<StringVariable, string>
    {
        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}
