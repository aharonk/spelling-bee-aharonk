namespace SpellingBlock
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.letter1 = new System.Windows.Forms.Button();
            this.letter2 = new System.Windows.Forms.Button();
            this.letter3 = new System.Windows.Forms.Button();
            this.letter4 = new System.Windows.Forms.Button();
            this.letter5 = new System.Windows.Forms.Button();
            this.letter6 = new System.Windows.Forms.Button();
            this.center = new System.Windows.Forms.Button();
            this.userWord = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.enter = new System.Windows.Forms.Button();
            this.shuffleLetters = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.level = new System.Windows.Forms.Label();
            this.foundWords = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.foundWordCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            // 
            // letter1
            // 
            this.letter1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.letter1.Location = new System.Drawing.Point(151, 102);
            this.letter1.Name = "letter1";
            this.letter1.Size = new System.Drawing.Size(75, 75);
            this.letter1.TabIndex = 0;
            this.letter1.UseVisualStyleBackColor = true;
            this.letter1.Click += new System.EventHandler(this.Letter_Click);
            // 
            // letter2
            // 
            this.letter2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.letter2.Location = new System.Drawing.Point(232, 146);
            this.letter2.Name = "letter2";
            this.letter2.Size = new System.Drawing.Size(75, 75);
            this.letter2.TabIndex = 1;
            this.letter2.UseVisualStyleBackColor = true;
            this.letter2.Click += new System.EventHandler(this.Letter_Click);
            // 
            // letter3
            // 
            this.letter3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.letter3.Location = new System.Drawing.Point(232, 227);
            this.letter3.Name = "letter3";
            this.letter3.Size = new System.Drawing.Size(75, 75);
            this.letter3.TabIndex = 2;
            this.letter3.UseVisualStyleBackColor = true;
            this.letter3.Click += new System.EventHandler(this.Letter_Click);
            // 
            // letter4
            // 
            this.letter4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.letter4.Location = new System.Drawing.Point(151, 264);
            this.letter4.Name = "letter4";
            this.letter4.Size = new System.Drawing.Size(75, 75);
            this.letter4.TabIndex = 3;
            this.letter4.UseVisualStyleBackColor = true;
            this.letter4.Click += new System.EventHandler(this.Letter_Click);
            // 
            // letter5
            // 
            this.letter5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.letter5.Location = new System.Drawing.Point(70, 227);
            this.letter5.Name = "letter5";
            this.letter5.Size = new System.Drawing.Size(75, 75);
            this.letter5.TabIndex = 4;
            this.letter5.UseVisualStyleBackColor = true;
            this.letter5.Click += new System.EventHandler(this.Letter_Click);
            // 
            // letter6
            // 
            this.letter6.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.letter6.Location = new System.Drawing.Point(70, 143);
            this.letter6.Name = "letter6";
            this.letter6.Size = new System.Drawing.Size(75, 75);
            this.letter6.TabIndex = 5;
            this.letter6.UseVisualStyleBackColor = true;
            this.letter6.Click += new System.EventHandler(this.Letter_Click);
            // 
            // center
            // 
            this.center.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.center.Location = new System.Drawing.Point(151, 183);
            this.center.Name = "center";
            this.center.Size = new System.Drawing.Size(75, 75);
            this.center.TabIndex = 6;
            this.center.UseVisualStyleBackColor = true;
            this.center.Click += new System.EventHandler(this.Letter_Click);
            // 
            // userWord
            // 
            this.userWord.AutoSize = true;
            this.userWord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userWord.Location = new System.Drawing.Point(0, 0);
            this.userWord.Name = "userWord";
            this.userWord.Size = new System.Drawing.Size(0, 21);
            this.userWord.TabIndex = 7;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(89, 369);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 30);
            this.delete.TabIndex = 7;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.DeleteClick);
            // 
            // enter
            // 
            this.enter.Location = new System.Drawing.Point(206, 369);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(75, 30);
            this.enter.TabIndex = 9;
            this.enter.Text = "Enter";
            this.enter.UseVisualStyleBackColor = true;
            this.enter.Click += new System.EventHandler(this.SubmitGuess);
            // 
            // shuffleLetters
            // 
            this.shuffleLetters.Location = new System.Drawing.Point(170, 369);
            this.shuffleLetters.Name = "shuffleLetters";
            this.shuffleLetters.Size = new System.Drawing.Size(30, 30);
            this.shuffleLetters.TabIndex = 8;
            this.shuffleLetters.Text = "🗘";
            this.shuffleLetters.UseVisualStyleBackColor = true;
            this.shuffleLetters.Click += new System.EventHandler(this.ShuffleLetters);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(502, 26);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(258, 26);
            this.progressBar1.TabIndex = 10;
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level.Location = new System.Drawing.Point(391, 26);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(88, 25);
            this.level.TabIndex = 12;
            this.level.Text = "Beginner";
            // 
            // foundWords
            // 
            this.foundWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.foundWords.FormattingEnabled = true;
            this.foundWords.ItemHeight = 15;
            this.foundWords.Location = new System.Drawing.Point(0, 22);
            this.foundWords.MultiColumn = true;
            this.foundWords.Name = "foundWords";
            this.foundWords.Size = new System.Drawing.Size(368, 315);
            this.foundWords.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.foundWordCount);
            this.panel1.Controls.Add(this.foundWords);
            this.panel1.Location = new System.Drawing.Point(391, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 341);
            this.panel1.TabIndex = 14;
            // 
            // foundWordCount
            // 
            this.foundWordCount.AutoSize = true;
            this.foundWordCount.Location = new System.Drawing.Point(0, 0);
            this.foundWordCount.Name = "foundWordCount";
            this.foundWordCount.Size = new System.Drawing.Size(134, 15);
            this.foundWordCount.TabIndex = 14;
            this.foundWordCount.Text = "You have found 0 words";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.level);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.shuffleLetters);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.center);
            this.Controls.Add(this.userWord);
            this.Controls.Add(this.letter6);
            this.Controls.Add(this.letter5);
            this.Controls.Add(this.letter4);
            this.Controls.Add(this.letter3);
            this.Controls.Add(this.letter2);
            this.Controls.Add(this.letter1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
        }

        #endregion

        private Button letter1;
        private Button letter2;
        private Button letter3;
        private Button letter4;
        private Button letter5;
        private Button letter6;
        private Button center;
        private Label userWord;
        private Button delete;
        private Button enter;
        private Button shuffleLetters;
        private ProgressBar progressBar1;
        private Label level;
        private ListBox foundWords;
        private Panel panel1;
        private Label foundWordCount;
    }
}