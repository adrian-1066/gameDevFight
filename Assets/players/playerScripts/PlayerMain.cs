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

    public int m_LightDamage;
    public float m_lightDist;
    public int m_MedDamage;
    public float m_medDist;
    public int m_hevDamage;
    public float m_hevDist;

    public float m_light1Dur;
    public float m_light2Dur;
    public float m_light3Dur;

    public float m_medDur;
    public float m_hevDur;

    public bool m_canAttack;
    public int m_damage;

    public GameObject m_enemy;
    public PlayerMain m_enemyMain;

    public bool m_isBlocking;

    public playerStats m_stats;

    public bool m_isStunned;

    public float m_dist;
    private void Start()
    {
        m_currentCombo2 = new int[2];
        m_currentCombo3 = new int[3];
        
    }

    virtual public void lightAttack()
    {

    }

    virtual public void medAttack()
    {

    }

    virtual public void hevAttack()
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

    public IEnumerator C_attackDuration(float duration, float distance, int damage)
    {
        yield return new WaitForSeconds(duration);
        m_canAttack = true;
        m_animator.SetBool("isAttacking", false);
        m_animator.SetInteger("attackType", -1);

        checkDistance(distance, damage, duration);
    }

    public IEnumerator C_stunDuration(float duration)
    {
        m_animator.SetBool("isGrabbed", true);
        m_player.GetComponent<playerControllor>().m_canMove = false;
        m_isStunned = true;
        m_canAttack = false;
        yield return new WaitForSeconds(duration);
        m_isStunned = false;
        m_canAttack = true;
        m_animator.SetBool("isGrabbed", false);
        m_player.GetComponent<playerControllor>().m_canMove = true;

    }

    public void checkDistance(float distance, int damage, float duration)
    {
        float tempDist = Vector3.Distance(m_player.transform.position, m_enemy.transform.position);

        //tempDist = (transform.position.x + m_enemy.transform.position.x) / 2;
        //Debug.Log(tempDist);
        if(tempDist <= distance)
        {
            m_enemyMain.takeDamage(damage, duration);
        }


    }

    public void takeDamage(int damage, float duration)
    {
        if(!m_isBlocking)
        {
            m_stats.takeDamage(damage);
            StartCoroutine(C_stunDuration(duration));
        }

    }




}
