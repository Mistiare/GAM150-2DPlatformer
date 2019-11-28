using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassageKey : MonoBehaviour
{
    public GameObject Key1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameVariables.KeyCount > 0)
        {
            if (Key1.activeInHierarchy)
            {
                Key1.SetActive(false);
                GameVariables.KeyCount--;
                Destroy(gameObject);
            }
        }
    }
}