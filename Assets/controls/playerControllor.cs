using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControllor : MonoBehaviour
{
    private bool m_isMoving;
    private Vector3 m_direction;
    [SerializeField]
    private float m_moveSpeed;

    public PlayerMain m_player;
    private playerSetUp m_playerSetUp;
    private Animator m_animator;

    public int m_playerIndex;

    public bool m_hasGameStarted;

    public bool m_canMove;
    private void Start()
    {
        m_canMove = true;
        m_isMoving = false;
        m_playerSetUp = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<playerSetUp>();
        m_playerSetUp.setUpPlayer(gameObject);
        m_animator = gameObject.GetComponent<Animator>();
        m_player.m_canAttack = true;

    }

    private void Update()
    {
        if(m_isMoving)
        {
            transform.position += (m_direction * m_moveSpeed);
        }
    }

    public void move(InputAction.CallbackContext context)
    {
       if(!m_hasGameStarted)
        {
            return;
        }

       if(!m_canMove)
        {
            m_isMoving=false;
            return;
        }

        Debug.Log("i am moving");
        Vector3 dir = context.ReadValue<Vector2>();
        if(dir == Vector3.zero)
        {
            m_isMoving = false;
            m_animator.SetBool("isWalking", false);
        }
        else
        {
            m_direction = dir;
            m_direction.y = 0f;
            m_isMoving = true;
            m_animator.SetBool("isWalking", true);
        }
        
        
    }

    public void lightAttack(InputAction.CallbackContext context)
    {
        if (!m_hasGameStarted)
        {
            return;
        }

        if (m_player.m_canAttack)
        {
            

            if (context.ReadValue<float>() == 1)
            {
                //Debug.Log("light attack");
                m_player.lightAttack();
               // m_player.m_canAttack = false;
                //StartCoroutine(C_attackDuration(m_player.m_lightAttackDuration));
            }
            else if (context.ReadValue<float>() == 0)
            {
                //Debug.Log("attack ended");
            }
            else
            {
                //Debug.Log("ahhhhhh");
            }
        }
        
    }

    public void normalAttack(InputAction.CallbackContext context)
    {
        if (!m_hasGameStarted)
        {
            return;
        }

        if (context.ReadValue<float>() == 1)
        {
            m_player.medAttack();
            //m_player.m_canAttack = false;
            //Debug.Log("light attack");
            //m_player.testTwo();
        }
    }

    public void heavyAttack(InputAction.CallbackContext context)
    {
        if (!m_hasGameStarted)
        {
            return;
        }

        if (context.ReadValue<float>() == 1)
        {
            m_player.hevAttack();

        }
    }

    public IEnumerator C_attackDuration(float duration)
    {

        yield return new WaitForSeconds(duration);
        m_animator.SetBool("isAttacking", false);
        m_player.m_canAttack = true;
    }

    

    
}
