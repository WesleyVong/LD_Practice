using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Handler : MonoBehaviour
{
    public void Display(string txt, float time = 2)
    {
        StartCoroutine(Timer(txt, time));
    }
    IEnumerator Timer(string txt, float time)
    {
        GetComponent<TextMesh>().text = txt;
        yield return new WaitForSeconds(time);
        GetComponent<TextMesh>().text = "";
    }
}
