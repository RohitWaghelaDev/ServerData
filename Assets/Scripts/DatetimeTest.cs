using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DatetimeTest : MonoBehaviour
{

    DateTime creationTime;

    // Start is called before the first frame update
    void Start()
    {
        creationTime = DateTime.UtcNow;
        Debug.Log(creationTime);
        Invoke("Timer", 240);
    }

    public void Timer()
    {
        DateTime currentTime = DateTime.Now;
        Debug.Log(currentTime);

        int minutes = (creationTime - currentTime).Minutes;
        Debug.Log("Time Passed" + minutes);
    }
}
