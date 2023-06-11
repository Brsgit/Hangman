namespace Letters
{
    public class LetterModel
    {
        private char letter;
        public char Letter => letter;

        public LetterModel(char letter)
        {
            this.letter = letter;
        }
    }
}