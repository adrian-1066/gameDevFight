using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public int charID;
    public RuntimeAnimatorController controller;
    public Animator m_animator;
    public GameObject m_player;

    public float m_lightAttackDuration;
    protected int m_attackType;
    public List<int> m_recentAttackInput = new List<int>();

    private void Start()
    {
        
    }

    virtual public void lightAttack()
    {

    }

    public void testOne()
    {
        Debug.Log("test one");
    }

    virtual public void testTwo()
    {
        Debug.Log("test two failed");
    }

    public IEnumerator C_attackDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        m_animator.SetBool("isAttacking", false);
    }

    
}
