using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel;
using Data;

namespace AppTracker
{
    public partial class FormPosition : Form
    {
      //  Position _position = new Position();
        List<Period> _periods = new List<Period>();

        public FormPosition(Position newPosition)
        {
            InitializeComponent();
            DataBinding = newPosition;
        }

        public Position DataBinding { get; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataBinding.Position1 = this.textBoxPosition.Text;
            DataBinding.Company = this.textBoxCompany.Text;
            DataBinding.Location = this.textBoxLocation.Text;
            DataBinding.DateApplied = this.dateApplied.Value;
            DataBinding.Contact = this.textBoxContact.Text;
            DataBinding.Description = this.textBoxDescription.Text;
            DataBinding.URL = this.textBoxURL.Text;
            DataBinding.Period = comboPeriod.SelectedItem as Period;
        }

        private void FormPosition_Load(object sender, EventArgs e)
        {
            // set up combobox list
            _periods = Data.PeriodMethods.SelectPeriods();

            foreach (Period p in _periods)
            {
                comboPeriod.Items.Add(p);
            }

            comboPeriod.SelectedIndex = 0;

            // setup form contents
            this.textBoxPosition.Text = DataBinding.Position1;
            this.textBoxCompany.Text = DataBinding.Company;
            this.textBoxLocation.Text = DataBinding.Location;
            this.dateApplied.Value = DataBinding.DateApplied;
            this.textBoxContact.Text = DataBinding.Contact;
            this.textBoxDescription.Text = DataBinding.Description;
            this.textBoxURL.Text = DataBinding.URL;
            comboPeriod.SelectedItem = DataBinding.Period;
        }
    }
}
