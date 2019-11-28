using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public GameObject Key1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameVariables.KeyCount += 1;
            Destroy(gameObject);
            Key1.SetActive(true);
            Debug.Log("Enabled");
            Debug.Log("Key collected");
        }
    }
}
