﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {

    MenuInput input;
    int charactersCount;
    int currentIndexCharacter = 0;
    Image characterImage;
    Image confirmImage;
    Image forbiddenImage;
    bool joined = false;
    bool ready = false;
    bool forbidden = false;
    CharacterData characterData;

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
        var characterData = CharactersManager.Instance.GetCharacterDataByIndex(currentIndexCharacter);

        forbidden = CheckCharacterForbidden(characterData);
        forbiddenImage.enabled = forbidden;

        if (input.Right && !ready)
        {
            currentIndexCharacter = (currentIndexCharacter + 1) % charactersCount;
            characterImage.sprite = CharactersManager.Instance.GetCharacterDataByIndex(currentIndexCharacter).avatar;
        }
        else if (input.Left && !ready)
        {
            currentIndexCharacter = (charactersCount + currentIndexCharacter - 1) % charactersCount;
            characterImage.sprite = CharactersManager.Instance.GetCharacterDataByIndex(currentIndexCharacter).avatar;
        }

        if (input.Cancel)
        {
            if (ready)
            {
                confirmImage.enabled = false;
                ready = false;
                CharactersManager.Instance.decreasePlayerReady(currentIndexCharacter);
            }
            else
            {
                characterImage.sprite = CharactersManager.Instance.pressStartSprite;
                CharactersManager.Instance.ReturningPlayer(input.joysticks[0], gameObject);
                input.enabled = false;
                enabled = false;
                joined = false;
            }
        }
        else if (input.Confirm && !forbidden && !ready)
        {
            confirmImage.enabled = true;
            ready = true;
            CharactersManager.Instance.increasePlayerReady(currentIndexCharacter, input.joysticks[0]);
            characterData = CharactersManager.Instance.GetCharacterDataByIndex(currentIndexCharacter);
        }
    }

    private bool CheckCharacterForbidden(CharacterData characterData)
    {
        if (!ready && joined)
        {
            foreach (var selected in CharactersManager.Instance.selecteds)
            {
                if (selected == characterData)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void JoinCharacter()
    {
        joined = true;
        characterImage.sprite = CharactersManager.Instance.GetCharacterDataByIndex(currentIndexCharacter).avatar;
    }
}
