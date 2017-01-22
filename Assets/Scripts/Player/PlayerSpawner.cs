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

            // adiciona o corpo do player
            var playerData = players[i];
            var bodyPrefab = playerData.character.bodyPrefab;
            Instantiate(bodyPrefab,
                player.transform.position + bodyPrefab.transform.localPosition,
                player.transform.rotation,
                player.transform);

            // inicializa os componentes
            player.GetComponent<Animator>().runtimeAnimatorController = playerData.character.animationController;
            player.GetComponent<PlayerInput>().Joystick = playerData.joystick;
            player.GetComponent<PlayerHealth>().Init(playerData.character);
        }
    }
}
