using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public bool isDead = false;
    public int speed = 8;
    public bool jumping = false;
    public Rigidbody rb;
    public int jumpForce = 5;

    public GameObject StealthSkin;
    public GameObject NormalSkin;
    // Start is called before the first frame update
    void Start()
    {
        StealthSkin.SetActive(false);
        NormalSkin.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }

            if (Input.GetButtonDown("Jump") && jumping == false)
            {
                jumping = true;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            if(Input.GetKey(KeyCode.E))
            {
                StealthSkin.SetActive(true);
                NormalSkin.SetActive(false);
            }
            else
            {
                StealthSkin.SetActive(false);
                NormalSkin.SetActive(true);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumping = false;
        }
    }
}
