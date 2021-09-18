using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    public GameObject TrashPrefab;
    public GameObject NotTrashPrefab;
    public GameObject Missile;
    public global _global;
    public GameObject[] Trash;
    private int prevTrashIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        _global = GameObject.FindGameObjectWithTag("global").GetComponent<global>();
        StartCoroutine(GenerateTrash());
    }

    // Update is called once per frame
    IEnumerator GenerateTrash()
    {
        while (_global.speed != 0)
        {
            yield return new WaitForSeconds(0.5f);
            RandomTrash();
            if (Random.Range(0, 5) == 1)
                Instantiate(Missile, new Vector3(20, -4.59f, 0), Quaternion.identity);
        }
    }

    void RandomTrash()
    {
        float height = Random.Range(-4f, 3.8f);
        int trashIndex = Random.Range(0, Trash.Length);

        while (trashIndex == prevTrashIndex)
            trashIndex = Random.Range(0, Trash.Length);
        Instantiate(Trash[trashIndex], new Vector3(20, height, 0), Quaternion.identity);
        prevTrashIndex = trashIndex;
    }
}
