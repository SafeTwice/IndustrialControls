using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IndustrialControls
{
    public class ImageCheckBox : CheckBox
    {
        #region Dependency Properties

        public static readonly DependencyProperty CheckedImageSourceProperty =
        DependencyProperty.Register( nameof( CheckedImageSource ), typeof( ImageSource ), typeof( ImageCheckBox ),
            new FrameworkPropertyMetadata( null, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public ImageSource CheckedImageSource
        {
            get { return (ImageSource) GetValue( CheckedImageSourceProperty ); }
            set { SetValue( CheckedImageSourceProperty, value ); }
        }

        public static readonly DependencyProperty UncheckedImageSourceProperty =
            DependencyProperty.Register( nameof( UncheckedImageSource ), typeof( ImageSource ), typeof( ImageCheckBox ),
                new FrameworkPropertyMetadata( null, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public ImageSource UncheckedImageSource
        {
            get { return (ImageSource) GetValue( UncheckedImageSourceProperty ); }
            set { SetValue( UncheckedImageSourceProperty, value ); }
        }

        public static readonly DependencyProperty DisabledImageSourceProperty =
            DependencyProperty.Register( nameof( DisabledImageSource ), typeof( ImageSource ), typeof( ImageCheckBox ),
                new FrameworkPropertyMetadata( null, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public ImageSource DisabledImageSource
        {
            get { return (ImageSource) GetValue( DisabledImageSourceProperty ); }
            set { SetValue( DisabledImageSourceProperty, value ); }
        }

        public static readonly DependencyProperty ImageStretchProperty =
            DependencyProperty.Register( nameof( ImageStretch ), typeof( Stretch ), typeof( ImageCheckBox ),
                new FrameworkPropertyMetadata( Stretch.Uniform, FrameworkPropertyMetadataOptions.AffectsRender ) );

        public Stretch ImageStretch
        {
            get { return (Stretch) GetValue( ImageStretchProperty ); }
            set { SetValue( ImageStretchProperty, value ); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register( nameof( IsReadOnly ), typeof( bool ), typeof( ImageCheckBox ),
                new FrameworkPropertyMetadata( false, FrameworkPropertyMetadataOptions.None, OnReadOnlyChanged ) );

        public bool IsReadOnly
        {
            get { return (bool) GetValue( IsReadOnlyProperty ); }
            set { SetValue( IsReadOnlyProperty, value ); }
        }

        #endregion

        static ImageCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata( typeof( ImageCheckBox ),
                new FrameworkPropertyMetadata( typeof( ImageCheckBox ) ) );
            IsHitTestVisibleProperty.OverrideMetadata( typeof( ImageCheckBox ),
                new FrameworkPropertyMetadata( true, null, CoerceIsHitTestVisibleAndFocusable ) );
            FocusableProperty.OverrideMetadata( typeof( ImageCheckBox ),
                new FrameworkPropertyMetadata( true, null, CoerceIsHitTestVisibleAndFocusable ) );
            HorizontalContentAlignmentProperty.OverrideMetadata( typeof( ImageCheckBox ),
                new FrameworkPropertyMetadata( HorizontalAlignment.Center ) );
        }

        private static void OnReadOnlyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            var thisControl = (ImageCheckBox) d;
            var isReadonly = (bool) e.NewValue;

            thisControl.IsHitTestVisible = !isReadonly;
            thisControl.Focusable = !isReadonly;
        }

        private static object CoerceIsHitTestVisibleAndFocusable( DependencyObject d, object baseValue )
        {
            var thisControl = ( ImageCheckBox ) d;
            return thisControl.IsReadOnly ? false : baseValue;
        }
    }
}
