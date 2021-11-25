
namespace CTFTool
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu_Main = new System.Windows.Forms.MenuStrip();
            this.MenuItem_Misc = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Crypto = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Web = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Reverse = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Pwn = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Other = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox_Output = new System.Windows.Forms.GroupBox();
            this.GroupBox_Input = new System.Windows.Forms.GroupBox();
            this.GroupBox_Explain = new System.Windows.Forms.GroupBox();
            this.RichTextBox_Input = new System.Windows.Forms.RichTextBox();
            this.RichTextBox__Explain = new System.Windows.Forms.RichTextBox();
            this.RichTextBox_Output = new System.Windows.Forms.RichTextBox();
            this.Menu_Main.SuspendLayout();
            this.GroupBox_Output.SuspendLayout();
            this.GroupBox_Input.SuspendLayout();
            this.GroupBox_Explain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu_Main
            // 
            this.Menu_Main.Font = new System.Drawing.Font("Palatino Linotype", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Misc,
            this.MenuItem_Crypto,
            this.MenuItem_Web,
            this.MenuItem_Reverse,
            this.MenuItem_Pwn,
            this.MenuItem_Other});
            this.Menu_Main.Location = new System.Drawing.Point(0, 0);
            this.Menu_Main.Name = "Menu_Main";
            this.Menu_Main.Size = new System.Drawing.Size(1009, 27);
            this.Menu_Main.TabIndex = 0;
            // 
            // MenuItem_Misc
            // 
            this.MenuItem_Misc.Name = "MenuItem_Misc";
            this.MenuItem_Misc.Size = new System.Drawing.Size(57, 23);
            this.MenuItem_Misc.Text = "MISC";
            // 
            // MenuItem_Crypto
            // 
            this.MenuItem_Crypto.Name = "MenuItem_Crypto";
            this.MenuItem_Crypto.Size = new System.Drawing.Size(78, 23);
            this.MenuItem_Crypto.Text = "CRYPTO";
            // 
            // MenuItem_Web
            // 
            this.MenuItem_Web.Name = "MenuItem_Web";
            this.MenuItem_Web.Size = new System.Drawing.Size(53, 23);
            this.MenuItem_Web.Text = "WEB";
            // 
            // MenuItem_Reverse
            // 
            this.MenuItem_Reverse.Name = "MenuItem_Reverse";
            this.MenuItem_Reverse.Size = new System.Drawing.Size(83, 23);
            this.MenuItem_Reverse.Text = "REVERSE";
            // 
            // MenuItem_Pwn
            // 
            this.MenuItem_Pwn.Name = "MenuItem_Pwn";
            this.MenuItem_Pwn.Size = new System.Drawing.Size(56, 23);
            this.MenuItem_Pwn.Text = "PWN";
            // 
            // MenuItem_Other
            // 
            this.MenuItem_Other.Name = "MenuItem_Other";
            this.MenuItem_Other.Size = new System.Drawing.Size(79, 23);
            this.MenuItem_Other.Text = "OTHERS";
            // 
            // GroupBox_Output
            // 
            this.GroupBox_Output.Controls.Add(this.RichTextBox_Output);
            this.GroupBox_Output.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox_Output.Location = new System.Drawing.Point(0, 480);
            this.GroupBox_Output.Name = "GroupBox_Output";
            this.GroupBox_Output.Size = new System.Drawing.Size(1009, 106);
            this.GroupBox_Output.TabIndex = 1;
            this.GroupBox_Output.TabStop = false;
            this.GroupBox_Output.Text = "输出";
            // 
            // GroupBox_Input
            // 
            this.GroupBox_Input.Controls.Add(this.RichTextBox_Input);
            this.GroupBox_Input.Dock = System.Windows.Forms.DockStyle.Left;
            this.GroupBox_Input.Location = new System.Drawing.Point(0, 27);
            this.GroupBox_Input.Name = "GroupBox_Input";
            this.GroupBox_Input.Size = new System.Drawing.Size(575, 453);
            this.GroupBox_Input.TabIndex = 2;
            this.GroupBox_Input.TabStop = false;
            this.GroupBox_Input.Text = "输入";
            // 
            // GroupBox_Explain
            // 
            this.GroupBox_Explain.Controls.Add(this.RichTextBox__Explain);
            this.GroupBox_Explain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_Explain.Location = new System.Drawing.Point(575, 27);
            this.GroupBox_Explain.Name = "GroupBox_Explain";
            this.GroupBox_Explain.Size = new System.Drawing.Size(434, 453);
            this.GroupBox_Explain.TabIndex = 3;
            this.GroupBox_Explain.TabStop = false;
            this.GroupBox_Explain.Text = "说明";
            // 
            // RichTextBox_Input
            // 
            this.RichTextBox_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox_Input.Location = new System.Drawing.Point(3, 22);
            this.RichTextBox_Input.Name = "RichTextBox_Input";
            this.RichTextBox_Input.Size = new System.Drawing.Size(569, 428);
            this.RichTextBox_Input.TabIndex = 0;
            this.RichTextBox_Input.Text = "";
            // 
            // RichTextBox__Explain
            // 
            this.RichTextBox__Explain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox__Explain.Location = new System.Drawing.Point(3, 22);
            this.RichTextBox__Explain.Name = "RichTextBox__Explain";
            this.RichTextBox__Explain.Size = new System.Drawing.Size(428, 428);
            this.RichTextBox__Explain.TabIndex = 0;
            this.RichTextBox__Explain.Text = "";
            // 
            // RichTextBox_Output
            // 
            this.RichTextBox_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox_Output.Location = new System.Drawing.Point(3, 22);
            this.RichTextBox_Output.Name = "RichTextBox_Output";
            this.RichTextBox_Output.Size = new System.Drawing.Size(1003, 81);
            this.RichTextBox_Output.TabIndex = 0;
            this.RichTextBox_Output.Text = "";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 586);
            this.Controls.Add(this.GroupBox_Explain);
            this.Controls.Add(this.GroupBox_Input);
            this.Controls.Add(this.GroupBox_Output);
            this.Controls.Add(this.Menu_Main);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.Menu_Main;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_Main";
            this.Text = "CTF工具";
            this.Menu_Main.ResumeLayout(false);
            this.Menu_Main.PerformLayout();
            this.GroupBox_Output.ResumeLayout(false);
            this.GroupBox_Input.ResumeLayout(false);
            this.GroupBox_Explain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu_Main;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Misc;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Crypto;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Web;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Reverse;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Pwn;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Other;
        private System.Windows.Forms.GroupBox GroupBox_Output;
        private System.Windows.Forms.GroupBox GroupBox_Input;
        private System.Windows.Forms.GroupBox GroupBox_Explain;
        private System.Windows.Forms.RichTextBox RichTextBox_Input;
        private System.Windows.Forms.RichTextBox RichTextBox__Explain;
        private System.Windows.Forms.RichTextBox RichTextBox_Output;
    }
}

