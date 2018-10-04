using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisononhit : MonoBehaviour
{
    public GameObject pickup;


    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerStay(Collider collider)
    {
        print(collider.name);
        if (collider.tag == "enemy")
        {
            Destroy(collider.gameObject);
        }
    }
}