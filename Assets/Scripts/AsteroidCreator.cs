using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
  [SerializeField] GameObject[] Asteroids = default;
  [SerializeField] float spawnSize = default;
  [SerializeField] float spawnDelay = default;
  public bool spawning = default;
  [SerializeField] float spawnDelayDecreaseSpeed = default;
  [SerializeField] float minSpawnDelay = default;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(SpawnAsteroid());
    spawnDelayDecreaseSpeed = SceneManagerUI.self.spawnDelayDecreaseSpeed;
  }

  IEnumerator SpawnAsteroid()
  {
    Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], transform.position + new Vector3(Random.Range(-spawnSize, spawnSize), 0, 0), Quaternion.identity);
    yield return new WaitForSeconds(spawnDelay);

    if (spawning)
    {
      StartCoroutine(SpawnAsteroid());
    }
  }

  // Update is called once per frame
  void Update()
  {
    spawnDelay -= spawnDelayDecreaseSpeed * Time.deltaTime;
    if (spawnDelay < minSpawnDelay)
    {
      spawnDelay = minSpawnDelay;
    }
  }
}