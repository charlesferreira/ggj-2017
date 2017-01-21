using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowResult : MonoBehaviour {

	// Use this for initialization
	void Start () {

        int index = 0;
        int playersCount = ResultManager.Instance.players.Count;
        foreach (var position in GetComponentsInChildren<RankingPosition>())
        {
            if (index >= playersCount) break;
            position.ShowCharacter(ResultManager.Instance.players[index].avatar);
            index++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
