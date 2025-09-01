using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reprint
{
    public partial class AlarmSetControl : UserControl
    {
        private ReprintEntities db = new ReprintEntities();

        public AlarmSetControl()
        {
            InitializeComponent();
            btnSave.Click += btnSave_Click;
            cmbDataName.SelectedIndexChanged += cmbDataName_SelectedIndexChanged;
            txtAlarmValue.TextChanged += txtAlarmValue_TextChanged;
            txtStopValue.TextChanged += txtStopValue_TextChanged;
            dgvAlarm.CellClick += dgvAlarm_CellClick;
            this.Load += AlarmSetControl_Load;
        }

        private void ShowAlarms()
        {
            dgvAlarm.Rows.Clear();
            var alarms = db.Alarm.ToList();
            foreach (var alarm in alarms)
            {
                dgvAlarm.Rows.Add(
                    alarm.DataName,
                    alarm.AlarmValue?.ToString() ?? "0",
                    alarm.StopValue?.ToString() ?? "0",
                    alarm.Unit,
                    "修改",
                    "删除"
                );
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string dataName = cmbDataName.Text;
            int alarmValue = int.TryParse(txtAlarmValue.Text, out var av) ? av : 0;
            int stopValue = int.TryParse(txtStopValue.Text, out var sv) ? sv : 0;
            string unit = txtUnit.Text;

            if (alarmValue > stopValue)
            {
                MessageBox.Show("停机值不能小于报警值！");
                return;
            }

            var alarm = db.Alarm.FirstOrDefault(a => a.DataName == dataName);
            if (alarm != null)
            {
                alarm.AlarmValue = alarmValue;
                alarm.StopValue = stopValue;
                alarm.Unit = unit;
            }
            else
            {
                db.Alarm.Add(new Alarm
                {
                    DataName = dataName,
                    AlarmValue = alarmValue,
                    StopValue = stopValue,
                    Unit = unit
                });
            }
            db.SaveChanges();
            ShowAlarms();
        }

        private void dgvAlarm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string dataName = dgvAlarm.Rows[e.RowIndex].Cells[0].Value.ToString();
            var alarm = db.Alarm.FirstOrDefault(a => a.DataName == dataName);

            if (e.ColumnIndex == 5) // 删除
            {
                if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (alarm != null)
                    {
                        db.Alarm.Remove(alarm);
                        db.SaveChanges();
                        ShowAlarms();
                    }
                }
            }
            else if (e.ColumnIndex == 4) // 修改
            {
                if (alarm != null)
                {
                    cmbDataName.Text = alarm.DataName;
                    txtUnit.Text = alarm.Unit;
                    txtAlarmValue.Text = alarm.AlarmValue?.ToString() ?? "0";
                    txtStopValue.Text = alarm.StopValue?.ToString() ?? "0";
                }
            }
        }

        private void cmbDataName_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbDataName.SelectedIndex)
            {
                case 0: txtUnit.Text = "rpm"; break;
                case 1: txtUnit.Text = "N.m"; break;
                default: txtUnit.Text = "g"; break;
            }
            txtAlarmValue.Text = "0";
            txtStopValue.Text = "0";
        }

        private void txtAlarmValue_TextChanged(object sender, EventArgs e)
        {
            if (cmbDataName.Text.Contains("转速") && int.TryParse(txtAlarmValue.Text, out int value) && value > 20000)
            {
                MessageBox.Show("转速最高限定20000rpm");
                txtAlarmValue.Text = "20000";
            }
            if (cmbDataName.Text.Contains("扭矩") && int.TryParse(txtAlarmValue.Text, out int value2) && value2 > 500)
            {
                MessageBox.Show("扭矩最高限定500N.m");
                txtAlarmValue.Text = "500";
            }
            if (cmbDataName.Text.Contains("振动") && int.TryParse(txtAlarmValue.Text, out int value3) && value3 > 10)
            {
                MessageBox.Show("振动最高限定10g");
                txtAlarmValue.Text = "10";
            }
            if (string.IsNullOrEmpty(txtAlarmValue.Text))
            {
                txtAlarmValue.Text = "0";
            }
        }

        private void txtStopValue_TextChanged(object sender, EventArgs e)
        {
            if (cmbDataName.Text.Contains("转速") && int.TryParse(txtStopValue.Text, out int value) && value > 20000)
            {
                MessageBox.Show("转速最高限定20000rpm");
                txtStopValue.Text = "20000";
            }
            if (cmbDataName.Text.Contains("扭矩") && int.TryParse(txtStopValue.Text, out int value2) && value2 > 500)
            {
                MessageBox.Show("扭矩最高限定500N.m");
                txtStopValue.Text = "500";
            }
            if (cmbDataName.Text.Contains("振动") && int.TryParse(txtStopValue.Text, out int value3) && value3 > 10)
            {
                MessageBox.Show("振动最高限定10g");
                txtStopValue.Text = "10";
            }
            if (string.IsNullOrEmpty(txtStopValue.Text))
            {
                txtStopValue.Text = "0";
            }
        }

        private void AlarmSetControl_Load(object sender, EventArgs e)
        {
            cmbDataName.Items.Clear();
            cmbDataName.Items.Add("转速");
            cmbDataName.Items.Add("扭矩");
            cmbDataName.Items.Add("振动");
            if (cmbDataName.Items.Count > 0)
                cmbDataName.SelectedIndex = 0;
            txtUnit.Text = "rpm";
            txtAlarmValue.Text = "0";
            txtStopValue.Text = "0";
            ShowAlarms();
        }
    }
}
