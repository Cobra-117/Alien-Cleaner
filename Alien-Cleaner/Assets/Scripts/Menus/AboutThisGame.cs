using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutThisGame : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject AboutThisGameCanvas;

    public void onClick()
    {
        MainCanvas.SetActive(false);
        AboutThisGameCanvas.SetActive(true);
    }
}
