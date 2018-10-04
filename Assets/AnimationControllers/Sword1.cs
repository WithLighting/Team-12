using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sword1 : MonoBehaviour
{
    [SerializeField] MeleeWeapon weapon;

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
        if (collider.tag == "enemy")
        {
            Destroy(collider.gameObject);
        }
    }
}