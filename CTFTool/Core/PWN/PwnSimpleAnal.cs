using System;
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
            return false;
        }
    }
}