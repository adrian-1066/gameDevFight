using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageTracker : MonoBehaviour
{

    public Slider m_playerOneUi;
    public Slider m_playerTwoUi;

    public playerStats m_playerOne;
    public playerStats m_playerTwo;

   

    public void updateHealth()
    {
        m_playerOneUi.value = m_playerOne.m_health;
        m_playerTwoUi.value = m_playerTwo.m_health;
    }

    // Update is called once per frame
    void Update()
    {

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
