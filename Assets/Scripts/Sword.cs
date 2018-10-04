using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sword : MonoBehaviour
{
    [SerializeField] MeleeWeapon weapon;
    public GameObject Pickups;

    private void Start()
    {
        weapon = GetComponent<MeleeWeapon>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Attack();
        }
        return;
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