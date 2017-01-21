using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;

	void Start () {
        var players = PlayersManager.Instance.Players;
        foreach(var playerData in players) {
            var player = Instantiate(playerPrefab);
            player.GetComponent<Animator>().runtimeAnimatorController = playerData.character.animationController;
            player.GetComponent<PlayerController>().joystick = playerData.joystick;
        }
    }
}
