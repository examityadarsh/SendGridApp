using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendGridApp
{
    public partial class Migration : Form
    {
        string connString = string.Empty;
        string destconnString = string.Empty;
        StringBuilder sptext = new System.Text.StringBuilder();
        StringBuilder completestatement = new System.Text.StringBuilder();
        DataTable desttable = new DataTable();
        string server = "10.223.81.0";//"172.25.16.39";
        string username = "Core";
        string Password = "C0r35ql";

        string destserver = "10.223.81.0";// "172.25.16.182";
        string destusername = "Core";
        string destpwd = "C0r35ql";
        public Migration()
        {
            InitializeComponent();
            label5.Visible = true;
            try
            {
                //step 1 get the production database db list
                BindDatabasefromSource();
                //step 2 on selection of db pull the scripts list
                //step 3 onclick of next button 
                //step 4 pull the scripts and generate in destination server
                //step 5 select the sp name
                //step 6 click on modify the scripts
            }
            catch (Exception ex)
            {
                label5.Text = ex.ToString();
            }
        }

        private void BindDatabasefromSource()
        {

            connString = "Data Source=" + server + "; User ID=" + username + ";Password=" + Password + ";";
            DataTable tblDatabases = null;
            using (SqlConnection sqlConx = new SqlConnection(connString))
            {
                sqlConx.Open();
                tblDatabases = sqlConx.GetSchema("Databases");
                sqlConx.Close();

            }
            foreach (DataRow row in tblDatabases.Rows)
            {
                if (row["database_name"].ToString().Contains("Examity"))
                    listBox1.Items.Add(row["database_name"]);
            }
        }

        private void FillSPs()
        {
            label3.Visible = true;
            chkSPlist.Visible = true;
            chkSPlist.Items.Clear();
            try
            {
                DataTable dtable = new DataTable();
                //get all teh sps from teh db
                //SELECT Name FROM sys.procedures
                connString = connString + " Initial Catalog= " + listBox1.SelectedItem.ToString();
                //string query = "SELECT Name FROM sys.procedures order by name asc";
                string query = "sELECT name FROM sys.sql_modules m INNER JOIN sys.objects o " +
                    "ON o.object_id = m.object_id WHERE m.definition like '%msdb.dbo.sp_send_dbmail%' " +
                    "order by name asc";

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dtable);
                conn.Close();
                da.Dispose();

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    chkSPlist.Items.Add(dtable.Rows[i]["Name"].ToString());
                    chkSPlist.SetSelected(i, true);
                    chkSPlist.SelectedIndex = i;
                    chkSPlist.SelectedItem = true;

                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillSPs();
            }
            catch (Exception ex)
            {

                label5.Text = ex.ToString();
            }
        }

        private void chkSPlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkSPlist.CheckedItems.Count > 0)
            {
                button1.Visible = true;
            }
            else button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in chkSPlist.CheckedItems)
                {
                    using (SqlConnection sqlConnection = new SqlConnection())
                    {
                        sqlConnection.ConnectionString = connString;
                        sqlConnection.Open();
                        SqlCommand sqlCommand = new SqlCommand("sys.sp_helptext", sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@objname", item);
                        DataSet ds = new DataSet();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.Fill(ds);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            sptext.AppendLine(dr[0].ToString());
                        }
                    }
                    if (sptext.ToString().Trim().Length > 0)
                    { Dataload(); sptext.Clear(); sptext.Length = 0; }

                }
                BindDestinationCheckBox(desttable);
            }
            catch (Exception ex)
            {
                label5.Visible = true;
                label5.Text = ex.ToString();
            }
        }

        private void Dataload()
        {

            destconnString = "Data Source=" + destserver + "; User ID=" + destusername + ";Password=" + destpwd + ";Initial Catalog=TestDB";
            ///string destconnString = "Data Source=" + destserver + "; User ID=" + destusername + ";Password=" + destpwd + ";Initial Catalog=" + listBox1.SelectedItem.ToString() + ";";

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = destconnString;
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sptext.ToString(), sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.ExecuteNonQuery();
            }


        }

        private void BindDestinationCheckBox(DataTable desttable)
        {
            panel2.Visible = true; label4.Visible = true;
            string query = "SELECT name FROM sys.procedures";
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = destconnString;

                SqlCommand sqlCommand = new SqlCommand(query.ToString(), sqlConnection);
                sqlConnection.Open();
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                // this will query your database and return the result to your datatable
                da.Fill(desttable);

                da.Dispose();

                for (int i = 0; i < desttable.Rows.Count; i++)
                {
                    checkedListBox2.Items.Add(desttable.Rows[i]["Name"].ToString());
                    //checkedListBox2.SetSelected(i, true);
                }
                sqlCommand.Dispose();
            }
        }
    }
}
