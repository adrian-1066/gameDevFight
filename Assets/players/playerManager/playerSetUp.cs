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

    private GameObject m_p1Actor;
    private GameObject m_p2Actor;


    public GameObject m_p1Ui;
    public GameObject m_p2Ui;
   
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
        temp.m_playerIndex = user;
        Animator tempAni = player.GetComponent<Animator>();

        
        if(user == 0)
        {

            m_p1Actor = player;
            temp.m_player = m_playerOne;
            m_playerOne.m_stats = m_playerOneChar.GetComponent<playerStats>();
            m_playerOne.m_player = player;
            m_playerOne.m_animator = tempAni;
            m_playerOne.m_comboList = m_comboList;
            tempAni.runtimeAnimatorController = m_playerOne.controller;
            m_damageTracker.m_playerOne = player.GetComponent<playerStats>();
            player.GetComponent<SpriteRenderer>().flipX = true;
            m_camFollow.m_playerOne = player;
            m_p1Ui.SetActive(false);
            m_p2Ui.SetActive(true);
        }
        else if(user == 1)
        {
            m_p2Actor = player;
            temp.m_player = m_playerTwo;
            m_playerTwo.m_stats = m_playerTwoChar.GetComponent<playerStats>();
            m_playerTwo.m_player = player;
            m_playerTwo.m_animator = tempAni;
            m_playerTwo.m_comboList = m_comboList;
            tempAni.runtimeAnimatorController = m_playerTwo.controller;
            m_damageTracker.m_playerTwo = player.GetComponent<playerStats>();
            m_camFollow.m_playerTwo = player;
            m_camFollow.m_bothPlayersIn = true;
            m_p2Ui.SetActive(false );

            setUpSecondary();
        }
        
        
    }

    private void setUpSecondary()
    {
        m_playerOne.m_enemyMain = m_playerTwo;
        m_playerOne.m_enemy = m_p2Actor;

        m_playerTwo.m_enemyMain = m_playerOne;
        m_playerTwo.m_enemy = m_p1Actor;

        m_damageTracker.m_playerOne = m_playerOne.GetComponent<playerStats>();
        m_damageTracker.m_playerTwo = m_playerTwo.GetComponent<playerStats>();

        m_p1Actor.gameObject.GetComponent<playerControllor>().m_hasGameStarted = true;
        m_p2Actor.gameObject.GetComponent<playerControllor>().m_hasGameStarted = true;
        m_damageTracker.m_hasGameStarted = true;



    }
}
