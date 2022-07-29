using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelScript : MonoBehaviour
{
    bool exploding;
    float tolerance = 1.25f;

    void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > tolerance) {
            triggerExplosionWithDelay(.1f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.CompareTag("Ground")) {
            triggerExplosionWithDelay(.1f);
        }
    }

    public void triggerExplosion()
    {
        GetComponent<ExplosionScript>().Explode();
        Destroy(gameObject);
    }

    public void triggerExplosionWithDelay(float delay)
    {
        if (!exploding) {
            exploding = true;
            Invoke("triggerExplosion", delay);
        }
    }
}
