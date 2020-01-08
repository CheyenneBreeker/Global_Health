using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a simple script that destroys an item after a little while to optimize performance, used for the carboard box animation
public class DestroyAfterTime : MonoBehaviour
{
    public int secondsBeforeDestruction = 4;
    public bool timerActive = false;

    private float currentTimer;

    void Start()
    {
        currentTimer = secondsBeforeDestruction * 60;
    }

    void FixedUpdate()
    {
        if (currentTimer > 0 && timerActive)
        {
            currentTimer--;
        }
        
        if(currentTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ActivateTimer()
    {
        timerActive = true;
    }
}
