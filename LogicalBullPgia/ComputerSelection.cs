using System;
using System.Collections.Generic;

namespace LogicalBoolPgia
{
    public class ComputerSelection
    {
        private const int k_StartRangeSelection = 1;
        private const int k_EndRangeSelection = 8;
        private const int k_CountOfLettersSelection = 4;
        private static readonly Random sr_Random = new Random();
        private readonly List<eColorName> r_RandomComputerSelection = new List<eColorName>(k_CountOfLettersSelection);
        
        public ComputerSelection()
        {
            randomSelection();
        }

        public List<eColorName> RandomList
        {
            get
            {
                return r_RandomComputerSelection;
            }
        }

        private void randomSelection()
        {
            int randomIndexSelection = sr_Random.Next(k_StartRangeSelection, k_EndRangeSelection);
            eColorName randomElement = (eColorName) randomIndexSelection;

            r_RandomComputerSelection.Add(randomElement);

            while (r_RandomComputerSelection.Count < k_CountOfLettersSelection) 
            {
                randomIndexSelection = sr_Random.Next(k_StartRangeSelection, k_EndRangeSelection);
                randomElement = (eColorName)randomIndexSelection;

                if (checkDuplicatesColors(r_RandomComputerSelection, randomElement))
                {
                    r_RandomComputerSelection.Add(randomElement);
                }
            }
        }

        private bool checkDuplicatesColors(List<eColorName> i_RandomComputerSelection, eColorName i_LastRandomElementSelection)
        {
            bool isValidSelection = true;

            foreach (eColorName element in i_RandomComputerSelection)
            {
                if (element.Equals(i_LastRandomElementSelection))
                {
                    isValidSelection = false;
                    break;
                }
            }

            return isValidSelection;
        }
    }
}