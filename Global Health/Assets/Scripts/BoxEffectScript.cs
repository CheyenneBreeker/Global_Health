using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEffectScript : MonoBehaviour
{
    public GameObject buildingToCover;

    private Animator boxAnimator;
    // Start is called before the first frame update
    void Start()
    {
        boxAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // The building will remain inactive untill it is fully built, only then should we start removing the box animation
        if(buildingToCover.activeInHierarchy)
        {
            StopLooping();
        }
    }

    //Stops the animation loop
    public void StopLooping()
    {
        boxAnimator.SetBool("ShouldLoop", false);
        gameObject.GetComponent<DestroyAfterTime>().ActivateTimer();
    }
}
