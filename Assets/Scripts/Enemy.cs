using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource gotHitAudioSource;
    public AudioSource diedAudioSource;

    void OnTriggerEnter(Collider collider) {
      gotHitAudioSource.Play();
    }

    void OnTriggerStay(Collider collider) {
      if (Input.GetMouseButton(0)) {
        diedAudioSource.Play();
        StartCoroutine(SelfDestroyAfterSound());
      }
    }

    IEnumerator SelfDestroyAfterSound()
     {
         while (diedAudioSource.isPlaying)
         {
             yield return null;
         }

         Destroy(gameObject);
     }
}
