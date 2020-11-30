using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Change BackColor, 
/// FlatAppearance.BorderColor, 
/// FlatAppearance.MouseDownBackColor, 
/// FlatAppearance.MouseOverBackColor
/// to be equal to the color of the backgroud!!!!!!
/// </summary>

namespace ePOSOne.btnProduct
{
    public class RoundButton : Button
    {
        private Color _borderColor = Color.Silver;
        private Color _onHoverBorderColor = Color.Gray;
        private Color _onDownBorderColor = Color.Yellow;
        private Color _buttonColor = Color.Red;
        private Color _onHoverButtonColor = Color.Yellow;
        private Color _onDownButtonColor = Color.Orange;
        private Color _textColor = Color.White;
        private Color _onHoverTextColor = Color.Gray;
        private Color _onDownTextColor = Color.Black;

        private int _borderThickness = 4;
        private int _borderThicknessByTwo = 2;

        private bool _isDown = false;
        private bool _isHovering;


        public RoundButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            if (this.Focus() == true)
            {
                this.Text = "Focused";
            }

            DoubleBuffered = true;

            MouseDown += (sender, e) =>
            {
                _isHovering = true;
                _isDown = true;
                Invalidate();
            };
            MouseUp += (sender, e) =>
            {
                _isHovering = true;
                _isDown = false;
                Invalidate();
            };
            MouseEnter += (sender, e) =>
            {
                _isHovering = true;
                _isDown = false;
                Invalidate();
            };
            MouseLeave += (sender, e) =>
            {
                _isHovering = false;
                _isDown = false;
                Invalidate();
            };
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Brush brush;
            if (_isHovering == true && _isDown == true)
            {
                brush = new SolidBrush(_onDownBorderColor);
            }
            else if (_isHovering == true && _isDown == false)
            {
                brush = new SolidBrush(_onHoverBorderColor);
            }
            else 
            {
                brush = new SolidBrush(_borderColor);
            }
            //Brush brush = new SolidBrush(_isHovering ? _onHoverBorderColor : _borderColor);

            //Border
            g.FillEllipse(brush, 0, 0, Height, Height);
            g.FillEllipse(brush, Width - Height, 0, Height, Height);
            g.FillRectangle(brush, Height / 2, 0, Width - Height, Height);

            brush.Dispose();

            if (_isHovering == true && _isDown == true)
            {
                brush = new SolidBrush(_onDownButtonColor);
            }
            else if (_isHovering == true && _isDown == false)
            {
                brush = new SolidBrush(_onHoverButtonColor);
            }
            else
            {
                brush = new SolidBrush(_buttonColor);
            }
            //brush = new SolidBrush(_isHovering ? _onHoverButtonColor : _buttonColor);

            //Inner part. Button itself
            g.FillEllipse(brush, _borderThicknessByTwo, _borderThicknessByTwo, Height - _borderThickness,
                Height - _borderThickness);
            g.FillEllipse(brush, (Width - Height) + _borderThicknessByTwo, _borderThicknessByTwo,
                Height - _borderThickness, Height - _borderThickness);
            g.FillRectangle(brush, Height / 2 + _borderThicknessByTwo, _borderThicknessByTwo,
                Width - Height - _borderThickness, Height - _borderThickness);

            brush.Dispose();

            if (_isHovering == true && _isDown == true)
            {
                brush = new SolidBrush(_onDownTextColor);
            }
            else if (_isHovering == true && _isDown == false)
            {
                brush = new SolidBrush(_onHoverTextColor);
            }
            else
            {
                brush = new SolidBrush(_textColor);
            }
            //brush = new SolidBrush(_isHovering ? _onHoverTextColor : _textColor);

            //Button Text
            SizeF stringSize = g.MeasureString(Text, Font);
            g.DrawString(Text, Font, brush, (Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2);
        }


        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public Color OnHoverBorderColor
        {
            get => _onHoverBorderColor;
            set
            {
                _onHoverBorderColor = value;
                Invalidate();
            }
        }

        public Color OnDownBorderColor
        {
            get => _onDownBorderColor;
            set
            {
                _onDownBorderColor = value;
                Invalidate();
            }
        }

        public Color ButtonColor
        {
            get => _buttonColor;
            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }

        public Color OnHoverButtonColor
        {
            get => _onHoverButtonColor;
            set
            {
                _onHoverButtonColor = value;
                Invalidate();
            }
        }

        public Color OnDownButtonColor
        {
            get => _onDownButtonColor;
            set
            {
                _onDownButtonColor = value;
                Invalidate();
            }
        }

        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        public Color OnHoverTextColor
        {
            get => _onHoverTextColor;
            set
            {
                _onHoverTextColor = value;
                Invalidate();
            }
        }

        public Color OnDownTextColor
        {
            get => _onDownTextColor;
            set
            {
                _onDownTextColor = value;
                Invalidate();
            }
        }

        public int BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                Invalidate();
            }
        }

        public int borderThicknessByTwo
        {
            get => _borderThicknessByTwo;
            set
            {
                _borderThicknessByTwo = value;
                Invalidate();
            }
        }

        //private void rbtnFocus_Enter(object sender, EventArgs e)
        //{
        //    _borderThickness = _borderThickness + 2;
        //    _borderThicknessByTwo = _borderThicknessByTwo + 2;
        //}

        //private void rbtnFocus_Leave(object sender, EventArgs e)
        //{
        //    _borderThickness = _borderThickness - 2;
        //    _borderThicknessByTwo = _borderThicknessByTwo - 2;
        //}
    }
}