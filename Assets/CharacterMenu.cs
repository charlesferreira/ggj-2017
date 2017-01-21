using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {

    MenuInput input;
    int charactersCount;
    int currentIndexCharacter = 0;
    Image characterImage;


    void Awake()
    {
        input = GetComponent<MenuInput>();
    }

    void Start()
    {
        charactersCount = CharactersManager.Instance.charactersSprites.Count;
        characterImage = GetComponentInChildren<Image>();
        characterImage.sprite = CharactersManager.Instance.pressStartSprite;
    }

    void Update()
    {
        if (input.Right)
        {
            currentIndexCharacter = (currentIndexCharacter + 1) % charactersCount;
            characterImage.sprite = CharactersManager.Instance.GetCharacterSpriteByIndex(currentIndexCharacter);
        }
        else if (input.Left)
        {
            currentIndexCharacter = (charactersCount + currentIndexCharacter - 1) % charactersCount;
            characterImage.sprite = CharactersManager.Instance.GetCharacterSpriteByIndex(currentIndexCharacter);
        }

        if (input.Confirm)
        {
            
        }
    }

    public void SetFirstCharacter()
    {
        characterImage.sprite = CharactersManager.Instance.GetCharacterSpriteByIndex(currentIndexCharacter);
    }
}
