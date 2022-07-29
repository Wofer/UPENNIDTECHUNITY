using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    float speed = 4;
    float radius = 25;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<UnStealthScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(player.transform.position, transform.position);
        if (Distance <= radius && player.CompareTag("Unstealth"))
        {
            transform.LookAt(player.transform);
        }
    }

    /*public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Unstealth"))
        {
            transform.LookAt(Vector3.Distance);
        }
    }*/
}
