using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuiBoolPgia
{
    public partial class FormBoolPgiaNumberOfRounds : Form
    {
        private const int k_MinimumNumberOfChances = 4;
        private const int k_MaximumNumberOfChances = 10;
        private int m_NumberOfChances = k_MinimumNumberOfChances;
        private FormBoolPgiaGame m_FormBoolPgiaGame;
        
        public FormBoolPgiaNumberOfRounds()
        {
            InitializeComponent();
        }

        private void buttonNumberOfRounds_Click(object sender, EventArgs e)
        {
            if (m_NumberOfChances < k_MaximumNumberOfChances)
            {
                m_NumberOfChances++;
            }
            else
            {
                m_NumberOfChances = k_MinimumNumberOfChances;
            }

            this.buttonNumberOfRounds.Text = string.Format(@"Number of chances: {0}", m_NumberOfChances);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            m_FormBoolPgiaGame = new FormBoolPgiaGame(m_NumberOfChances);

            m_FormBoolPgiaGame.ShowDialog();
            this.Close();
        }
    }
}
