﻿// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Forms.Core;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ICanRead.Core
{
    public partial class FormsApp : MvxFormsApplication
    {
        public FormsApp()
        {
            InitializeComponent();
        }
    }
}