using System;
using System.Windows.Forms;

namespace CTFTool
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        //简单题分析
        private void MenuItem_Pwn_Simple_Click(object sender, EventArgs e)
        {
            PwnSimpleAnal oPwnSimpleAnal = new PwnSimpleAnal(RichTextBox_Input, RichTextBox_Explain, RichTextBox_Output);
            oPwnSimpleAnal.Start();
        }

        //Ret2Libc
        private void MenuItem_Pwn_Ret2Libc_Click(object sender, EventArgs e)
        {
            PwnRet2Libc oPwnRet2Libc = new PwnRet2Libc(RichTextBox_Input, RichTextBox_Explain, RichTextBox_Output);
            oPwnRet2Libc.Start();
        }
    }
}