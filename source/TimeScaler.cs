using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VinoUtility;

public class TimeScaler : MonoBehaviour
{
    public float minTimeScale = 0.5f;
    public float duration = 0.5f;
    public float stopTime = 1f;

    IEnumerator TimeStop(float minTimeScale,float duration)
    {
        yield return StartCoroutine(LerpUtility.Lerp(1f,minTimeScale,duration, (x) => Time.timeScale = x));
        yield return new WaitForSecondsRealtime(stopTime);
        yield return StartCoroutine(LerpUtility.Lerp(minTimeScale,1f,duration, (x) => Time.timeScale = x));
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(TimeStop(minTimeScale,duration));
        }
    }
}
