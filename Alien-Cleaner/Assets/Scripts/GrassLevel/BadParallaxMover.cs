using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadParallaxMover : MonoBehaviour
{
    public bool IsStatic = false;
    public float Speed;
    public Vector3 targetPosition;
    public GameObject secondParallax;
    public global _global;

    void Start()
    {
        targetPosition = new Vector3(-1000, transform.position.y, transform.position.z);
        _global = GameObject.FindGameObjectWithTag("global").GetComponent<global>();
    }

    void Update()
    {
        if (IsStatic == true)
            return;
        if (transform.position.x > secondParallax.transform.position.x)
        {
            transform.position = new Vector3
            (secondParallax.transform.position.x + 19.1f, transform.position.y, transform.position.z);
        }
        else if (_global.speed != 0)
        {
            float step = Speed * _global.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
            if (transform.position.x <= -19.1f)
                transform.position = new Vector3(secondParallax.transform.position.x + 19.1f, transform.position.y, transform.position.z);
        }

    }
}
