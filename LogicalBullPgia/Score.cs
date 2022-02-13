using System.Collections.Generic;

namespace LogicalBoolPgia
{
    public struct Score
    {
        public eScore[] CalculateScore(eColorName[] i_UserInput, List<eColorName> i_ComputerInput)
        {
            eScore[] scoreList = { eScore.Blank, eScore.Blank, eScore.Blank, eScore.Blank };

            int countCorrectsPlace = checkCorrectPlace(i_UserInput, i_ComputerInput);
            int countCorrectsNotInPlace = checkCorrectNotInPlace(i_UserInput, i_ComputerInput);
            int numberOfBools = countCorrectsNotInPlace - countCorrectsPlace;

            for (int i = 0; i < countCorrectsPlace; i++)
            {
                scoreList[i] = eScore.Bool;
            }

            for (int i = countCorrectsPlace; i < countCorrectsNotInPlace; i++)
            {
                scoreList[i] = eScore.Pgia;
            }

            return scoreList;
        }

        private int checkCorrectPlace(eColorName[] i_UserInput, List<eColorName> i_ComputerInput)
        {
            int countCorrects = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (i_UserInput[i].Equals(i_ComputerInput[i]))
                {
                    countCorrects++;
                }
            }

            return countCorrects;
        }

        private int checkCorrectNotInPlace(eColorName[] i_UserInput, List<eColorName> i_ComputerInput)
        {
            int countCorrects = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                for (int j = 0; j < i_UserInput.Length; j++)  
                {
                    if (i_UserInput[i].Equals(i_ComputerInput[j]))
                    {
                        countCorrects++;
                    }
                }
            }

            return countCorrects;
        }
    }
}
