using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YRCard : MonoBehaviour
{

    public void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("YellowCard") || other.gameObject.CompareTag("RedCard"))
        {
            FindObjectOfType<AudioManager>().Play("Card");
            Destroy(other.gameObject);
        }
    }

}
