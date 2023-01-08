using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlantStoreButton : MonoBehaviour
{
    private PlantStorePanel storePanel;

    private void Awake()
    {
        storePanel = transform.parent.GetComponent<PlantStorePanel>();
    }

    public void OnBuyClick(bool isClickBuy)
    {        
        if (isClickBuy)
        {
            if (SaveData.goldPoint >= GameManager.Inst.plantGpValue[SaveData.plantClick])
            {
                SaveData.plantClick += 1;
                PlayerPrefs.SetInt("PlantClick", SaveData.plantClick);

                storePanel.subClickText.text = $"X {GameManager.Inst.plantValue[SaveData.plantClick]}";
                storePanel.clickValueText.text = String.Format("{0:#,###}", GameManager.Inst.plantGpValue[SaveData.plantClick]);
                SaveData.goldPoint -= GameManager.Inst.plantGpValue[SaveData.plantClick - 1];
                GameManager.Inst.SetGoldPointText();
            }
        }
        else
        {
            if (SaveData.goldPoint >= GameManager.Inst.plantGpValue[SaveData.plantAuto-1])
            {
                SaveData.plantAuto += 1;
                PlayerPrefs.SetInt("PlantAuto", SaveData.plantAuto);

                storePanel.subAutoText.text = $"X {GameManager.Inst.plantValue[SaveData.plantAuto]}";
                storePanel.autoVlaueText.text = String.Format("{0:#,###}", GameManager.Inst.plantGpValue[SaveData.plantAuto]);

                SaveData.goldPoint -= GameManager.Inst.plantGpValue[SaveData.plantAuto];      
                GameManager.Inst.SetGoldPointText();
            }
        }
    }


}
