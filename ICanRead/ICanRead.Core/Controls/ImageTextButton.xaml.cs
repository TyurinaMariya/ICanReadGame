using ICanRead.Core.Customization;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICanRead.Core.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageTextButton
    { 
        public ImageTextButton()
		{
			InitializeComponent ();

            innerImageButton.SetBinding(ImageButton.SourceProperty, new Binding(nameof(ImageSource), source: this));
            innerImageButton.SetBinding(ImageButton.AspectProperty, new Binding(nameof(ImageAspect), source: this));


            innerLabel.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
            innerLabel.SetBinding(Label.MarginProperty, new Binding(nameof(TextMargin), source: this));
            innerLabel.SetBinding(Label.FontSizeProperty, new Binding(nameof(FontSize), source: this));

            var pressedCommand = new MvxCommand(() =>
            {
                if (ClickedImageSource != null && IsEnabled)
                {
                    innerLabel.Margin = ClickedTextMargin;
                    innerImageButton.Source = ClickedImageSource;
                }
                
            });
            var releaseCommand = new MvxAsyncCommand( async () =>
            {
                innerLabel.Margin = TextMargin;
                innerImageButton.Source = ImageSource;

                Clicked?.Invoke(this, EventArgs.Empty);

                if (Command != null && Command.CanExecute(CommandParameter))
                {
                    if (Command is IMvxAsyncCommand)
                        await(Command as IMvxAsyncCommand).ExecuteAsync(CommandParameter);
                    else
                        Command.Execute(CommandParameter);
                }

            });

            innerImageButton.GestureRecognizers.Add(new PressedGestureRecognizer {Command = pressedCommand });
            innerLabel.GestureRecognizers.Add(new PressedGestureRecognizer { Command = pressedCommand });

            innerImageButton.GestureRecognizers.Add(new ReleasedGestureRecognizer { Command = releaseCommand });
            innerLabel.GestureRecognizers.Add(new ReleasedGestureRecognizer { Command = releaseCommand });

        }
        public event EventHandler Clicked;

        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(ImageTextButton), default(ImageSource));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty ImageAspectProperty =
            BindableProperty.Create("ImageAspect", typeof(Aspect), typeof(ImageTextButton), default(Aspect));

        public Aspect ImageAspect
        {
            get { return (Aspect)GetValue(ImageAspectProperty); }
            set { SetValue(ImageAspectProperty, value); }
        }
        
        public static readonly BindableProperty ClickedImageSourceProperty =
            BindableProperty.Create("ClickedImageSource", typeof(ImageSource), typeof(ImageTextButton), default(ImageSource));

        public ImageSource ClickedImageSource
        {
            get { return (ImageSource)GetValue(ClickedImageSourceProperty); }
            set { SetValue(ClickedImageSourceProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
              BindableProperty.Create("Text", typeof(string), typeof(ImageTextButton), default(string));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextMarginProperty =
              BindableProperty.Create(nameof(TextMargin), typeof(Thickness), typeof(ImageTextButton), default(string));

        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }


        public static readonly BindableProperty ClickedTextMarginProperty =
             BindableProperty.Create(nameof(ClickedTextMargin), typeof(Thickness), typeof(ImageTextButton), default(string));

        public Thickness ClickedTextMargin
        {
            get { return (Thickness)GetValue(ClickedTextMarginProperty); }
            set { SetValue(ClickedTextMarginProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
              BindableProperty.Create("FontSize", typeof(double), typeof(ImageTextButton), default(double));

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
          BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ImageTextButton), null);

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
          BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ImageTextButton), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value);
            }
        }
    }
}