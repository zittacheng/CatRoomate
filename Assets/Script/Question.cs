using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CR
{
    public class Question : MonoBehaviour {
        public List<Answer> Answers;
        [TextArea]
        public string TextValue;
        public string AnimOverride;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual void OnLoad()
        {
            if (AnimOverride != "")
                RoomateControl.Main().ChangeAnim(AnimOverride);
        }

        public static Question Main()
        {
            return RoomateControl.Main().MainQuestion;
        }
    }
}