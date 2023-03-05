using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public int charID;

    public void testOne()
    {
        Debug.Log("test one");
    }

    virtual public void testTwo()
    {
        Debug.Log("test two failed");
    }

    
}
