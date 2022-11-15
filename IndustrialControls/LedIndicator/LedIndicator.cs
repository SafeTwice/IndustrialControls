using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IndustrialControls
{
    public class LedIndicator : CheckBox
    {
        #region Dependency Properties

        public static readonly DependencyProperty CheckedBrushProperty =
        DependencyProperty.Register( nameof( CheckedBrush ), typeof( Brush ), typeof( LedIndicator ),
            new FrameworkPropertyMetadata( Brushes.Green, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public Brush CheckedBrush
        {
            get { return (Brush) GetValue( CheckedBrushProperty ); }
            set { SetValue( CheckedBrushProperty, value ); }
        }

        public static readonly DependencyProperty UncheckedBrushProperty =
            DependencyProperty.Register( nameof( UncheckedBrush ), typeof( Brush ), typeof( LedIndicator ),
                new FrameworkPropertyMetadata( Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public Brush UncheckedBrush
        {
            get { return (Brush) GetValue( UncheckedBrushProperty ); }
            set { SetValue( UncheckedBrushProperty, value ); }
        }

        public static readonly DependencyProperty DisabledBrushProperty =
            DependencyProperty.Register( nameof( DisabledBrush ), typeof( Brush ), typeof( LedIndicator ),
                new FrameworkPropertyMetadata( Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public Brush DisabledBrush
        {
            get { return (Brush) GetValue( DisabledBrushProperty ); }
            set { SetValue( DisabledBrushProperty, value ); }
        }

        public static readonly DependencyProperty CheckedHighlightProperty =
        DependencyProperty.Register( nameof( CheckedHighlight ), typeof( double ), typeof( LedIndicator ),
            new FrameworkPropertyMetadata( 1.0, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public double CheckedHighlight
        {
            get { return (double) GetValue( CheckedHighlightProperty ); }
            set { SetValue( CheckedHighlightProperty, value ); }
        }

        public static readonly DependencyProperty UncheckedHighlightProperty =
            DependencyProperty.Register( nameof( UncheckedHighlight ), typeof( double ), typeof( LedIndicator ),
                new FrameworkPropertyMetadata( 0.3, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public double UncheckedHighlight
        {
            get { return (double) GetValue( UncheckedHighlightProperty ); }
            set { SetValue( UncheckedHighlightProperty, value ); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register( nameof( IsReadOnly ), typeof( bool ), typeof( LedIndicator ),
                new FrameworkPropertyMetadata( true, FrameworkPropertyMetadataOptions.None, OnReadOnlyChanged ) );

        public bool IsReadOnly
        {
            get { return (bool) GetValue( IsReadOnlyProperty ); }
            set { SetValue( IsReadOnlyProperty, value ); }
        }

        #endregion

        static LedIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata( typeof( LedIndicator ),
                new FrameworkPropertyMetadata( typeof( LedIndicator ) ) );
            IsHitTestVisibleProperty.OverrideMetadata( typeof( LedIndicator ),
                new FrameworkPropertyMetadata( false, null, CoerceIsHitTestVisibleAndFocusable ) );
            FocusableProperty.OverrideMetadata( typeof( LedIndicator ),
                new FrameworkPropertyMetadata( false, null, CoerceIsHitTestVisibleAndFocusable ) );
            HorizontalContentAlignmentProperty.OverrideMetadata( typeof( LedIndicator ),
                new FrameworkPropertyMetadata( HorizontalAlignment.Center ) );
        }

        private static void OnReadOnlyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            var ledControl = (LedIndicator) d;
            var isReadonly = (bool) e.NewValue;

            ledControl.IsHitTestVisible = !isReadonly;
            ledControl.Focusable = !isReadonly;
        }

        private static object CoerceIsHitTestVisibleAndFocusable( DependencyObject d, object baseValue )
        {
            var ledControl = ( LedIndicator ) d;
            return ledControl.IsReadOnly ? false : baseValue;
        }
    }
}
