using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YRCard : MonoBehaviour
{

    public void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("YellowCard") || other.gameObject.CompareTag("RedCard"))
        {
            Destroy(other.gameObject);
        }
    }

}
