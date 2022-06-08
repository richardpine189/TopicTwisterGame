using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class SendAnswersAction : IAnswerSender
    {
        IAnsweringService _answersService;
        public SendAnswersAction(IAnsweringService answeringService)
        {
            _answersService = answeringService;
        }
        public void SendAnswers(string[] answers)
        {
            _answersService.SendToRepository(answers);
        }
    }
}
