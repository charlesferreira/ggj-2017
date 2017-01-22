using UnityEngine;
using System.Collections;

public class MiniWaves : MonoBehaviour {

    public float speed = 1;
    MeshRenderer mr;
    public float phase;
    public float amplitude = 10;

	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        mr.sharedMaterial.mainTextureOffset += Vector2.left * speed * Time.deltaTime;
        phase += Time.deltaTime;
        transform.position += Vector3.up * amplitude * Mathf.Sin(phase);
	}
}
