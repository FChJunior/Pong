using UnityEngine;

public class IAController : MonoBehaviour
{
    [SerializeField]
    private Transform ball;
    [SerializeField]
    private float speed;
    private Vector2 direction;

    void Update()
    {
        if (!ScoreController.instance.InPlay)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
            return;
        }
        direction.x = transform.position.x;
        direction.y = ball.position.y;
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }
}
