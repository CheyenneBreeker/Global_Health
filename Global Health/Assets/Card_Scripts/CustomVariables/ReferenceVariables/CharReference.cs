using System;

namespace PegTool.Variables.ReferenceVariables
{
    [Serializable]
    public class CharReference : AbstractVariableReference<CharVariable, char>
    {
        public static implicit operator char(CharReference reference)
        {
            return reference.Value;
        }
    }
}
