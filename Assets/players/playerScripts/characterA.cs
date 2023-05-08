using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterA : PlayerMain
{
    

    

    override public void lightAttack()
    {
        if(!m_canAttack)
        {
            return;
        }
        m_canAttack = false;
        m_animator.SetBool("isAttacking", true);
        //m_animator.SetInteger("attackType", 0);
        m_attackType = 0;
        Vector2 temp = new Vector2(m_attackType, Time.time);
        m_recentAttackInput.Add(temp);
        int attackAni = attackCombo();
        //Debug.Log(attackAni);
        m_animator.SetInteger("attackType", attackAni);

        if(attackAni == m_attackType)
        {
            m_damage = m_LightDamage;
            m_dist = m_lightDist;
        }
        if (m_recentAttackInput.Count >= 3)
        {
            m_recentAttackInput.Clear();
        }
        float tempDur;

        if(attackAni == 0)
        {
            tempDur = m_light1Dur;
        }
        else if(attackAni == 22)
        {
            tempDur = m_light2Dur;
        }
        else if(attackAni == 20)
        {
            tempDur = m_light3Dur;
        }
        else
        {
            tempDur = m_light1Dur;
        }

        StartCoroutine(C_attackDuration(tempDur, m_dist, m_damage));

    }

    public override void medAttack()
    {
        if (!m_canAttack)
        {
            return;
        }
        m_canAttack = false;
        m_animator.SetBool("isAttacking", true);
        m_attackType = 1;
        Vector2 temp = new Vector2(m_attackType, Time.time);
        m_recentAttackInput.Add(temp);
        int attackAni = attackCombo();
        m_animator.SetInteger("attackType", attackAni);
        if (attackAni == m_attackType)
        {
            m_damage = m_MedDamage;
            m_dist = m_medDist; ;
        }

        float tempDur;

        if (attackAni == 1)
        {
            tempDur = m_medDur;
        }
        else if (attackAni == 22)
        {
            Debug.Log("doing the med hev combo");
            tempDur = m_light2Dur;
        }
        else if (attackAni == 20)
        {
            Debug.Log("doing the med light combo");
            tempDur = m_light3Dur;
        }
        else
        {
            
            tempDur = m_medDur;
        }

        StartCoroutine(C_attackDuration(tempDur, m_dist, m_damage));
    }

    public override void hevAttack()
    {
        if (!m_canAttack)
        {
            return;
        }
        m_canAttack = false;
        m_animator.SetBool("isAttacking", true);
        m_attackType = 2;
        Vector2 temp = new Vector2(m_attackType, Time.time);
        m_recentAttackInput.Add(temp);
        int attackAni = attackCombo();
        m_animator.SetInteger("attackType", attackAni);
        if (attackAni == m_attackType)
        {
            m_damage = m_hevDamage;
            m_dist = m_hevDist;
        }

        float tempDur;
        if (attackAni == 2)
        {
            tempDur = m_hevDur;
        }
        else if (attackAni == 22)
        {
            tempDur = m_light2Dur;
        }
        else if (attackAni == 20)
        {
            tempDur = m_light3Dur;
        }
        else
        {
            tempDur = m_hevDur;
        }

        StartCoroutine(C_attackDuration(tempDur, m_dist, m_damage));
    }

    override public void testTwo()
    {
        Debug.Log("test two success");
    }


    private int attackCombo()
    {
        if(m_recentAttackInput.Count > 1)
        {
            float to2timeDif = 30f;
            bool to2NotNull = false;
            int comboSize;
            //in the list 0 would be the oldest attack input
            float to1timeDif = m_recentAttackInput[0].y - m_recentAttackInput[1].y;
            if(m_recentAttackInput.Count >= 3)
            {
                to2timeDif = m_recentAttackInput[0].y - m_recentAttackInput[2].y;
                to2NotNull = true;
            }
            
            if (to1timeDif <= 1f)
            {
                if(to2NotNull)
                {
                    if(to2timeDif <= 1.5f)
                    {

                        comboSize = 3;


                    }
                    else
                    {
                        comboSize = 2;
                    }

                }
                else
                {
                    comboSize = 2;
                }


                Debug.Log("the combo size is " + comboSize);

                if(comboSize == 2)
                {
                    int temp0 = ((int)(m_recentAttackInput[0].x));
                    int temp1 = ((int)(m_recentAttackInput[1].x));
                    int[] tempCombo = new int[comboSize];
                    Debug.Log(tempCombo[0] + " " + tempCombo[1]);
                    tempCombo[0] = temp0;
                    tempCombo[1] = temp1;
                    m_currentCombo2 = tempCombo;


                }
                else if(comboSize == 3)
                {
                    int temp0 = ((int)(m_recentAttackInput[0].x));
                    int temp1 = ((int)(m_recentAttackInput[1].x));
                    int temp2 = ((int)(m_recentAttackInput[2].x));
                    int[] tempCombo = new int[comboSize];
                    tempCombo[0] = temp0;
                    tempCombo[1] = temp1;
                    tempCombo[2] = temp2;
                    m_currentCombo3 = tempCombo;

                }


                int comboToDo = comboCheck(comboSize);
                int comboAni;
                Debug.Log("the combo to do " + comboToDo);
                if(comboToDo != -1)
                {
                    
                    comboAni = comboToDo;
                    Debug.Log("combo ani is " + comboAni);
                    return comboAni;
                }
                else
                {
                    Debug.Log("there is no combo ani");
                    return m_attackType;
                }
                               

            }
            else
            {
                m_recentAttackInput.Clear();
                return m_attackType;
            }


            
            


        }
        else
        {
            Debug.Log("there is not enough inputs");
            return m_attackType;
        }

    }


    private int comboCheck(int comboSize)
    {
        int comboToDo = -1;
        if(comboSize == 2)
        {
            Debug.Log("checking for combo size 2");
            for(int x = 0; x < m_comboList.m_list2.Length; x++)
            {
                if (m_comboList.m_list2[x].comboPattern[0] == m_currentCombo2[0] && m_comboList.m_list2[x].comboPattern[1] == m_currentCombo2[1])
                {
                    //comboToDo = x;
                    comboToDo = m_comboList.m_list2[x].m_animationNum;
                    m_damage = m_comboList.m_list2[x].m_attackDamage;
                    m_dist = m_comboList.m_list2[x].m_distance;
                    Debug.Log("combo found for combo size 2");
                    break;
                }
            }

            return comboToDo;
        }
        else if(comboSize == 3)
        {
            //Debug.Log(m_comboList.m_list3[0].m_animationNum);
            for (int x = 0; x < m_comboList.m_list3.Length; x++)
            {
                //Debug.Log(x);
                if (m_comboList.m_list3[x].comboPattern[0] == m_currentCombo3[0] && m_comboList.m_list3[x].comboPattern[1] == m_currentCombo3[1] && m_comboList.m_list3[x].comboPattern[2] == m_currentCombo3[2]  )
                {
                    //comboToDo = x;
                    comboToDo = m_comboList.m_list3[x].m_animationNum;
                    m_damage = m_comboList.m_list3[x].m_attackDamage;
                    m_dist = m_comboList.m_list3[x].m_distance;
                    Debug.Log("combo found for combo size 3");
                    break;
                }
            }
            return comboToDo;

        }
        else
        {
            Debug.Log("no combo has been found");
            return -1;
        }


        
    }

}
