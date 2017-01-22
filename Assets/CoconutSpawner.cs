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
            Instantiate(coconutPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval.RandomValue);
        }
    }
}
