using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public SO_Dialog dialog;
    [SerializeField]
    bool DialogStarted = false;

    private void OnEnable()
    {
        EventHandler.DialogEvent += DialogNPCEvent;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if(DialogStarted && Input.GetKeyDown(KeyCode.J))
        {
            DialogStarted = false;
        }

        if(!DialogStarted)
        {
           UIManager.Instance.HideDialogBox();
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag.Equals(Tags.Player) && dialog != null)
        {
            DialogStarted = true;
            DialogNPCEvent(dialog.Dialogs[0].dialog[0], dialog.Dialogs[0].speakersImage, transform.position);
        }
    }

    public void DialogNPCEvent(string speech, Sprite sprite, Vector3 pos)
    {
        UIManager.Instance.ShowDialogBox();
        UIManager.Instance.ShowText(speech, sprite, pos);
    }
}
