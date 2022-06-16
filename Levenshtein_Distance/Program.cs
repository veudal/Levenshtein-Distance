namespace Levenshtein_Distance
{
    internal class Levenshtein_Distance
    {
        private static void Main()
        {

        }

        public static int GetLevenshteinDistance(string firstWord, string secondWord)
        {
            int[,] matrix = new int[firstWord.Length, secondWord.Length];
            PrepareMatrix(firstWord, secondWord, matrix);
            return CalculateLevenshteinDistance(firstWord, secondWord, matrix);
        }

        public static double GetPercentageDifference(string firstWord, string secondWord)
        {
            float distance = GetLevenshteinDistance(firstWord, secondWord);
            if (firstWord.Length < 1)
            {
                if (secondWord.Length < 1)
                    return 100;

                else
                    return 0;
            }
            else if (firstWord.Length > secondWord.Length)
            {
                return firstWord.Length / distance;
            }
            else
            {
                return secondWord.Length / distance;
            }
        }

        private static int CalculateLevenshteinDistance(string firstWord, string secondWord, int[,] matrix)
        {
            for (int i = 1; i < firstWord.Length; i++)
            {
                for (int j = 1; j < secondWord.Length; j++)
                {
                    int bottomLeft = matrix[i - 1, j - 1];
                    int bottomRight = matrix[i, j - 1];
                    int topLeft = matrix[i - 1, j];

                    bottomRight++;
                    topLeft++;
                    if (firstWord[i] != secondWord[j])
                        bottomLeft++;

                    matrix[i, j] = Math.Min(topLeft, Math.Min(bottomRight, bottomLeft));
                }
            }
            return matrix[firstWord.Length - 1, secondWord.Length - 1];
        }

        private static void PrepareMatrix(string firstWord, string secondWord, int[,] matrix)
        {
            for (int i = 0; i < firstWord.Length; i++)
            {
                matrix[i, 0] = i;
            }
            for (int j = 0; j < secondWord.Length; j++)
            {
                matrix[0, j] = j;
            }
        }
    }
}