namespace QuizPlayer 
{
    class Player 
    {
        private int currentPoints;

        public void IncrementPoints() 
        {
            currentPoints++;
        }
        
        public int GetPoints() 
        {
            return currentPoints;
        }
    }
}