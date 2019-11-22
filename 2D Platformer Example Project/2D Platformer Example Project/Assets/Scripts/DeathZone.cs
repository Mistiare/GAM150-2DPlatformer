using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour 
{
  private static bool dead = false;

  private void Awake()
  {
    dead = false;
  }

  void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
      if (dead) return;
      dead = true;

			Debug.Log("Player hit the death zone!");
      GameManager.Instance.Death();
    }
	}
}
