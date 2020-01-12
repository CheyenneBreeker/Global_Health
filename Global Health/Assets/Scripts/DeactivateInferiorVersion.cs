using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInferiorVersion : MonoBehaviour
{
    public GameObject oldVersion;
    // Start is called before the first frame update
    void Start()
    {
        oldVersion.SetActive(false);
    }
}
