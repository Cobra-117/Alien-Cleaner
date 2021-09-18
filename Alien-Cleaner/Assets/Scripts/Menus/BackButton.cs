using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject CurrentCanvas;

    public void onClick()
    {
        MainCanvas.SetActive(true);
        CurrentCanvas.SetActive(false);
    }
}
