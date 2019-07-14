using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washing_Machine : MonoBehaviour
{
    [Tooltip("If state is true, the machine is on, if state is false, the machine is off")]
    public bool state;

    public bool occupied = false;
    public GameObject occupiedObj;

    public bool isWasher;
    public bool isDryer;



    private void Update()
    {
        if (occupiedObj != null && !occupiedObj.GetComponent<Clothes>().busy && state)
        {
            state = false;
            occupiedObj = null;
            Debug.Log("Reset");
        }

        if (occupiedObj != null)
        {
            occupied = true;
        }
        else
        {
            occupied = false;
        }
    }

    private void OnMouseDown()
    {
        if (occupiedObj != null)
        {
            state = true;
            if (isWasher)
            {
                occupiedObj.GetComponent<Clothes>().Wash();
            }
            if (isDryer)
            {
                occupiedObj.GetComponent<Clothes>().Dry();
            }
            
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clothes" && collision.gameObject.GetComponent<Clothes>().selected == false && !occupied)
        {
            if (occupiedObj == null)
            {
                occupiedObj = collision.gameObject;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!state)
        {
            occupiedObj = null;
        }
        
    }
}
