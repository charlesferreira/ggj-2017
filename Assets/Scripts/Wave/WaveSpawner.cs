using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject wavePrefab;
    public float interval;

    void Start() {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave() {
        while (true) {
            yield return new WaitForSeconds(interval + Random.Range(0f, 2f));
            Instantiate(wavePrefab, transform.position, transform.rotation);
        }
    }
}
