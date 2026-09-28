using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    [SerializeField] private TextMeshProUGUI textP1;
    [SerializeField] private TextMeshProUGUI textP2;
    [SerializeField] private TextMeshProUGUI winner;
    [SerializeField] private GameObject menu;
    private bool inPlay;
    public bool InPlay { get { return inPlay; } }
    private int scoreP1;
    private int scoreP2;
    public int ScoreP1
    {
        set
        {
            if (value == 1)
            {
                UpdateScorePanel(p1: value);
            }
        }
    }
    public int ScoreP2
    {
        set
        {
            if (value == 1)
            {
                UpdateScorePanel(p2: value);
            }
        }
    }
    [SerializeField]
    private int goal;
    private void Awake()
    {
        instance = this;
    }
    public void RestartGame()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        UpdateScorePanel();
        winner.gameObject.SetActive(false);
        inPlay = true;
    }
    private void UpdateScorePanel(int p1 = 0, int p2 = 0)
    {
        scoreP1 += p1;
        scoreP2 += p2;
        textP1.text = scoreP1.ToString();
        textP2.text = scoreP2.ToString();
        UpdateStateGame();
    }
    private void UpdateStateGame()
    {
        if (scoreP1 >= goal || scoreP2 >= goal)
        {
            menu.SetActive(true);
            inPlay = false;
            winner.gameObject.SetActive(true);
            winner.text = scoreP1 >= goal
                                         ? "O Jogador 1 Venceu!!!"
                                         : "O Jogador 2 Venceu!!!";
        }
    }
}
