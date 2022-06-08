using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Services
{
    public class AnswersService : IAnsweringService
    {
        IAnswersRepository _answersRepository;
        public AnswersService(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository;
        }
        public void SendToRepository(string[] answers)
        {
            _answersRepository.SaveAnswers(answers);
        }
    }
}
