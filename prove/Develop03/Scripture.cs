public class Scripture
{   
    private Reference refName;
    private List<Word> script;
    public bool isAllWordsHidden;

    private class Reference
    {
        private string _text;
        public Reference(string text)
        {
            _text = text;
        }
        public void Display()
        {
            Console.WriteLine(_text);
        }
    }
    private class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text, bool isHidden)
        {
            _text = text;
            _isHidden = isHidden;
        }

        public bool GetIsHidden()
        {
            return _isHidden;
        }

        public void SetIsHidden(bool isHidden)
        {
            _isHidden = isHidden;
        }
        public void Display()
        {
            if (_isHidden)
            {
                foreach (char c in _text)
                {
                    if (char.IsLetter(c))
                    {
                    Console.Write("_");
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
            }
            else
            {
                Console.Write(_text);
            }
        }

 
    }

    public Scripture(string text)
    {
        //Creating Reference from the first part of the text
        List<string> splitText = new List<string>(text.Split(">>>"));
        refName = new Reference(splitText[0]);


        script = new List<Word>();
        splitText = new List<string>(splitText[1].Split(" "));
        foreach (string word in splitText)
        {
            script.Add(new Word(word, false));
        }

        isAllWordsHidden = false;


    }

    public void Display()
    {
        refName.Display();
        foreach (Word word in script)
        {
            word.Display();
            Console.Write(" ");
        }
    }

    public void HideMoreWords(int numToHide)
    {
        List<Word> visibleWords = new List<Word>();
        Random random = new Random();

        //Gathers the visible words
        foreach (Word word in script)
        {
            if (word.GetIsHidden() == false)
            {
                visibleWords.Add(word);
            }
        }


        if (visibleWords.Count > numToHide)
        {
            for (int i = 0; i <= numToHide; i++)
            {
                int ranInt = random.Next(visibleWords.Count);
                visibleWords[ranInt].SetIsHidden(true);
                visibleWords.RemoveAt(ranInt);
            }
            Console.WriteLine("Finished hiding words");
        }
        else
        {
            foreach (Word word in visibleWords)
            {
                word.SetIsHidden(true);
            }
            isAllWordsHidden = true;
        }

    }   
}
