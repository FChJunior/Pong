using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput input;
    public static InputManager instance;

    private Vector2 moveP1;
    private Vector2 moveP2;

    public Vector2 MoveP1 { get { return moveP1; } }
    public Vector2 MoveP2 { get { return moveP2; } }

    private void Awake()
    {
        instance = this;
    }

    private void OnMoveP1(InputValue input)
    {
        moveP1 = new Vector2(0, input.Get<float>());
    }
    private void OnMoveP2(InputValue input)
    {
        moveP2 = new Vector2(0, input.Get<float>());
    }
}
