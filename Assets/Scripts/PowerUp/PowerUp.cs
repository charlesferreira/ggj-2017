using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject iconPrefab;

    public float timeToLive = 20;
    [Range(0, 1)]
    public float jumpIncrease;

    void Start() {
        Destroy(gameObject, timeToLive);
    }
}
