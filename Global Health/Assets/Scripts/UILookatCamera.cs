using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookatCamera : MonoBehaviour
{
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera");
    }
    // Start is called before the first frame update
    void Update()
    {
        Vector3 targetPostition = new Vector3(target.gameObject.transform.position.x,
                                       this.transform.position.y,
                                       target.gameObject.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
}
