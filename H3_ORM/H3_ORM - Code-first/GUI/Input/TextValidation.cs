namespace H3_ORM___Code_first.Input;

class TextValidation
{
    public static int ValidNumberSelection(string text, int lowerLimit, int upperLimit, int attempts = 5)
    {
        Console.WriteLine(text);
        var userInput = Console.ReadLine();
        int defaultChoice = lowerLimit;

        int intInput = int.TryParse(userInput, out defaultChoice) ? defaultChoice : 0;

        int i = 0;

        while (lowerLimit > intInput || intInput > upperLimit)
        {
            // Take input
            Console.WriteLine(text);

            userInput = Console.ReadLine();
            defaultChoice = lowerLimit;

            // Check
            intInput = int.TryParse(userInput, out defaultChoice) ? defaultChoice : 0;

            // Count attempts
            i++;
            if (i > attempts)
            {
                throw new InputAttempsExceeded("All attemps used");
            }
        }

        return intInput;
    }

    public static string ValidText(string text, int attempts = 5)
    {
        int i = 0;

        while (true)
        {
            // Read input
            Console.WriteLine(text);
            var input = Console.ReadLine();

            // Contains text?
            if (!string.IsNullOrEmpty(input))
                return input;

            // Count attempts
            i++;
            if (i > attempts)
            {
                throw new InputAttempsExceeded("All attemps used");
            }
        }
    }
}
