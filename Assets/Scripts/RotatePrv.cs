using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePrv : MonoBehaviour
{
    public float Speed = 10f;

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, Speed * Time.deltaTime);
    }
}
