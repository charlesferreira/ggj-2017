using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float maxMoveSpeed;
    public float jumpSpeed;
    [Range(0, 1)]
    public float jumpMoveAttenuation;

    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    PlayerInput input;
    bool jumping = false;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
	}

    void Update() {
        // movimento
        if (input.Left) {
            sr.flipX = true;
            Move(Vector2.left);
        }
        else if (input.Right) {
            sr.flipX = false;
            Move(Vector2.right);
        }
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

    void OnTriggerEnter2D(Collider2D other) {
        var powerUp = other.GetComponent<PowerUp>();
        if (powerUp != null) {
            jumpSpeed += powerUp.jumpIncrease;
            Destroy(powerUp.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (jumping && other.transform.CompareTag("Island")) {
            anim.SetTrigger("Landed");
            jumping = false;
        }
    }

    private void Jump() {
        if (jumping) return;

        anim.SetTrigger("Jumping");

        var velocity = rb.velocity; ;
        velocity.y = jumpSpeed;
        rb.velocity = velocity;
        jumping = true;
    }

    private void Move(Vector3 direction) {
        var force = direction * moveSpeed * Time.deltaTime;
        if (jumping)
            force *= jumpMoveAttenuation;
        else
            anim.SetTrigger("Running");
        rb.AddForce(force);
    }
}
