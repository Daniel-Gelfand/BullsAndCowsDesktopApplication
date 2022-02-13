using System.Collections.Generic;
using System.Drawing;

namespace LogicalBoolPgia
{
    public class BoolPgiaGame
    {
        private const eColorName k_NoColorWasSelected = 0;
        private const int k_NumberOfElementToGuess = 4;
        private readonly Score r_Score;
        private ComputerSelection m_ComputerSelection;
        private eColorName[] m_UserGuessesList = new eColorName[k_NumberOfElementToGuess];
        private int m_NumberOfUserGuesses;

        public BoolPgiaGame()
        {
        }

        public eColorName[] UserGuessesList
        {
            get
            {
                return m_UserGuessesList;
            }

            set
            {
                m_UserGuessesList = value;
            }
        }

        public ComputerSelection ComputerSelection
        {
            get { return m_ComputerSelection; }
        }

        public void StartNewGame(int i_NumberOfRows)
        {
            m_NumberOfUserGuesses = i_NumberOfRows;
            m_ComputerSelection = new ComputerSelection();
        }

        public bool IsTheGameOver()
        {
            return isSuccessfulGuess() || !isStillHasAChances();
        }

        private bool isStillHasAChances()
        {
            bool isGameOver = m_NumberOfUserGuesses > 0;

            return isGameOver;
        }

        public eScore[] GetScoreList()
        {
            return r_Score.CalculateScore(m_UserGuessesList, m_ComputerSelection.RandomList);
        }

        private bool isSuccessfulGuess()
        {
            bool isWinner = false;
            int counterSuccessfulGuesses = 0;

            for (int i = 0; i < k_NumberOfElementToGuess; i++)
            {
                if (m_UserGuessesList[i] == m_ComputerSelection.RandomList[i])
                {
                    counterSuccessfulGuesses++;
                }
            }

            isWinner = counterSuccessfulGuesses == k_NumberOfElementToGuess;
            m_NumberOfUserGuesses--;
            m_UserGuessesList = new eColorName[k_NumberOfElementToGuess];

            return isWinner;
        }

        private bool checkDuplicatesColors()
        {
            bool isValidSelection = true;

            for (int i = 0; i < k_NumberOfElementToGuess; i++)
            {
                if (UserGuessesList[i] == k_NoColorWasSelected)
                {
                    isValidSelection = false;
                    break;
                }

                for (int j = i + 1; j < k_NumberOfElementToGuess; j++)
                {
                    if (UserGuessesList[i].Equals(UserGuessesList[j]))
                    {
                        isValidSelection = false;
                        break;
                    }
                }

                if (!isValidSelection)
                {
                    break;
                }
            }

            return isValidSelection;
        }

        public bool UpdateUserInputColorList(int i_Index, eColorName i_ColorName)
        {
            bool isValidInput = false;

            UserGuessesList[i_Index] = i_ColorName;

            if (checkDuplicatesColors())
            {
                isValidInput = true;
            }

            return isValidInput;
        }

        public Color[] ConvertComputerListToColorsList()
        {
            Color[] colors = new Color[k_NumberOfElementToGuess];

            for (int i = 0; i < k_NumberOfElementToGuess; i++)
            {
                colors[i] = convertComputerSelectionToColors(ComputerSelection.RandomList[i]);
            }

            return colors;
        }

        private Color convertComputerSelectionToColors(eColorName i_ColorElement)
        {
            Color color = default;

            switch (i_ColorElement)
            {
                case eColorName.BlueViolet:
                    color = Color.BlueViolet;
                    break;
                case eColorName.Red:
                    color = Color.Red;
                    break;
                case eColorName.Green:
                    color = Color.Green;
                    break;
                case eColorName.Aqua:
                    color = Color.Aqua;
                    break;
                case eColorName.Blue:
                    color = Color.Blue;
                    break;
                case eColorName.Yellow:
                    color = Color.Yellow;
                    break;
                case eColorName.Brown:
                    color = Color.Brown;
                    break;
                case eColorName.White:
                    color = Color.White;
                    break;
            }

            return color;
        }

        public Color[] ConvertScoresListToColorsList()
        {
            Color[] colors = new Color[k_NumberOfElementToGuess];

            for (int i = 0; i < k_NumberOfElementToGuess; i++)
            {
                colors[i] = convertScoreToColor(GetScoreList()[i]);
            }

            return colors;
        }

        private Color convertScoreToColor(eScore i_Score)
        {
            Color color = default;

            switch (i_Score)
            {
                case eScore.Blank:
                    color = default;
                    break;
                case eScore.Pgia:
                    color = Color.Yellow;
                    break;
                case eScore.Bool:
                    color = Color.Black;
                    break;
            }

            return color;
        }
    }
}
