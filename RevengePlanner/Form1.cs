using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevengePlanner
{
    public partial class Form1 : Form
    {
        static RevengeList db;
        string filename = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void BuildAllAndCreateDb()
        {
            dt_datetime.DataBindings.Clear();
            tb_name.DataBindings.Clear();
            tb_plan.DataBindings.Clear();
            db = new RevengeList();
            tss_guid.Text = db.Guid.ToString();
            bindnav.BindingSource = new BindingSource();
            bindnav.BindingSource.DataSource = db;
            bindnav.BindingSource.DataMember = "List";
            dt_datetime.DataBindings.Add("Text", bindnav.BindingSource, "DateTime");
            tb_name.DataBindings.Add("Text", bindnav.BindingSource, "Name");
            tb_plan.DataBindings.Add("Text", bindnav.BindingSource, "Text");
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void Create_Click(object sender, EventArgs e)
        {
            BuildAllAndCreateDb();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "XML файлы|*.xml|Все файлы|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BuildAllAndCreateDb();
                db.Load(ofd.FileName);
                filename = ofd.FileName;
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "XML файлы|*.xml|Все файлы|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                db.Save(sfd.FileName);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (filename == string.Empty)
                SaveAs_Click(sender, e);
            else
                db.Save(filename);
        }
    }
}