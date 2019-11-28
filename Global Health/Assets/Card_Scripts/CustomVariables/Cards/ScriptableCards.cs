using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "New Playing Card")]
public class ScriptableCard : ScriptableObject
{
        public string cardName;
        public float cardCost;
        [Multiline]
        public string cardFlavorText;
        
    
}

