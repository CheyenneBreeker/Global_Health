using System.Collections.Generic;
using UnityEngine;

namespace PegTool.Variables.RuntimeSets
{
    public abstract class AbstractRuntimeSet<T> : ScriptableObject
    {
        public List<T> items = new List<T>();

        public bool Add(T objectToAdd)
        {
            //potentialy improve code below by using something else then List
            if (!items.Contains(objectToAdd))
            {
                items.Add(objectToAdd);
                return true;
            }
            return false;
        }

        public bool Remove(T objectToRemove)
        {
            if (items.Contains(objectToRemove))
            {
                items.Remove(objectToRemove);
                return true;
            }
            return false;
        }
    }
}