using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CR
{
    public class AnswerRenderer : MonoBehaviour {
        public Text TEXT;
        public int Index;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!Question.Main())
                return;
            TEXT.text = Question.Main().Answers[Index].TextValue;
        }

        public void OnMouseEnter()
        {
            RoomateControl.Main().SelectAnswer(Question.Main().Answers[Index]);
        }
    }
}