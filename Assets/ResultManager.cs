using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResultManager : MonoBehaviour {

    public List<CharacterData> players = new List<CharacterData>();
    public GameObject menuPanel;

    MenuInput menuInput;

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
        menuInput = GetComponent<MenuInput>();
    }

    private void Start()
    {
        //PlayMusic.Instance.PlayIntroMusic();
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        if (menuInput.Confirm)
        {
            menuInput.enabled = false;
            menuPanel.SetActive(true);
        }
    }
}
