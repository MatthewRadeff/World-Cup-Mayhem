﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    // using the dimensions of the edges of the camera to give a spawn for the ball
    private float m_topOfCamera = 5.0f;
    private float m_bottomOfCamera = -5.5f;
    private float m_rightOfCamera = 2.7f;
    private float m_leftOfCamera = -2.7f;

    // values being used to show where the ball will be 
    private float m_xcoord;
    private float m_ycoord;
   

    // rigidbody of ball
    private Rigidbody2D m_ballRB;

    // the sprite of the ball gameobject
    private Sprite m_ballSprite;

    // referencing the character selection script  
    public CharacterSelection m_csScript;


	// Use this for initialization
	void Start ()
    {
        // getting the rigidbody of the ball
        m_ballRB = gameObject.GetComponent<Rigidbody2D>();

        // referencing the character selection script to grab the saved index of the sprite saved
        m_csScript.m_index = PlayerPrefs.GetInt("BallSelected");

        // getting the sprite/ sprite renderer of tha ball...referencing the CS script. grabbing the sprite list and using the index that was saved to set the new sprite
        m_ballSprite = gameObject.GetComponent<SpriteRenderer>().sprite = m_csScript.m_soccerBallList[m_csScript.m_index];
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        // knowing location of ball
        m_ycoord = m_ballRB.transform.position.y;
        m_xcoord = m_ballRB.transform.position.x;

        transform.Rotate(0,0,-5.0f);

        if (m_ycoord < m_bottomOfCamera)
        {
       
            // first by setting a new random x coord.
            m_xcoord = Random.Range(m_leftOfCamera, m_rightOfCamera);

            // setting new location and speed of ball
            m_ballRB.transform.position = new Vector2(m_xcoord, m_topOfCamera);
            m_ballRB.velocity = new Vector3(0, 0, 0);
        }

    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bottom") || other.gameObject.CompareTag("Barrier"))
        {
            // spawning ball back at the top when it scores..or glitches out and hits the barrier
            m_xcoord = Random.Range(m_leftOfCamera, m_rightOfCamera);
            m_ballRB.transform.position = new Vector2(m_xcoord, m_topOfCamera);
            m_ballRB.velocity = new Vector3(0, 0, 0);

        }
        
    }

}