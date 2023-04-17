using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSelection : MonoBehaviour
{
    public int[] m_playerSelections;
    private int m_currentPlayer;

    public GameObject m_selectionMenu;

    private void Start()
    {
        m_playerSelections = new int[2];
    }
    public void CharSelected(charID charID)
    {
        m_playerSelections[m_currentPlayer] = charID.ID;
        m_currentPlayer++;
        if(m_currentPlayer >= 2)
        {
            //start fight
            m_currentPlayer = 0;
        }
    }

    public void startFight()
    {


    }
}
