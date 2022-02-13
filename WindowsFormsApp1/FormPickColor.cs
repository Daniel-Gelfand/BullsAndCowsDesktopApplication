using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuiBoolPgia
{
    public partial class FormPickColor : Form
    {
        private const int k_SpaceBetweenButton = 5;
        private const int k_NumberOfColors = 8;
        private readonly Color[] m_Colors = { Color.BlueViolet, Color.Red, Color.Green, Color.Aqua, Color.Blue, Color.Yellow, Color.Brown, Color.White };
        private readonly Button[] m_ButtonColorSelect = new Button[k_NumberOfColors];
        private Color m_SelectedSelectedColor;

        public FormPickColor()
        {
            InitializeComponent();
            setPickColorButtons();
        }

        public Color SelectedColor
        {
            get
            {
                return m_SelectedSelectedColor;
            }

            set
            {
                m_SelectedSelectedColor = value;
            }
        }

        private void setPickColorButtons()
        {
            int pointX = 12;
            int pointY = 12;

            for (int i = 0; i < k_NumberOfColors; i++)
            {
                m_ButtonColorSelect[i] = new Button();
                m_ButtonColorSelect[i].BackColor = m_Colors[i];
                m_ButtonColorSelect[i].Location = new Point(pointX, pointY);
                m_ButtonColorSelect[i].Size = new Size(61, 57);
                m_ButtonColorSelect[i].TabIndex = i;
                m_ButtonColorSelect[i].UseVisualStyleBackColor = false;
                m_ButtonColorSelect[i].Click += new EventHandler(this.buttonSelectColor_Click);
                pointX += m_ButtonColorSelect[i].Width + k_SpaceBetweenButton;

                if (i == (k_NumberOfColors / 2) - 1)
                {
                    pointX = 12;
                    pointY = m_ButtonColorSelect[i].Bottom + k_SpaceBetweenButton;
                }

                this.Controls.Add(m_ButtonColorSelect[i]);
            }
        }

        private void buttonSelectColor_Click(object sender, EventArgs e)
        {
            SelectedColor = (sender as Button).BackColor;
            this.Close();
        }
    }
}
