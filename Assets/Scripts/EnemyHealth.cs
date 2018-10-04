using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour {
    public float Health = 30;
    private float CurrentHealth; 
   public int Damage;
    public GameObject HealthBar;
    public float CalcHChRatio;
    public int ScaleY = 1;

void Start() {
         CurrentHealth=Health ;

    }
    void Update (){
        


        if (Health <= 0) {

            Destroy(this.gameObject);

}
}
    void ApplyDamage() {

    }


    void OnTriggerExit(Collider collider) // does soemthing when collides with objects tagged as "weapon"
    {
        if (collider.gameObject.tag == "Weapon" )
       {

            Damage = GameObject.FindWithTag("Weapon").GetComponent<inflictDamageOnHit>().DamageOnHit;
            print("DamageINflict");
            Health -= Damage;
            CalcHChRatio = Health / CurrentHealth;

          HealthBar.transform.localScale = new Vector3(CalcHChRatio, ScaleY, transform.localScale.z);
            


        }
    } // inflict damage on hit 




}
