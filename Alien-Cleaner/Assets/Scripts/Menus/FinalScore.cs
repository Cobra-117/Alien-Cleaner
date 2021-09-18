using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + VariablesSaver.score.ToString();
    }
}
