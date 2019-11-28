using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  // Singleton setup.
  private static GameManager instance;
  public static GameManager Instance { get { return instance; } }

  [SerializeField]
  private AudioClip deathSound, winSound;
  private AudioSource audioSource;

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

    if (deathSound || winSound)
      audioSource = gameObject.AddComponent<AudioSource>();
  }

  public void Update()
  {
    // Restart if you press escape.
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      ResetGame();
    }
  }

    public void Death()
    {

        // Reset Game
        Debug.Log("Player has lost all of their lives.");
        ResetGame();
        return;
    } 

  public void NextLevel()
  {
    Debug.Log("Player has finished the level!");
    // Win sound
    if (winSound && audioSource)
      audioSource.PlayOneShot(winSound);
  }

  public void ResetGame()
  {
    instance = null;
    SceneManager.LoadScene(0);
    Destroy(gameObject);
  }
}