using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class CharactersManager : MonoBehaviour {

    [Header("Imagens")]
    public List<CharacterData> charactersDatas = new List<CharacterData>();
    public Sprite pressStartSprite;
    public Sprite confirmSprite;
    public Sprite forbiddenSprite;

    [Header("Scene")]
    public int nextSceneIndex = 2;
    public int prevSceneIndex = 0;

    [Header("Instructions")]
    public Image instructionsImage;
    public Sprite startingSprite;

    [Header("Characters Menu")]
    public List<CharacterMenu> charactersMenu = new List<CharacterMenu>();

    [HideInInspector] public List<CharacterData> charactersSelecteds = new List<CharacterData>();
    List<Joystick> joysticksSelecteds = new List<Joystick>();

    int playersReady;

    [HideInInspector] public bool starting = false;

    MenuInput input;

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

        input = GetComponent<MenuInput>();
    }
	
	void Update ()
    {
        if (input.Cancel)
            if (!IsAnyPlayer())
                Exit();
    }

    private bool IsAnyPlayer()
    {
        foreach (var characterMenu in charactersMenu)
        {
            if (characterMenu.joined)
                return true;
        }
        return false;
    }

    internal void Exit()
    {
        SceneManager.LoadScene(prevSceneIndex);
    }

    public CharacterData GetCharacterDataByIndex(int index)
    {
        return charactersDatas[index];
    }

    public void CheckStartGame()
    {
        if (CheckAllPayersAreReady())
        {
            StartGame();
        }
    }

    bool CheckAllPayersAreReady()
    {
        //Se há jogadores
        if (charactersMenu.Where(x => x.joined).Any())
            //Se há jogadores não prontos
            if (charactersMenu.Where(x => x.joined).Where(y => !y.ready).Any())
                return false;
            else
                return true;
        else
            return false;
    }

    private void StartGame()
    {
        starting = true;
        //Percorrer a lista de jogadores buscando jogadores prontos e joysticks
        foreach (var characterMenu in charactersMenu)
        {
            if (characterMenu.ready)
            {
                charactersSelecteds.Add(characterMenu.characterData);
                joysticksSelecteds.Add(characterMenu.input.joysticks[0]);
            }
        }

        PlayersManager.Instance.Init(charactersSelecteds, joysticksSelecteds);

        //instructionsImage.sprite = startingSprite;
        Invoke("CallNextScene", 1);   
    }

    
    void CallNextScene()
    {
        PlayMusic.Instance.PlayGameMusic();
        SceneManager.LoadScene(nextSceneIndex);
    }

    internal bool IsCharacterSelected(CharacterData characterData)
    {
        foreach (var characterMenu in charactersMenu)
            if (characterMenu.ready)
                if (characterMenu.characterData == characterData)
                    return true;

        return false;
    }
}
