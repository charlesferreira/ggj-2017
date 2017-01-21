using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {

    MenuInput input;
    int charactersCount;
    int currentIndexCharacter = 0;
    Image characterImage;
    Image confirmImage;
    bool selected = false;

    void Awake()
    {
        input = GetComponent<MenuInput>();
    }

    void Start()
    {
        charactersCount = CharactersManager.Instance.charactersSprites.Count;
        characterImage = GetComponentsInChildren<Image>()[0];
        confirmImage = GetComponentsInChildren<Image>()[1];
        confirmImage.sprite = CharactersManager.Instance.confirmSprite;
        confirmImage.enabled = false;
        characterImage.sprite = CharactersManager.Instance.pressStartSprite;
    }

    void Update()
    {
        if (input.Right && !selected)
        {
            currentIndexCharacter = (currentIndexCharacter + 1) % charactersCount;
            characterImage.sprite = CharactersManager.Instance.GetCharacterSpriteByIndex(currentIndexCharacter);
        }
        else if (input.Left && !selected)
        {
            currentIndexCharacter = (charactersCount + currentIndexCharacter - 1) % charactersCount;
            characterImage.sprite = CharactersManager.Instance.GetCharacterSpriteByIndex(currentIndexCharacter);
        }

        if (input.Cancel)
        {
            if (selected)
            {
                confirmImage.enabled = false;
                selected = false;
                CharactersManager.Instance.decreasePlayerReady();
            }
            else
            {
                characterImage.sprite = CharactersManager.Instance.pressStartSprite;
                CharactersManager.Instance.ReturningPlayer(input.joysticks[0], gameObject);
                input.enabled = false;
                enabled = false;
            }
        }
        else if (input.Confirm)
        {
            confirmImage.enabled = true;
            selected = true;
            CharactersManager.Instance.increasePlayerReady();
        }
    }

    public void SetFirstCharacter()
    {
        characterImage.sprite = CharactersManager.Instance.GetCharacterSpriteByIndex(currentIndexCharacter);
    }
}
