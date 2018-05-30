using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public GoalieScript m_swipeControls;
    public Transform m_player;
    private Vector3 m_desiredPosition;

    private void Update()
    {
        if(m_swipeControls.SwipeLeft)
        {
            m_desiredPosition += Vector3.left;
        }
        if(m_swipeControls.SwipeRight)
        {
            m_desiredPosition += Vector3.right;
        }


        m_player.transform.position = Vector3.MoveTowards(m_player.transform.position,m_desiredPosition, 3f * Time.deltaTime);

        if(m_swipeControls.Tap)
        {
            Debug.Log("tap!");
        }
    }

}
