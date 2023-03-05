using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cursorControls : MonoBehaviour
{
    public bool m_controllorMouseMove;
    Vector2 m_mouseChange;
    public void moveMouseCursor(InputAction.CallbackContext context)
    {

        if (m_controllorMouseMove)
        {
            m_controllorMouseMove = false;
            
        }
        else
        {
            m_mouseChange = context.ReadValue<Vector2>();
            m_controllorMouseMove = true;
        }
        
        
        Debug.Log(m_mouseChange);
        
        

        
        

    }

    private void Update()
    {
        
        if(m_controllorMouseMove)
        {
            
            Vector2 currentMousePos = Mouse.current.position.ReadValue();
            Mouse.current.WarpCursorPosition((currentMousePos += m_mouseChange));
        }
    }
}
