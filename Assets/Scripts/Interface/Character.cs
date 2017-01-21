using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public Sprite sprite;
    [HideInInspector] public bool selected = false;

    public Character(Sprite sprite)
    {
        this.sprite = sprite;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
