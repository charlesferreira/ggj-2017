using UnityEngine;

[CreateAssetMenu(menuName = "Common/Input")]
public class Joystick : ScriptableObject {

    public string AButton { get { return name + " A"; } }
    public string BButton { get { return name + " B"; } }
    public string XButton { get { return name + " X"; } }
    public string YButton { get { return name + " Y"; } }
    public string StartButton { get { return name + " Start"; } }
    public string Horizontal { get { return name + " Horizontal"; } }
    public string Vertical { get { return name + " Vertical"; } }

}
