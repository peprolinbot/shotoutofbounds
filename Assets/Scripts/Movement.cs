using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
  public float rotateSpeed = 30f;
  public AudioSource shotAudioSource;
  public int bullets;
  public float timeBeforeReload;
  public float reloadDuration;
  public static int bulletsLeft;

  float reloadBulletDuration;
  bool lastFrameClicked = false;

  void Start() {
    bulletsLeft = bullets;
    reloadBulletDuration = reloadDuration/bullets;
  }

  void Update()
  {
    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
      transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
    } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
      transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
    if (Input.GetMouseButton(0) && !lastFrameClicked && bulletsLeft > 0) { // Not an else if to allow shooting in movement
      lastFrameClicked = true;
      bulletsLeft -= 1;
      GameObject.Find("Canvas/Bullets/Bullet ("+bulletsLeft+")").GetComponent<Image>().enabled = false;
      if (bulletsLeft <= 0) {
        StartCoroutine(ReloadBullets());
      }
      shotAudioSource.Play();
    } else if (!Input.GetMouseButton(0)) {
      lastFrameClicked = false;
    }
  }

  IEnumerator ReloadBullets()
  {
      yield return new WaitForSeconds(timeBeforeReload);
      for (var i = 0; i < bullets; i++) {
          GameObject.Find("Canvas/Bullets/Bullet ("+i+")").GetComponent<Image>().enabled = true;
          yield return new WaitForSeconds(reloadBulletDuration);
      }
      bulletsLeft = bullets;
  }
}
