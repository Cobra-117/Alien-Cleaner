using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public global _global;
    public float UpDownSpeed;
    public float MaxHeight;
    public float MinHeight;
    public Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        _global = GameObject.FindGameObjectWithTag("global").GetComponent<global>();
        targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 touchPos;
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
            GoUp();
        if (Input.GetKey(KeyCode.S))
             GoDown();
        if (Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0));
            GoUpDown(touchPos.y);
        }
        if (_global.speed == 0)
        {
            Vector3 raycast = new Vector3(transform.position.x + 0.43f, transform.position.y, transform.position.z);
            RaycastHit2D raycastHit = Physics2D.Raycast(raycast, -Vector2.up);
            Debug.DrawRay(raycast, -Vector2.up);
            raycast = new Vector3(transform.position.x - 0.43f, transform.position.y, transform.position.z);
            raycastHit = Physics2D.Raycast(raycast, -Vector2.up);
            Debug.DrawRay(raycast, -Vector2.up);
        }
    }

    GameObject isHittingObject(string tag)
    {
        Vector3 raycast = new Vector3 (transform.position.x + 0.43f, transform.position.y, transform.position.z);
        RaycastHit2D raycastHit = Physics2D.Raycast(raycast, -Vector2.up);
        Debug.DrawRay(raycast, -Vector2.up);
        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.gameObject.CompareTag(tag))
            {
                return raycastHit.transform.gameObject;
            }
        }
        raycast = new Vector3(transform.position.x - 0.43f, transform.position.y, transform.position.z);
        raycastHit = Physics2D.Raycast(raycast, -Vector2.up);
        Debug.DrawRay(raycast, -Vector2.up);
        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.gameObject.CompareTag(tag))
            {
                return raycastHit.collider.gameObject;
            }
        }
        return null;
    }

    void GoUp()
    {
        targetPosition = new Vector3(transform.position.x, 1000, transform.position.z);
        float step = UpDownSpeed * Time.deltaTime;
        if (transform.position.y < MaxHeight)
            transform.position = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
    }

    void GoDown()
    {
        targetPosition = new Vector3(transform.position.x, -1000, transform.position.z);
        float step = UpDownSpeed * Time.deltaTime;
        if (transform.position.y > MinHeight)
            transform.position = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
    }

    void GoUpDown(float YPos)
    {
        targetPosition = new Vector3(transform.position.x, YPos, transform.position.z);
        float step = UpDownSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
            _global.score += 100;
        }
        else if (collision.gameObject.tag == "NotTrash")
        {
            Destroy(collision.gameObject);
            _global.score += 100;
        }
        else if (collision.gameObject.tag == "Missile")
        {
            SceneManager.LoadScene(2);
            _global.hasLost = true;
            VariablesSaver.score = _global.score;
        }
    }
}
