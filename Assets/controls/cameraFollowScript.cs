using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowScript : MonoBehaviour
{
    public bool m_bothPlayersIn;

    public GameObject m_playerOne;
    public GameObject m_playerTwo;

    private void Start()
    {
        m_bothPlayersIn = false;
    }


    private void Update()
    {
        if(m_bothPlayersIn)
        {
            followPlayers();
        }
    }

    private void followPlayers()
    {
        float temp = (m_playerOne.transform.position.x + m_playerTwo.transform.position.x) / 2;

        if(temp >= -2 && temp <= 2)
        {
            Vector3 tempPos = new Vector3(temp, transform.position.y, transform.position.z);
            transform.position = tempPos;
        }

    }




}
