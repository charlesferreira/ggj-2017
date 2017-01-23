using UnityEngine;

public class GameplaySetup : MonoBehaviour {

	void Start () {
        if (PlayMusic.Instance == null || PlayMusic.Instance.gameMusic.isPlaying)
            return;
        PlayMusic.Instance.introMusic.Stop();
        PlayMusic.Instance.gameMusic.Play();
    }
}
