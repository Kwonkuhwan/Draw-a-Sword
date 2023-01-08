using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwordRock : MonoBehaviour
{
    private Animator swordAnim;
    private AudioSource swordSource;

    private void Awake()
    {
        swordAnim = GetComponentInChildren<Animator>();
        swordSource = GetComponent<AudioSource>();
    }

    public void OnAnimStart()
    {
        if (swordAnim != null)
        {
            swordAnim.SetTrigger("RockClick");
            swordSource.Play();
        }
    }
}
