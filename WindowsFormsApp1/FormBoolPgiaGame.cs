using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogicalBoolPgia;

namespace GuiBoolPgia
{
    
    public partial class FormBoolPgiaGame : Form
    {
        private const int k_SpaceBetweenButton = 5;
        private const int k_NumberOfGuesses = 4;
        private const bool k_Enable = true;
        private const bool k_Disable = false;
        private readonly Button[] r_ButtonsArrows;
        private readonly Button[] r_ButtonsComputerSelection;
        private readonly Button[,] r_ButtonsUserGuesses;
        private readonly Button[,] r_ButtonShowResult;
        private readonly int r_NumberOfRounds;
        private FormPickColor m_FormPickColor;
        private BoolPgiaGame m_BoolPgiaGame;
        private int m_CurrentStage = 0;

        public FormBoolPgiaGame(int i_NumberOfRounds)
        {
            r_NumberOfRounds = i_NumberOfRounds;
            r_ButtonsArrows = new Button[r_NumberOfRounds];
            r_ButtonsComputerSelection = new Button[k_NumberOfGuesses];
            r_ButtonsUserGuesses = new Button[r_NumberOfRounds, k_NumberOfGuesses];
            r_ButtonShowResult = new Button[r_NumberOfRounds, k_NumberOfGuesses];

            InitializeComponent();
            showDynamicButtonsAndStartGame();
        }

        private void showDynamicButtonsAndStartGame()
        {
            setUserGuessButtons();
            setBlackButtons();
            setResultButtons();
            StartGame();
        }

        public void StartGame()
        {
            m_BoolPgiaGame = new BoolPgiaGame();
            m_BoolPgiaGame.StartNewGame(r_NumberOfRounds);
            changeEnableStatusButtonsByStage(m_CurrentStage, k_Enable);
        }

        private void setUserGuessButtons()
        {
            int pointX = 12;
            int pointY = 117;

            for (int i = 0; i < r_NumberOfRounds; i++)
            {
                for (int j = 0; j < k_NumberOfGuesses; j++)
                {
                    r_ButtonsUserGuesses[i, j] = new Button();
                    r_ButtonsUserGuesses[i, j].Location = new Point(pointX, pointY);
                    r_ButtonsUserGuesses[i, j].Enabled = false;
                    r_ButtonsUserGuesses[i, j].Size = new Size(62, 66);
                    r_ButtonsUserGuesses[i, j].UseVisualStyleBackColor = false;
                    r_ButtonsUserGuesses[i, j].TabIndex = j;
                    r_ButtonsUserGuesses[i, j].Click += new EventHandler(this.setColorButton_Click);

                    pointX += k_SpaceBetweenButton + r_ButtonsUserGuesses[i, j].Width;
                    this.Controls.Add(r_ButtonsUserGuesses[i, j]);
                }

                int locationForArrowButton = ((r_ButtonsUserGuesses[i, k_NumberOfGuesses - 1].Top + r_ButtonsUserGuesses[i, k_NumberOfGuesses - 1].Bottom) / 2) - 16;

                setArrowButton(locationForArrowButton, i);
                pointY = k_SpaceBetweenButton + r_ButtonsUserGuesses[i, 0].Bottom;
                pointX = 12;
            }
        }

        private void setResultButtons()
        {
            int pointX = r_ButtonsArrows[0].Right + k_SpaceBetweenButton;
            int pointY = r_ButtonsArrows[0].Top - k_SpaceBetweenButton;

            for (int i = 0; i < r_NumberOfRounds; i++)
            {
                pointY = r_ButtonsArrows[i].Top - k_SpaceBetweenButton;
                pointX = r_ButtonsArrows[0].Right + k_SpaceBetweenButton;

                for (int j = 0; j < k_NumberOfGuesses; j++)
                {
                    r_ButtonShowResult[i, j] = new Button();
                    r_ButtonShowResult[i, j].Location = new Point(pointX, pointY);
                    r_ButtonShowResult[i, j].Enabled = false;
                    r_ButtonShowResult[i, j].Size = new Size(20, 20);
                    r_ButtonShowResult[i, j].UseVisualStyleBackColor = false;

                    pointX += k_SpaceBetweenButton + r_ButtonShowResult[i, j].Width;

                    this.Controls.Add(r_ButtonShowResult[i, j]);

                    if (j == (k_NumberOfGuesses / 2) - 1)
                    {
                        pointY = r_ButtonShowResult[i, 0].Bottom + k_SpaceBetweenButton;
                        pointX = r_ButtonsArrows[0].Right + k_SpaceBetweenButton;
                    }
                }
            }

            int widthSize = r_ButtonShowResult[r_NumberOfRounds - 1, 1].Right + (k_SpaceBetweenButton * 2);
            int bottomSize = r_ButtonsUserGuesses[r_NumberOfRounds - 1, 0].Bottom + (k_SpaceBetweenButton * 2);

            this.ClientSize = new Size(widthSize, bottomSize);
        }

