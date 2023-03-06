using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cursorControls : MonoBehaviour
{
    public bool m_controllorMouseMove;
    Vector3 m_mouseChange;

    [SerializeField]
    private float m_mouseSpeed;
    public void moveMouseCursor(InputAction.CallbackContext context)
    {
        Vector3 Dir = context.ReadValue<Vector2>();



        if (Dir == Vector3.zero)
        {
            m_controllorMouseMove = false;
        }
        else
        {
            m_mouseChange = Dir;
            m_controllorMouseMove = true;
        }



        //Debug.Log(m_mouseChange);






    }

    private void Update()
    {

        if (m_controllorMouseMove)
        {
            transform.position += (m_mouseChange * m_mouseSpeed);
            Vector3 mousePos = Camera.main.WorldToScreenPoint(transform.position);
            Debug.Log(mousePos);
            Mouse.current.WarpCursorPosition(mousePos);

        }
        else
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 tempPos = Camera.main.ScreenToWorldPoint(mousePos);
            tempPos.z = 0;
            transform.position = tempPos;
        }
    }
}
