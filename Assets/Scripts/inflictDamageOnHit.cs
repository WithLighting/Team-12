using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inflictDamageOnHit : MonoBehaviour {
    public int MainDamageOnHit = 10;
    public int DamageOnHit= 10;
    public int AttackLevel;
    void Update() {
        AttackLevel = GameObject.Find("Main_Char").GetComponent<Character1>().m_AttackLevel;

        if (AttackLevel <= 0)
        {
            DamageOnHit = 0;
        }

        else
        {
            DamageOnHit= MainDamageOnHit;
        }

}
}
