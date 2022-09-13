﻿public class AnswersService : IAnsweringService
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

