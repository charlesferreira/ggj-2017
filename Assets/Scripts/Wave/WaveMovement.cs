using UnityEngine;

public class WaveMovement : MonoBehaviour {

    public float timeToLive = 5;
    public Interval speedRange;

    float speed;

    public float Speed { get { return speed; } }

    void Start() {
        Destroy(gameObject, timeToLive);
        speed = speedRange.RandomValue;
    }

    void Update () {
        var movement = Vector2.right * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
	}
}
