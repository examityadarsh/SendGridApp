using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
using System.Configuration;


namespace SendGridApp
{
    public partial class StartPage : Form
    {
        String connString = null;
        SqlConnection sqlConnection;
        DataTable tblDatabases = null;
        [Obsolete]
        public StartPage()
        {
            InitializeComponent();
            FillDBType();
            TxtServer.Text = ConfigurationSettings.AppSettings.Get("SourceSERVER").ToString(); //"172.25.16.39";
            TxtUsername.Text = "Core";
            TxtPassword.Text = "C0r35ql";
        }

        private void FillDBType()
        {
            List<string> myInts = new List<string>();

            myInts.Add("SQL");
            myInts.Add("MySQL");
            //myInts.Add("Oracle");

            for (int i = 0; i < myInts.Count; i++)
            {
                CMBDBType.Items.Add(myInts[i]);

            }

            CMBDBType.SelectedIndex = 0;

        }

        private void BtnCloseWindow_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Thank you! Bye...");
            StartPage.ActiveForm.Close();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
           
            string SELITEM = "NO";
            try
            {
                if (CMBDBType.SelectedItem.Equals("SQL"))
                {
                    connString = "Data Source=" + TxtServer.Text + "; User ID=" + TxtUsername.Text + ";Password=" + TxtPassword.Text + ";";
                    using (SqlConnection sqlConx = new SqlConnection(connString))
                    {
                        sqlConx.Open();
                        tblDatabases = sqlConx.GetSchema("Databases");
                        sqlConx.Close();
                        SELITEM = "OK";
                    }
                }

                if (SELITEM == "OK")
                {
                    MessageBox.Show("Select the Database");
                    CMBMyDB.Focus();

                    CMBMyDB.Items.Clear();
                    foreach (DataRow row in tblDatabases.Rows)
                    {
                        CMBMyDB.Items.Add(row["database_name"]);
                    }
                    CMBMyDB.Text = "Examity_Prod_";
                }
                else
                {
                    MessageBox.Show("UserName/Password/Server not matching.Please check if capslock is on.");
                }
                CMBMyDB.Items.Add("NewDB");

            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.ToString() + "\\n UserName/Password/Server not matching.Please check if capslock is on.");
            }
        }

        private void CMBDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtServer.Text = null;
            TxtUsername.Text = null;
            TxtPassword.Text = null;
            CMBMyDB.Text = null;
            CMBMyDB.Items.Clear();
            lblcreatedb.Visible = false;
            TxtNewDB.Text = null;
            TxtNewDB.Visible = false;
        }

        [Obsolete]
        private void BtnCreateConnection_Click(object sender, EventArgs e)
        {
            connString = "Data Source=" + TxtServer.Text + "; User ID=" + TxtUsername.Text + ";Password=" + TxtPassword.Text + ";";
            ConfigurationSettings.AppSettings.Set("Connstring", string.Empty);
            connString = connString + " Initial Catalog= " + CMBMyDB.SelectedItem.ToString();
            ConfigurationSettings.AppSettings.Set("Connstring", connString);
            ConfigurationSettings.AppSettings.Set("DBType", CMBDBType.SelectedItem.ToString());
            ConfigurationSettings.AppSettings.Set("DBName", CMBMyDB.SelectedItem.ToString());

            StringBuilder AddEmailQueue = new StringBuilder();
            AddEmailQueue.Append("Create or Alter Procedure USP_AddToEmailQueue(");
            AddEmailQueue.AppendLine("@TO nvarchar(2000),");
            AddEmailQueue.AppendLine("@CC nvarchar(2000) null,");
            AddEmailQueue.AppendLine("@BCC nvarchar(2000) null,");
            AddEmailQueue.AppendLine("@Subject nvarchar(2000),");
            AddEmailQueue.AppendLine("@Details nvarchar(max),");
            AddEmailQueue.AppendLine("@StatusId int,");
            AddEmailQueue.AppendLine("@Comments nvarchar(max)");
            AddEmailQueue.AppendLine(")");
            AddEmailQueue.AppendLine("AS");
            AddEmailQueue.AppendLine("Begin");
            AddEmailQueue.AppendLine("SET NOCOUNT ON;");
            AddEmailQueue.AppendLine("Declare @ClientName varchar(300) ,@ClientId Int");
            AddEmailQueue.AppendLine("select @ClientID = Portal.ClientId, @ClientName = Portal.Clientname from[examityportal].[dbo].tblclients as Portal inner join tblclientdetails as ClientData on Portal.ClientName = ClientData.ClientName order by Portal.clientname asc");
            AddEmailQueue.AppendLine("INSERT INTO [Examity_Common].dbo.[tblEmailQueue](ClientId, ClientName,[To], Cc, Bcc, Subject, Details, StatusId, Comments, AddedOn, MailSentOn)");
            AddEmailQueue.AppendLine("VALUES(@ClientID, @ClientName, @TO, @CC, @BCC, @Subject, @Details, @StatusId, @Comments, GETUTCDATE(), GetUTCdate())");
            AddEmailQueue.AppendLine("End");


            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = connString;
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(AddEmailQueue.ToString(), sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                sqlConnection.Close();
            }

            MainPage M = new MainPage();
            M.Show();
        }

        private void CMBMyDB_TabIndexChanged(object sender, EventArgs e)
        {
            if (sqlConnection != null) { sqlConnection.Close(); }
            ConfigurationSettings.AppSettings.Set("DBName", string.Empty);
            ConfigurationSettings.AppSettings.Set("Connstring", string.Empty);
            ConfigurationSettings.AppSettings.Set("DBName", CMBMyDB.SelectedItem.ToString());
        }
    }
}
