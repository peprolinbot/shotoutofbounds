using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public float rotateSpeed = 30f;

    void Update()
    {
      transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
