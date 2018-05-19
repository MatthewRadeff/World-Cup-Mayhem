using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterSelection : MonoBehaviour
{
    // image being changed to be selected
    public Image m_soccerBallImage;

    // list of Soccer balls
    public List<Sprite> m_soccerBallList = new List<Sprite>();

    // position of ball selected
    public int m_index = 0;


    void Start()
    {
       
    }

    // right button to select soccer balls
    public void RightSelection()
    {
        if(m_index < m_soccerBallList.Count - 1)
        {
            m_index++;
            m_soccerBallImage.sprite = m_soccerBallList[m_index];
            
        }
       
    }

    // left button to select soccer balls
    public void LeftSelection()
    {
        if (m_index > 0)
        {
            m_index--;
            m_soccerBallImage.sprite = m_soccerBallList[m_index];
           
        }
    }


    public void ChangeScene(string sceneName)
    {
        // saves ball being selected
        PlayerPrefs.SetInt("BallSelected", m_index);
        // loads into scene
        SceneManager.LoadScene(sceneName);    
    }


}