using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Vector3 moveVector = new Vector3(0, 1, 0);
    public int speed = 5;
    bool facingRight = true;
    bool noticed = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(noticed == false)
        {
            // transform.Translate(moveVector * speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);

            if (transform.position.z <= -3.0f && facingRight == false)
            {
                transform.rotation = Quaternion.Euler(rot);
                facingRight = true;
            }
            if (transform.position.z >= 3.0f && facingRight == true)
            {
                transform.rotation = Quaternion.Euler(rot);
                facingRight = false;
            }
        }
        else
        {

        }
    }

    public void OnTriggerStay(Collider other)
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
    }
}
