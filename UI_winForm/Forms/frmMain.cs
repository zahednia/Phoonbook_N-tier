using BLL.Dto;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_winForm.Forms
{
    public partial class frmMain : Form
    {
        private readonly ContactService contactService;
        public frmMain()
        {
            InitializeComponent();
            contactService = new ContactService();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;


            var listContact = contactService.GetContactLists();
            SettingGridview(listContact);

            this.Cursor = Cursors.Default;

        }

        private void SettingGridview(List<ContactListDto> listContact)
        {
            dataGridView1.DataSource = listContact;
            dataGridView1.Columns[0].HeaderText = "شناسه";
            dataGridView1.Columns[1].HeaderText = "نام";
            dataGridView1.Columns[2].HeaderText = "شماره تلفن";
            dataGridView1.Columns[3].HeaderText = "مشخصات";

            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            var listContacts = contactService.SearchContact(txtSearchKey.Text);
            SettingGridview(listContacts);
            this.Cursor = Cursors.Default;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = contactService.DeleteContact(Id);

            if (result.IsSuccess == true)
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain_Load(null, null);
            }
            else
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void ShowDetail()
        {
            var Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            frmDetailContact frmDetailContact = new frmDetailContact(Id);
            frmDetailContact.ShowDialog();
        }

        private void frmMain_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            frmAddContact frmAddContact = new frmAddContact();
            frmAddContact.ShowDialog();
            frmMain_Load(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            frmEdit frmEdit = new frmEdit(Id);
            frmEdit.ShowDialog();
            frmMain_Load(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
