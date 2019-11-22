using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
  private void Start()
  {
    if (GameManager.Instance)
      GameManager.Instance.StopClock();
  }

  public void ResetGame()
  {
    if (GameManager.Instance)
      GameManager.Instance.ResetGame();

    SceneManager.LoadScene(0);
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}