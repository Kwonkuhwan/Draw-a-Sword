using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharactersStoreButton : MonoBehaviour
{
    private CharactersStorePanel storePanel;

    private void Awake()
    {
        storePanel = transform.parent.GetComponent<CharactersStorePanel>();
    }


    public void OnClick(bool isLeft)
    {
        int indexMax = GameManager.Inst.charactersSprite.Length - 1;
        if (isLeft)
        {
            storePanel.Index--;
        }
        else
        {
            storePanel.Index++;
        }

        storePanel.characterImage.sprite = GameManager.Inst.charactersSprite[storePanel.Index];
        storePanel.characterName.text = GameManager.Inst.charactersName[storePanel.Index];
        storePanel.characterValue.text = String.Format("{0:#,###}", GameManager.Inst.charactersSpValue[storePanel.Index]);

        if (SaveData.charactersBuyCheck[storePanel.Index] == 1)
        {
            ButtonManager.Inst.BuyBtnActive(false);
        }
        else
        {
            ButtonManager.Inst.BuyBtnActive(true);
        }
    }

    public void OnBuyClick()
    {
        if (SaveData.swordPoint >= GameManager.Inst.charactersSpValue[storePanel.Index])
        {
            SaveData.swordPoint -= GameManager.Inst.charactersSpValue[storePanel.Index];
            PlayerPrefs.SetInt("SwordPoint", SaveData.swordPoint);
            GameManager.Inst.SetSwordPointText();

            string cName = "Character";
            PlayerPrefs.SetInt($"{cName}_{storePanel.Index}", 1);
            SaveData.charactersBuyCheck[storePanel.Index] = PlayerPrefs.GetInt($"{cName}_{storePanel.Index}", 0); // 캐릭터 구매 유무를 가져온다.
            ButtonManager.Inst.BuyBtnActive(false);

            GameManager.Inst.SetCharacter();
        }
    }


}
