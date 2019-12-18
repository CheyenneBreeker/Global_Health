using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIP : MonoBehaviour
{
    string ipv4 = IPManager.GetIP(ADDRESSFAM.IPv4);

    string ipv6 = IPManager.GetIP(ADDRESSFAM.IPv6);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ipv4);
        Debug.Log(ipv6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
