using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool p1;

    private Vector2 move;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!ScoreController.instance.InPlay)
        {
            move = Vector2.zero;
            transform.position = new Vector3(transform.position.x, 0, 0);
            return;
        }
        // if (p1)
        //     move = InputManager.instance.MoveP1 * speed;
        // else
        //     move = InputManager.instance.MoveP2 * speed;

        move = p1 ? InputManager.instance.MoveP1 * speed : move = InputManager.instance.MoveP2 * speed;
    }
    private void FixedUpdate()
    {
        body.linearVelocity = move;
    }
}
