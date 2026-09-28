using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button bt_sPlayer;
    [SerializeField]
    private Button bt_mPlayer;
    [SerializeField]
    private Button bt_Exit;

    [SerializeField]
    private PlayerController p2;
    [SerializeField]
    private IAController ia;
    [SerializeField]
    private BallController ball;
    void Start()
    {
        bt_sPlayer.onClick.AddListener(SinglePlayer);
        bt_mPlayer.onClick.AddListener(Multiplayer);
        bt_Exit.onClick.AddListener(ExitGame);
    }

    private void SinglePlayer()
    {
        ScoreController.instance.RestartGame();
        ball.Launcher();
        ia.enabled = true;
        p2.enabled = false;
        gameObject.SetActive(false);
    }
    private void Multiplayer()
    {
        ScoreController.instance.RestartGame();
        ball.Launcher();
        ia.enabled = false;
        p2.enabled = true;
        gameObject.SetActive(false);
    }
    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
