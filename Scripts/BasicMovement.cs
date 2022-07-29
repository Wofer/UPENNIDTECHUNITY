using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Vector3 moveVector = new Vector3(0, 1, 0);
    public int speed = 5;
    bool facingRight = true;
    public bool noticed = false;
    Vector3 LeftLimit;
    Vector3 RightLimit;
    public float Range = 6;
    public GameObject player;
    float radius = 25;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<UnStealthScript>().gameObject;
        LeftLimit = new Vector3(transform.position.x, transform.position.y, transform.position.z - Range / 2f);
        RightLimit = new Vector3(transform.position.x, transform.position.y, transform.position.z + Range / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(player.transform.position, transform.position);
        noticed = Distance <= radius && player.CompareTag("Unstealth");
        
        if (noticed == false)
        {
            // transform.Translate(moveVector * speed * Time.deltaTime);
           //Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
            if(facingRight)
            {
                transform.LookAt(RightLimit);
            }
            else
            {
                transform.LookAt(LeftLimit);
            }

            if (transform.position.z <= LeftLimit.z && facingRight == false)
            {
                facingRight = true;
            }
            if (transform.position.z >= RightLimit.z && facingRight == true)
            {
                facingRight = false;
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {

        }
    }

    /*public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Unstealth"))
        {
            noticed = true;
        }
        else
        {
            noticed = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Unstealth"))
        {
            noticed = false;
        }
    }*/
}
