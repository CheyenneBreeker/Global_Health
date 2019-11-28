using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ListExtension
{
    public static T GetRandomFromList<T>(this List<T> list)
    {
        if (list.Count == 0 || list == null)
            return default(T);
        return list[Random.Range(0, list.Count)];
    }
}
