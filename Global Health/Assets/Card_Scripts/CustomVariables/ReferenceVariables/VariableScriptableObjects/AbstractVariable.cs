using UnityEngine;

namespace PegTool.Variables
{
    public abstract class AbstractVariable<T> : ScriptableObject
    {
        [Multiline]
        public string DeveloperDescription = "";

        [MinMaxRange(-9001,9001)]
        public T Value;

        /// <summary>
        /// Sets the value of this variable to the param value
        /// </summary>
        /// <param name="value">Value this variable should equate too</param>
        public virtual void SetValue(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Sets the value of this variable to the param value
        /// </summary>
        /// <param name="value">Value this variable should equate too</param>
        public virtual void SetValue(AbstractVariable<T> value)
        {
            Value = value.Value;
        }

        /// <summary>
        /// Adds the amount to this Variables value.
        /// </summary>
        /// <param name="amount">The amount to add</param>
        public abstract void ApplyChange(T amount);

        /// <summary>
        /// Adds the amount to this Variables value.
        /// </summary>
        /// <param name="amount">The amount to add</param>
        public abstract void ApplyChange(AbstractVariable<T> amount);

    }

}
