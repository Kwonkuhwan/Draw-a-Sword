using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public StorePanel charactersStore;
    public Button charactersStoreBtn;

    private void Start()
    {
        charactersStoreBtn.onClick.AddListener(() => StoreClick());
    }

    public void StoreClick()
    {
        if (!charactersStore.IsShow)
        {
            charactersStore.Show();
        }
        else
        {
            charactersStore.Hide();
        }
    }

}
