using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
  public GameObject enemyPrefab;
  public GameObject xPositiveWall;
  public GameObject xNegativeWall;
  public GameObject zPositiveWall;
  public GameObject zNegativeWall;
  public float distanceFromWall;
  public float ySpawn;
  public float sideOffsetFromCenter;
  public float spawnRate;

  float xSpawn;
  float zSpawn;

    void Start() {
      InvokeRepeating("RandomSpawn", 0, spawnRate);
    }

    void RandomSpawn()
    {

      switch (Random.Range(0, 3)) {
          case 0: // xPositiveWall
              xSpawn = xPositiveWall.transform.position.x + distanceFromWall;
              zSpawn = Random.Range(xPositiveWall.transform.position.z - sideOffsetFromCenter, xPositiveWall.transform.position.z + sideOffsetFromCenter);
              break;
          case 1: // xNegativeWall
              xSpawn = xNegativeWall.transform.position.x - distanceFromWall;
              zSpawn = Random.Range(xNegativeWall.transform.position.z - sideOffsetFromCenter, xNegativeWall.transform.position.z + sideOffsetFromCenter);
              break;
          case 2: // zPositiveWall
              xSpawn = Random.Range(zPositiveWall.transform.position.x - sideOffsetFromCenter, zPositiveWall.transform.position.x + sideOffsetFromCenter);
              zSpawn = zPositiveWall.transform.position.z + distanceFromWall;
              break;
          case 3: // zNegativeWall
              xSpawn = Random.Range(zNegativeWall.transform.position.x - sideOffsetFromCenter, zNegativeWall.transform.position.x + sideOffsetFromCenter);
              zSpawn = zNegativeWall.transform.position.z - distanceFromWall;
              break;
      }

      Instantiate(enemyPrefab, new Vector3(xSpawn, ySpawn, zSpawn), Quaternion.identity);
    }

    void Update() {

    }
}
