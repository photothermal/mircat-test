using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.MIRcatTest
{
    class QCLChip
    {
        public int ChipNum;
        public double minWn;
        public double maxWn;

        public bool Contains(double wavenumber) => (wavenumber >= minWn) && (wavenumber <= maxWn);
        public double CenterWn => Math.Round((minWn + maxWn) / 2, 1);
    }
}
