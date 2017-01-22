using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public float minY = -5;

    CharacterData characterData;

    public void Init(CharacterData characterData) {
        this.characterData = characterData;
    }

    void Update () {
	    if (transform.position.y < minY) {
            print(characterData);
            ResultManager.Instance.Add(characterData);
            Destroy(gameObject);
        }
	}
}
