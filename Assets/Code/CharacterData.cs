using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character")]
public class CharacterData : ScriptableObject
{
    public string Name;
    public Sprite PortraitBig;
    public Sprite PortraitSmall;
    [TextArea(3, 10)]
    public string Description;
}
