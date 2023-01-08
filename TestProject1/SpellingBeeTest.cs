using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellingBeeModel;

namespace SpellingBeeTests
{
    [TestClass]
    public class SpellingBeeTest
    {
        private static List<string> GetAllWords()
        {
            return new List<string>(
                File.ReadAllLines("C:/Users/askat/source/repos/spelling-bee-aharonk/SpellingBeeModel/words.txt"));
        }

        [TestMethod]
        public void LetterGeneration()
        {
            var allWords = GetAllWords();

            var letters = new SpellingBee(new Random()).RandomLetters(7, allWords);
            letters.Length.Should().Be(7).And.Be(letters.Distinct().Count());

            new SpellingBee(new Random(4)).RandomLetters(7, allWords)
                .Should().Equal(new List<char> {'l', 'c', 'a', 's', 'h', 'o', 'r'});
        }

        [TestMethod]
        public void Add()
        {
            var model = new SpellingBee(new Random(4));
            model.InitFields(GetAllWords());

            foreach (var c in new[] {'s', 'c', 'h', 'o', 'l', 'a', 'r'})
            {
                model.Add(c);
            }
        }

        [TestMethod]
        public void AddFail()
        {
            var model = new SpellingBee(new Random(4));
            model.InitFields(GetAllWords());

            foreach (var c in "bdefgijkmnpqtuvwxyz".ToCharArray())
            {
                this.Invoking(_ => model.Add(c)).Should().Throw<ArgumentException>();
            }
        }

        private SpellingBee.Result GuessWord(string word, SpellingBee model)
        {
            foreach (var c in word)
            {
                model.Add(c);
            }

            return model.Guess();
        }

        [TestMethod]
        public void Guess()
        {
            var model = new SpellingBee(new Random(4));
            model.InitFields(GetAllWords());

            GuessWord("scholar", model).Should().Be(SpellingBee.Result.Valid);
            model.CalcPercentage().Should().NotBe(0);
            model.CalcRank().Should().NotBe(Rank.Beginner);
        }

        [TestMethod]
        public void GuessFail()
        {
            var model = new SpellingBee(new Random(4));
            model.InitFields(GetAllWords());

            // too short
            GuessWord("oar", model).Should().Be(SpellingBee.Result.TooShort);
            model.CalcPercentage().Should().Be(0);
            model.CalcRank().Should().Be(Rank.Beginner);


            // not a word
            GuessWord("shol", model).Should().Be(SpellingBee.Result.NotAWord);
            model.CalcPercentage().Should().Be(0);
            model.CalcRank().Should().Be(Rank.Beginner);

            // no center
            GuessWord("rash", model).Should().Be(SpellingBee.Result.NoCenter);
            model.CalcPercentage().Should().Be(0);
            model.CalcRank().Should().Be(Rank.Beginner);

            // already found
            GuessWord("also", model).Should().Be(SpellingBee.Result.Valid);
            model.CalcPercentage().Should().Be(2);
            model.CalcRank().Should().Be(Rank.GoodStart);

            GuessWord("also", model).Should().Be(SpellingBee.Result.AlreadyFound);
            model.CalcPercentage().Should().Be(2);
            model.CalcRank().Should().Be(Rank.GoodStart);
        }

        [TestMethod]
        public void Del()
        {
            var model = new SpellingBee(new Random(4));
            model.InitFields(GetAllWords());
            model.Add('a');
            model.Add('l');
            model.Del();
            model.Add('l');
            model.Add('s');
            model.Add('o');
            model.Guess().Should().Be(SpellingBee.Result.Valid);

            model.Add('c');
            model.Add('o');
            model.Add('a');
            model.Add('l');
            model.Del();
            model.Del();
            model.Add('a');
            model.Add('l');
            model.Guess().Should().Be(SpellingBee.Result.Valid);

            model.Add('c');
            model.Add('a');
            model.Add('s');
            model.Add('h');
            model.Add('o');
            model.Del();
            model.Del();
            model.Del();
            model.Del();
            model.Del();
            model.Add('s');
            model.Add('o');
            model.Add('l');
            model.Add('a');
            model.Add('r');
            model.Guess().Should().Be(SpellingBee.Result.Valid);
        }

        [TestMethod]
        public void Ranks()
        {
            var model = new SpellingBee(new Random(4));
            model.InitFields(GetAllWords());
            model.CalcRank().Should().Be(Rank.Beginner);


            GuessWord("coal", model);
            model.CalcPercentage().Should().Be(2);
            model.CalcRank().Should().Be(Rank.GoodStart);

            GuessWord("also", model);
            model.CalcPercentage().Should().Be(4);
            model.CalcRank().Should().Be(Rank.GoodStart);

            GuessWord("call", model);
            model.CalcPercentage().Should().Be(6);
            model.CalcRank().Should().Be(Rank.MovingUp);

            GuessWord("cool", model);
            model.CalcPercentage().Should().Be(8);
            model.CalcRank().Should().Be(Rank.Good);

            GuessWord("class", model);
            model.CalcPercentage().Should().Be(17);
            model.CalcRank().Should().Be(Rank.Solid);

            GuessWord("color", model);
            model.CalcPercentage().Should().Be(27);
            model.CalcRank().Should().Be(Rank.Nice);

            GuessWord("alcohol", model);
            model.CalcPercentage().Should().Be(40);
            model.CalcRank().Should().Be(Rank.Great);

            GuessWord("scholar", model);
            model.CalcPercentage().Should().Be(54);
            model.CalcRank().Should().Be(Rank.Amazing);

            GuessWord("school", model);
            GuessWord("local", model);
            model.CalcPercentage().Should().Be(75);
            model.CalcRank().Should().Be(Rank.Genius);

            GuessWord("solar", model);
            GuessWord("shall", model);
            GuessWord("hall", model);
            GuessWord("loss", model);
            GuessWord("roll", model);
            model.CalcPercentage().Should().Be(100);
        }
    }
}