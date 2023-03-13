using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerSetUp : MonoBehaviour
{
    private PlayerMain m_playerOne;
    private PlayerMain m_playerTwo;
    public characterSO m_charList;

    private void Start()
    {
        m_playerOne = m_charList.AllCharScript[0];
        m_playerTwo = m_charList.AllCharScript[0];
    }

    public void setUpPlayer(GameObject player)
    {
        int user = player.GetComponent<PlayerInput>().user.index;
        playerControllor temp = player.GetComponent<playerControllor>();
        Animator tempAni = player.GetComponent<Animator>();

        
        if(user == 0)
        {
            

            temp.m_player = m_playerOne;
            m_playerOne.m_player = player;
            m_playerOne.m_animator = tempAni;
            tempAni.runtimeAnimatorController = m_playerOne.controller;
        }
        else if(user == 1)
        {
            temp.m_player = m_playerTwo;
            m_playerTwo.m_player = player;
            m_playerTwo.m_animator = tempAni;
            tempAni.runtimeAnimatorController = m_playerTwo.controller;
        }
        
        
    }
}
