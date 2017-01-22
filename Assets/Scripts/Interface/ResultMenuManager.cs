using UnityEngine;
using System.Collections;

public class ResultMenuManager : MonoBehaviour {

    public GameObject menuPanel;

    MenuInput menuInput;

    private void Awake()
    {
        menuInput = GetComponent<MenuInput>();
    }
    private void Start()
    {
        PlayMusic.Instance.PlayIntroMusic();
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        if (menuInput.Confirm)
        {
            menuPanel.SetActive(true);
        }
    }
}
