using UnityEngine;

public class WaveDragging : MonoBehaviour {

    [Range(0, 1)]
    public float dragFactor;

    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D other) {
        var wave = other.GetComponent<WaveMovement>();
        if (wave != null) {
            var velocity = rb.velocity;
            velocity.x = wave.Speed * dragFactor;
            rb.velocity = velocity;
        }
    }
}
