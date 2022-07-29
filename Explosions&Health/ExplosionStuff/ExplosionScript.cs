using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float blastRadius;
    public float blastForce;

    public bool testButton;

    public List<GameObject> explosionParticles = new List<GameObject>();

    void Start()
    {
        //Explode();
    }

    private void Update()
    {
        if (testButton) { Explode(); testButton = false; }
    }

    public void Explode()
    {
        Collider[] objectsWithinRadius = Physics.OverlapSphere(transform.position, blastRadius);
        Debug.Log(objectsWithinRadius.Length);

        GameObject particles = Instantiate(explosionParticles[Random.Range(0, explosionParticles.Count)], transform.position, Quaternion.identity);
        particles.transform.localScale = Vector3.one * blastRadius * .0075f;
        Destroy(particles, 7.5f);

        foreach (Collider objectHit in objectsWithinRadius) {
            Vector3 dir = (objectHit.transform.position - transform.position).normalized;
            RaycastHit hit;

            float dis = Vector3.Distance(objectHit.transform.position, transform.position);
            float appliedForce = blastForce * (1 - dis / blastRadius);

            if (Physics.Raycast(transform.position, dir, out hit, blastRadius)) {
                if (hit.transform.GetComponent<Rigidbody>() != null) {
                    Rigidbody rb = hit.transform.GetComponent<Rigidbody>();

                    //Debug.Log(appliedForce);
                    rb.AddForce(dir * appliedForce, ForceMode.Impulse);

                    //if dealing damage:
                    //check if enemy/has the health-bearing script
                    //if so, write equation using 'appliedForce'iy
                }
                if (hit.transform.GetComponent<ExplosiveBarrelScript>() != null) {
                    hit.transform.GetComponent<ExplosiveBarrelScript>().triggerExplosionWithDelay(Random.Range(.1f, .4f));
                }
                if (hit.transform.GetComponent<BaseEnemyScript>() != null) {
                    hit.transform.GetComponent<BaseEnemyScript>().dealDamage(appliedForce);
                }
            }
        }
    }
}
