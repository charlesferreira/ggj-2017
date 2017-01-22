using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    
    public GameObject wavePrefab;
    [Range(0.01f, 1)]
    public float startingScale;
    [Range(0.01f, 0.1f)]
    public float scaleIncrementFactor;
    public Interval interval;
    public Interval scaleRandomFactor;

    float currentScale = 1f;

    void Start() {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave() {
        while (true) {
            var delta = Random.Range(0f, interval.Max - interval.Min);
            yield return new WaitForSeconds(interval.Min + delta);

            var wave = (GameObject)Instantiate(wavePrefab, transform.position, transform.rotation);

            currentScale *= (1 + scaleIncrementFactor);
            var scale = startingScale * currentScale * (1 + scaleRandomFactor.RandomValue);
            wave.transform.localScale *= scale;
        }
    }
}
