using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Unstealth"))
        {
            
        }
    }
}
