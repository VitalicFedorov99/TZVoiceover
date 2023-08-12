using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettings : ButtonHoverScale
{
    public void OpenSettings() 
    {
        isSelect = true; 
        Scale();
    }

    public void CloseSettings() 
    {
        isSelect = false;
        Lessen();
    }
}
