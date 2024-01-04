using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace chess
{
    public partial class PromotionDialog : Form
    {

        public PieceType SelectedPieceType { get; private set; }
        public PromotionDialog()
        {
            InitializeComponent();
            SelectedPieceType = PieceType.Queen; // Default selection
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the selected piece type based on the radio button selection
            if (radioButton1.Checked)
                SelectedPieceType = PieceType.Queen;
            else if (radioButton2.Checked)
                SelectedPieceType = PieceType.Rook;
            else if (radioButton3.Checked)
                SelectedPieceType = PieceType.Bishop;
            else if (radioButton4.Checked)
                SelectedPieceType = PieceType.Knight;


            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
