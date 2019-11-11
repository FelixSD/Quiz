using System;
using QuizElements;
using QuizAnswers;
using QuizPlayer;

namespace QuizGame 
{
    class Quiz 
    {
        public Elements[] defaultElements;
        public Elements[] userGeneratedElements;

        public void SelectOptions(Player player) 
        {
            Console.WriteLine("---- Willkommen zum super schweren Quiz ! ----");
            Console.WriteLine("> Mit Auswahl 0 Spiel beenden");
            Console.WriteLine("> Mit Auswahl 1 neues Quiz-Element erstellen");
            Console.WriteLine("> Mit Auswahl 2 Spiel starten");
            Console.WriteLine("> Deine Wahl: ");
            string auswahl = Console.ReadLine();
            int auswahlInt = Int32.Parse(auswahl);
            
            switch(auswahlInt) 
            {
                case 0:
                    System.Environment.Exit(1);
                    break;
                case 1:
                    GenerateElements(player);
                    break;
                case 2:
                    StartGame(player);
                    break;
                default:
                    Console.WriteLine("Für die eingegebene Zahl gibt es keine Aktion !");
                    Console.WriteLine("------------------------");
                    SelectOptions(player);
                    break;
            }
        }

        public void GenerateElements(Player player) 
        {
            Console.WriteLine("Wie viele Quiz-Elemente willst du erstellen ?");
            Console.WriteLine("> Deine Wahl: ");
            string numElements = Console.ReadLine();
            int numElementsInt = Int32.Parse(numElements);
            Elements[] userGeneratedElementsArray = new Elements[numElementsInt];
            for(int i = 0; i < userGeneratedElementsArray.Length; i++) 
            {
                Console.WriteLine("> Frage eingeben: ");
                string question = Console.ReadLine();
                Console.WriteLine("> Antwortanzahl zur Frage: ");
                string numAnswers = Console.ReadLine();
                int numAnswersInt = Int32.Parse(numAnswers);
                Answers[] answersArray = new Answers[numAnswersInt];
                for(int j = 0; j < numAnswersInt; j++) 
                {
                    Console.WriteLine("> Antwort " + (j + 1) + ": ");
                    string answer = Console.ReadLine();
                    Console.WriteLine("Ist die antwort richtig ? (true oder false eingeben) (immer nur eine richtige Antwort erlaubt):");
                    string isCorrect = Console.ReadLine();
                    bool isCorrectBool = Boolean.Parse(isCorrect);
                    Answers answers = new Answers(answer, isCorrectBool);
                    answersArray[j] = answers;
                }
            Elements element = new Elements(question, answersArray);
            userGeneratedElementsArray[i] = element;
            }
            userGeneratedElements = userGeneratedElementsArray;
            SelectOptions(player);
        }

        public void StartGame(Player player) 
        {
            Console.WriteLine("---- Du hast dich für den Spielstart entschieden. Wähle die richtige Antwort zur Frage (single-choice) ----");
            if(userGeneratedElements == null) 
            {
                for(int i = 0; i < defaultElements.Length; i++) 
                {
                    Console.WriteLine("> " + defaultElements[i].question);
                    for(int j = 0; j < defaultElements[i].answers.Length; j++) 
                    {
                        Console.WriteLine("     " + j + ". " + defaultElements[i].answers[j].answer);
                    }
                    Console.WriteLine("> Deine Wahl: ");
                    string auswahl = Console.ReadLine();
                    int auswahlInt = Int32.Parse(auswahl);
                    Console.WriteLine("> " + defaultElements[i].answers[auswahlInt].answer);
                    EvaluateAnswer(defaultElements, i, auswahlInt, player);
                }
            } 
            else 
            {
                Elements[] allElements = MergeElementsArrays(defaultElements, userGeneratedElements);
                for(int i = 0; i < allElements.Length; i++) 
                {
                    Console.WriteLine("> " + allElements[i].question);
                    for(int j = 0; j < allElements[i].answers.Length; j++) 
                    {
                        Console.WriteLine("     " + j + ". " + allElements[i].answers[j].answer);
                    }
                    Console.WriteLine("> Deine Wahl: ");
                    string auswahl = Console.ReadLine();
                    int auswahlInt = Int32.Parse(auswahl);
                    Console.WriteLine("> " + allElements[i].answers[auswahlInt].answer);
                    EvaluateAnswer(allElements, i, auswahlInt, player);
                }
            }
        }
        
        public Elements[] MergeElementsArrays(Elements[] defaultElements, Elements[] userGeneratedElements) 
        {
            Elements[] allElements = new Elements[defaultElements.Length + userGeneratedElements.Length];
            Array.Copy(defaultElements, allElements, defaultElements.Length);
            Array.Copy(userGeneratedElements, 0, allElements, defaultElements.Length, userGeneratedElements.Length);

            return allElements;
        }

        public void EvaluateAnswer(Elements[] toEvaluateArray, int currentElement, int chosenAnswer, Player player) 
        {
            if(toEvaluateArray[currentElement].answers[chosenAnswer].isCorrect && currentElement < toEvaluateArray.Length-1) 
            {
                Console.WriteLine("Deine Antwort ist richtig !");
                Console.WriteLine("---- Deine aktuelle Punktzahl: " + CalculatePoints(player) + " Punkt(e) ----");
            } 
            else if(!toEvaluateArray[currentElement].answers[chosenAnswer].isCorrect && currentElement < toEvaluateArray.Length-1) 
            {
                 Console.WriteLine("Deine Antowort ist NICHT richtig !");
                 Console.WriteLine("---- Deine aktuelle Punktzahl: " + player.GetPoints() + " Punkt(e) ----");
            } 
            else if(toEvaluateArray[currentElement].answers[chosenAnswer].isCorrect && currentElement < toEvaluateArray.Length) 
            {
                Console.WriteLine("Deine Antwort ist richtig !");
                Console.WriteLine("---- Glückwunsch. Du hast das Spiel mit einer Gesamtpunktzahl von " + CalculatePoints(player) + " Punkt(en) abgeschlossen ----");
            } 
            else 
            {
                Console.WriteLine("Deine Antowort ist NICHT richtig !");
                Console.WriteLine("---- Glückwunsch. Du hast das Spiel mit einer Gesamtpunktzahl von " + player.GetPoints() + " Punkt(en) abgeschlossen ----");
            }
        }

        public int CalculatePoints(Player player) 
        {
            player.IncrementPoints();

            return player.GetPoints();
        }
    }
}