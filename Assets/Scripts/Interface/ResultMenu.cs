using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResultMenu : MonoBehaviour {

    List<Button> buttons = new List<Button>();
    MenuInput input;
    int currentIndexButton = 0;

    void Awake()
    {
        input = GetComponent<MenuInput>();

        foreach (Transform child in transform)
        {
            buttons.Add(child.GetComponent<Button>());
        }
    }

    private void OnEnable()
    {
        currentIndexButton = 0;
    }
    void Update()
    {
        if (input.Up)
        {
            currentIndexButton = (currentIndexButton + 1) % buttons.Count;
        }
        else if (input.Down)
        {
            currentIndexButton = (buttons.Count + currentIndexButton - 1) % buttons.Count;
        }

        buttons[1].Select();
        buttons[currentIndexButton].Select();

        if (input.Confirm)
        {
            buttons[currentIndexButton].onClick.Invoke();
        }
    }
}
