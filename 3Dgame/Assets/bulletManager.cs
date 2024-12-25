using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 40,ForceMode.Impulse);
        //Impulseˆêu‚¾‚¯—Í‚ğ‰Á‚¦‚é
    }
 
}
