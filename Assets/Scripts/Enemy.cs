using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int e_speed = 5;
    public float range = 5;
    public bool detected;
    public Rigidbody e_basic;
    public Character1 playerCharacter;

    private void Awake()
    {
        if (playerCharacter == null)
            playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Character1>();

        e_basic = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Vector3 fromEnemyToPlayer = playerCharacter.transform.position - transform.position;
        if (fromEnemyToPlayer.magnitude <= range)
        {
            e_basic.MovePosition(transform.position + fromEnemyToPlayer.normalized * e_speed * Time.deltaTime);
        }
    }


}
