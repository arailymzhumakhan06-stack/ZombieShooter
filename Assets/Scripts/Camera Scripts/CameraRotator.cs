using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField] private float rotateSpeed = 0.25f;

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }
}
