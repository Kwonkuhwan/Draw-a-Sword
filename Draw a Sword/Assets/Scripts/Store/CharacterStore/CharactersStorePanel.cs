using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharactersStorePanel : StorePanel
{
    public Image characterImage;
    public Text characterName;
    public Text characterValue;

    private int index = 0;
    public int Index
    {
        get => index;
        set
        {
            index = value;
            int indexMax = GameManager.Inst.charactersSprite.Length - 1;

            if (index < 0)
                index = indexMax;

            if (index > indexMax)
                index = 0;

        }
    }


    override protected void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        characterImage.sprite = GameManager.Inst.charactersSprite[Index];
        characterName.text = GameManager.Inst.charactersName[Index];
        characterValue.text = String.Format("{0:#,###}", GameManager.Inst.charactersSpValue[Index]);
    }

    override public void Hide()
    {
        base.Hide();
    }

    override public void Show()
    {
        base.Show();

        if (SaveData.charactersBuyCheck[index] == 1)
            ButtonManager.Inst.BuyBtnActive(false);
        else
            ButtonManager.Inst.BuyBtnActive(true);
    }
}
