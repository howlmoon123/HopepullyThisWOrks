using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogObject : MonoBehaviour
{
    public SO_Dialog o_Dialog;

    private void OnValidate()
    {
       foreach(Dialog dialog in o_Dialog.Dialogs)
        {
            dialog.speakersName = gameObject.name;
            dialog.speakersImage = GetComponent<SpriteRenderer>().sprite;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
