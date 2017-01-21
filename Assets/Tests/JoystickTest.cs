using UnityEngine;

public class JoystickTest : MonoBehaviour {

    public Joystick joystick;
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown(joystick.AButton)) print("A");
	    if (Input.GetButtonDown(joystick.BButton)) print("B");
	    if (Input.GetButtonDown(joystick.XButton)) print("X");
        if (Input.GetButtonDown(joystick.YButton)) print("Y");
        if (Input.GetButtonDown(joystick.StartButton)) {
            print("Start");
            print("Horizontal: " + Input.GetAxis(joystick.Horizontal));
            print("Vertical: " + Input.GetAxis(joystick.Vertical));
        }
    }
}
