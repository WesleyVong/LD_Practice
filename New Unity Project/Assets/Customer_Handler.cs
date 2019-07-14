using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Handler : MonoBehaviour
{
    public GameObject[] items;
    public GameObject replyText;

    

    public string helloText = "Hello";
    public string thankText = "Thanks";
    public string goodbyeText = "Goodbye";

    public bool satisfied;
    public bool arrived;

    private void Init()
    {
        replyText.GetComponent<Text_Handler>().Display(helloText,2);

        //Drops items
        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(items[i],transform.position - transform.up/2,transform.rotation,transform);
            items[i] = null;
        }
    }

    private void Update()
    {
        if (!satisfied)
        {
            if (transform.position.y > 0)
            {
                transform.position = transform.position + -transform.up * Time.deltaTime;
            }
            else
            {
                if (!arrived)
                {
                    arrived = true;
                    Init();
                }
            }
        }
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                break;
            }
            if (i == items.Length -1 && arrived)
            {
                satisfied = true;
            }
        }
        if (satisfied)
        {
            replyText.GetComponent<Text_Handler>().Display(goodbyeText);
            transform.position = transform.position + transform.up * Time.deltaTime;
            if (transform.position.y > 5)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("HEY");
        if (collision.gameObject.tag == "Clothes" && collision.gameObject.GetComponent<Clothes>().selected == false && 
            collision.gameObject.GetComponent<Clothes>().isWet == false &&
            collision.gameObject.GetComponent<Clothes>().isDirty == false)
        {
            Debug.Log("THX");
            replyText.GetComponent<Text_Handler>().Display(thankText);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = collision.gameObject;
                    break;
                }
            }
            collision.gameObject.SetActive(false);
        }
    }
}
