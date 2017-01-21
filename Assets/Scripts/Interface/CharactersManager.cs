using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharactersManager : MonoBehaviour {

    [Header("Imagens")]
    public List<Sprite> charactersSprites = new List<Sprite>();
    public Sprite pressStartSprite;
    [Header("Canvas")]
    public List<GameObject> playerCanvas = new List<GameObject>();

    List<Character> characters = new List<Character>();
    List<Joystick> joysticks = new List<Joystick>();

    static CharactersManager instance;
    public static CharactersManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<CharactersManager>();
            return instance;
        }
    }

    void Awake () {
        foreach (var characterSprite in charactersSprites)
        {
            characters.Add(new Character(characterSprite));
        }
        foreach (var joystick in GetComponent<MenuInput>().joysticks)
        {
            joysticks.Add(joystick);
        }
        foreach (var canvas in playerCanvas)
        {
            canvas.GetComponent<MenuInput>().enabled = false;
        }
	}
	
	void Update () {
        foreach (var joystick in joysticks)
        {
            if (Input.GetButtonDown(joystick.StartButton))
            {
                playerCanvas[0].GetComponent<MenuInput>().enabled = true;
                playerCanvas[0].GetComponent<MenuInput>().joysticks[0] = joystick;
                playerCanvas[0].GetComponent<CharacterMenu>().SetFirstCharacter();
                playerCanvas.RemoveAt(0);
            }
        }
	}

    public Sprite GetCharacterSpriteByIndex(int index)
    {
        return charactersSprites[index];
    }
}
