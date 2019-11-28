namespace PegTool.Variables
{
    public abstract class AbstractRangeVariable<T>
    {
        public T minValue;
        public T maxValue;

        public abstract T Center { get; }

        /// <summary>
        /// Gets a random value between this range variables min(including) and max(excluding)
        /// </summary>
        /// <returns>A random value between this range variables min(including) and max(excluding)</returns>
        abstract public T GetRandomValue();

        abstract public bool IsInRange(T valueToCheckIfIsInRange);

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.minValue, this.maxValue);
        }
    }
}