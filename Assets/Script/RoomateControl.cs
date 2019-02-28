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

        public void Awake()
        {
            Questions = new List<Question>();
            foreach (Question Q in QuestionObject.GetComponentsInChildren<Question>())
                Questions.Add(Q);
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
        }

        public void SelectAnswer(Answer A)
        {
            Anim.SetTrigger(A.AnimKey);
            ChangeScore(A.ScoreChange);
            NextQuetsion();
        }

        public void NextQuetsion()
        {
            if (!Questions.Contains(MainQuestion) || Questions.IndexOf(MainQuestion) + 1 >= Questions.Count)
                return;
            LoadQuestion(Questions[Questions.IndexOf(MainQuestion) + 1]);
        }

        public void LoadQuestion(Question Q)
        {
            MainQuestion = Q;
        }

        public void ChangeScore(float Value)
        {
            Score += Value;
        }

        public static RoomateControl Main()
        {
            return Camera.main.GetComponent<RoomateControl>();
        }
    }
}