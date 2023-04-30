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
        m_attackType = 0;
        if(m_recentAttackInput.Count >= 3)
        {
            m_recentAttackInput.RemoveAt(0);
            m_recentAttackInput.Add(m_attackType);
            attackCombo();
        }
        //StartCoroutine(C_attackDuration(m_lightAttackDuration));


    }

    override public void testTwo()
    {
        Debug.Log("test two success");
    }


    private void attackCombo()
    {


    }

}
