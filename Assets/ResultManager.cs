using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResultManager : MonoBehaviour {

    public List<CharacterData> players = new List<CharacterData>();

    static ResultManager instance;
    public static ResultManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<ResultManager>();
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
