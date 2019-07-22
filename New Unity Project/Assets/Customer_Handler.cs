using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Handler : MonoBehaviour
{
    public GameObject[] items;
    public GameObject replyText;

    public GameObject timerBar;

    public float waitTime = 30;

    public string helloText = "Hello";
    public string thankText = "Thanks";
    public string goodbyeText = "Goodbye";

    public bool satisfied;
    public bool arrived;
    public bool late;

    private void Init()
    {
        replyText.GetComponent<Text_Handler>().Display(helloText,2);

        //Drops items
        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(items[i],transform.position - transform.up/2,transform.rotation,transform);
            items[i] = null;
        }

        timerBar.GetComponent<Timer_Bar>().SetTimer(waitTime);
    }

    private void Update()
    {
        // Brings customer to store
        if (!satisfied && !late)
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

        // Checks whether all customer items are washed
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                break;
            }
            if (i == items.Length - 1 && arrived)
            {
                satisfied = true;
            }
        }

        // Returns customer
        if (satisfied || late)
        {
            if (!late)
            {
                replyText.GetComponent<Text_Handler>().Display(goodbyeText);
            }
            
            transform.position = transform.position + transform.up * Time.deltaTime;
            if (transform.position.y > 5)
            {
                Destroy(gameObject);
            }
        }

        // Checks whether the player is late on the order
        if (timerBar.GetComponent<Timer_Bar>().completed && !late && arrived)
        {
            replyText.GetComponent<Text_Handler>().Display("I'm Leaving, this is taking too long");
            late = true;
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
