using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePanel : MonoBehaviour
{
    private Animator anim;
    private bool isShow;
    public bool IsShow
    {
        get => isShow;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        isShow = false;
    }

    public void Hide()
    {
        if (anim == null) return;

        anim.SetTrigger("doHide");
        isShow = false;
    }

    public void Show()
    {
        if (anim == null) return;

        anim.SetTrigger("doShow");
        isShow = true;
    }
}
