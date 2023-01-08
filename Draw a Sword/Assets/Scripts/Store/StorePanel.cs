using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StorePanel : MonoBehaviour
{
    private Animator anim;
    private bool isShow;
    public bool IsShow
    {
        get => isShow;
    }

    virtual protected void Awake()
    {
        anim = GetComponent<Animator>();
        isShow = false;
    }

    virtual public void Hide()
    {
        if (anim == null) return;

        anim.SetTrigger("doHide");
        isShow = false;
    }

    virtual public void Show()
    {
        if (anim == null) return;

        anim.SetTrigger("doShow");
        isShow = true;
    }
}
