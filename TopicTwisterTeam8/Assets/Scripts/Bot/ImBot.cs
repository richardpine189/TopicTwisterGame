using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;


    public class ImBot : MonoBehaviour
    {
        private User _botUserData;
        
        private int _difficulty;

        public void BotInstaller(BootConfiguration bootDificulty)
        {
            _difficulty = bootDificulty.Difficulty;
            _botUserData = new User(666, "ImBot");
        }

        public void BotAnswer()
        {

        }

        public void BotGetLetter()
        {

        }

        
    }

    public class BootConfiguration : ScriptableObject
    {
        [SerializeField]
        [Range(0, 3)] private int _difficulty;

        public int Difficulty { get => _difficulty; set => _difficulty = value; }
    }
