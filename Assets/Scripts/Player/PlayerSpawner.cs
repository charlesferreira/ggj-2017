using UnityEngine;
using System.Collections.Generic;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;
    public List<Transform> spawnPoints;

    void Start() {
        var players = PlayersManager.Instance.Players;
        for (int i = 0; i < players.Count; i++) {
            // instancia o player
            var spawnPoint = spawnPoints[i];
            var player = (GameObject)Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

            // inicializa os componentes
            var playerData = players[i];
            player.GetComponent<Animator>().runtimeAnimatorController = playerData.character.animationController;
            player.GetComponent<PlayerInput>().Joystick = playerData.joystick;
        }
    }
}
