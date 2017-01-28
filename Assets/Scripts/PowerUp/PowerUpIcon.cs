using UnityEngine;

public class PowerUpIcon : MonoBehaviour {
    public float timeToLive = 0.333f;
    public float moveSpeed = 1;

    void Start () {
        Destroy(gameObject, timeToLive);
	}
	
	void Update () {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime, Space.World);
	}
}
