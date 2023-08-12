using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCharacter : ButtonHoverScale
{
    [SerializeField] private CharacterData characterButton;

    [SerializeField] private CharacterDataContainer container;

    public void OnSelect()
    {
        if (container.Value != characterButton)
            return;

        Scale();
        isSelect = true;
    }
    public void OffSelect() 
    {
        isSelect = false;
        Lessen();
    }

}
