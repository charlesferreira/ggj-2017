using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Joystick Joystick { private get; set; }

    public bool Left { get { return Input.GetAxis(Joystick.Horizontal) < 0; } }
    public bool Right { get { return Input.GetAxis(Joystick.Horizontal) > 0; } }
    public bool Jump { get { return Input.GetButtonDown(Joystick.AButton); } }
}
