using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CR
{
    public class AnswerRenderer : MonoBehaviour {
        public bool Active;
        public Text TEXT;
        public int Index;
        public Color ActiveColor;
        public Color DisableColor;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!Question.Main() || Question.Main().Answers.Count <= Index)
            {
                Active = false;
                TEXT.text = "";
                return;
            }

            Active = true;
            TEXT.text = Question.Main().Answers[Index].TextValue;
            if (RoomateControl.Main().CurrentChoiceIndex == Index)
                TEXT.color = ActiveColor;
            else
                TEXT.color = DisableColor;
        }

        public void OnMouseEnter()
        {
            if (!Active)
                return;

            RoomateControl.Main().CurrentChoiceIndex = Index;
        }

        public void OnMouseExit()
        {
            if (!Active)
                return;

            if (RoomateControl.Main().CurrentChoiceIndex == Index)
                RoomateControl.Main().CurrentChoiceIndex = -1;
        }

        public void OnMouseDown()
        {
            if (!Active)
                return;

            RoomateControl.Main().SelectAnswer(Question.Main().Answers[Index]);
        }
    }
}