using Reprint.Module;
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
    public partial class ReadTestInfoForm : Form
    {
        public ReadTestInfoForm()
        {
            InitializeComponent();
        }
        public int type;
        public TestControl testContro;
        public DataManageControl dataManageControl;
        CommonBLL commonBll = new CommonBLL();

        List<TestInfo> testInfos = new List<TestInfo>();
        private int dgvShowCount = 20;
        private void btnSearchTest_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                MessageBox.Show("结束日期不能小于起始日期", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (testInfos == null || testInfos.Count <= 0)
            {
                MessageBox.Show("目前没有实验信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nowTestInfos = testInfos.Where(a => Convert.ToDateTime(a.Time) <= dateTimePicker2.Value && Convert.ToDateTime(a.Time) >= dateTimePicker1.Value).ToList();

            if (nowTestInfos == null || nowTestInfos.Count <= 0)
            {
                MessageBox.Show("没有查询到实验信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DgvShow();
        }

        private void ReadTestInfoForm_Load(object sender, EventArgs e)
        {
            testInfos = commonBll.sdEntities.TestInfo.ToList();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            if (testDataGrid.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择实验", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string testCodeStr = testDataGrid.SelectedRows[0].Cells[1].Value.ToString();
            if (type == 0)
            {
                testContro.realTestInfo =
              commonBll.sdEntities.TestInfo.Where(a => a.TestCode == testCodeStr).ToList()[0];
                testContro.ReflashTestInfo();
            }
            if (type == 1)
            {
                dataManageControl.realTestInfo =
              commonBll.sdEntities.TestInfo.Where(a => a.TestCode == testCodeStr).ToList()[0];
                dataManageControl.ReflashTestInfo();
            }

            this.Close();
        }

        private int dgvAllPageCount = 0;
        private int dgvPageIndex = 0;
        List<TestInfo> nowTestInfos = new List<TestInfo>();
        /// <summary>
        /// 显示试验页面
        /// </summary>
        private void DgvShow()
        {
            if (nowTestInfos == null || nowTestInfos.Count <= 0)
            {
                return;
            }

            int int1 = nowTestInfos.Count % dgvShowCount;
            if (int1 > 0)
            {
                dgvAllPageCount = nowTestInfos.Count / dgvShowCount + 1;
            }
            else
            {
                dgvAllPageCount = nowTestInfos.Count / dgvShowCount;
            }
            if (dgvAllPageCount > 0)
            {
                dgvPageIndex = 1;
            }
            //总的页码数
            txtProductAllPage.Text = dgvAllPageCount.ToString();
            //当前页码数量
            txtProductPageIndex.Text = dgvPageIndex.ToString();
            DgvShowData();
        }

        private void DgvShowData()
        {
            if (nowTestInfos == null || nowTestInfos.Count <= 0 || dgvPageIndex <= 0)
            {
                return;
            }

            if (dgvPageIndex < dgvAllPageCount)
            {
                testDataGrid.Rows.Clear();
                for (int i = (dgvPageIndex - 1) * dgvShowCount; i < dgvPageIndex * dgvShowCount; i++)
                {
                    string[] strs = new string[] { nowTestInfos[i].TestName, nowTestInfos[i].TestCode, nowTestInfos[i].UserName, nowTestInfos[i].Time };
                    testDataGrid.Rows.Add(strs);

                }
            }
            if (dgvPageIndex == dgvAllPageCount)
            {
                testDataGrid.Rows.Clear();
                for (int i = (dgvPageIndex - 1) * dgvShowCount; i < nowTestInfos.Count; i++)
                {
                    string[] strs = new string[] { nowTestInfos[i].TestName, nowTestInfos[i].TestCode, nowTestInfos[i].UserName, nowTestInfos[i].Time };
                    testDataGrid.Rows.Add(strs);
                }
            }
        }
        private void btnProductGoto_Click(object sender, EventArgs e)
        {

            if (int.Parse(txtProductSetPage.Text) > dgvAllPageCount)
            {
                MessageBox.Show("输入的调整页码不能大于总页码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvPageIndex = int.Parse(txtProductSetPage.Text);
            //当前页码数量
            txtProductPageIndex.Text = dgvPageIndex.ToString();
            DgvShowData();
        }
    }
}
