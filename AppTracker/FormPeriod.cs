using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppTracker;
using DataModel;

namespace AppTracker
{
    public partial class FormPeriod : Form
    {
        public FormPeriod(Period newPeriod)
        {
            InitializeComponent();
            DataBinding = newPeriod;
        }

        public Period DataBinding { get; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataBinding.DateFrom = this.datePickerFrom.Value;
            DataBinding.DateTo = this.datePickerTo.Value;
        }

        private void FormPeriod_Load(object sender, EventArgs e)
        {
            datePickerFrom.Value = DataBinding.DateFrom;
            datePickerTo.Value = DataBinding.DateTo;
        }
    }
}
