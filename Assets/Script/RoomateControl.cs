using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CR
{
    public class RoomateControl : MonoBehaviour {
        public GameObject QuestionObject;
        public List<Question> Questions;
        public Question MainQuestion;
        public Text QuestionText;
        public Animator Anim;
        public float Score;
        public int CurrentChoiceIndex;
        public bool AutoImportQuestionList;
        [Space]
        public Question WinQuestion;
        public Question LoseQuestion;
        public int ScoreRequirement;

        public void Awake()
        {
            if (AutoImportQuestionList)
            {
                Questions = new List<Question>();
                foreach (Question Q in QuestionObject.GetComponentsInChildren<Question>())
                    Questions.Add(Q);
            }
            LoadQuestion(Questions[0]);
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (!MainQuestion)
                return;
            QuestionText.text = MainQuestion.TextValue;

            if (Input.GetButtonDown("Next"))
            {
                CurrentChoiceIndex++;
                if (MainQuestion && CurrentChoiceIndex >= MainQuestion.Answers.Count)
                    CurrentChoiceIndex = 0;
            }
            else if (Input.GetButtonDown("Previous"))
            {
                CurrentChoiceIndex--;
                if (CurrentChoiceIndex < 0 && MainQuestion)
                    CurrentChoiceIndex = MainQuestion.Answers.Count - 1;
            }
            if (Input.GetButtonDown("ENTER"))
            {
                if (MainQuestion && CurrentChoiceIndex >= 0 && CurrentChoiceIndex < MainQuestion.Answers.Count)
                    SelectAnswer(MainQuestion.Answers[CurrentChoiceIndex]);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        public void SelectAnswer(Answer _A)
        {
            ChangeAnim(_A.AnimKey);
            ChangeScore(_A.ScoreChange);
            NextQuetsion();
        }

        public void ChangeAnim(string _Key)
        {
            Anim.SetTrigger(_Key);
        }

        public void NextQuetsion()
        {
            if (!Questions.Contains(MainQuestion))
                return;
            if (Questions.IndexOf(MainQuestion) + 1 >= Questions.Count)
            {
                EndGame();
                return;
            }
            LoadQuestion(Questions[Questions.IndexOf(MainQuestion) + 1]);
        }

        public void LoadQuestion(Question _Q)
        {
            MainQuestion = _Q;
            _Q.OnLoad();
        }

        public void ChangeScore(float _Value)
        {
            Score += _Value;
        }

        public void EndGame()
        {
            if (Score >= ScoreRequirement)
                LoadQuestion(WinQuestion);
            else
                LoadQuestion(LoseQuestion);
        }

        public static RoomateControl Main()
        {
            return Camera.main.GetComponent<RoomateControl>();
        }
    }
}