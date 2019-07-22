using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Handler : MonoBehaviour
{
    public int money = 0;

    public void Add(int num)
    {
        money += num;
    }
}
