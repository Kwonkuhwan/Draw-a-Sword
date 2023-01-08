using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlantStorePanel : StorePanel
{
    public Text subClickText;
    public Text clickValueText;
    public Text subAutoText;
    public Text autoVlaueText;

    override protected void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SaveData.plantClick = PlayerPrefs.GetInt("PlantClick", 0);
        SaveData.plantAuto = PlayerPrefs.GetInt("PlantAuto", 0);

        subClickText.text = $"X {GameManager.Inst.plantValue[SaveData.plantClick]}";
        clickValueText.text = String.Format("{0:#,###}", GameManager.Inst.plantGpValue[SaveData.plantClick]);
        subAutoText.text = $"X {GameManager.Inst.plantValue[SaveData.plantAuto]}";
        autoVlaueText.text = String.Format("{0:#,###}", GameManager.Inst.plantGpValue[SaveData.plantAuto]);
    }

    override public void Hide()
    {
        base.Hide();
    }

    override public void Show()
    {
        base.Show();
    }
}
