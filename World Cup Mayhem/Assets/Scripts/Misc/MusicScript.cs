using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicScript : MonoBehaviour
{

    public AudioClip[] clips;
    private AudioSource audioSource;

    public int m_index;
    public int m_repeatCounter1;
    public int m_repeatCounter2;
    public int m_repeatCounter3;
    public int m_repeatCounter4;


    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;

        m_repeatCounter1 = 0;
        m_repeatCounter2 = 0;
        m_repeatCounter3 = 0;
        m_repeatCounter4 = 0;
    }

    void Awake ()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");

        if(obj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
	}


    private AudioClip  GetClip()
    {
        m_index = Random.Range(0,clips.Length);

       if(m_index == 0)
       {
            m_repeatCounter1++;
            if((m_repeatCounter1/2) >= 1)
            {
                m_index++;
                m_repeatCounter1 = 0;
            }

       }
       if(m_index == 1)
       {
            m_repeatCounter2++;
            if ((m_repeatCounter2/2) >= 1)
            {
                m_index++;
                m_repeatCounter2 = 0;
            }

        }
       if(m_index == 2)
       {
            m_repeatCounter3++;
            if ((m_repeatCounter3/2) >= 1)
            {
                m_index++;
                m_repeatCounter3 = 0;
                
            }
        }
        if (m_index == 3)
        {
            m_repeatCounter4++;
            if ((m_repeatCounter4 / 2) >= 1)
            {
                m_index = 0;
                m_repeatCounter4 = 0;

            }
        }


        return clips[m_index];
    }



    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = GetClip();
            audioSource.Play();
        }
    }




}
