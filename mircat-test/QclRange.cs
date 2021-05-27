using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.MIRcatTest
{
    public class QclRange
    {
        public int ChipNum;
        public double minWn;
        public double maxWn;

        public bool Contains(double wavenumber) => (wavenumber >= MinWn) && (wavenumber <= MaxWn);
        public double CenterWn => Math.Round((minWn + maxWn) / 2, 1);
        public double MinWn => Math.Min(minWn, maxWn);
        public double MaxWn => Math.Max(minWn, maxWn);
    }
}
