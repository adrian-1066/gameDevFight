using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterA : PlayerMain
{

    private void Start()
    {
        
    }

    override public void lightAttack()
    {
        m_animator.SetBool("isAttacking", true);
        m_animator.SetInteger("attackType", 0);
        //StartCoroutine(C_attackDuration(m_lightAttackDuration));


    }

    override public void testTwo()
    {
        Debug.Log("test two success");
    }

}
