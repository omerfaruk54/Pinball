using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText, highScoreText, remainingText;
    [SerializeField] Button playButton, restartButton, quitButton;
    [SerializeField] Vector2 startPos;

    public PlayerController playerController;
    public ColorChanger colorChanger;
    public CircleColorChanger circleColorChanger;

    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject sqaure2, circle2;
    [SerializeField] private GameObject movingSquare, movingCircle;


    private int score, highScore, lvlScore;




    private void Awake()
    {
        Time.timeScale = 0;
        score = 0;
        lvlScore = 300;
        playerController.GetComponent<PlayerController>();
        startPos= new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));

        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        remainingText.text = "NEXT LEVEL: " + (lvlScore);


    }

    private void Start()
    {

        ball.transform.position = startPos;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
        //ball.transform.position= new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
    }

   



    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }



        if (score >= 300)
        {
            movingCircle.SetActive(true);
        }
        if (score >= 500)
        {
            movingSquare.SetActive(true);
        }


        if (lvlScore - score <= 0)
        {
            lvlScore = 500;
            remainingText.text = "NEXT LEVEL: " + (lvlScore);
        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CirclePoint"))
        {
            AddPoints(20);
            scoreText.text = "" + score;
            playerController.power += 600;
            circleColorChanger.CircleChangeColor();

        }



        if (collision.gameObject.CompareTag("SquarePoint"))
        {
            AddPoints(10);
            scoreText.text = "" + score;
            playerController.power += 300;

            colorChanger.ChangeColor();

        }

        if (collision.gameObject.CompareTag("CirclePoint2"))
        {
            AddPoints(20);
            scoreText.text = "" + score;
            playerController.power += 600;
            circle2.gameObject.GetComponent<CircleColorChanger>().CircleChangeColor();

        }



        if (collision.gameObject.CompareTag("SquarePoint2"))
        {
            AddPoints(10);
            scoreText.text = "" + score;
            playerController.power += 300;

            sqaure2.gameObject.GetComponent<ColorChanger>().ChangeColor();

        }


        if (collision.gameObject.CompareTag("MovingCircle"))
        {
            AddPoints(30);
            scoreText.text = "" + score;
            playerController.power += 600;
            movingCircle.gameObject.GetComponent<MovingCircle>().MovingCircleChangeColor();

        }

        if (collision.gameObject.CompareTag("MovingSquare"))
        {
            AddPoints(30);
            scoreText.text = "" + score;
            playerController.power += 600;
            movingSquare.gameObject.GetComponent<MovingSquare>().MovingSquareChangeColor();

        }




        if (collision.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);

        }


    }


    public void PlayGame()
    {
        Time.timeScale = 1;
        playButton.gameObject.SetActive(false);
        ball.transform.position = startPos;
        playerController.power = 4000f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

