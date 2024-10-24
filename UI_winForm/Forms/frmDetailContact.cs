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
    public partial class frmDetailContact : Form
    {

        private readonly ContactService contactService;
        private readonly int ContactId;
        public frmDetailContact(int ContactId)
        {
            InitializeComponent();
            contactService = new ContactService();
            this.ContactId = ContactId;
        }

        private void frmDetailContact_Load(object sender, EventArgs e)
        {
            var contact = contactService.GetContactDetatil(ContactId);
            if (contact.IsSuccess == false)
            {
                MessageBox.Show(contact.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblId.Text = contact.Data.Id.ToString();
            lblName.Text = contact.Data.Name;
            lblLastName.Text = contact.Data.LastName;
            lblCompany.Text = contact.Data.Company;
            lblPhoneNumber.Text = contact.Data.PhoneNumber;
            lblDescription.Text = contact.Data.Description;
            lblCreatetAt.Text = contact.Data.CreateAt.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
