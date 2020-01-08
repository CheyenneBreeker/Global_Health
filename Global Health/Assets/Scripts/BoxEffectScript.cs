using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEffectScript : MonoBehaviour
{
    public bool shouldLoop;

    private Animator boxAnimator;
    // Start is called before the first frame update
    void Start()
    {
        boxAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!shouldLoop)
        {
            StopLooping();
            gameObject.GetComponent<DestroyAfterTime>().ActivateTimer();
        }
    }

    //Stops the animation loop
    public void StopLooping()
    {
        boxAnimator.SetBool("ShouldLoop", false);
    }
}
