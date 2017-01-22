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
            ResultManager.Instance.players.Add(characterData);
            DestroyImmediate(gameObject);

            if (ResultManager.Instance.players.Count == PlayersManager.Instance.Players.Count) {
                SceneManager.LoadScene(3);
            }
        }
	}
}
