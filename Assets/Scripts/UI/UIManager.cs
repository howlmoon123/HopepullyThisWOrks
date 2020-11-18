using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonMonobehaviour<UIManager>
{
    [SerializeField]
    CanvasGroup dialogGroup;

    [SerializeField]
    TextMeshProUGUI DialogBox;
    [SerializeField]
    Image image;
    public bool DialogIsStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        DialogBox.text = "";
        dialogGroup.alpha = 0;
    }



    public void ShowText(string dialog , Sprite sprite ,Vector3 pos)
    {
        ShowDialogBox();
        Vector3 newPos = new Vector3(pos.x, pos.y + 5, 0);
 
        if (DialogIsStarted)
        {
            Debug.LogError("dialog " + dialog + " Pos " + newPos);
            ShowDialogBox();
            dialogGroup.gameObject.transform.position = newPos;
            image.sprite = sprite;
            DialogBox.text = dialog;

        }
        else
        {
            HideDialogBox();
        }
    }

    public void ShowDialogBox()
    {
        dialogGroup.alpha = 1;
        DialogIsStarted = true;
    }

    public void HideDialogBox()
    {
        dialogGroup.alpha = 0;
        DialogIsStarted = false;
    }

}
