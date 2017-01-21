using UnityEngine;

public class WaveMovement : MonoBehaviour {

    public float speed;
	
	void Update () {
        var movement = Vector2.right * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
	}
}
