using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;

        public AmmoSlot(AmmoType ammoType, int ammoAmount)
        {
            this.ammoType = ammoType;
            this.ammoAmount = ammoAmount;
        }
    }
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    public void AddAmmo(AmmoType ammotype, int ammoAmount)
    {
        GetAmmoSlot(ammotype).ammoAmount += ammoAmount;
    }

    public void ReduceAmmo(AmmoType ammotype)
    {
        GetAmmoSlot(ammotype).ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
