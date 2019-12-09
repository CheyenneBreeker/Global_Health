using System;

namespace PegTool.Variables.ReferenceVariables
{
    [Serializable]
    abstract public class AbstractVariableReference<T, U>
        where T : AbstractVariable<U>
    {
        public bool UseConstant = true;
        public U ConstantValue;
        public T Variable;

        public U Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator U(AbstractVariableReference<T, U> reference)
        {
            return reference.Value;
        }
    }
}
