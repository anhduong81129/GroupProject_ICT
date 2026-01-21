using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (player == null)
            player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (player != null)
            scoreText.text = "SCORE : " + player.Score;
    }
}
