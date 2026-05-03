using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] private float lightDecay = .1f;
    [SerializeField] private float angleDecay = 1f;
    [SerializeField] private float minAngle = 40f;

    Light flashLight;

    private void Awake()
    {
        flashLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();

        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (flashLight.spotAngle <= minAngle)
        {
            return;
        }

        flashLight.spotAngle -= angleDecay * Time.deltaTime;
    }

    private void DecreaseLightIntensity()
    {
        if (flashLight.intensity <= 0)
        {
            return;
        }

        flashLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void AddLightIntensity(float lightIntensity)
    {
        flashLight.intensity += lightIntensity;
    }

    public void AddLightAngle(float lightAngle)
    {
        flashLight.spotAngle += lightAngle;
    }
}
