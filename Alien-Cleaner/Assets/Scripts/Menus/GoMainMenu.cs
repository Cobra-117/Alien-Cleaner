using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainMenu : MonoBehaviour
{
    public void onButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
