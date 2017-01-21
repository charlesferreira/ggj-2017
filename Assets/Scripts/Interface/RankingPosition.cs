using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingPosition : MonoBehaviour {

    public void ShowCharacter(Sprite avatar)
    {
        GetComponentInChildren<Image>().sprite = avatar;
    }
}
