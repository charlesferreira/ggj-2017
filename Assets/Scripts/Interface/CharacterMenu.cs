using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {

    Image characterImage;
    Image confirmImage;
    Image forbiddenImage;
    bool forbidden = false;
    [HideInInspector] public bool joined = false;
    [HideInInspector] public bool ready = false;
    [HideInInspector] public MenuInput input;
    [HideInInspector] public CharacterData characterData;
    int charactersCount;
    public int currentIndexCharacter = 0;

    void Awake()
    {
        input = GetComponent<MenuInput>();
    }

    void Start()
    {
        charactersCount = CharactersManager.Instance.charactersDatas.Count;
        characterImage = GetComponentsInChildren<Image>()[0];
        confirmImage = GetComponentsInChildren<Image>()[1];
        forbiddenImage = GetComponentsInChildren<Image>()[2];
        confirmImage.sprite = CharactersManager.Instance.confirmSprite;
        forbiddenImage.sprite = CharactersManager.Instance.forbiddenSprite;
        confirmImage.enabled = false;
        forbiddenImage.enabled = false;
        characterImage.sprite = CharactersManager.Instance.pressStartSprite;
    }

    void Update()
    {
        if (CharactersManager.Instance.starting)
        {
            enabled = false;
            forbiddenImage.enabled = false;
            return;
        }

        if ((input.Up || input.Right) && joined && !ready)
        {
            currentIndexCharacter = (currentIndexCharacter + 1) % charactersCount;
            UpdateCharacterData();
        }
        else if ((input.Down || input.Left) && joined && !ready)
        {
            currentIndexCharacter = (charactersCount + currentIndexCharacter - 1) % charactersCount;
            UpdateCharacterData();
        }

        if (!ready && joined)
        {
            if (CharactersManager.Instance.IsCharacterSelected(characterData))
                forbidden = true;
            else
                forbidden = false;

            forbiddenImage.enabled = forbidden;
        }

        if (input.Start && !joined)
        {
            UpdateCharacterData();
            joined = true;
        }
        else if (input.Cancel)
        {
            if (ready)
            {
                confirmImage.enabled = false;
                ready = false;
            }
            else if (joined)
            {
                characterImage.sprite = CharactersManager.Instance.pressStartSprite;
                joined = false;
                CharactersManager.Instance.CheckStartGame();
            }
        }
        else if (input.Confirm && joined && !forbidden && !ready)
        {
            confirmImage.enabled = true;
            ready = true;
            CharactersManager.Instance.CheckStartGame();
        }
    }

    private void UpdateCharacterData()
    {
        characterData = CharactersManager.Instance.GetCharacterDataByIndex(currentIndexCharacter);
        characterImage.sprite = characterData.avatar;
        characterImage.SetNativeSize();
    }

    public void JoinCharacter()
    {
        joined = true;
        characterData = CharactersManager.Instance.GetCharacterDataByIndex(currentIndexCharacter);
        characterImage.sprite = characterData.avatar;
    }
}
