using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float lightIntensity = .5f;
    [SerializeField] private float lightAngle = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(lightIntensity);
            other.GetComponentInChildren<FlashLightSystem>().AddLightAngle(lightAngle);
            Destroy(gameObject);
        }
    }
}
