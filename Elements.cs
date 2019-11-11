using QuizAnswers;

namespace QuizElements 
{
    class Elements 
    {
        public string question;
        public Answers[] answers;

        public Elements(string question, Answers[] answers) 
        {
            this.question = question;
            this.answers = answers;
        }
    }
}