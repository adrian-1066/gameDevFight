using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class damageTracker : MonoBehaviour
{

    public Slider m_playerOneUi;
    public Slider m_playerTwoUi;

    public playerStats m_playerOne;
    public playerStats m_playerTwo;

    public float m_timeTotal;
    public float m_currentSecond;
    public TMP_Text m_timer;

    public void updateHealth()
    {
        m_playerOneUi.value = m_playerOne.m_health;
        m_playerTwoUi.value = m_playerTwo.m_health;
    }

    // Update is called once per frame
    void Update()
    {

        if(m_playerOne != null)
        {
            updateHealth();
        }
        m_currentSecond += Time.deltaTime;
        if(m_currentSecond >= 1f)
        {
            m_timeTotal -= 1f;
            m_currentSecond = 0f;
            m_timer.text = m_timeTotal.ToString();
        }
        
        

        if(m_timeTotal <= 0f)
        {
            Debug.Log("game over");
        }
        //m_playerOneUi.value = m_playerOne.m_health;
        //m_playerTwoUi.value = m_playerTwo.m_health;

        //if(m_playerOne.m_health <= 0 || m_playerTwo.m_health <= 0)
        //{
        //    //end game
        //}
        //else if(m_playerOne.m_health <= 0 && m_playerTwo.m_health <= 0)
        //{
        //    //draw
        //}
      
        

    }
}
