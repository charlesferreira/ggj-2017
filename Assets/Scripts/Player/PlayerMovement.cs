using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float maxMoveSpeed;
    public float jumpSpeed;
    [Range(0, 1)]
    public float jumpMoveAttenuation;

    Animator anim;
    Rigidbody2D rb;
    PlayerInput input;
    bool jumping = false;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
	}

    void Update() {
        // movimento
        if (input.Left)
            Move(Vector2.left, "Left");
        else if (input.Right)
            Move(Vector2.right, "Right");
        else anim.SetTrigger("Idle");

        // pulo
        if (input.Jump) Jump();
    }

    void LateUpdate() {
        if (Mathf.Abs(rb.velocity.x) > maxMoveSpeed) {
            var velocity = rb.velocity;
            velocity.x = Mathf.Clamp(velocity.x, -maxMoveSpeed, maxMoveSpeed);
            rb.velocity = velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Island"))
            jumping = false;
    }

    void OnTriggerStay2D(Collider2D other) {
        print("Olha a onda!");
        if (other.CompareTag("Wave")) {
            var velocity = rb.velocity;
            velocity.x = other.GetComponent<WaveMovement>().DragVelocity;
            rb.velocity = velocity;
        }
    }

    private void Jump() {
        if (jumping) return;

        var velocity = rb.velocity; ;
        velocity.y = jumpSpeed;
        rb.velocity = velocity;
        jumping = true;
    }

    private void Move(Vector3 direction, string animationTrigger) {
        /*
        var velocity = rb.velocity;
        velocity.x = direction.x * moveSpeed;
        rb.velocity = velocity;
        */
        var force = direction * moveSpeed * Time.deltaTime;
        if (jumping)
            force *= jumpMoveAttenuation;
        rb.AddForce(force);
        anim.SetTrigger(animationTrigger);
    }
}
