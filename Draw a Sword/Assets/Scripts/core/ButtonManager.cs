using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager>
{
    // 캐릭터 상점
    public GameObject cSPObj;
    public GameObject cSLeftObj;
    public GameObject cSRightObj;
    public GameObject cSBuyObj;

    private CharactersStorePanel cSPanel;
    private CharactersStoreButton cSLeft;
    private CharactersStoreButton cSRight;
    private CharactersStoreButton cSsBuy;

    public Button cSBtn;
    private Button cSLeftBtn;
    private Button cSRightBtn;
    private Button cSBuyBtn;

    // 강화 상점
    public GameObject pSObj;
    public GameObject pSClickObj;
    public GameObject pSAutoObj;

    private PlantStorePanel plantPanel;
    private PlantStoreButton pSClick;
    private PlantStoreButton pSAuto;

    public Button pSBtn;
    private Button pSClickBtn;
    private Button pSAutoBtn;

    // 옵션
    public GameObject opObj;


    private void Awake()
    {
        // 캐릭터
        cSPanel = cSPObj.GetComponent<CharactersStorePanel>();

        cSLeft = cSLeftObj.GetComponent<CharactersStoreButton>();
        cSRight = cSRightObj.GetComponent<CharactersStoreButton>();
        cSsBuy = cSBuyObj.GetComponent<CharactersStoreButton>();

        cSLeftBtn = cSLeftObj.GetComponent<Button>();
        cSRightBtn = cSRightObj.GetComponent<Button>();
        cSBuyBtn = cSBuyObj.GetComponent<Button>();

        // 강화
        plantPanel = pSObj.GetComponent<PlantStorePanel>();

        pSClick = pSClickObj.GetComponent<PlantStoreButton>();
        pSAuto = pSAutoObj.GetComponent<PlantStoreButton>();

        pSClickBtn = pSClickObj.GetComponent<Button>();
        pSAutoBtn = pSAutoObj.GetComponent<Button>();
    }

    private void Start()
    {
        cSBtn.onClick.AddListener(() => CSClick());
        cSLeftBtn.onClick.AddListener(() => CSLeftClick());
        cSRightBtn.onClick.AddListener(() => CSRightClick());
        cSBuyBtn.onClick.AddListener(() => CSBuyClick());

        pSBtn.onClick.AddListener(() => PlantClick());
        pSClickBtn.onClick.AddListener(() => PSClickBuy());
        pSAutoBtn.onClick.AddListener(() => PSAutoBuy());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Inst.isCSShow)
            {
                cSPanel.Hide();
                GameManager.Inst.isCSShow = false;
            }

            if (GameManager.Inst.isPSShow)
            {
                plantPanel.Hide();
                GameManager.Inst.isPSShow = false;
            }

            if (GameManager.Inst.isOpShow)
            {
                opObj.SetActive(false);
                GameManager.Inst.isOpShow = false;
                Time.timeScale = 1;

            }
            else
            {
                opObj.SetActive(true);
                GameManager.Inst.isOpShow = true;
                Time.timeScale = 0;
            }
        }
    }

    #region 캐릭터 상점
    public void CSClick()
    {
        if (GameManager.Inst.isPSShow)
        {
            plantPanel.Hide();
            GameManager.Inst.isPSShow = false;
        }

        if (!cSPanel.IsShow)
        {
            cSPanel.Show();
            GameManager.Inst.isCSShow = true;
        }
        else
        {
            cSPanel.Hide();
            GameManager.Inst.isCSShow = false;
        }
    }

    public void CSLeftClick()
    {
        cSLeft.OnClick(true);
    }

    public void CSRightClick()
    {
        cSRight.OnClick(false);
    }

    public void CSBuyClick()
    {
        cSsBuy.OnBuyClick();
    }

    #endregion

    public void BuyBtnActive(bool isactive)
    {
        cSBuyBtn.gameObject.SetActive(isactive);
    }

    #region 강화 상점
    public void PlantClick()
    {
        if (GameManager.Inst.isCSShow)
        {
            cSPanel.Hide();
            GameManager.Inst.isCSShow = false;
        }

        if (!plantPanel.IsShow)
        {
            plantPanel.Show();
            GameManager.Inst.isPSShow = true;
        }
        else
        {
            plantPanel.Hide();
            GameManager.Inst.isPSShow = false;
        }
    }

    public void PSClickBuy()
    {
        pSClick.OnBuyClick(true);
    }

    public void PSAutoBuy()
    {
        pSAuto.OnBuyClick(false);
    }

    #endregion
}
