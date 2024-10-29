using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBreak : MonoBehaviour
{

    MeshFilter meshFilter;
    public Transform center;
    public float radius = 5f;

    
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        var vertics = new Vector3[meshFilter.mesh.vertices.Length];
        for(int i =0;i<vertics.Length;i++)
        {
            var v = meshFilter.mesh.vertices[i];
            vertics[i] = v;
            //Debug.Log("vertics[" + i + "] = " + vertics[i]);
            var worldV = transform.TransformPoint(v);
            if(Vector3.Distance(worldV ,center.position) < radius)
            {
                vertics[i] = transform.InverseTransformPoint(worldV + radius * (worldV - center.position).normalized);
                Debug.Log("vertics[" + i + "] = " + vertics[i]);
            }

        }
        meshFilter.mesh.vertices = vertics;
        meshFilter.mesh.RecalculateNormals();
        
    }
}
