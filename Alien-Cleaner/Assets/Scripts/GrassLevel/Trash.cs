using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public float speed;
    public Vector3 targetPosition;
    public global _global;

    // Update is called once per frame
    void Start()
    {
        targetPosition = new Vector3(-1000, transform.position.y, transform.position.z);
        _global = GameObject.FindGameObjectWithTag("global").GetComponent<global>();
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
            Random.Range(0, 360));
    }

    void Update()
    {
        //transform.Translate(new Vector3(-speed * 1.5f * Time.deltaTime, 0, 0));
        float step = speed * _global.speed * Time.deltaTime;
        if (_global.speed != 0)
            transform.position = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
        if (transform.position.x <= -15)
            Destroy(this.gameObject);
    }
}
