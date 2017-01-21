using UnityEngine;
using System.Collections.Generic;

public class PlayersManager : MonoBehaviour {

    public List<PlayerData> players;

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
        if (players == null)
            players = new List<PlayerData>();
    }

	public void SetPlayers(List<CharacterData> charactersData, List<Joystick> joysticks) {
        players.Clear();
        for (int i = 0; i < charactersData.Count; i++) {
            var playerData = ScriptableObject.CreateInstance<PlayerData>();
            playerData.character = charactersData[i];
            playerData.joystick = joysticks[i];
            players.Add(playerData);
        }
    }
}
