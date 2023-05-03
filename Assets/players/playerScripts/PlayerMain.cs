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
    public List<Vector2> m_recentAttackInput = new List<Vector2>();
    public listOfCombos m_comboList;
    protected int[] m_currentCombo2;
    protected int[] m_currentCombo3;

    public float m_light1Dur;
    public float m_light2Dur;
    public float m_light3Dur;

    public float m_medDur;
    public float m_hevDur;

    private void Start()
    {
        m_currentCombo2 = new int[2];
        m_currentCombo3 = new int[3];
        
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
        m_animator.SetInteger("attackType", -1);
    }

    

    
}
