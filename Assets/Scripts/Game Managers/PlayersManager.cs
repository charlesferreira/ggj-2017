using UnityEngine;
using System.Collections.Generic;

public class PlayersManager : MonoBehaviour {

    public List<PlayerData> players = new List<PlayerData>();

    public List<PlayerData> Players { get { return players; } }
    
    static PlayersManager instance;
    public static PlayersManager Instance {
        get {
            if (instance == null)
                instance = FindObjectOfType<PlayersManager>();
            return instance;
        }
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void Init(List<CharacterData> charactersData, List<Joystick> joysticks) {
        ResultManager.Instance.players.Clear();
        Players.Clear();
        for (int i = 0; i < charactersData.Count; i++) {
            var playerData = ScriptableObject.CreateInstance<PlayerData>();
            playerData.character = charactersData[i];
            playerData.joystick = joysticks[i];
            Players.Add(playerData);
        }
    }
}
