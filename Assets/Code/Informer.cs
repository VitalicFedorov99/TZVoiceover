using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informer : MonoBehaviour
{
    public void DiaryOpened() // OnDiaryOpened
    {
        Debug.Log("Diary opened");    
    }

    public void DiaryClosed() // OnDiaryClosed
    {
        Debug.Log("Diary closed");
    }

    public void DiaryPageChanged() // OnDiaryPageChanged
    {
        Debug.Log("Diary page changed");
    }
}
