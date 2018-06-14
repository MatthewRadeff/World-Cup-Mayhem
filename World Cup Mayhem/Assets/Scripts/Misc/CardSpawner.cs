using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    // using the dimensions of the edges of the camera to give a spawn for the cards
    private float m_topOfCamera = 8.0f;
    private float m_rightOfCamera = 2.7f;
    private float m_leftOfCamera = -2.7f;

    public GameObject m_yellowCardPrefab = null;
    public GameObject m_redCardPrefab = null;
    public GameObject m_cardSpawner = null;

    public float m_ycSpawnSeconds;
    public float m_rcSpawnSeconds;
    public float m_spawnSeconds = 2.0f;
    public float m_waitToSpawn = 10.0f;

    private float m_xcoord;

    public int m_redCardCount;
    public int m_yellowCardCount;

    // Use this for initialization
    void Start ()
    {
        m_redCardCount = 0;
        m_yellowCardCount = 0;
        
        StartCoroutine(SpawnRYCards());

    }
	



    private IEnumerator SpawnRYCards()
    {
        while(true)
        {
            if(m_yellowCardCount == 0)
            {
                yield return new WaitForSeconds(this.m_spawnSeconds);
                StartCoroutine(SpawnYellowCard());
            }
            if(m_redCardCount == 0)
            {
                yield return new WaitForSeconds(this.m_spawnSeconds);
                StartCoroutine(SpawnRedCard());
            }
            
        }
    }

    // coroutine to spawn cards at random intervals
    private IEnumerator SpawnYellowCard()
    {
        while(true)
        {
            yield return new WaitForSeconds(this.m_spawnSeconds);
            m_ycSpawnSeconds = Random.Range(30, 60);
            Debug.Log("yellow card spawns in: " + m_ycSpawnSeconds);
           yield return new WaitForSeconds(this.m_ycSpawnSeconds);
            if(m_yellowCardCount <= 2)
            {
                GameObject ycard = Instantiate(this.m_yellowCardPrefab) as GameObject;
                m_xcoord = Random.Range(m_leftOfCamera, m_rightOfCamera);
                ycard.GetComponent<Rigidbody2D>().transform.position = new Vector3(m_xcoord, m_topOfCamera, 5.0f);
                ycard.GetComponent<BoxCollider2D>().transform.position = new Vector3(m_xcoord, m_topOfCamera, 5.0f);
                m_yellowCardCount++;  
            }
            else
            {
                Debug.Log("stopped yellow card coroutine cuz too many cards rn");
                StopCoroutine(SpawnYellowCard());
                yield return new WaitForSeconds(this.m_waitToSpawn);
                Debug.Log("resumed yellow card coroutine");
                m_yellowCardCount = 0;
                StartCoroutine(SpawnYellowCard());
            }

        }
    }


    private IEnumerator SpawnRedCard()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.m_spawnSeconds);
            m_rcSpawnSeconds = Random.Range(60, 90);
            Debug.Log("red card spawns in: " + m_rcSpawnSeconds);
           yield return new WaitForSeconds(this.m_rcSpawnSeconds);
            if(m_redCardCount <= 2)
            {
                GameObject rcard = Instantiate(this.m_redCardPrefab) as GameObject;
                m_xcoord = Random.Range(m_leftOfCamera, m_rightOfCamera);
                rcard.GetComponent<Rigidbody2D>().transform.position = new Vector3(m_xcoord, m_topOfCamera, 5.0f);
                rcard.GetComponent<BoxCollider2D>().transform.position = new Vector3(m_xcoord, m_topOfCamera, 5.0f);
                m_redCardCount++;
            }
            else
            {
                Debug.Log("stopped red card coroutine cuz too many cards rn");
                StopCoroutine(SpawnRedCard());
                yield return new WaitForSeconds(this.m_waitToSpawn);
                Debug.Log("resumed red card coroutine");
                m_redCardCount = 0;
                StartCoroutine(SpawnRedCard());
            }


        }
    }
}
