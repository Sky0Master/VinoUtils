using System.Linq;
using UnityEngine;

public class SeqMove : MonoBehaviour
{
    public Transform[] wayPoints;
    public float moveSpeed = 1f;
    int curIndex;
    public bool isLoop = false;
    public bool isReverseLoop = false;
    int delta;
    bool useChildren = false;
    public Transform parentNode;
    void Start()
    {
        if(parentNode!=null)
            useChildren = true;

        curIndex = 0;
        delta = 1;
        if(useChildren)
        {
            wayPoints = new Transform[parentNode.childCount];
            for(int i = 0; i < parentNode.childCount; i++)
            {
                wayPoints[i] = parentNode.GetChild(i);
            }
        }
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, wayPoints[curIndex].position) < 0.1f)
        {
            curIndex += delta;
        }
        if(curIndex < wayPoints.Length && curIndex >= 0)
        {
           transform.position = Vector3.MoveTowards(transform.position, wayPoints[curIndex].position, moveSpeed * Time.deltaTime);
        }
        else if(isReverseLoop) {
                delta = -delta;
                curIndex += delta;
        }
        else if(isLoop)
        {
            curIndex = 0;
        }
        else{
            gameObject.SetActive(false);
        }
    }
}
