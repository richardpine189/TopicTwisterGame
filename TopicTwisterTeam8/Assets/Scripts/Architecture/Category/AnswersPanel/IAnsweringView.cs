using System;

namespace Architecture.Category.AnswersPanel
{
    public interface IAnsweringView
    {
        event Action<string[]> OnStopClick;

        public void SendAnswers();
    }
}