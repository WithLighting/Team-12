using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onhit : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Weapon")
        {
            Destroy(this.gameObject);
        }
    }
}