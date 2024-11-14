using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace VinoUtility{
public class TransformTransition : MonoBehaviour
{
    public Transform endTrans;
    
    public float duration = 1f;
    public UnityEvent endEvent;

    public void Play()
    {
        var stPos = transform.position;
        var stRot = transform.rotation;
        var stScale = transform.localScale;

        StartCoroutine(LerpUtility.Lerp(stPos,endTrans.position,duration, pos => transform.position = pos));
        StartCoroutine(LerpUtility.Lerp(stRot.eulerAngles,endTrans.rotation.eulerAngles,duration, rot => transform.rotation = Quaternion.Euler(rot)));
        StartCoroutine(LerpUtility.Lerp(stScale,endTrans.localScale,duration, scale => transform.localScale = scale, ()=>{endEvent?.Invoke();}));
    }
}
}