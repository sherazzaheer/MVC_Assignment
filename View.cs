using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WinAssignment1
{
    public partial class View : Form
    {
        #region Model Block
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["Strcon"]);
        public View()
        {
            InitializeComponent();
        }
        #endregion

        #region Container Block
        public void bindGrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Customers", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvCustomers.DataSource = ds.Tables[0];
        }
        
        public void DML(string Qry)
        {
            SqlCommand obj = new SqlCommand(Qry, con);
            con.Open();
            obj.ExecuteNonQuery();
            con.Close();
            bindGrid();
        }

        public void ctrlsFilling(DataGridViewCellEventArgs e)
        {
            txtCustID.Text = gvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCompName.Text = gvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtContName.Text = gvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtContTitle.Text = gvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = gvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtCity.Text = gvCustomers.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPostalCode.Text = gvCustomers.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPhone.Text = gvCustomers.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtRegion.Text = gvCustomers.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtCountry.Text = gvCustomers.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtFax.Text = gvCustomers.Rows[e.RowIndex].Cells[10].Value.ToString();
        }
        public void ctrlsEmpty()
        {
            txtCustID.Text = null;
            txtCompName.Text = null;
            txtContName.Text = null;
            txtContTitle.Text = null;
            txtAddress.Text = null;
            txtCity.Text = null;
            txtPostalCode.Text = null;
            txtPhone.Text = null;
            txtRegion.Text = null;
            txtCountry.Text = null;
            txtFax.Text = null;
        }
        #endregion

        #region View to Container
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Qry = "insert into Customers values('" + txtCompName.Text + "','" + txtContName.Text + "','" + txtContTitle.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtPostalCode.Text + "','" + txtPhone.Text + "','" + txtRegion.Text + "','" + txtCountry.Text + "','" + txtFax.Text + "')";
            DML(Qry);
            ctrlsEmpty();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCustID.Enabled = false;
            bindGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Qry = "delete from Customers where CustID ="+ txtCustID.Text;
            DML(Qry);
            ctrlsEmpty();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Qry = "update Customers set comName = '" + txtCompName.Text + "', contName = '" + txtContName.Text + "', contTitle = '" + txtContTitle.Text + "', adrress = '" + txtAddress.Text + "', city = '" + txtCity.Text + "', postalCode = '" + txtPostalCode.Text + "', phone = '" + txtPhone.Text + "', region = '" + txtRegion.Text + "', country = '" + txtCountry.Text + "', fax = '" + txtFax.Text + "' where custID = " + txtCustID.Text + "";
            DML(Qry);
            ctrlsEmpty();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ctrlsEmpty();
        }

        private void gvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ctrlsFilling(e);
        }
        #endregion
    }
}
