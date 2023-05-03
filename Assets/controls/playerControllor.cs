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
    private void Start()
    {
        m_isMoving = false;
        m_playerSetUp = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<playerSetUp>();
        m_playerSetUp.setUpPlayer(gameObject);
        m_animator = gameObject.GetComponent<Animator>();

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
       
        Vector3 dir = context.ReadValue<Vector2>();
        if(dir == Vector3.zero)
        {
            m_isMoving = false;
            m_animator.SetBool("isWalking", false);
        }
        else
        {
            m_direction = dir;
            m_isMoving = true;
            m_animator.SetBool("isWalking", true);
        }
        
        
    }

    public void lightAttack(InputAction.CallbackContext context)
    {
        
        if(context.ReadValue<float>() == 1 )
        {
            //Debug.Log("light attack");
            m_player.lightAttack();
            StartCoroutine(C_attackDuration(m_player.m_lightAttackDuration));
        }
        else if(context.ReadValue<float>() == 0)
        {
            //Debug.Log("attack ended");
        }
        else
        {
            //Debug.Log("ahhhhhh");
        }
        
    }

    public void normalAttack(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            //Debug.Log("light attack");
            m_player.testTwo();
        }
    }

    public void heavyAttack(InputAction.CallbackContext context)
    {

    }

    public IEnumerator C_attackDuration(float duration)
    {

        yield return new WaitForSeconds(duration);
        m_animator.SetBool("isAttacking", false);
    }

    
}
