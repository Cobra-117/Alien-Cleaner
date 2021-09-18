using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMover : MonoBehaviour
{
    public bool IsStatic = false;
    public bool IsFirst = true;
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
        if (IsFirst == true)
        {
            float step = Speed * _global.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
            secondParallax.transform.position = new Vector3(transform.position.x + 23, transform.position.y, transform.position.z);
            if (transform.position.x <= -23)
            {
                transform.position = new Vector3(secondParallax.transform.position.x + 23, transform.position.y, transform.position.z);
                IsFirst = false;
            }
        }
        else
        {
            float step = Speed * _global.speed * Time.deltaTime;
            secondParallax.transform.position = Vector3.MoveTowards(secondParallax.transform.localPosition, targetPosition, step);
            transform.position = new Vector3(secondParallax.transform.position.x + 23, transform.position.y, transform.position.z);
            if (secondParallax.transform.position.x <= -23)
            {
                secondParallax.transform.position = new Vector3(transform.position.x + 23, transform.position.y, transform.position.z);
                IsFirst = true;
            }
        }
    }
}
