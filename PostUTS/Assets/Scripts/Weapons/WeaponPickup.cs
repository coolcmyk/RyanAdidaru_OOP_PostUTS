using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder;
    Weapon weapon;

    void Awake(){
      if(weapon == null)
      {
        weapon = weaponHolder;
      }
    }

    void Start(){
      if(weapon != null){
        TurnVisual(false);
      }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Objek Player Memasuki trigger");
            weapon.transform.parent = other.transform;
            TurnVisual(true, weapon);
            Player.Instance.weaponState = true;
        }
        else{
            Debug.Log("Objek Player tidak Memasuki trigger");
            TurnVisual(false);
        }
    }
     

    void TurnVisual(bool on){
      if(on){
        weapon.GetComponent<SpriteRenderer>().enabled= on;
        weapon.transform.localPosition = new Vector2(0, 0);
      }
    }

    void TurnVisual(bool on, Weapon weapon){
      if(on){
        weapon.GetComponent<SpriteRenderer>().enabled = on;
        weapon.transform.localPosition = new Vector2(0, 0);
      }
    }
}
