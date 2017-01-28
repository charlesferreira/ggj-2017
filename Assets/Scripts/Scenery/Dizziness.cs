using UnityEngine;

public class Dizziness : MonoBehaviour {

    [Header("Tilt")]
    public float tiltSpeed = 1f;
    public float tiltIntensity = 0.01f;

    [Header("Float")]
    public float floatSpeed = 1f;
    public float floatIntensity = 0.01f;

    float currentTilt;
    float currentFloat;

    void FixedUpdate () {
        currentTilt += tiltSpeed * Time.fixedDeltaTime;
        currentFloat += floatSpeed * Time.fixedDeltaTime;

        transform.Rotate(Vector3.forward, Mathf.Cos(currentTilt) * tiltIntensity);
        transform.Translate(Vector2.up * Mathf.Cos(currentFloat) * floatIntensity, 0);
    }
}
