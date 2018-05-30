using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalieScript : MonoBehaviour
{
    public PlayerInput m_script;
    private bool m_isTap;
    private bool m_isSwipeLeft;
    private bool m_isSwipeRight;
    private bool m_isDragging = false;

    private Vector2 m_startTouch;
    private Vector2 m_swipeDelta;

    private void Update()
    {
        // resetting every frame
        m_isTap = m_isSwipeRight = m_isSwipeLeft = false;

        #region Computer Input
        if(Input.GetMouseButtonDown(0))
        {
            m_isTap = true;
            m_isDragging = true;
            m_startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            m_isDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Input 
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                m_isTap = true;
                m_isDragging = true;
                m_startTouch = Input.touches[0].position;
            }
            if(Input.touches[0].phase == TouchPhase.Moved)
            {
                m_isDragging = true;
                m_script.m_player.transform.position = transform.position; 
               
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                m_isDragging = false;
                Reset();
            }
        }


        #endregion 


        // calculate the distance
        m_swipeDelta = Vector2.zero;

        if(m_isDragging)
        {
            if(Input.touches.Length > 0)
            {
                m_swipeDelta = Input.touches[0].position - m_startTouch;
                m_script.m_player.transform.position = m_swipeDelta;
            }
            else if(Input.GetMouseButton(0))
            {
                // vector 2 is in parenthesis cuz mouse position is a vector 3 so we are casting it into vector 2
                m_swipeDelta = (Vector2)Input.mousePosition - m_startTouch;
                m_script.m_player.transform.position = m_swipeDelta;
            }
        }


        // did we cross the swiping deadzone...so it knows it wants a swipe
        if(m_swipeDelta.magnitude > 10)
        {
            // which direction?
            float x = m_swipeDelta.x;
            float y = m_swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                // left or right
                if(x < 0)
                {
                    m_isSwipeLeft = true;
                }
                else
                {
                    m_isSwipeRight = true;
                }
            }
            Reset();
        }
    }

    private void Reset()
    {
        m_startTouch = m_swipeDelta = Vector2.zero;
        m_isDragging = false;
    }

    
    public Vector2 SwipeDelta { get { return m_swipeDelta; } }
    public bool SwipeLeft { get { return m_isSwipeLeft; } }
    public bool SwipeRight { get { return m_isSwipeRight; } }
    public bool Tap { get { return m_isTap; } }

	
}
