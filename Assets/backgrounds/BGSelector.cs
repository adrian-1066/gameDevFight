using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BGSelector : MonoBehaviour
{
    public backGroundsSO m_BGList;
    public int m_currentBG;
    public GameObject m_BG;
    private SpriteRenderer m_BGRenderer;
    private void Start()
    {
        m_BGRenderer = m_BG.GetComponent<SpriteRenderer>();

        SetBackgroud();
    }

    

    private void SetBackgroud()
    {
        m_BGRenderer.sprite = m_BGList.m_backgroundList[m_currentBG];

    }

    
}
