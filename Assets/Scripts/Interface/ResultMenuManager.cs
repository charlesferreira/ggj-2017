using UnityEngine;
using System.Collections;

public class ResultMenuManager : MonoBehaviour {

    public GameObject menuPanel;

    MenuInput menuInput;
    private bool canShowMenu = false;

    private void Awake()
    {
        menuInput = GetComponent<MenuInput>();
    }
    private void Start()
    {
        StartCoroutine(ShowPanel());
        menuPanel.SetActive(false);
    }

    IEnumerator ShowPanel() {
        yield return new WaitForSeconds(1f);
        canShowMenu = true;
    }

    private void Update()
    {
        if (menuInput.Confirm && canShowMenu)
        {
            menuPanel.SetActive(true);
        }
    }
}
