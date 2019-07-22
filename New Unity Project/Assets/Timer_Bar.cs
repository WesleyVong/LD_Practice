using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Bar : MonoBehaviour
{
    private float timer;

    private float maxTime;

    private Vector3 origScale;
    private Vector3 targetScale;

    public bool completed;

    private void Start()
    {
        origScale = transform.localScale;
    }

    private void Update()
    {
        if (timer > 0)
        {
            completed = false;
            timer -= Time.deltaTime;

            targetScale.x = origScale.x * (timer/maxTime);
            transform.localScale = targetScale;
        }
        else
        {
            completed = true;
            targetScale.x = 0;
            transform.localScale = targetScale;
        }
    }

    public void SetTimer(float time)
    {
        maxTime = time;
        timer = maxTime;
        transform.localScale = origScale;
        targetScale = origScale;
        completed = false;
    }
}
