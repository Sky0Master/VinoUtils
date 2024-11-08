using System;
using UnityEngine;
using VinoUtility;

public class AutoGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    
    public float interval = 1f;
    public bool isRandom;
    
    public bool isRunning;
    
    public bool asSon = true;
    float _lastGenerateTime;

    int _index = 0;
    
    public Action<GameObject> onGenerate;
    public void StartGenerate()
    {
        isRunning = true;
    }
    public void StopGenerate()
    {
        isRunning = false;
    }
    public void Generate()
    {
        if(isRandom)
        {
            _index = UnityEngine.Random.Range(0, prefabs.Length);
        }
        GameObject obj = Instantiate(prefabs[_index]);
        obj.transform.position = transform.position;
        if(asSon)
            obj.transform.SetParent(transform);
    
        _index = (_index + 1) % prefabs.Length;
        onGenerate?.Invoke(obj);
    }
    void Update()
    {
        if(!isRunning)
            return;
        if(Time.time - _lastGenerateTime >= interval)
        {
            Generate();
            _lastGenerateTime = Time.time;
        }
    }

    // Example
    // private void Start() {
    //     onGenerate += (obj) => {
    //         GetComponent<RotateSon2D>().MakeUniform(transform.GetActiveChildren());
    //     };
    // }
}
