using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {

    public List<CharacterData> players = new List<CharacterData>();

    static ResultManager instance;
    bool gameIsEnding = false;

    public static ResultManager Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<ResultManager>();
            return instance;
        }
    }

    public void Add(CharacterData characterData) {
        players.Add(characterData);
        if (players.Count >= PlayersManager.Instance.Players.Count - 1 && !gameIsEnding) {
            gameIsEnding = true;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame() {
        yield return new WaitForSeconds(3);
        gameIsEnding = false;
        SceneManager.LoadScene(3);
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
