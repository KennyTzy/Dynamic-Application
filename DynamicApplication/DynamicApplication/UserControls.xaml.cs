﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Npgsql;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace DynamicApplication
{
    /// <summary>
    /// Interaction logic for UserControls.xaml
    /// </summary>
    public partial class UserControls : UserControl
    {
        private static string mssqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mssqlFile";
        private static string mysqlfile = AppDomain.CurrentDomain.BaseDirectory + "\\mysqlFile";
        public static string mssqlConString, mysqlConString;
        public static SqlConnection mscon = new SqlConnection(mssqlConString);
        public static MySqlConnection mycon;
        public DataTable Dt = new DataTable();
        MainWindow main = new MainWindow();

       
        public UserControls()
        {
            InitializeComponent();
           
            MsSqlInitializeFile();
            mssqlConString = MsSqlRead();

        }
        //mssql
        /*postgre
        private static string postgrefile = AppDomain.CurrentDomain.BaseDirectory + "\\postgreFile";
        public static string postgreConString;
        public static NpgsqlConnection pgcon = new NpgsqlConnection(postgreConString);
        */

        //mssql
        public static void MsSqlInitializeFile()
        {
            if (!File.Exists(mssqlfile))
            {
                StreamWriter sw = new StreamWriter(mssqlfile);
                sw.WriteLine("");
                sw.Dispose();
                sw.Close();
            }
        }

        public static string MsSqlRead()
        {
            if (!File.Exists(mssqlfile))
            {
                return "";
            }
            StreamReader sr = new StreamReader(mssqlfile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }

        //mysql
        public static void MySqlInitializeFile()
        {
            if (!File.Exists(mysqlfile))
            {
                StreamWriter sw = new StreamWriter(mysqlfile);
                sw.WriteLine("");
                sw.Dispose();
                sw.Close();
            }
        }

        public static string MySqlRead()
        {
            if (!File.Exists(mysqlfile))
            {
                return "";
            }
            StreamReader sr = new StreamReader(mysqlfile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }

        /*postgre
        public static void PostgreInitializeFile()
        {
            if (!File.Exists(postgrefile))
            {
                StreamWriter sw = new StreamWriter(postgrefile);
                sw.WriteLine("");
                sw.Dispose();
                sw.Close();
            }
        }

        public static string PostgreRead()
        {
            if (!File.Exists(postgrefile))
            c
            StreamReader sr = new StreamReader(postgrefile);
            string str = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            return str.Trim();
        }
        */
        public void AddButton(int numParameters, string[] info, int numButtons)
        {
          
            MsSqlInitializeFile();
            mssqlConString = MsSqlRead();
            //string query = "SELECT * FROM dbo.TASK6TBL";
            //using (SqlConnection con = new SqlConnection(mssqlConString))
            //{
            //    con.Open();
            //    using (SqlCommand cmd = new SqlCommand(query, con))
            //    {
            //        SqlDataAdapter da = new SqlDataAdapter(query, con);
            //        Dt = new DataTable("Insert");
            //        da.Fill(Dt);
            //    }
            //}
 
           for(int a = 1; a <= numParameters; a++)
            {
                
                Label lblSample = new Label();
                lblSample.Content = info[a-1];
                lblSample.FontFamily = new FontFamily("Century Gothic");
                lblSample.FontSize = 13;

                TextBox txtSample = new TextBox();  
                txtSample.Width = 150;
                txtSample.FontFamily = new FontFamily("Century Gothic");
                txtSample.FontSize = 15;

                StackPanel pnl = new StackPanel();
                pnl.Children.Clear();   

                pnl.Orientation = Orientation.Horizontal;
                pnl.Margin = new Thickness(10); 

                pnl.Children.Add(lblSample);
                pnl.Children.Add(txtSample);

                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Margin = new Thickness(10);
                StackPanel pnlbtn = new StackPanel();
                pnlbtn.Children.Clear();

                pnlbtn.Orientation = Orientation.Horizontal;
                pnlbtn.Margin = new Thickness(10);

                
                if (a == numParameters && numButtons != 0)
                {
                    for (int i = 0; i < numButtons; i++)
                    {
                        
                        Button btn = new Button();
                        //btn.Tag = Convert.ToInt32(row[0]);

                        btn.Width = 75;
                        btn.Height = 40;

                        btn.Margin = new Thickness(10, 10, 10, 10);
                        btn.BorderBrush = Brushes.AliceBlue;
                        btn.BorderThickness = new Thickness(2, 2, 2, 2);
                        string p = "btn" + info[a + i].ToString();
                        string strtrim =  p.Trim();
                        btn.Name = strtrim;
                        btn.Content = info[a + i].ToString();

                        btn.FontFamily = new FontFamily("Century Gothic");
                        btn.FontSize = 15;
                        btn.FontWeight = FontWeights.UltraBold;
                        pnlbtn.Children.Add(btn);

                    }

                }
                stackPanel.Children.Add(pnl);
                stackPanel.Children.Add(pnlbtn);
            }
           
        }

    }
}
