using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int pickupAmmoAmount = 10;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Ammo>().AddAmmo(ammoType, pickupAmmoAmount);
            Destroy(gameObject);
        }
    }
}
