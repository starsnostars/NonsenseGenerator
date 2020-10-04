using LoremGenerator.Properties;
using System;
using System.Linq;
using System.Text;

namespace LoremGenerator
{
    public class Generator
    {
        const string RESOURCE_KEY = "Words";
        private string[] _words;

        private readonly int _minWords = 10;
        private readonly int _maxWords = 20;

        private readonly Random _rand = new Random();

        public string Generate(int paragraphs = 1)
        {
            return GenerateParagraph(paragraphs);
        }

        private string GenerateParagraph(int paragraphs)
        {
            if (_words == null)
            {
                LoadWords();
            }

            var res = new StringBuilder();
            for (int i = 0; i < paragraphs; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    res.Append(GenerateSentence());
                }
                res.Append(Environment.NewLine);
            }

            return res.ToString();
        }

        private string GenerateSentence()
        {
            var res = new StringBuilder();
            int len = _rand.Next(_minWords, _maxWords);

            for (int i = 0; i < len; i++)
            {
                res.Append($"{GetRandomWord(i == 0)} ");

                if (_rand.NextDouble() >= 0.9f)
                {
                    res.Length -= 1;
                    res.Append(", ");
                }
            }

            res.Length -= 1;
            res.Append(". ");
            return res.ToString();
        }

        private string GetRandomWord(bool capitalize)
        {
            int len = _words.Length;

            string res = _words[_rand.Next(0, len)];

            if (capitalize)
            {
                return res.First().ToString().ToUpper() + res.Substring(1);
            } 
            else
            {
                return res;
            }
        }

        private void LoadWords()
        {
            string words = Resources.ResourceManager.GetString(RESOURCE_KEY);
            _words = words.Split(";", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
