using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public global _global;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        _global = GameObject.FindGameObjectWithTag("global").GetComponent<global>();
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(transform.position.x, Random.Range(-3f, 5f), transform.position.z);
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

    }

    // Update is called once per frame
    void Update()
    {
        if (_global.speed != 0)
            transform.position = transform.position + transform.TransformDirection(new Vector3((speed * _global.speed + 4f) * Time.deltaTime, 0, 0));
        if (transform.position.x <= -15)
            Destroy(this.gameObject);
    }
}
