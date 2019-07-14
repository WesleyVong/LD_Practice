using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    [Tooltip("If the item has been picked up")]
    public bool selected;

    public float washTime = 5;
    public float dryTime = 5;

    public bool isDirty = true;
    public bool isWet = false;

    [Tooltip("Item is in a machine")]
    public bool busy;

    private float timer;

    private Vector3 target;

    private void OnMouseDown()
    {
        selected = !selected;
    }

    private void Update()
    {
        if (selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;

            transform.position = target;
        }

        timer -= Time.deltaTime;
    }

    public void Wash()
    {
        StartCoroutine(WashProcess());
    }

    public void Dry()
    {
        StartCoroutine(DryProcess());
    }

    IEnumerator WashProcess()
    {
        busy = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        isWet = true;
        GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f);

        yield return new WaitForSeconds(washTime);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        isDirty = false;
        busy = false;
    }

    IEnumerator DryProcess()
    {
        busy = true;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(dryTime);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        isWet = false;
        GetComponent<SpriteRenderer>().color = Color.white;

        busy = false;
    }
}
