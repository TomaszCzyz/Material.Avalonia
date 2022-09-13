using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Material.Dialog.Interfaces;
using Material.Dialog.ViewModels;

namespace Material.Dialog.Views
{
    public class TimePickerDialog : Window, IDialogWindowResult<DateTimePickerDialogResult>, IHasNegativeResult
    {
        private TimePickerDialogViewModel _viewModel;
        private Carousel PART_PagesRoot;
        private Grid _callerPanel1;
        private Grid _callerPanel2;
        private readonly Stack<IPointer> _pointers;
        private bool HoldingPointer => _pointers.Count >= 1;

        private void CreateCallerCells1() => CreateCallerCellsToPanel(_callerPanel1, 12, firstText: 12, decreaseShows: false);
        private void CreateCallerCells2() => CreateCallerCellsToPanel(_callerPanel2, 60, padNumbers: true);

        private void CreateCallerCellsToPanel(Grid panel, int counts, float radius = 109, int firstText = 0, bool padNumbers = false,
            bool decreaseShows = true)
        {
            var offset = (Math.PI * 2) * 0.25;
            var target = 0;

            for (var i = 0; i < counts; i++)
            {
                if (decreaseShows)
                {
                    if (target == i)
                    {
                        target += 5;
                    }
                    else
                        continue;
                }

                var r = i / (float)counts * (Math.PI * 2) - offset;
                var x = radius * Math.Cos(r);
                var y = radius * Math.Sin(r);

                var v = (i == 0 ? firstText : i);
                var text = padNumbers ? v.ToString("D2") : v.ToString();
                var cell = CreateCallerCell(x, y, text);
                panel.Children.Add(cell);
            }
        }

        private Control CreateCallerCell(double x, double y, string text)
        {
            var root = new Border()
            {
                Classes = Classes.Parse("CallerCell"),
                RenderTransform = new TranslateTransform(x, y),
                Background = SolidColorBrush.Parse("Transparent"),
                Child = new Grid() { Children = { new Border() { Name = "PointerEnterFeedback", }, new TextBlock() { Text = text } } }
            };
            return root;
        }

        public DateTimePickerDialogResult Result { get; set; }

        public TimePickerDialog()
        {
            Result = new DateTimePickerDialogResult();
            _pointers = new Stack<IPointer>();

            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif

            // Create decorations
            _callerPanel1 = this.Get<Grid>(nameof(_callerPanel1));
            _callerPanel2 = this.Get<Grid>(nameof(_callerPanel2));
        }

        public void AttachViewModel(TimePickerDialogViewModel vm)
        {
            DataContext = vm;
            _viewModel = vm;
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            PART_PagesRoot = this.Get<Carousel>("PART_PagesRoot");

            CreateCallerCells1();
            CreateCallerCells2();
        }

        public DateTimePickerDialogResult GetResult() => Result;

        public void SetNegativeResult(DialogResult result) => Result.Result = result.GetResult;

        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);

        private void CallerPanel_OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            _pointers.Push(e.Pointer);
            var panel = sender as Control;
            var pointer = e.GetPosition(panel);
            CallerPanel_OnPointerPressOrMove(panel, pointer);
        }

        private void CallerPanel_OnPointerMoved(object sender, PointerEventArgs e)
        {
            var panel = sender as Control;
            var pointer = e.GetPosition(panel);
            CallerPanel_OnPointerPressOrMove(panel, pointer);
        }

        private void CallerPanel_OnPointerPressOrMove(Control panel, Point p)
        {
            if (HoldingPointer)
            {
                var radius = panel.Bounds.Width / 2;

                var radians = Math.Atan2(p.X - radius, p.Y - radius);
                var degree = 360 - ((radians * 180 / Math.PI) + 180);
                ProcessPick(degree);
            }
        }

        private void ProcessPick(double deg)
        {
            var mul = PART_PagesRoot.SelectedIndex == 1 ? 60 : 12;

            var v = (int)Math.Round(deg / 360 * mul);

            if (v == mul)
                v = 0;

            if (PART_PagesRoot.SelectedIndex == 1)
                _viewModel.SecondField = (ushort)v;
            else
                _viewModel.FirstField = (ushort)v;
        }

        private void CallerPanel_OnPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            _pointers.Pop();

            if (!HoldingPointer)
                PART_PagesRoot.Next();
        }
    }
}
