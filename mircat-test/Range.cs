using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.MIRcatTest
{
    public class Range : ICloneable, IEquatable<Range>
    {
        #region Private fields

        private double minValue;
        private double maxValue;

        #endregion

        #region Constructors

        public Range()
        {
            this.Min = 0;
            this.Max = 0;
        }
        public Range(double min, double max)
        {
            if (double.IsNaN(min) || double.IsNaN(max))
            {
                throw new ArgumentOutOfRangeException("Wavenumber range");
            }

            this.minValue = Math.Min(min, max);
            this.maxValue = Math.Max(min, max);
        }
        public Range(Range obj)
        {
            this.Copy(obj);
        }

        #endregion

        #region Public properties

        public double Min
        {
            get
            {
                return Math.Min(this.minValue, this.maxValue);
            }
            set
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException("Range Minimum");
                }

                var oldMax = this.Max;

                if (value >= oldMax)
                {
                    this.minValue = this.maxValue = value;
                }
                else
                {
                    this.maxValue = oldMax;
                    this.minValue = value;
                }
            }
        }
        public double Max
        {
            get
            {
                return Math.Max(this.minValue, this.maxValue);
            }
            set
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException("Range Maximum");
                }

                var oldMin = this.Min;
                var oldMax = this.Max;

                if (value <= oldMin)
                {
                    this.minValue = this.maxValue = value;
                }
                else
                {
                    this.maxValue = value;
                    this.minValue = oldMin;
                }
            }
        }
        public double Center
        {
            get
            {
                return (this.minValue + this.maxValue) * 0.5D;
            }
        }
        public double Width
        {
            get
            {
                return Math.Abs(this.minValue - this.maxValue);
            }
        }

        #endregion

        #region Public API

        public bool Contains(double wn)
        {
            if (double.IsInfinity(wn) || double.IsNaN(wn))
            {
                return false;
            }

            return this.Min <= wn && wn <= this.Max;
        }

        #region Implementation of Copy

        public void Copy(Range obj)
        {
            this.minValue = obj.minValue;
            this.maxValue = obj.maxValue;
        }

        #endregion

        #endregion

        #region Implementation of ICloneable

        public object Clone()
        {
            return new Range(this);
        }

        #endregion

        #region Implementation of IEquatable

        public bool Equals(Range obj)
        {
            if (null == obj)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return this.Min.Equals(obj.Min)
                && this.Max.Equals(obj.Max);
        }

        #endregion

        #region Overrides

        public override int GetHashCode()
        {
            unchecked // overflow/wrap is fine
            {
                int hash = (int)2166136261;

                hash = hash * 16777619 ^ this.Min.GetHashCode();
                hash = hash * 16777619 ^ this.Max.GetHashCode();

                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Range);
        }
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.Min, this.Max);
        }

        #endregion
    }
}
