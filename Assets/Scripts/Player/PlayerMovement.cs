﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Running")]
    public float moveForce;
    public float maxMoveSpeed;

    [Header("Jumping")]
    public float jumpSpeed;
    [Range(0, 1)]
    public float jumpMoveAttenuation;

    [Header("Dragging")]
    [Range(0, 1)]
    public float runningDrag;
    [Range(0, 1)]
    public float jumpingDrag;
    [Range(0, 1)]
    public float idleDrag;

    AudioSource jumpSound;

    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    PlayerInput input;
    bool jumping = false;
    bool running = false;
    bool hasPlayerOnHead = false;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        jumpSound = GetComponent<AudioSource>();
	}

    void Update() {
        // movimento
        running = true;
        if (input.Left) {
            sr.flipX = true;
            Move(Vector2.left);
        }
        else if (input.Right) {
            sr.flipX = false;
            Move(Vector2.right);
        }
        else {
            running = false;
            anim.SetTrigger("Idle");
        }

        // pulo
        if (input.Jump) Jump();
    }

    void LateUpdate() {
        // atrito e arrasto
        float drag = jumping 
            ? jumpingDrag 
            : (running 
                ? runningDrag
                : idleDrag);
        var velocity = rb.velocity;
        velocity.x *= (1 - drag);
        rb.velocity = velocity;

        // velocidade máxima
        if (Mathf.Abs(rb.velocity.x) > maxMoveSpeed) {
            velocity.x = Mathf.Clamp(velocity.x, -maxMoveSpeed, maxMoveSpeed);
            rb.velocity = velocity;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        var powerUp = other.GetComponent<PowerUp>();
        if (powerUp != null) {
            jumpSpeed += powerUp.jumpIncrease;
            Instantiate(powerUp.iconPrefab,
                transform.position + powerUp.iconPrefab.transform.position,
                transform.rotation);
            Destroy(powerUp.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        var isHeadCollision = other.collider.CompareTag("Player Head");
        if (jumping && (other.transform.CompareTag("Island") || isHeadCollision)) {
            anim.SetTrigger("Landed");
            jumping = false;
            if (isHeadCollision) {
                other.gameObject.GetComponent<PlayerMovement>().hasPlayerOnHead = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.collider.CompareTag("Player Feet"))
            hasPlayerOnHead = false;
    }

    private void Jump() {
        if (jumping) return;

        anim.SetTrigger("Jumping");

        var velocity = rb.velocity;
        velocity.y = jumpSpeed;
        if (hasPlayerOnHead) {
            velocity.y *= 2;
        }
        rb.velocity = velocity;

        jumpSound.Play();

        jumping = true;
    }

    private void Move(Vector3 direction) {
        var force = direction * moveForce * Time.deltaTime;
        if (jumping)
            force *= jumpMoveAttenuation;
        else
            anim.SetTrigger("Running");
        rb.AddForce(force);
    }
}
