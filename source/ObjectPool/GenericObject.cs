using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VinoUtils.ObjectPool 
{
public class GenericObject : MonoBehaviour, IPooledObject
{
    public float timeToDestroy = 3f;
    public float countDownTimer = 3f;
    public string poolTag;
    public bool isActive = false;

    public void OnRequestedFromPool()
    {
        isActive = true;
        countDownTimer = timeToDestroy;
    }

    public void DiscardToPool()
    {
        ObjectPooler.Instance.ReturnToPool(poolTag, this.gameObject);
        isActive = false;
    }

    void Update()
    {
        if (isActive)
        {
            countDownTimer -= Time.deltaTime;
            if (countDownTimer <= 0f)
            {
                DiscardToPool();
            }
        }
    }
}
}