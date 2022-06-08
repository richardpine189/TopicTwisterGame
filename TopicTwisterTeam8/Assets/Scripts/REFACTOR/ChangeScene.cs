using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Team8.TopicTwister
{
    public class ChangeScene : MonoBehaviour
    {
        public void ChangeToMain()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
