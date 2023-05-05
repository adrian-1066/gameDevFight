using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerSetUp : MonoBehaviour
{
    private PlayerMain m_playerOne;
    private GameObject m_playerOneChar;
    private PlayerMain m_playerTwo;
    private GameObject m_playerTwoChar;
    public characterSO m_charList;

    public listOfCombos m_comboList;

    private damageTracker m_damageTracker;
    private cameraFollowScript m_camFollow;
    private void Awake()
    {
        m_damageTracker = GetComponent<damageTracker>();

    }
    private void Start()
    {
        
        m_playerOneChar = Instantiate(m_charList.AllCharScript[0].gameObject);
        m_playerTwoChar = Instantiate(m_charList.AllCharScript[0].gameObject);
        m_playerOne = m_playerOneChar.GetComponent<PlayerMain>();
        m_playerTwo = m_playerTwoChar.GetComponent<PlayerMain>();
        m_camFollow = Camera.main.GetComponent<cameraFollowScript>();
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
            m_playerOne.m_comboList = m_comboList;
            tempAni.runtimeAnimatorController = m_playerOne.controller;
            m_damageTracker.m_playerOne = player.GetComponent<playerStats>();
            player.GetComponent<SpriteRenderer>().flipX = true;
            m_camFollow.m_playerOne = player;
        }
        else if(user == 1)
        {
            temp.m_player = m_playerTwo;
            m_playerTwo.m_player = player;
            m_playerTwo.m_animator = tempAni;
            m_playerTwo.m_comboList = m_comboList;
            tempAni.runtimeAnimatorController = m_playerTwo.controller;
            m_damageTracker.m_playerTwo = player.GetComponent<playerStats>();
            m_camFollow.m_playerTwo = player;
            m_camFollow.m_bothPlayersIn = true;
        }
        
        
    }
}
