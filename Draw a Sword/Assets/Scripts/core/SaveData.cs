using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;


public class SaveData : Singleton<GameManager>
{
    public static int[] charactersBuyCheck;     // 구매했으면 1, 아니면 0
    public static int swordPoint;               // Sp 재화
    public static int goldPoint;                // Gp 재화
    public static int plantClick;               // 클릭 강화 레벨
    public static int plantAuto;                // 자동 골드 획득 강화 레벨
}
