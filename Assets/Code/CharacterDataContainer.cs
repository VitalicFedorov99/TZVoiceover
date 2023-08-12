using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/CharacterContainer")]
public class CharacterDataContainer : ScriptableObject
{
    public CharacterData Value;
    public bool isChangeValue;
    public void SetValue(CharacterData character)
    {
        isChangeValue = false;
        if (character != Value)
            isChangeValue = true;
        Value = character;
    }


}
