using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    [SerializeField] private int highPointsTreshold;
    [SerializeField] private int lowPointsTreshold;
    [SerializeField] private int dyingScorePenalty;
    [SerializeField] private string[] levels;
    [SerializeField] private Image scoreImage;
    [SerializeField] private Sprite positiveRatingImage;
    [SerializeField] private Sprite neutralRatingImage;
    [SerializeField] private Sprite negativeRatingImage;
    [HideInInspector] public GameObject player;
    public int score = 0;
    private int currentLevel = 0;

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        ScoreChange();
        DontDestroyOnLoad(gameObject);
    }

    public void Respawn()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = LevelManager.instance.spawnPos;
        score -= dyingScorePenalty;

        if (score < 0)
            score = 0;
        ScoreChange();
    }

    public void LoadNextLevel()
    {
        if (currentLevel < levels.Length)
        {
            SceneManager.LoadScene(levels[currentLevel + 1]);
            currentLevel++;
        }
        else
            SceneManager.LoadScene("GameOver");
    }

    public void ScoreChange()
    {
        if (score >= highPointsTreshold)
            scoreImage.sprite = positiveRatingImage;
        else if (score > lowPointsTreshold)
            scoreImage.sprite = neutralRatingImage;
        else
            scoreImage.sprite = negativeRatingImage;
    }
}
