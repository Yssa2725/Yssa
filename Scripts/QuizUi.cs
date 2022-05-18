using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizUi : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText, scoreText, timerText;
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private GameObject gameOverPanel, gameMenuPanel, mainMenu;
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Button> options, uiButtons;
    [SerializeField] private Color correctCol, wrongCol, normalCOl;
    
    private Question question;
    private bool answered;

    public Text ScoreText { get { return scoreText; } }

    public Text TimerText { get { return timerText; } }

    public GameObject GameOverPanel { get { return gameOverPanel; } }

    // Start is called before the first frame update
    private void Start()
    {
        for(int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }

        for (int i = 0; i < uiButtons.Count; i++)
        {
            Button localBtn = uiButtons[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }

     
    }

    public void SetQuestion(Question question)
    {
        this.question = question;

        switch (question.questionType)
        {
            case QuestionType.TEXT:
                questionImage.transform.parent.gameObject.SetActive(false);
                break;
            case QuestionType.IMAGE:
 
                questionImage.transform.parent.gameObject.SetActive(true);
                questionImage.transform.gameObject.SetActive(true);

                questionImage.sprite = question.questionImg;
                break;
        }

        questionText.text = question.questionInfo;

        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);
        
        for (int i = 0; i <options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCOl;

        }
        answered = false;
    }

    public void ReduceLife(int index)
    {
        lifeImageList[index].color = normalCOl;
    }

    public void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
    }


    public void OnClick(Button btn)
    {
        if(quizManager.GameStatus == GameStatus.Playing)
        {
            if (!answered)
            {
                answered = true;
                bool val = quizManager.Answer(btn.name);

                if (val)
                {
                    btn.image.color = correctCol;


                }
                else
                {
                    btn.image.color = wrongCol;
                }

            }
       }

        switch (btn.name)
        {
            case "Folder1":
                quizManager.StartGame(0);
                mainMenu.SetActive(false);
                gameMenuPanel.SetActive(true);
                break;
        }
    }


    

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
}
