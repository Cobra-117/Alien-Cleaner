using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public global _global;
    // Start is called before the first frame update
    void Start()
    {
        _global = GameObject.FindGameObjectWithTag("global").GetComponent<global>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<UnityEngine.UI.Text>().text = _global.score.ToString();
    }
}
