using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RandomizedPosition : NetworkBehaviour
{
    [SerializeField]
    private Transform _child;

    //This makes it so that the code is only ran on the client
    //Think of it as a basic Start() method, but if one were to add this in there
    //there would be a "desync" between the host and client
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        StartCoroutine(__RandomizePosition());
    }

    private IEnumerator __RandomizePosition()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        Vector3 startPosition = transform.position;

        while (true)
        {
            transform.position = startPosition + ReturnRandom();
            _child.localPosition = ReturnRandom();
            yield return wait;
        }
    }

    private Vector3 ReturnRandom()
    {
        return new Vector3(
        Random.Range(-4f, 4f),
        Random.Range(-4f, 4f),
        0f);
    }
}
