using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharactersManager : MonoBehaviour {

    [Header("Imagens")]
    public List<CharacterData> charactersDatas = new List<CharacterData>();
    public Sprite pressStartSprite;
    public Sprite confirmSprite;
    public Sprite forbiddenSprite;

    [Header("Canvas")]
    public List<GameObject> playerCanvas = new List<GameObject>();

    [Header("Scene")]
    public int nextSceneIndex = 2;

    [Header("Instructions")]
    public Image instructionsImage;
    public Sprite startingSprite;

    List<Joystick> joysticks = new List<Joystick>();
    List<Joystick> joysticksSelecteds = new List<Joystick>();

    [HideInInspector] public List<CharacterData> selecteds = new List<CharacterData>();

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
                playerCanvas[0].GetComponent<CharacterMenu>().JoinCharacter();
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

    public CharacterData GetCharacterDataByIndex(int index)
    {
        return charactersDatas[index];
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
    public void increasePlayerReady(int index, Joystick joystick)
    {
        selecteds.Add(charactersDatas[index]);
        joysticksSelecteds.Add(joystick);

        playersReady++;
        if (playersReady == playersCount)
        {
            instructionsImage.sprite = startingSprite;
            Invoke("CallNextScene", 1);
        }
    }
    public void decreasePlayerReady(int index)
    {
        selecteds.Remove(charactersDatas[index]);
        joysticksSelecteds.RemoveAt(index);

        playersReady--;
    }

    void CallNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
