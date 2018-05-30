using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    public GameObject m_player;

    public Vector3 m_goCenter;
    public Vector3 m_touchPosition;
    public Vector3 m_offset;
    public Vector3 m_newGOCenter;

    RaycastHit hit;

    public bool m_dragging = false;



    public void Update()
    {
        // can prbly use the for loop setup aswell
        foreach(Touch m_touch in Input.touches)
        {
            switch(m_touch.phase)
            {
                case TouchPhase.Began:
                    Ray ray = Camera.main.ScreenPointToRay(m_touch.position);

                    if(Physics.SphereCast(ray,0.3f, out hit))
                    {
                        m_player = hit.collider.gameObject;
                        m_goCenter = m_player.transform.position;
                        m_touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        m_offset = m_touchPosition - m_goCenter;
                        m_dragging = true;


                    }
                    break;
                case TouchPhase.Moved:
                    if(m_dragging)
                    {
                        m_touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        m_newGOCenter = m_touchPosition - m_offset;
                        m_player.transform.position = new Vector3(m_newGOCenter.x,m_newGOCenter.y,m_newGOCenter.z);
                    }
                    break;
                case TouchPhase.Ended:
                    m_dragging = false;
                    break;
            }

        }

    }

}