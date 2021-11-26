using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CTFTool
{
    public class PwnSimpleAnal
    {
        //属性
        private RichTextBox m_cIn;
        private RichTextBox m_cExp;
        private RichTextBox m_cOut;

        //构造
        public PwnSimpleAnal(RichTextBox cIn, RichTextBox cExp, RichTextBox cOut)
        {
            //清空显示区域
            cExp.Text = cOut.Text = "";

            //初始化
            m_cIn = cIn;
            m_cExp = cExp;
            m_cOut = cOut;
        }

        //开始
        public void Start()
        {
            Boolean bExec = false;
            bExec = bExec || PwnExistShellCode();
            if (!bExec)
            {
                m_cExp.Text = m_cExp.Text + "分析失败" + Environment.NewLine;
            }
        }

        //直接可获取shell
        private Boolean PwnExistShellCode()
        {
            if (m_cIn.Text.Contains("system(\"/bin/sh\")"))
            {
                //说明
                m_cExp.Text += "函数中存在ShellCode!";

                //输出
                m_cOut.Text += "from pwn import *\n";
                m_cOut.Text += "\n";
                Regex vRegex = new Regex("(.*?):(\\d+)", RegexOptions.Multiline);
                Match vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    m_cOut.Text += "process = remote('" + vMatch.Groups[1].Value + "', " + vMatch.Groups[2].Value + ")\n";
                }
                else
                {
                    m_cOut.Text += "process = remote('IP', Port)\n";
                }
                m_cOut.Text += "process.interactive()\n";

                return true;
            }
            return false;
        }
    }
}