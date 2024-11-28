namespace Hangman
{
    class Hangman
    {
        /**Initialise word */
        static string word;

        /** Initialise playingWord */
        static string playingWord;

        /** number of maximum incorrect letters in a play */
        const int NUMBER_OF_GUESSES = 8;

        /*
        * At the start of the game, you are able to make as many mistakes as
        * NUMBER_OF_GUESSES.
        */
        static int guesses = NUMBER_OF_GUESSES;

        static List<char> incorrects;

        static void Main(string[] args)
        {
            setUp();
            while (!gameOver())
            {
                playGame();
            }
            if (youLose())
                printLoseMessage();
            if (youWin())
                printWinMessage();
        }

        /*
	     * This method reads user's input. If it's correct, playing word updates. If it
	     * isn't correct, you have -1 turn.
	     */
        private static void playGame()
        {
            Console.WriteLine("The word now looks like: " + playingWord);
            Console.Write("Lives: ");
            for (int i = 0; i < guesses; i++)
            {
                Console.Write("<3 ");
            }
            Console.WriteLine();

            char input = readChar();
            if (word.IndexOf(input) != -1)
            {
                Console.WriteLine("Your guess is correct.");
                playingWord = changePlayingWord(word, playingWord, input);
            }
            else
            {
                Console.WriteLine("There are no " + input + "'s in the word.");
                guesses--;
                incorrects.Add(input);
            }
        }

        /*
	     * This method "changes" playing word if you guessed the letter. During the
	     * process one hyphens is removed from playing word and instead of this guessed
	     * letter is added
	     */
        private static string changePlayingWord(String word, String playingWord, char ch)
        {
            string res = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (ch == word[i])
                {
                    res = playingWord.Substring(0, i) + ch + playingWord.Substring(i + 1);
                    playingWord = res;
                }
            }
            return res;
        }

        /*
	     * This method reads user's input and provides legality of input. It user enters
	     * guessed letter, the program asks to enter another symbol
	     */
        private static char readChar()
        {
            Console.WriteLine("Your guess:");
            string s = Console.ReadLine();
            char input = checkInput(s);

            while (playingWord.IndexOf(input) != -1 || incorrects.Contains(input))
            {
                Console.WriteLine("This letter is guessed or incorrect. Enter another one:");
                s = Console.ReadLine();
                input = checkInput(s);
            }
            return input;
        }

        /*
	     * This method provides legality of the input. User has to enter only one symbol
	     * and this symbol must be letter
	     */
        private static char checkInput(String s)
        {
            char ch;
            while (s.Length != 1 || !(('A' <= s[0] && 'Z' >= s[0]) || ('a' <= s[0] && 'z' >= s[0])))
            {
                Console.WriteLine("Illegal");
                s = Console.ReadLine();
            }
            ch = s.ToUpper()[0];
            return ch;
        }

        /*
	     * This method prints welcome message, chooses word and creates a playing word.
	     * Also it prepares canvas for playing: resets and displays playing word
	     */
        private static void setUp()
        {
            HangmanLexicon lex = new HangmanLexicon();
            Random random = new Random();
            Console.WriteLine("Welcome to Hangman!");
            word = lex.getWord(random.Next(0, lex.getWordCount()));
            incorrects = new List<char>();
            playingWord = "";
            for (int i = 0; i < word.Length; i++)
                playingWord += "-";
        }

        /** If you've made as many mistakes as you were able to do, you lose */
        private static bool youLose()
        {
            return guesses == 0;
        }

        /** If you guessed the word, you won */
        private static bool youWin()
        {
            return playingWord.Equals(word);
        }

        /** If you win or lose that means game is over */
        private static bool gameOver()
        {
            return youWin() || youLose();
        }

        /*
	     * If you lose, this method reports what word was and prints appropriate message
	     */
        private static void printLoseMessage()
        {
            Console.WriteLine("You're completely hung.");
            Console.WriteLine("The word was " + word);
            Console.WriteLine("You lose.");
        }

        /*
         * If you win, this method prints what word you guessed and appropriate message
         */
        private static void printWinMessage()
        {
            Console.WriteLine("You guessed the word: " + word);
            Console.WriteLine("You win.");
        }

    }
}

