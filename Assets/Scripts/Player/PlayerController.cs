using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Joystick joystick;
	
	void Update () {
        print(Input.GetAxis(joystick.Horizontal));
	}
}
