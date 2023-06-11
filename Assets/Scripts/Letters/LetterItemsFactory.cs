namespace Letters
{
    public class LettersFactory : IFactory<LetterModel>
    {
        public LetterModel Create(params object[] parameters)
        {
            var letter = new LetterModel((char)parameters[0]);
            return letter;
        }

    }
}