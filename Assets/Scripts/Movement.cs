using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public float rotateSpeed = 30f;
  public AudioSource shotAudioSource;

  void Update()
  {
    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
      transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
    } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
      transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
    if (Input.GetMouseButton(0)) { // Not an else if to allow shooting in movement
      shotAudioSource.Play();
    }
  }
}
