using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
  // Public variables
  public Vector2 MoveTo = new Vector2(2, 0);
  public float moveSpeed = 1f;
  public float waitTime = 2f;

  // Private variables
  private Vector2 pos1;
  private Vector2 pos2;
  private bool movingForward = true;

  private void Start()
  {
    // Set private variables
    pos1 = transform.position;
    pos2 = (Vector2)transform.position + MoveTo;

    // Start the coroutine
    StartCoroutine(MoveObject());
  }

  private IEnumerator MoveObject()
  {
    while (true)
    {
      // Wait in place.
      yield return new WaitForSeconds(waitTime);

      // Move to the other position
      float t = 0;
      while (t < 1)
      {
        transform.position = Vector2.Lerp(movingForward ? pos1 : pos2, movingForward ? pos2 : pos1, t);
        t += Time.deltaTime / moveSpeed;
        yield return null;
      }

      // Switch bool
      movingForward = !movingForward;
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
      collision.transform.SetParent(transform);
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
      collision.transform.SetParent(null);
  }
}