using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int[] charactersClickCount;
    public string[] charactersName;
    public Sprite[] charactersSprite;
    public Sprite[] swordSprite;

    public Collider2D rockCollider;

    public Text swordPointText;
    public Text goldPointText;

    static int totalClickCount;
    public static int swordPoint;
    public static int goldPoint;

    public SwordRock swordRock;

    private void Start()
    {
        totalClickCount = PlayerPrefs.GetInt("TotalClickCount", 0);
        swordPoint = PlayerPrefs.GetInt("SwordPoint", 0);
        swordPointText.text = string.Format("{0:0,0}", swordPoint);

        goldPoint = PlayerPrefs.GetInt("GoldPoint", 0);
        for (int i = 0; i < charactersName.Length; i++)
        {

        }
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (rayhit.collider != null)
        {
            if (rayhit.collider == rockCollider && Input.GetMouseButtonDown(0))
            {
                if(swordRock != null)
                {
                    swordRock.OnAnimStart();
                }

                TotalClickAdd();
                SwordPointAdd();
            }
        }
    }

    public void TotalClickAdd()
    {
        totalClickCount += 1;
        PlayerPrefs.SetInt("TotalClickCount", totalClickCount);
        Debug.Log($"Click : {totalClickCount}");
    }

    public void SwordPointAdd()
    {
        if (swordPointText == null) return;

        swordPoint += 1;
        PlayerPrefs.SetInt("SwordPoint", totalClickCount);
        swordPointText.text = String.Format("{0:#,###}", swordPoint);
    }
}
