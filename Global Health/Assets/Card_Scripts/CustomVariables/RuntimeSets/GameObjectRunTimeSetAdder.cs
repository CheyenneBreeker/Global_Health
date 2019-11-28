using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PegTool.Variables.RuntimeSets;

public class GameObjectRunTimeSetAdder : MonoBehaviour {
    
    public GameObjectRuntimeSet setToAddThis;
    public void OnEnable() { setToAddThis.Add(this.gameObject); }
    public void OnDisable() { setToAddThis.Remove(this.gameObject); }
}

