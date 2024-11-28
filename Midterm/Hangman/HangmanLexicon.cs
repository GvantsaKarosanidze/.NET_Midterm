using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanLexicon
    {
        private const string fileloc = "C:\\Users\\Greench\\source\\repos\\Midterm\\Hangman\\ShorterLexicon.txt";
        string[] lexicon;

        public HangmanLexicon()
        {
            /*
             * Opens and reads file. Every line of file is added into array
             */
            lexicon = File.ReadAllLines(fileloc);

        }

        /** Returns the number of words in the lexicon. */
        public int getWordCount()
        {
            return lexicon.Length;
        }

        /** Returns the word at the specified index. */
        public string getWord(int index)
        {
            return lexicon[index];
        }

    }
}
