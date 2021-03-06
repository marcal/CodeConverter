using System;
using System.Windows.Forms;

namespace WindowsAppVb
{
    public partial class WinformsDesignerTest
    {
        public WinformsDesignerTest()
        {
            base.Load += WinformsDesignerTest_EnsureSelfEventsWork;
            this.SizeChanged += WinformsDesignerTest_EnsureSelfEventsWork;
            this.MouseClick += (_, __) => WinformsDesignerTest_MouseClick();
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void CheckedChangedOrButtonClicked(object sender, EventArgs e)
        {
            string formConstructedText = "Form constructed";
            if (!(My.MyProject.Forms.m_WinformsDesignerTest == default) && (My.MyProject.Forms.WinformsDesignerTest.Text ?? "") != (formConstructedText ?? ""))
            {
                My.MyProject.Forms.WinformsDesignerTest.Text = formConstructedText;
            }
            else if (My.MyProject.Forms.m_WinformsDesignerTest is object && My.MyProject.Forms.m_WinformsDesignerTest is object)
            {
                My.MyProject.Forms.WinformsDesignerTest = null;
            }
        }

        private void WinformsDesignerTest_EnsureSelfEventsWork(object sender, EventArgs e)
        {
        }

        private void WinformsDesignerTest_MouseClick()
        {
        }

        public void Init()
        {
            MouseEventHandler noArgs = (_, __) => WinformsDesignerTest_MouseClick();
            MouseClick += noArgs;
            MouseClick += (_, __) => WinformsDesignerTest_MouseClick();
            MouseClick -= noArgs;
            MouseClick -= (_, __) => WinformsDesignerTest_MouseClick(); // Generates a VB warning because it has no effect
        }

        public void Init_Advanced(MouseEventHandler paramToHandle)
        {
            Init();
            MouseClick += paramToHandle;
            WinformsDesignerTest_MouseClick();
        }
    }
}