using UnityEngine;

public class WaveDragging : MonoBehaviour {

    [Range(0, 1)]
    public float dragFactor;

    Rigidbody2D rb;
    bool isDragging = false;
    float dragSpeed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        var wave = other.GetComponent<WaveMovement>();
        if (wave != null) {
            dragSpeed = wave.Speed * dragFactor;
            isDragging = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        var wave = other.GetComponent<WaveMovement>();
        if (wave != null) {
            isDragging = false;
        }
    }

    void FixedUpdate() {
        if (!isDragging) return;

        var velocity = rb.velocity;
        velocity.x = dragSpeed;
        rb.velocity = velocity;
    }
}
