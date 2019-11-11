using QuizGame;
using QuizElements;
using QuizAnswers;
using QuizPlayer;

class Quizstarter 
{
    public static void Main(string[] args) 
    {
        Quiz quiz1 = new Quiz();
        Player player = new Player();
        Answers answer11 = new Answers("Nein, Programmieren ist keine Kunst", false);
        Answers answer12 = new Answers("Nein, Programmieren ist Handwerk, Softwaredesign eine Kunst", true);
        Answers answer13 = new Answers("Ja Programmieren ist eine Kunst", false);
        Answers[] answers1Array = {answer11, answer12, answer13};
        Elements element1 = new Elements("Ist programmieren eine Kunst ?", answers1Array);
        Answers answer21 = new Answers("+ steht für eine public Variable/Methode im Klassendiagramm", true);
        Answers answer22 = new Answers("+ steht für eine private Variable/Methode im Klassendiagramm", false);
        Answers answer23 = new Answers("+ steht für eine protected Variable/Methode im Klassendiagramm", false);
        Answers[] answers2Array = {answer21, answer22, answer23};
        Elements element2 = new Elements("Für was steht das + Zeichen im Klassendiagramm ?", answers2Array);
        Answers answer31 = new Answers("Pudge", false);
        Answers answer32 = new Answers("Slark", false);
        Answers answer33 = new Answers("Sven", false);
        Answers answer34 = new Answers("Jax", true);
        Answers[] answers3Array = {answer31, answer32, answer33, answer34};
        Elements element3 = new Elements("Welchen Held gibt es in Dota2 nicht ?", answers3Array);
        Elements[] defaultElementsArray = {element1, element2,element3};
        quiz1.defaultElements = defaultElementsArray;
        quiz1.SelectOptions(player);
    }
}