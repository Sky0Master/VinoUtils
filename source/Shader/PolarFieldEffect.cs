using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PolarFieldEffect : MonoBehaviour
{
    Material _effectMaterial;
    public Shader effectShader;

    
    public float radius = 1f;
    
    public float maxEffectRadius = 10f;

    public string targetTag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        _effectMaterial = new Material(effectShader);
    }
    public void UpdateMaterialParams()
    {
        var targets = FindObjectsByType<SpriteRenderer>(FindObjectsSortMode.None).ToList();
        foreach(var target in targets)
        {
            if(target.gameObject.tag != targetTag) continue;
            if(Vector2.Distance(target.transform.position,transform.position) > maxEffectRadius)
                continue;
            if(target.material.shader != _effectMaterial.shader)
                target.material = _effectMaterial;
            target.material.SetVector("_CenterPosition",transform.position);
            target.material.SetFloat("_Size",radius);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMaterialParams();
    }
}
