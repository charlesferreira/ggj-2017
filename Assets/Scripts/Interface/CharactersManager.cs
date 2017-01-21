using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharactersManager : MonoBehaviour {

    [Header("Imagens")]
    public List<Sprite> charactersSprites = new List<Sprite>();
    public Sprite pressStartSprite;
    public Sprite confirmSprite;

    [Header("Canvas")]
    public List<GameObject> playerCanvas = new List<GameObject>();

    [Header("Scene")]
    public int nextSceneIndex = 2;

    List<Character> characters = new List<Character>();
    List<Joystick> joysticks = new List<Joystick>();

    int playersCount;
    int playersReady;

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
	
	void Update ()
    {
        CheckJoinningPlayer();
    }

    private void CheckJoinningPlayer()
    {
        List<Joystick> removeJoysticks = new List<Joystick>();
        foreach (var joystick in joysticks)
        {
            if (Input.GetButtonDown(joystick.StartButton))
            {
                playerCanvas[0].GetComponent<MenuInput>().enabled = true;
                playerCanvas[0].GetComponent<MenuInput>().joysticks[0] = joystick;
                playerCanvas[0].GetComponent<CharacterMenu>().enabled = true;
                playerCanvas[0].GetComponent<CharacterMenu>().SetFirstCharacter();
                playerCanvas.RemoveAt(0);
                removeJoysticks.Add(joystick);
                increasePlayerCount();
            }
        }
        foreach (var joystick in removeJoysticks)
        {
            joysticks.Remove(joystick);
        }
    }

    public Sprite GetCharacterSpriteByIndex(int index)
    {
        return charactersSprites[index];
    }
    public void ReturningPlayer(Joystick joystick, GameObject canvas)
    {
        joysticks.Add(joystick);
        playerCanvas.Insert(0, canvas);
        decreasePlayerCount();
    }

    void increasePlayerCount()
    {
        playersCount++;
    }
    void decreasePlayerCount()
    {
        playersCount--;
    }
    public void increasePlayerReady()
    {
        playersReady++;
        if (playersReady == playersCount)
        {
            Invoke("CallNextScene", 1);
        }
    }
    public void decreasePlayerReady()
    {
        playersReady--;
    }

    void CallNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
