using Reprint;
using Reprint.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reprint
{
    public partial class DefineChannelControl : UserControl
    {
        private CommonBLL commonBll = new CommonBLL();
        public DefineChannelControl()
    {
         InitializeComponent();
            btnSave.Click += btnSave_Click;
            dgvChannel.CellClick += dgvChannel_CellClick;
            this.Load += DefineChannelControl_Load;
            txtChannelCode.SelectedIndexChanged += txtChannelCode_SelectedIndexChanged;
            txtMax.KeyPress += commonBll.InputFloatOrNeg_KeyPress;
         txtMin.KeyPress += commonBll.InputFloatOrNeg_KeyPress;
    }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double max = 0.0, min = 0.0, readMax = 63355.0, readMin = 0.0;

            if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtUnit.Text.Trim()))
            {
                MessageBox.Show("参数名和单位不能为空");
                return;
            }
            try
            {
                max = Convert.ToDouble(txtMax.Text.Trim());
                min = Convert.ToDouble(txtMin.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("最大最小值输入了非法字符");
                return;
            }
            if (max <= min)
            {
                MessageBox.Show("最大值不能小于等于最小值");
                return;
            }
            double k = Math.Round((max - min) / (readMax - readMin), 5);
            double b = Math.Round(min - k * readMin, 5);

            DefineChannal defineChannel = new DefineChannal()
            {
                ChannelCode = txtChannelCode.Text,
                DataName = txtName.Text.Trim(),
                Uint = txtUnit.Text.Trim(),
                Max = max,
                Min = min,
                Ratio = k,
                Address = txtChannelCode.SelectedIndex,
                Offset = b
};
            if (commonBll.sdEntities.DefineChannal.Where(a => a.DataName == defineChannel.DataName).Any())
            {
                MessageBox.Show("参数名已经存在");
                return;
            }

            var defineChannals = commonBll.sdEntities.DefineChannal.Where(a => a.ChannelCode == defineChannel.ChannelCode).ToList();
            if (defineChannals.Count > 0)
            {
                defineChannel.Id = defineChannals.First().Id;
                commonBll.sdEntities.DefineChannal.AddOrUpdate(defineChannel);
            }
            else
            {
                commonBll.sdEntities.DefineChannal.Add(defineChannel);
            }
            commonBll.sdEntities.SaveChanges();
            Show();
        }
        private void Show()
        {
            var defineChannels = commonBll.sdEntities.DefineChannal.ToList();
            dgvChannel.Rows.Clear();
            foreach (var defineChannel in defineChannels)
            {
                dgvChannel.Rows.Add(new[] {
            defineChannel.ChannelCode,
            defineChannel.DataName,
            defineChannel.Uint,
            defineChannel.Max.ToString(),
            defineChannel.Min.ToString()
        });
            }
        }
        private void dgvChannel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                string channelCode = dgvChannel.Rows[e.RowIndex].Cells[0].Value.ToString();
                var defineChannels = commonBll.sdEntities.DefineChannal.Where(a => a.ChannelCode == channelCode).ToList();
                if (defineChannels.Count <= 0)
                    return;
                commonBll.sdEntities.DefineChannal.Remove(defineChannels[0]);
                commonBll.sdEntities.SaveChanges();
                Show();
            }
        }
        private void DefineChannelControl_Load(object sender, EventArgs e)
        {
            LoadChannelCodes();
            Show();

            // 居中内容Panel
            CenterContentPanel();
            this.SizeChanged += (s, args) => CenterContentPanel();
        }

        private void CenterContentPanel()
        {
            if (panel1 != null)
            {
                panel1.Left = (this.Width - panel1.Width) / 2;
                panel1.Top = (this.Height - panel1.Height) / 2;
            }
        }

        private void LoadChannelCodes()
        {
            txtChannelCode.Items.Clear();
            var channelCodes = commonBll.sdEntities.DefineChannal.Select(c => c.ChannelCode).ToList();
            foreach (var code in channelCodes)
            {
                txtChannelCode.Items.Add(code);
            }
            if (txtChannelCode.Items.Count > 0)
                txtChannelCode.SelectedIndex = 0;
        }

        private void InitializeChannel()
        {
            var defineChannels = new List<DefineChannal>();
            for (int i = 0; i < txtChannelCode.Items.Count; i++)
            {
                defineChannels.Add(new DefineChannal()
                {
                    ChannelCode = txtChannelCode.Items[i].ToString(),
                    DataName = "未定义" + (i + 1),
                    Uint = "",
                    Max = 0,
                    Min = 0,
                    Ratio = 0,
                    Address = 0,
                    Offset = 0
                });
            }
            foreach (var channel in defineChannels)
            {
                if (!commonBll.sdEntities.DefineChannal.Any(a => a.ChannelCode == channel.ChannelCode))
                {
                    commonBll.sdEntities.DefineChannal.Add(channel);
                }
            }
            commonBll.sdEntities.SaveChanges();
            Show();
        }

        private void txtChannelCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCode = txtChannelCode.Text;
            var channel = commonBll.sdEntities.DefineChannal.FirstOrDefault(c => c.ChannelCode == selectedCode);
            if (channel != null)
            {
                txtName.Text = channel.DataName;
                txtUnit.Text = channel.Uint;
                txtMax.Text = channel.Max.ToString();
                txtMin.Text = channel.Min.ToString();
                // 如有其他字段可继续补充
            }
        }
    }
}
