using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookatCamera : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Update()
    {
        Vector3 targetPostition = new Vector3(target.position.x,
                                       this.transform.position.y,
                                       target.position.z);
        this.transform.LookAt(targetPostition);
    }
}