        private void setBlackButtons()
        {
            int pointX = 12;
            int pointY = 12;

            for (int i = 0; i < k_NumberOfGuesses; i++)
            {
                r_ButtonsComputerSelection[i] = new Button();
                r_ButtonsComputerSelection[i].BackColor = Color.Black;
                r_ButtonsComputerSelection[i].Location = new Point(pointX, pointY);
                r_ButtonsComputerSelection[i].Size = new Size(62, 66);
                r_ButtonsComputerSelection[i].Enabled = false;
                pointX += k_SpaceBetweenButton + r_ButtonsComputerSelection[i].Width;
                this.Controls.Add(r_ButtonsComputerSelection[i]);
            }
        }

        private void setArrowButton(int i_LocationForButton, int i_NumberOfButton)
        {
            int pointX = 285;
            int pointY = i_LocationForButton;

            r_ButtonsArrows[i_NumberOfButton] = new Button();
            r_ButtonsArrows[i_NumberOfButton].Enabled = false;
            r_ButtonsArrows[i_NumberOfButton].Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            r_ButtonsArrows[i_NumberOfButton].Location = new Point(pointX, pointY);
            r_ButtonsArrows[i_NumberOfButton].Size = new Size(75, 32);
            r_ButtonsArrows[i_NumberOfButton].Text = "-->>";
            r_ButtonsArrows[i_NumberOfButton].UseVisualStyleBackColor = true;
            r_ButtonsArrows[i_NumberOfButton].Click += setArrowButtons_Click;

            pointY = r_ButtonsArrows[i_NumberOfButton].Bottom + (k_SpaceBetweenButton * 2);
            this.Controls.Add(r_ButtonsArrows[i_NumberOfButton]);
        }

        private void changeEnableStatusButtonsByStage(int i_Stage, bool i_StatusForButton)
        {
            for (int i = 0; i < k_NumberOfGuesses; i++)
            {
                r_ButtonsUserGuesses[i_Stage, i].Enabled = i_StatusForButton;
            }
        }

        private void gameOverMode()
        {
            Color[] colors = m_BoolPgiaGame.ConvertComputerListToColorsList();

            for (int i = 0; i < k_NumberOfGuesses; i++)
            {
                r_ButtonsComputerSelection[i].BackColor = colors[i];
            }
        }

        private void updateGuessResultButtons()
        {
            Color[] colors = m_BoolPgiaGame.ConvertScoresListToColorsList();

            for (int i = 0; i < colors.Length; i++)
            {
                r_ButtonShowResult[m_CurrentStage, i].BackColor = colors[i];
            }
        }

        private void setColorButton_Click(object sender, EventArgs e)
        {
            m_FormPickColor = new FormPickColor();
            m_FormPickColor.ShowDialog();

            (sender as Button).BackColor = m_FormPickColor.SelectedColor;

            eColorName.TryParse(m_FormPickColor.SelectedColor.Name, out eColorName colorName);

            if (m_BoolPgiaGame.UpdateUserInputColorList((sender as Button).TabIndex, colorName))
            {
                r_ButtonsArrows[m_CurrentStage].Enabled = true;
                r_ButtonsArrows[m_CurrentStage].ForeColor = Color.Black;
            }
            else
            {
                r_ButtonsArrows[m_CurrentStage].Enabled = false;
                r_ButtonsArrows[m_CurrentStage].ForeColor = default;
            }
        }

        private void setArrowButtons_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;

            updateGuessResultButtons();
            changeEnableStatusButtonsByStage(m_CurrentStage, k_Disable);

            if (m_BoolPgiaGame.IsTheGameOver())
            {
                gameOverMode();
            }
            else
            {
                m_CurrentStage++;
                changeEnableStatusButtonsByStage(m_CurrentStage, k_Enable);
            }
        }
    }
}