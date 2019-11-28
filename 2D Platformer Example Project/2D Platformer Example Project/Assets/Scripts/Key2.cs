using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key2 : MonoBehaviour
{
    public GameObject GoldenKey2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameVariables.KeyCount += 1;
            Destroy(gameObject);
            GoldenKey2.SetActive(true);
            Debug.Log("Enabled");
            Debug.Log("Key collected");
        }
    }
}