using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
  private static Music instance;

  private void Awake()
  {
    // This will allow this game-object to travel across scenes and not get deleted.
    if (instance != null && instance != this)
    {
      Destroy(gameObject);
      return;
    }

    instance = this;
    DontDestroyOnLoad(gameObject);
  }

  private void Start()
  {
    AudioSource aSource = GetComponent<AudioSource>();
    aSource.Play();
  }
}