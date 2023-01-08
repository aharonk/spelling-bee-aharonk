using SpellingBeeModel;

namespace SpellingBlock
{
    public partial class Form1 : Form
    {
        private readonly SpellingBee _model;
        private bool _wrongGuess;

        public Form1()
        {
            _model = new SpellingBee();

            SuspendLayout();
            InitializeComponent();
            userWord.Text = "";

            // centers label over controls
            RecenterWord();

            // add model variables
            ArrangeLetters();


            // finish Form
            ResumeLayout(false);
            PerformLayout();
        }

        private void RecenterWord()
        {
            using (var g = CreateGraphics())
            {
                var sf = g.MeasureString(userWord.Text, userWord.Font, 307 - 70);
                userWord.Size = new Size(
                    (int) Math.Ceiling(sf.Width), (int) Math.Ceiling(sf.Height));
            }

            userWord.Location = new Point(70 + ((307 - 70) - userWord.Width) / 2, 66);
        }

        private void ArrangeLetters()
        {
            center.Text = _model.GetCenter().ToString().ToUpper();
            var letters = _model.GetOtherLetters();
            letter1.Text = letters[0].ToString().ToUpper();
            letter2.Text = letters[1].ToString().ToUpper();
            letter3.Text = letters[2].ToString().ToUpper();
            letter4.Text = letters[3].ToString().ToUpper();
            letter5.Text = letters[4].ToString().ToUpper();
            letter6.Text = letters[5].ToString().ToUpper();
        }

        private void Letter_Click(object sender, EventArgs e)
        {
            var b = (Button) sender;

            if (_wrongGuess)
            {
                userWord.Text = "";
                _wrongGuess = false;
            }

            userWord.Text += userWord.Text == "" ? b.Text : b.Text.ToLower();

            _model.Add(b.Text.ToLower()[0]);
            RecenterWord();
        }

        private void ShuffleLetters(object sender, EventArgs e)
        {
            _model.Shuffle();
            ArrangeLetters();
        }

        private void SubmitGuess(object sender, EventArgs e)
        {
            SpellingBee.Result res;
            _wrongGuess = true;
            if ((res = _model.Guess()) == SpellingBee.Result.Valid)
            {
                foundWords.DataSource = null;
                foundWords.DataSource = _model.GetFoundWords();
                userWord.Text = "";
                _wrongGuess = false;
                level.Text = _model.CalcRank().ScreenName();
                progressBar1.Value = _model.CalcPercentage();
                foundWordCount.Text = "You have found " + _model.GetFoundWords().Count + " words";
                if (_model.CalcPercentage() == 100)
                {
                    MessageBox.Show("You found all the words!", "You won!");
                }
            }
            else
                userWord.Text = res switch
                {
                    SpellingBee.Result.TooShort => "Too Short",
                    SpellingBee.Result.NotAWord => "Not in word list",
                    SpellingBee.Result.AlreadyFound => "Already found",
                    SpellingBee.Result.NoCenter => "Missing center letter",
                    _ => ""
                };

            RecenterWord();
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            _model.Del();
            if (userWord.Text.Length > 0)
            {
                userWord.Text = userWord.Text[..^1];
                RecenterWord();
            }
        }
    }
}