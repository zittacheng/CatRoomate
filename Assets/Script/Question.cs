using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CR
{
    public class Question : MonoBehaviour {
        public List<Answer> Answers;
        public string TextValue;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Next()
        {

        }

        public static Question Main()
        {
            return RoomateControl.Main().MainQuestion;
        }
    }
}