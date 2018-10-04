using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP_ : MonoBehaviour {
 public int SpinSpeed;
    public int UPnDownSpeed;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        transform.Rotate(Vector3.up * SpinSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * UPnDownSpeed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            this.gameObject.SetActive(false);
        }
    }

}
