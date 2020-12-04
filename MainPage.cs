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
using System.Text.RegularExpressions;
using System.Configuration;

namespace SendGridApp
{
    public partial class MainPage : Form
    {
        #region Variable Declaration
        string dbtype = null, connString = null;
        DataTable dtable = new DataTable();
        StringBuilder sptext = new System.Text.StringBuilder();
        StringBuilder completestatement = new System.Text.StringBuilder();
        #endregion

        public MainPage()
        {
            InitializeComponent();
            System.Configuration.AppSettingsReader appreader = new System.Configuration.AppSettingsReader();
            dbtype = (string)appreader.GetValue("DBType", typeof(string));
            connString = (string)appreader.GetValue("Connstring", typeof(string));
            FillSPs();
        }

        private void FillSPs()
        {
            try
            {
                //StringBuilder query = new StringBuilder();
                //get all teh sps from teh db
                //SELECT Name FROM sys.procedures

                //string query = "SELECT Name FROM sys.procedures order by name asc";
                //query.Append("SELECT name FROM  sys.procedures WHERE  name in ('Usp_canvasdataload','Usp_canvascorrectdata',");
                //query.Append("'Usp_canvasdataloadanalytics','Usp_canvasinsertcourseadmin','USP_CanvasLogin','USP_CanvasSendMail','BlackboardDataload','blackboardsendemail','blackboarddatalog','USP_BlackboardInsertCourseAdmin',");
                //query.Append("'usp_dataload_courses','d2lsendemail','desire2learndataload','usp_d2linsertcourseadmin','usp_desiredtoelarninsertcourseadmin',");
                //query.Append("'ups_d2linsertcourseadmin','LMSDatalogCourseImportCount','Usp_canvaslogin','Usp_canvassendemail','moodlecorrectdata','moodlegetreportcontent',");
                //query.Append("'USP_MoodleInsertCourseAdmin','USP_MoodleLogin','USP_MoodleSendMail','USP_MoodleDataLoadAnalytics','USP_MoodleDataload','USP_MoodleCorrectData',");
                //query.Append("'USP_MoodleGetCourseData','SSIS_Final_Load','convertbetweentimezones')");
                string query = "sELECT name FROM sys.sql_modules m INNER JOIN sys.objects o " +
"ON o.object_id = m.object_id WHERE m.definition like '%msdb.dbo.sp_send_dbmail%' " +
"order by name asc";
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query.ToString(), conn);
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

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
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

                    //DataView dv = ds.Tables[0].DefaultView;
                    //dv.Sort = "name desc";
                    //DataTable sortedDT = dv.ToTable();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sptext.Append(dr[0].ToString());
                    }
                }
                sptext.AppendLine(Environment.NewLine);
                sptext.AppendLine("go");
                sptext.AppendLine(Environment.NewLine);
                if (sptext.ToString().Length > 0)
                {
                    lblMessage.Visible = true;
                    textBox3.Text = sptext.ToString();
                }
                else
                { textBox3.Text = string.Empty; lblMessage.Visible = false; }
            }
        }

        private void chkSPlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkSPlist.Select();
            Start.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string alltext = textBox3.Text;
                string newstr = string.Empty;
                string ip = ConfigurationSettings.AppSettings.Get("SERVER").ToString(); //"[172.25.16.39]";// ConfigurationSettings.AppSettings.Get("SERVER").ToString();
                string dbname = ConfigurationSettings.AppSettings.Get("DBName").ToString(); //"Examity_Prod_AAPC";// ConfigurationSettings.AppSettings.Get("DBName").ToString();
                string usestatement = "use " + dbname + Environment.NewLine + "go" + Environment.NewLine;

                string[] str = new string[] { "@recipients", "@cc","@blind_copy_recipients", "@subject", "@body" };
                //string[] str = new string[] { textBox1.Text };
                //alltext = alltext.ToString().Replace("create", "alter");

                string result = Regex.Replace(alltext.ToString(), "create proc", "CREATE OR ALTER PROCEDURE", RegexOptions.IgnoreCase);
                result = Regex.Replace(result.ToString(), "create procedure", "CREATE OR ALTER PROCEDURE", RegexOptions.IgnoreCase);
                result = Regex.Replace(result.ToString(), "create  proc", "CREATE OR ALTER PROCEDURE", RegexOptions.IgnoreCase);
                result = Regex.Replace(result, "Procedureedure", "Procedure", RegexOptions.IgnoreCase);
                result = result.Trim();
                //string.Replace.
                string receipients = "''";
                string cc = "''";
                string bcc = "''";
                string subject = "''";
                string body = "''";
                string result1 = "''";// alltext.ToString().Replace("create", "alter"); 
                //10.223.81.0
                foreach (string s in str)
                {
                    alltext = alltext.Trim();
                    bool regexbool = Regex.IsMatch(alltext, string.Format(@"(^|\s){0}", Regex.Escape(s)), RegexOptions.IgnoreCase);
                    if (regexbool)
                    {
                        var regex = new Regex(".*" + s + "(.*),.* ");
                        result1 = regex.Match(alltext).Groups[1].Value;
                        result1 = result1.Replace("=", String.Empty).Replace(",", string.Empty);
                        switch (s)
                        {
                            case "@recipients":
                                receipients = result1;
                                break;
                            case "@blind_copy_recipients":
                                bcc = result1;
                                break;
                            case "@subject":
                                subject = result1;
                                break;
                            case "@body":
                                body = result1;
                                break;
                            case "@cc":
                                cc = result1;
                                break;
                        }
                    }
                }
              
                result = Regex.Replace(result, "exec msdb.dbo.", @"/* Exec", RegexOptions.IgnoreCase);
                completestatement.AppendLine(string.Empty);
                completestatement.Append("EXEC USP_AddToEmailQueue ");
                completestatement.Append(receipients);
                completestatement.Append(",");

                completestatement.Append(cc);
                completestatement.Append(",");

                completestatement.Append(bcc);
                completestatement.Append(",");

                completestatement.Append(subject);
                completestatement.Append(",");


                completestatement.Append(body);
                completestatement.Append(",");
                completestatement.Append(21);
                completestatement.Append(",");
                completestatement.Append("'");

            
                textBox3.Text = Regex.Replace(result, "html", "HTML'*/" + completestatement.ToString(), RegexOptions.IgnoreCase).Trim();

                completestatement.Clear();
            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.ToString();
                MessageBox.Show(ex.ToString());

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty; textBox3.Text = string.Empty;
            sptext.Length = 0;
            chkSPlist.ClearSelected();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //using (SqlConnection sqlConnection = new SqlConnection())
            //{
            //    sqlConnection.ConnectionString = connString;
            //    sqlConnection.Open();
            //    SqlCommand sqlCommand = new SqlCommand(textBox3.Text.ToString(), sqlConnection);
            //    sqlCommand.CommandType = CommandType.Text;
            //    sqlCommand.ExecuteNonQuery();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

    public static class StringExtensions
    {
        public static string SafeReplace(this string input, string find, string replace, bool matchWholeWord)
        {
            string textToFind = matchWholeWord ? string.Format(@"\s{0}\s", find) : find;
            return Regex.Replace(input, textToFind, replace, RegexOptions.IgnoreCase);
        }
    }
}
