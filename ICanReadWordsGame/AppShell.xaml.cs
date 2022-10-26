namespace ICanReadWordsGame
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.Navigating += AppShell_Navigating;
        }

        private void AppShell_Navigating(object sender, ShellNavigatingEventArgs e)
        {
        }
    }
}