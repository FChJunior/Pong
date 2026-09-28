using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]
    private float initSpeed;
    private float speed;
    private float addSpeed = 0.1f;
    private Vector2 direction;
    [SerializeField]
    private Vector2 randomDirection;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = initSpeed;
        Launcher();
    }
    private void Launcher()
    {
        if (direction.x == 0) direction.x = Random.value > 0.5f ? 1f : -1f;
        direction.y = Random.Range(-1f, 1f);
        Move(direction);
    }
    private void Move(Vector2 direction)
    {
        body.linearVelocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            ScoreController.instance.ScoreP2 = 1;
            StartCoroutine(ResetPosition());
            direction.x = -1;
            return;
        }
        if (collision.gameObject.CompareTag("Goal2"))
        {
            ScoreController.instance.ScoreP1 = 1;
            StartCoroutine(ResetPosition());
            direction.x = 1;
            return;
        }
        speed += addSpeed;
        randomDirection.x *= body.linearVelocityX > 0 ? 1 : -1;
        randomDirection.y *= body.linearVelocityY > 0 ? 1 : -1;
        Move(body.linearVelocity + randomDirection);
    }

    private IEnumerator ResetPosition()
    {
        body.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        if (ScoreController.instance.InPlay)
        {
            speed = initSpeed;
            Launcher();
        }
    }
}