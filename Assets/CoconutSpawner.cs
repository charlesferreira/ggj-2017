using UnityEngine;
using System.Collections;

public class CoconutSpawner : MonoBehaviour {

    public GameObject coconutPrefab;
    public Interval interval;

    void Start() {
        StartCoroutine(SpawnCoconut());
    }

    IEnumerator SpawnCoconut() {
        while (true) {
            yield return new WaitForSeconds(interval.RandomValue);
            Instantiate(coconutPrefab, transform.position, transform.rotation);
        }
    }
}
