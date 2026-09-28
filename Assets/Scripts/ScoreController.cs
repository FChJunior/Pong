using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    [SerializeField] private TextMeshProUGUI textP1;
    [SerializeField] private TextMeshProUGUI textP2;
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

    private void Awake()
    {
        instance = this;
        RestartGame();
    }
    private void RestartGame()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        UpdateScorePanel();
    }
    private void UpdateScorePanel(int p1 = 0, int p2 = 0)
    {
        scoreP1 += p1;
        scoreP2 += p2;
        textP1.text = scoreP1.ToString();
        textP2.text = scoreP2.ToString();
    }
}
