using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowResult : MonoBehaviour {

    List<Transform> children = new List<Transform>();

	// Use this for initialization
	void Start () {

        foreach (Transform item in transform)
        {
            children.Add(item);
        }
        int index = 0;
        int playersCount = ResultManager.Instance.players.Count;
        foreach (var position in GetComponentsInChildren<RankingPosition>())
        {
            if (index >= playersCount) break;
            children[0].gameObject.SetActive(true);
            position.ShowCharacter(ResultManager.Instance.players[index].avatarResult);
            index++;
        }
        ResultManager.Instance.players.Clear();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
