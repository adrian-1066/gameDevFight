using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class damageTracker : MonoBehaviour
{

    public Slider m_playerOneUi;
    public Slider m_playerTwoUi;

    public playerStats m_playerOne;
    public playerStats m_playerTwo;

    public float m_timeTotal;
    public float m_currentSecond;
    public TMP_Text m_timer;

    public bool m_hasGameStarted;

    public bool m_hasGameFinished;

    public GameObject m_gameOverScreen;
    public TMP_Text m_winnersText;
    public TMP_Text m_endTimer;
    public float m_endTimeTotal;
    public float m_endTimeSec;

    public void updateHealth()
    {
        m_playerOneUi.value = m_playerOne.m_health;
        m_playerTwoUi.value = m_playerTwo.m_health;
        if(m_playerOne.m_health <= 0f || m_playerTwo.m_health <= 0f)
        {
            gameOver();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(m_hasGameFinished)
        {
            m_endTimer.text = m_endTimeTotal.ToString();
            m_endTimeSec += Time.deltaTime;
            if(m_endTimeSec >= 1f)
            {
                m_endTimeTotal -= 1f;
                m_endTimer.text = m_endTimeTotal.ToString();
                m_endTimeSec = 0f;
            }

            if(m_endTimeTotal <= 0f)
            {
                SceneManager.LoadScene("endStage", LoadSceneMode.Single);
            }

        }

        if(!m_hasGameStarted)
        {
            return;
        }

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
            gameOver();
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

    private void gameOver()
    {
        m_hasGameStarted = false;
        m_hasGameFinished = true;
        m_gameOverScreen.SetActive(true);


        if(m_playerOne.m_health > m_playerTwo.m_health)
        {
            m_winnersText.text = "Player one wins";
            //p1 wins
        }
        else if(m_playerOne.m_health < m_playerTwo.m_health)
        {
            m_winnersText.text = "Player two wins";
            //p2 wins
        }
        else
        {
            m_winnersText.text = "wow... a draw";
            //draw
        }



    }
}
