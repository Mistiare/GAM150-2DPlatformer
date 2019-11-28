using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public GameObject Key2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameVariables.KeyCount > 0)
        {
            if (Key2.activeInHierarchy)
            {
                Key2.SetActive(false);
                GameVariables.KeyCount--;
                Destroy(gameObject);
                GameManager.Instance.NextLevel();
            }
        }
    }
}
