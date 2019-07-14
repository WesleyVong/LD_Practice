using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People_Spawner : MonoBehaviour
{
    public GameObject[] peoples;

    private GameObject slot1;

    private void Update()
    {
        if (slot1 == null)
        {
            slot1 = Instantiate(peoples[Random.Range(0, peoples.Length)], new Vector3(-1, 3, 0), transform.rotation);
        }
        if (slot1.transform.position.y > 3.5)
        {
            slot1 = null;
        }
    }
}
