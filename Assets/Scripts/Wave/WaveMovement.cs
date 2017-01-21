using System;
using UnityEngine;

public class WaveMovement : MonoBehaviour {

    public float speed;
    [Range(0, 1)]
    public float dragFactor;

    void Update () {
        var movement = Vector2.right * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
	}

    public float DragVelocity { get { return speed * dragFactor; } }
}
