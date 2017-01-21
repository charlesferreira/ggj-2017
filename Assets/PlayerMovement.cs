using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;

    Animator anim;
    Rigidbody rb;
    PlayerInput input;
    bool jumping = false;

    void Start () {
        rb = GetComponent<Rigidbody>();
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

    void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("Island"))
            jumping = false;
    }

    private void Jump() {
        if (jumping) return;

        var velocity = rb.velocity; ;
        velocity.y = jumpSpeed;
        rb.velocity = velocity;
        jumping = true;
    }

    private void Move(Vector3 direction, string animationTrigger) {
        var velocity = rb.velocity;
        velocity.x = direction.x * moveSpeed;
        rb.velocity = velocity;
        anim.SetTrigger(animationTrigger);
    }
}
