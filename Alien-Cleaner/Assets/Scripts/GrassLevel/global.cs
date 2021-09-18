using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour
{
    public float speed = 1.5f;
    public bool isWaiting = false;
    public bool hasLost = false;
    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        if (isWaiting == false)
            StartCoroutine(UpdateSpeed());
    }

    IEnumerator UpdateSpeed()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1f);
        if (speed != 0)
            speed += 0.05f;
        isWaiting = false;
        if (hasLost == true)
            speed = 0;
    }
}
