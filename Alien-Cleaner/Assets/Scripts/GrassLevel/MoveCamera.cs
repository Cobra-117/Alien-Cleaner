using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Vector3 targetPosition;
    public global _global;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(1000, transform.position.y, transform.position.z);
        _global = GameObject.FindGameObjectWithTag("global").GetComponent<global>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = _global.speed * 4 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
    }
}
