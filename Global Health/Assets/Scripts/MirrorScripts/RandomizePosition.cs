using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_RandomizePosition());
    }

    private IEnumerator _RandomizePosition()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        Vector3 startPosition = transform.position;

        while (true)
        {
            transform.position = startPosition + ReturnRandom();
            yield return wait;
        }
    }

    private Vector3 ReturnRandom()
    {
        return new Vector3(
            Random.Range(-4.0f, 4.0f),
            Random.Range(-4.0f, 4.0f),
            0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
