using System;
using UnityEngine.IO;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    public int[] charactersClickCount;          // 캐릭별 클릭 카운트
    public int[] charactersSpValue;             // 캐릭터 Sp 가격
    public int[] charactersGetGoldValue;        // 캐릭터가 얻는 Gp량
    public bool[] charactersBuyCheck;           // 캐릭터 구매 유무
    public string[] charactersName;             // 캐릭터 이름
    public Sprite[] charactersSprite;           // 캐릭터 이미지

    public int[] plantGpValue;                  // 강화 Gp 가격
    public int[] plantValue;                    // 강화 배수

    public static int totalClickCount;          // 총 클릭 횟수

    public Sprite[] swordSprite;                // 검 이미지

    public Collider2D rockCollider;

    public Text swordPointText;                 // Sp 재화 텍스트
    public Text goldPointText;                  // Gp 재화 텍스트

    public SwordRock swordRock;                 // 돌에 박힌 검 컴포넌트

    public bool isCSShow = false;
    public bool isPSShow = false;
    public bool isOpShow = false;

    public GameObject[] charactoers;

    public float autoTimeMax = 3.0f;
    public float autotime = 0.0f;

    private void Start()
    {
        totalClickCount = PlayerPrefs.GetInt("TotalClickCount", 0);                 // PlayerPrefs에서 총 클릭 횟수를 가져온다.
        SaveData.swordPoint = PlayerPrefs.GetInt("SwordPoint");                     // PlayerPrefs에서 소드 포인트를 가져온다.
        SetSwordPointText();

        SaveData.goldPoint = PlayerPrefs.GetInt("GoldPoint");                       // PlayerPrefs에서 골드 포인트를 가져온다.
        SetGoldPointText();

        string cName = "Character";
        SaveData.charactersBuyCheck = new int[charactersName.Length];
        for (int i = 0; i < charactersName.Length; i++)                             // 캐릭터 이름 개수 만큼 돌린다.
        {
            int t = PlayerPrefs.GetInt($"{cName}_{i}");
            SaveData.charactersBuyCheck[i] = PlayerPrefs.GetInt($"{cName}_{i}"); // 캐릭터 구매 유무를 가져온다.

            if (SaveData.charactersBuyCheck[i] == 1)
            {
                charactoers[i].SetActive(true);
            }
            else
            {
                charactoers[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (isCSShow || isPSShow || isOpShow) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     // 카메라 좌표를  월드좌표로 변환
        RaycastHit2D rayhit = Physics2D.Raycast(mousePos, Vector2.zero);            // 마우스 좌표를 Raycast화 시킨다.

        if (rayhit.collider != null)
        {
            if (rayhit.collider == rockCollider && Input.GetMouseButtonDown(0))     // 돌 컬라이더를 클릭했을때
            {
                if (swordRock != null)
                {
                    swordRock.OnAnimStart();                                        // 애니메이션 시작
                }

                TotalClickAdd();                                                    // 총 클릭 회수 증가
                SwordPointAdd();                                                    // Sp 획득
            }
        }

    }

    private void LateUpdate()
    {
        if (isOpShow) return;

        if (autotime > autoTimeMax)
        {
            int getGold = 0;
            for (int i = 0; i < SaveData.charactersBuyCheck.Length; i++)
            {
                if (SaveData.charactersBuyCheck[i] == 1)
                {
                    getGold += charactersGetGoldValue[i] * plantValue[SaveData.plantAuto];
                }
            }

            SaveData.goldPoint += getGold;
            SetGoldPointText();
            autotime = 0.0f;
        }

        autotime += Time.deltaTime;
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

        SaveData.swordPoint += 1 * plantValue[SaveData.plantClick];
        SetSwordPointText();
    }

    public void SetSwordPointText()
    {
        PlayerPrefs.SetInt("SwordPoint", SaveData.swordPoint);
        if (SaveData.swordPoint < 1000) swordPointText.text = $"{SaveData.swordPoint}";
        else swordPointText.text = String.Format("{0:#,###}", SaveData.swordPoint);      // 소드 포인트를 텍스트에 적용한다.
    }

    public void GoldPointAdd()
    {
        if (goldPointText == null) return;

        SaveData.goldPoint += 1;
        SetGoldPointText();

    }
    public void SetGoldPointText()
    {
        PlayerPrefs.SetInt("GoldPoint", SaveData.goldPoint);
        if (SaveData.goldPoint < 1000) goldPointText.text = $"{SaveData.goldPoint}";
        else goldPointText.text = String.Format("{0:#,###}", SaveData.goldPoint);      // 골드 포인트를 텍스트에 적용한다.
    }


    public void SetCharacter()
    {
        for (int i = 0; i < charactoers.Length; i++)
        {
            if(SaveData.charactersBuyCheck[i] == 1)
            {
                charactoers[i].SetActive(true);
            }
        }
    }

    public void Clear()
    {
        string cName = "Character";
        for (int i = 0; i < charactersName.Length; i++)
        {
            PlayerPrefs.SetInt($"{cName}_{i}", 0);
        }
    }
}
