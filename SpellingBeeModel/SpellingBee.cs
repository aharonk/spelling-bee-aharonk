using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SpellingBeeTests")]
[assembly: InternalsVisibleTo("ConsoleAppTemplate")]

namespace SpellingBeeModel
{
    public class SpellingBee
    {
        private readonly Random _rand;

        private char _center;
        private char[] _letters = Array.Empty<char>();
        private LinkedList<char> _currentWord = new();
        private Dictionary<string, int> _validWords = new();
        private readonly List<string> _foundWords = new();
        private int _maxScore, _currentScore;

        #region Constructors and Initializers

        public SpellingBee()
        {
            _rand = new Random();
            InitFields(new List<string>(File.ReadAllLines("../../../../SpellingBeeModel/words.txt")));
        }

        internal SpellingBee(Random rand)
        {
            _rand = rand;
        }

        internal void InitFields(List<string> words)
        {
            while (_maxScore < 50) // ensure enough words for a good game
            {
                var letters = RandomLetters(7, words);

                _center = letters[0];
                _letters = letters[1..];

                _validWords = ContainsPangram(letters, words, out _maxScore);
            }
        }

        internal Dictionary<string, int> ContainsPangram(char[] letters, List<string> words, out int maxScore)
        {
            var localValidWords = new Dictionary<string, int>();
            
            // remove all words that have letters other than the chosen 7
            words.RemoveAll(words.Where(word => word.Any(c => !letters.Contains(c))).Contains);

            // remove all words not containing center, calculate maxScore, and generate the validWord/score table
            maxScore = words.Where(word => word.Contains(letters[0])).Aggregate(0, (i, word) =>
            {
                var score =  word.Distinct().Count() == 7 ? 7 : 0 + word.Length == 4 ? 1 : word.Length;
                localValidWords.Add(word, score);
                return score + i;
            });

            return localValidWords;
        }

        internal char[] RandomLetters(int n, List<string> words)
        {
            var sevenLetterOptions = words.Where(word => word.Distinct().Count() == n).ToArray();
            var word = sevenLetterOptions.ElementAt(_rand.Next(sevenLetterOptions.Length)).Distinct().ToArray();
            Shuffle(word);
            return word;
        }

        #endregion

        #region Getters

        public char GetCenter()
        {
            return _center;
        }

        public char[] GetOtherLetters()
        {
            return _letters;
        }

        public List<string> GetFoundWords()
        {
            return _foundWords;
        }

        #endregion

        internal void Shuffle(char[] arr)
        {
            for (var i = arr.Length - 1; i > 0; i--)
            {
                var j = _rand.Next(i + 1);
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        public void Shuffle()
        {
            Shuffle(_letters);
        }

        public void Add(char c)
        {
            if (c != _center && !_letters.Contains(c))
            {
                throw new ArgumentException($"The character {c} is not valid.");
            }

            _currentWord.AddLast(c);
        }

        public void Del()
        {
            if (_currentWord.Count > 0)
            {
                _currentWord.RemoveLast();
            }
        }

        private void DelAll()
        {
            _currentWord = new LinkedList<char>();
        }

        public Result Guess()
        {
            if (_currentWord.Count < 4)
            {
                DelAll();
                return Result.TooShort;
            }

            if (!_currentWord.Contains(_center))
            {
                DelAll();
                return Result.NoCenter;
            }

            var word = _currentWord.Aggregate("", (current, c) => current + c);
            DelAll();

            if (_validWords.Keys.Contains(word))
            {
                _currentScore += _validWords[word];
                _validWords.Remove(word); // prevent points multiple times from same word
                _foundWords.Add(word);
                return Result.Valid;
            }

            return _foundWords.Contains(word) ? Result.AlreadyFound : Result.NotAWord;
        }

        public enum Result
        {
            Valid,
            TooShort,
            NotAWord,
            AlreadyFound,
            NoCenter,
        }

        public Rank CalcRank()
        {
            return CalcPercentage() switch
            {
                >= (int) Rank.Genius => Rank.Genius,
                >= (int) Rank.Amazing => Rank.Amazing,
                >= (int) Rank.Great => Rank.Great,
                >= (int) Rank.Nice => Rank.Nice,
                >= (int) Rank.Solid => Rank.Solid,
                >= (int) Rank.Good => Rank.Good,
                >= (int) Rank.MovingUp => Rank.MovingUp,
                >= (int) Rank.GoodStart => Rank.GoodStart,
                _ => Rank.Beginner
            };
        }

        public int CalcPercentage()
        {
            return (int) Math.Round(100.0 * _currentScore / _maxScore, 0, MidpointRounding.AwayFromZero);
        }
    }
}