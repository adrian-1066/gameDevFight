using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterA : PlayerMain
{
    

    

    override public void lightAttack()
    {
        m_animator.SetBool("isAttacking", true);
        //m_animator.SetInteger("attackType", 0);
        m_attackType = 0;
        Vector2 temp = new Vector2(m_attackType, Time.time);
        m_recentAttackInput.Add(temp);
        int attackAni = attackCombo();

        m_animator.SetInteger("attackType", attackAni);
        

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


                int comboToDo = comboCheck(comboSize);
                int comboAni;
                if (comboSize == 2)
                {
                    int temp0 = ((int)(m_recentAttackInput[0].x));
                    int temp1 = ((int)(m_recentAttackInput[1].x));
                    int[] tempCombo = new int[comboSize];
                    tempCombo[0] = temp0;
                    tempCombo[1] = temp1;
                    m_currentCombo2 = tempCombo;
                    //int zeroInp = ((int)temp0);
                    comboAni = m_comboList.m_list2[comboToDo].m_animationNum;
                    return comboAni;
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
                    Debug.Log(comboToDo);
                    comboAni = m_comboList.m_list3[comboToDo].m_animationNum;
                    return comboAni;
                }
                else
                {
                    return m_attackType;
                }

                


            }
            else
            {
                return m_attackType;
            }


            //the if check should check for 2 then 3, if 2 is a yes then it checks 3, if 3 is yes then play animation if it is a no then it plays the 2 animation
            


        }
        else
        {
            return m_attackType;
        }

    }


    private int comboCheck(int comboSize)
    {
        int comboToDo = -1;
        if(comboSize == 2)
        {
            for(int x = 0; x < m_comboList.m_list2.Length; x++)
            {
                if (m_comboList.m_list2[x].comboPattern == m_currentCombo2)
                {
                    comboToDo = x;
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
                if (m_comboList.m_list3[x].comboPattern == m_currentCombo3)
                {
                    comboToDo = x;
                    break;
                }
            }
            return comboToDo;

        }
        else
        {
            return -1;
        }


        
    }

}
