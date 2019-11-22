using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  // Singleton setup.
  private static GameManager instance;
  public static GameManager Instance { get { return instance; } }

  public int startingLives = 10;
  public float timeToWin = 300f;

  [HideInInspector]
  public int livesRemaining;
  [HideInInspector]
  public float timeRemaining;

  private bool countdownTime = true;

  private GUIStyle guiStyle = new GUIStyle();

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

    // Set lives and timer.
    livesRemaining = startingLives;
    timeRemaining = timeToWin;

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

    // Do nothing if we're not counting down time.
    if (!countdownTime)
      return;

    // Decrease time
    timeRemaining -= Time.deltaTime;

    if (timeRemaining < 0)
    {
      // Reset Game
      Debug.Log("Player has ran out of time!");
      ResetGame();
    }
  }

  private void OnGUI()
  {
    // Show lives and time left.
    guiStyle.fontSize = 30;
    GUILayout.Label(" Lives: " + livesRemaining, guiStyle);
    GUILayout.Label(" Time Left: " + timeRemaining.ToString("0"), guiStyle);
  }

  public void Death()
  {
    // Remove a life.
    livesRemaining--;

    // Sound
    if (deathSound && audioSource)
      audioSource.PlayOneShot(deathSound);

    if (livesRemaining < 0)
    {
      // Reset Game
      Debug.Log("Player has lost all of their lives.");
      ResetGame();
      return;
    }

    // Reload the level.
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void NextLevel()
  {
    Debug.Log("Player has finished the level!");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

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

  public void StopClock()
  {
    countdownTime = false;
  }
}