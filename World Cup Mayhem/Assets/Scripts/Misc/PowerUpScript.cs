using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerUpScript : MonoBehaviour
{

    // empty yellow card images
    public GameObject m_card1;
    public GameObject m_ycard1;
    public GameObject m_card2;
    public GameObject m_ycard2;
    public int m_yellowCardCounter;
    

	// Use this for initialization
	void Start ()
    {
        // setting card counter to 0
        m_yellowCardCounter = 0;

        m_ycard1.SetActive(false);
        m_ycard2.SetActive(false);

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(m_yellowCardCounter >= 2)
        {
            SceneManager.LoadScene("GameOverYellowCard");
        }
		
	}


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("YellowCard"))
        {
            FindObjectOfType<AudioManager>().Play("Card");
            m_yellowCardCounter++;
            //Debug.Log(m_yellowCardCounter);
            Destroy(other.gameObject);
            if(m_yellowCardCounter == 1)
            {
                m_card1.SetActive(false);
                m_ycard1.SetActive(true);
            }
            if(m_yellowCardCounter >= 2)
            {
                m_card2.SetActive(false);
                m_ycard2.SetActive(true);
            }
        }
        if(other.gameObject.CompareTag("RedCard"))
        {
            FindObjectOfType<AudioManager>().Play("Card");
            Destroy(other.gameObject);
            SceneManager.LoadScene("GameOverRedCard");
        }
        
    }




}
