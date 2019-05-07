using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
  public GameObject player;
  public GameObject enemy;
  public GameObject ramen;
  public float spawnTimer;
  public Transform[] spawnPoints;
  public float cd = 2;


  public int bosscount = 0;
  public int minibosscount = 0;


	// Use this for initialization
	void Start ()
  {
    //InvokeRepeating("Spawn", spawnTimer, spawnTimer);
    player = GameObject.FindGameObjectWithTag("Player");
  }
	
	// Update is called once per frame
	void Update () {
    Spawn();
	}

  void Spawn()
  {
    // If the player has no health left...
    if (player != null)
    {
      if (player.GetComponent<Player_Health>().currentHealth <= 0f)
      {
        // ... exit the function.
        return;
      }
    }
    // Find a random index between zero and one less than the number of spawn points.
    int spawnPointIndex = Random.Range(0, spawnPoints.Length);

    // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.


  if (cd <= 0)
    {
      if (minibosscount< 4)
      {
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
  minibosscount++;
      }
      if (bosscount< 1)
      {
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
bosscount++;
      }

      cd = 10;
    }
    else
    {
      cd -= Time.deltaTime;

    }

  }
}

