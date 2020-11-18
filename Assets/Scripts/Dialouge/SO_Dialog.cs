using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialog/Dialog", fileName ="New Dialog")]
public class SO_Dialog : ScriptableObject
{
    public List<Dialog> Dialogs = new List<Dialog>();

    private void OnValidate()
    {
      
    }
}
