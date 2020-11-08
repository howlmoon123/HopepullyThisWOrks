using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObscuringItemFader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        Debug.LogError("Ob Trigger on Player " + target.name);
        ObscuringItemFader[] obscuringItemFaders = target.GetComponentsInChildren<ObscuringItemFader>();
        if(obscuringItemFaders.Length > 0)
        {
            for(int i = 0; i < obscuringItemFaders.Length; i++)
            {
                obscuringItemFaders[i].FadeOut();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        ObscuringItemFader[] obscuringItemFaders = target.GetComponentsInChildren<ObscuringItemFader>();
        if (obscuringItemFaders.Length > 0)
        {
            for (int i = 0; i < obscuringItemFaders.Length; i++)
            {
                obscuringItemFaders[i].FadeIn();
            }
        }
    }
}
