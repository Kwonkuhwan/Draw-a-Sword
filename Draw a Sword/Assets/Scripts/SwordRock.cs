using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwordRock : MonoBehaviour
{
    private Animator swordAnim;

    private void Awake()
    {
        swordAnim = GetComponentInChildren<Animator>();
    }

    public void OnAnimStart()
    {
        if (swordAnim != null)
        {
            swordAnim.SetTrigger("RockClick");
        }
    }
}
