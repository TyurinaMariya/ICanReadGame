using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace ICanReadWordsGame.Controls;

public partial class ImageTextButton
{
#if WINDOWS
    private Image innerImageButtonClicked;
    private Label innerClickedLabel;
#endif

    public ImageTextButton()
    {
        InitializeComponent();

            innerImageButton.SetBinding(ImageButton.SourceProperty, new Binding(nameof(ImageSource), source: this));
        innerImageButton.SetBinding(ImageButton.AspectProperty, new Binding(nameof(ImageAspect), source: this));
        innerLabel.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
        innerLabel.SetBinding(Label.MarginProperty, new Binding(nameof(TextMargin), source: this));
        innerLabel.SetBinding(Label.FontSizeProperty, new Binding(nameof(FontSize), source: this));


#if WINDOWS
        innerImageButtonClicked = new Image
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.Transparent,
            IsVisible = false

        };
        innerGrid.Children.Add(innerImageButtonClicked);
        innerClickedLabel = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            FontAttributes = FontAttributes.Bold,
            TextColor = new Color(0xF3, 0x45, 0x3B),
            BackgroundColor = Colors.Transparent,
            IsVisible = false
        };
        innerGrid.Children.Add(innerClickedLabel);

        innerImageButtonClicked.SetBinding(ImageButton.SourceProperty, new Binding(nameof(ClickedImageSource), source: this));
        innerImageButtonClicked.SetBinding(ImageButton.AspectProperty, new Binding(nameof(ImageAspect), source: this));
        innerClickedLabel.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
        innerClickedLabel.SetBinding(Label.MarginProperty, new Binding(nameof(ClickedTextMargin), source: this));
        innerClickedLabel.SetBinding(Label.FontSizeProperty, new Binding(nameof(FontSize), source: this));

#endif



    }

    private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
    {
        Press();
        await Task.Run(() => Thread.Sleep(300));
        await Release();
    }

    private void Press()
    {
        if (ClickedImageSource != null && IsEnabled)
        {

#if WINDOWS
            innerImageButton.IsVisible=false;
            innerLabel.IsVisible=false;
            innerImageButtonClicked.IsVisible=true;
            innerClickedLabel.IsVisible=true;
#else
            innerImageButton.Source = ClickedImageSource;
            innerLabel.Margin = ClickedTextMargin;
#endif
        }
    }

    private async Task Release()
    {


#if WINDOWS
        innerImageButtonClicked.IsVisible=false;
        innerImageButton.IsVisible=true;
        innerClickedLabel.IsVisible=false;
        innerLabel.IsVisible=true;
#else
          innerImageButton.Source = ImageSource;
        innerLabel.Margin = TextMargin;
#endif

        Clicked?.Invoke(this, EventArgs.Empty);

        if (Command != null && 
            ((Command is IAsyncRelayCommand) || Command.CanExecute(CommandParameter) ))//not check method CanExecute for IAsyncRelayCommand:fix bug in AsyncRelayCommand.CanExecute(return false) when make fast click on two different buttons
        {
           await ((App)Application.Current).PlayerService.PlayClickSound();
            if (Command is IAsyncRelayCommand relayAsyncCommand)
                await relayAsyncCommand.ExecuteAsync(CommandParameter);
            else
                Command.Execute(CommandParameter);

        }
    }

    public event EventHandler Clicked;

    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(ImageTextButton));

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public static readonly BindableProperty ImageAspectProperty =
        BindableProperty.Create("ImageAspect", typeof(Aspect), typeof(ImageTextButton), default(Aspect));

    public Aspect ImageAspect
    {
        get => (Aspect)GetValue(ImageAspectProperty);
        set => SetValue(ImageAspectProperty, value);
    }

    public static readonly BindableProperty ClickedImageSourceProperty =
        BindableProperty.Create("ClickedImageSource", typeof(ImageSource), typeof(ImageTextButton));

    public ImageSource ClickedImageSource
    {
        get => (ImageSource)GetValue(ClickedImageSourceProperty);
        set => SetValue(ClickedImageSourceProperty, value);
    }

    public static readonly BindableProperty TextProperty =
          BindableProperty.Create("Text", typeof(string), typeof(ImageTextButton));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty TextMarginProperty =
          BindableProperty.Create(nameof(TextMargin), typeof(Thickness), typeof(ImageTextButton));

    public Thickness TextMargin
    {
        get => (Thickness)GetValue(TextMarginProperty);
        set => SetValue(TextMarginProperty, value);
    }


    public static readonly BindableProperty ClickedTextMarginProperty =
         BindableProperty.Create(nameof(ClickedTextMargin), typeof(Thickness), typeof(ImageTextButton));

    public Thickness ClickedTextMargin
    {
        get => (Thickness)GetValue(ClickedTextMarginProperty);
        set => SetValue(ClickedTextMarginProperty, value);
    }

    public static readonly BindableProperty FontSizeProperty =
          BindableProperty.Create("FontSize", typeof(double), typeof(ImageTextButton), 16.0);

    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty =
      BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ImageTextButton));

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public static readonly BindableProperty CommandProperty =
      BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ImageTextButton));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
}