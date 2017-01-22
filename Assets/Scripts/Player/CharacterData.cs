using UnityEngine;

[CreateAssetMenu(menuName = "Common/Character Data")]
public class CharacterData : ScriptableObject {

    public AnimatorOverrideController animationController;
    public Sprite avatar;
    public Sprite avatarResult;
    public GameObject bodyPrefab;

}
