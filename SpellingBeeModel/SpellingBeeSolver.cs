namespace SpellingBeeModel
{
    public class SpellingBeeSolver
    {
        /*
         * USAGE
         * foreach (var (len, words) in SpellingBeeModel.SpellingBeeSolver.Solve(center, others))
         * {
         *     Console.WriteLine(len);
         *     foreach (var word in words)
         *     {
         *         Console.Write(word + ", ");
         *     }
         *     Console.WriteLine("\n");
         * }
         */
        public static List<KeyValuePair<int, List<string>>> Solve(char center, char[] others,
            List<string>? words = null)
        {
            var wordSet = new HashSet<char> {center};
            foreach (var c in others)
            {
                wordSet.Add(c);
            }

            var allWords = words ?? new List<string>(File.ReadAllLines("../../../../SpellingBeeModel/words.txt"));

            var wordsByLength = new SortedDictionary<int, List<string>>();

            foreach (var word in allWords)
            {
                if (word.Length > 3 && word.Contains(center))
                {
                    var cont = true;
                    foreach (var c in word)
                    {
                        if (!wordSet.Contains(c))
                        {
                            cont = false;
                            break;
                        }
                    }

                    if (cont)
                    {
                        if (!wordsByLength.ContainsKey(word.Length))
                        {
                            wordsByLength[word.Length] = new List<string>();
                        }

                        wordsByLength[word.Length].Add(word);
                    }
                }
            }

            return wordsByLength.Reverse().ToList();
        }
    }
}