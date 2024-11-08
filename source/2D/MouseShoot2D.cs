using UnityEngine;
using VinoUtility;

public class MouseShoot2D : MonoBehaviour
{
    public float speed = 10f;
    public bool canShoot = true;
    public float liveTime = 5f;
    private float _shootTime;
    public AnimationCurve speedCurve;
    public Action<GameObject> onShoot;
    public void Shoot(GameObject projectile, Vector2 velocity)
    {
        projectile.transform.SetParent(null);
        var rig = projectile.GetComponent<Rigidbody2D>();
        rig.isKinematic = true;
        StartCoroutine(LerpUtility.Lerp(0,liveTime,liveTime,(t)=>{
            speed = speedCurve.Evaluate(t);
            rig.velocity = velocity * speed;
        }));
        onShoot?.Invoke(projectile);
    }
    // Update is called once per frame
    void Update()
    {
        if(canShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            canShoot = false;
            _shootTime = Time.time;
            Shoot(gameObject, transform.GetMouseVector2().normalized * speed);
        }
        if(!canShoot && Time.time - _shootTime > liveTime)
        {
            Destroy(gameObject);
        }
    }
}
