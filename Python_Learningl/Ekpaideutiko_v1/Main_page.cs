using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Ekpaideutiko_v1
{
    public partial class Main_page : Form
    {
        OleDbConnection connection = new OleDbConnection();
        int seconds = 0;
        int minutes = 0;
        string time;
		string[] category = new string[12];
		int question_number = 1;
        int current_mode = 1;
        int current_level = 1;
        string level = "easy";
        String query;
        string username;
        public Main_page(string name,string time,int id)
        {
            username = name;
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database2.accdb";
            quiz_panel.Visible = false;
            My_Scores_panel.Visible = false;
            Theory_panel.Visible = false;
            About_panel.Visible = false;
            // using view.details because it shows our columns in the ListView!
            ColumnHeader header1,header2,header3,header4,header5, header6, header7, header8;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            header3 = new ColumnHeader();
            header4 = new ColumnHeader();
			header5 = new ColumnHeader();
			header6 = new ColumnHeader();
			header7 = new ColumnHeader();
			header8 = new ColumnHeader();
			header1.Text = "Username";
            header2.Text = "Score";
            header3.Text = "Submit Date";
            header4.Text = "Time of quiz";
			header5.Text = "Theory Success rate";
			header6.Text = "Syntax Success rate";
			header7.Text = "Logic Success rate";
			header8.Text = "Typograhpic Success rate";
			header1.Width = 100;
            header2.Width = 70;
            header3.Width = 185;
            header4.Width = 120;
			header5.Width = 180;
			header6.Width = 180;
			header7.Width = 180;
			header8.Width = 230;
			listView1.Columns.Add(header1);
            listView1.Columns.Add(header2);
            listView1.Columns.Add(header3);
            listView1.Columns.Add(header4);
			listView1.Columns.Add(header5);
			listView1.Columns.Add(header6);
			listView1.Columns.Add(header7);
			listView1.Columns.Add(header8);
			listView1.View = View.Details;
            Name_label.Text = name + " !";
            DateTime now = DateTime.Now;
            String last = now.ToString();
            if (time == "0")
            {
                connection.Open();
                query = "UPDATE Table1 SET [lasttime] = ? WHERE ID = ?";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                var accessUpdateCommand = new OleDbCommand(query, connection);
                accessUpdateCommand.Parameters.AddWithValue("lasttime", last);
                accessUpdateCommand.Parameters.AddWithValue("ID", id);
                adapter.UpdateCommand = accessUpdateCommand;
                adapter.UpdateCommand.ExecuteNonQuery();
                connection.Close();
                datetimenow_label.Text = "now";
            }
            else
            {
                datetimenow_label.Text = time;
                connection.Open();
                query = "UPDATE Table1 SET [lasttime] = ? WHERE ID = ?";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                var accessUpdateCommand = new OleDbCommand(query, connection);
                accessUpdateCommand.Parameters.AddWithValue("lasttime", last);
                accessUpdateCommand.Parameters.AddWithValue("ID", id);
                adapter.UpdateCommand = accessUpdateCommand;
                adapter.UpdateCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void Close_picturebox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Close_picturebox_MouseEnter(object sender, EventArgs e)
        {
            Close_picturebox.Image = Properties.Resources.Delete_Red;
        }

        private void Close_picturebox_MouseLeave(object sender, EventArgs e)
        {
            Close_picturebox.Image = Properties.Resources.Delete_White;
        }
        // Logout button events !
        private void Logout_button_MouseEnter(object sender, EventArgs e)
        {
            Logout_button.ForeColor = Color.Goldenrod;
        }

        private void Logout_button_MouseLeave(object sender, EventArgs e)
        {
            Logout_button.ForeColor = Color.LightBlue;
        }

        private void Logout_button_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        //about button from menu events !
        private void About_button_MouseEnter(object sender, EventArgs e)
        {
            About_button.ForeColor = Color.Goldenrod;
        }

        private void About_button_MouseLeave(object sender, EventArgs e)
        {
            About_button.ForeColor = Color.LightBlue;
        }
        //Quiz button events !
        private void Quiz_button_MouseEnter(object sender, EventArgs e)
        {
            Quiz_button.ForeColor = Color.Goldenrod;
        }

        private void Quiz_button_MouseLeave(object sender, EventArgs e)
        {
            Quiz_button.ForeColor = Color.LightBlue;
        }
        //Theory button events !
        private void Theory_button_MouseEnter(object sender, EventArgs e)
        {
            Theory_button.ForeColor = Color.Goldenrod;
        }

        private void Theory_button_MouseLeave(object sender, EventArgs e)
        {
           Theory_button.ForeColor = Color.LightBlue;
        }
		//Help button events !
		private void Help_button_MouseEnter(object sender, EventArgs e)
		{
			Help_button.ForeColor = Color.Goldenrod;
		}

		private void Help_button_MouseLeave(object sender, EventArgs e)
		{
			Help_button.ForeColor = Color.LightBlue;
		}
		//take quiz button from menu !
		private void Quiz_button_Click(object sender, EventArgs e)
        {
            score = 0;
            arithmos = 0;
            //arithmos2 = 0;
            readyForsubmit = false;
            Next_picturebox.Image = Properties.Resources.Right_arrow;
            Next_picturebox.Enabled = true;
            Previous_picturebox.Enabled = true;
            question_number_label.Text = "1/12";
            metritis = 0;
            Array.Clear(tag_answer,0,12);
            seconds = 0;
            minutes = 0;
            question_number = 1;
            About_panel.Visible = false;
            quiz_panel.Visible = true;
            My_Scores_panel.Visible = false;
            Select_difficulty_label.Visible = true;
            Easy_label.Visible = true;
            Medium_label.Visible = true;
            Hard_label.Visible = true;
            Easy_picturebox.Visible = true;
            Medium_picturebox.Visible = true;
            Hard_picturebox.Visible = true;
            Next_picturebox.Visible = false;
            Previous_picturebox.Visible = false;
            question_number_label.Visible = false;
            timer_count_label.Visible = false;
            datetimenow_label.Visible = false;
            last_signin.Visible = false;
            question_label_title.Visible = false;
            question_label.Visible = false;
			question_richtextbox.Visible = false;
			Answer_label.Visible = false;
            answer_1.Visible = false;
            answer_2.Visible = false;
            answer_3.Visible = false;
            answer_4.Visible = false;
            question_richtextbox.ReadOnly = true;
            Theory_panel.Visible = false;
        }
        //Score Button events !
        private void Score_button_MouseEnter(object sender, EventArgs e)
        {
            Score_button.ForeColor = Color.Goldenrod;
        }

        private void Score_button_MouseLeave(object sender, EventArgs e)
        {
            Score_button.ForeColor = Color.LightBlue;
        }
		//difficulty level selected!
		int[] x = new int[12];
        int[] x1 = new int[4];
        int[] x2 = new int[8];
		string[] arr4 = new string[12];
        int arithmos = 0;
        string query2;
        string querytime;
        string queryselect;
        int countplays;

        int sumtheory1;
        int sumsyntax1;
        int sumlogic1;
        int sumtypographic1;

        string mincategory1;


        int[] sums1 = new int[4];

        List<int> theorylist = new List<int>();
        List<int> syntaxlist = new List<int>();
        List<int> logiclist = new List<int>();
        List<int> typographiclist = new List<int>();
        
        private void Easy_picturebox_Click(object sender, EventArgs e)
        {
            connection.Open();
            queryselect = "SELECT * FROM Table4 WHERE levelPlayed=" + 1 + " AND username='" + username + "'" ;
            OleDbCommand cmd2 = new OleDbCommand(queryselect, connection);
            OleDbDataReader rdr2 = cmd2.ExecuteReader();
            countplays = 0;
            while (rdr2.Read())
            {
                countplays ++;
            }
            connection.Close();
            if (countplays < 2)
            {
                connection.Open();
                query2 = "SELECT * FROM Table2";
                cmd2 = new OleDbCommand(query2, connection);
                rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    if (rdr2.GetString(7) == "theory")
                    {
                        theorylist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "syntax")
                    {
                        syntaxlist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "logic")
                    {
                        logiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "typographic")
                    {
                        typographiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                }
                

                connection.Close();
                level = "easy";
                Random r = new Random();
                int k = 0;
                int lentheory = theorylist.Count;

                for (int i = 0; i < 3; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lentheory);
                        if (!x.Contains(theorylist[k]))
                        {
                            x[i] = theorylist[k];
                            f = true;
                        }
                    }
                }
                int lensyntax = syntaxlist.Count;

                for (int i = 3; i < 6; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lensyntax);
                        if (!x.Contains(syntaxlist[k]))
                        {
                            x[i] = syntaxlist[k];
                            f = true;
                        }
                    }
                }
                int lenlogic = logiclist.Count;

                for (int i = 6; i < 9; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lenlogic);
                        if (!x.Contains(logiclist[k]))
                        {
                            x[i] = logiclist[k];
                            f = true;
                        }
                    }
                }

                int lentypographic = typographiclist.Count;

                for (int i = 9; i < 12; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lentypographic);
                        if (!x.Contains(typographiclist[k]))
                        {
                            x[i] = typographiclist[k];
                            f = true;
                        }
                    }
                }
            }
            else
            {
                connection.Open();
                querytime = "SELECT TOP 2 * FROM Table4 WHERE levelPlayed=" + 1 + " AND username='" + username  + "' ORDER BY datePlayed DESC";
                cmd2 = new OleDbCommand(querytime, connection);
                rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    sumtheory1 = sumtheory1 + Int32.Parse(rdr2.GetString(6));
                    sumsyntax1 = sumsyntax1 + Int32.Parse(rdr2.GetString(7));
                    sumlogic1 = sumlogic1 + Int32.Parse(rdr2.GetString(8));
                    sumtypographic1 = sumtypographic1 + Int32.Parse(rdr2.GetString(9));
                }
                connection.Close();
                sums1[0] = sumtheory1;
                sums1[1] = sumsyntax1;
                sums1[2] = sumlogic1;
                sums1[3] = sumtypographic1;
                int minvalue = sums1.Min();
                int minindex = sums1.ToList().IndexOf(minvalue);
                
                if (minindex == 0)
                {
                    mincategory1 = "theory";

                }
                else if(minindex == 1)
                {
                    mincategory1 = "syntax";

                   
                }
                else if(minindex == 2)
                {
                    mincategory1 = "logic";

                }
                else if(minindex == 3)
                {
                    mincategory1 = "typographic";
                }
                connection.Open();
                query2 = "SELECT * FROM Table2";
                cmd2 = new OleDbCommand(query2, connection);
                rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    if (rdr2.GetString(7) == "theory")
                    {
                        theorylist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "syntax")
                    {
                        syntaxlist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "logic")
                    {
                        logiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "typographic")
                    {
                        typographiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                }

               

                connection.Close();
                level = "easy";
                Random r = new Random();
                int k = 0;
                int lentheory = theorylist.Count;

                for (int i = 0; i < 2; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lentheory);
                        if (!x.Contains(theorylist[k]))
                        {
                            x[i] = theorylist[k];
                            f = true;
                        }
                    }
                }
                int lensyntax = syntaxlist.Count;

                for (int i = 2; i < 4; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lensyntax);
                        if (!x.Contains(syntaxlist[k]))
                        {
                            x[i] = syntaxlist[k];
                            f = true;
                        }
                    }
                }
                int lenlogic = logiclist.Count;

                for (int i = 4; i < 6; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lenlogic);
                        if (!x.Contains(logiclist[k]))
                        {
                            x[i] = logiclist[k];
                            f = true;
                        }
                    }
                }

                int lentypographic = typographiclist.Count;

                for (int i = 6; i < 8; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lentypographic);
                        if (!x.Contains(typographiclist[k]))
                        {
                            x[i] = typographiclist[k];
                            f = true;
                        }
                    }
                }
                if (mincategory1 == "theory")
                {
                    for (int i = 8; i < 12; i++)
                    {
                        bool f = false;
                        while (f == false)
                        {
                            k = r.Next(0, lentheory);
                            if (!x.Contains(theorylist[k]))
                            {
                                x[i] = theorylist[k];
                                f = true;
                            }
                        }
                    }
                }else if (mincategory1 == "syntax")
                {
                    for (int i = 8; i < 12; i++)
                    {
                        bool f = false;
                        while (f == false)
                        {
                            k = r.Next(0, lensyntax);
                            if (!x.Contains(syntaxlist[k]))
                            {
                                x[i] = syntaxlist[k];
                                f = true;
                            }
                        }
                    }
                }
                else if (mincategory1 == "logic")
                {
                    for (int i = 8; i < 12; i++)
                    {
                        bool f = false;
                        while (f == false)
                        {
                            k = r.Next(0, lenlogic);
                            if (!x.Contains(logiclist[k]))
                            {
                                x[i] = logiclist[k];
                                f = true;
                            }
                        }
                    }
                }else if (mincategory1 == "typographic")
                {
                    for (int i = 8; i < 12; i++)
                    {
                        bool f = false;
                        while (f == false)
                        {
                            k = r.Next(0, lentypographic);
                            if (!x.Contains(typographiclist[k]))
                            {
                                x[i] = typographiclist[k];
                                f = true;
                            }
                        }
                    }
                }




            }







            connection.Open();
            query = "SELECT * FROM Table2 where ID=" + x[0] + "";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
				question_richtextbox.Text = rdr.GetString(1);
                answer_1.Text = rdr.GetString(2);
                answer_2.Text = rdr.GetString(3);
                answer_3.Text = rdr.GetString(4);
                answer_4.Text = rdr.GetString(5);
                correctAnswers[0] = Int32.Parse(rdr.GetString(6));
				category[0] = rdr.GetString(7);
			}
            connection.Close();
            timer1.Start();

            //do functions to start the test !
            Select_difficulty_label.Text ="Difficulty : "+ level;
            Easy_label.Visible = false;
            Medium_label.Visible = false;
            Hard_label.Visible = false;
            Easy_picturebox.Visible = false;
            Medium_picturebox.Visible = false;
            Hard_picturebox.Visible = false;
            Next_picturebox.Visible = true;
            Previous_picturebox.Visible = false;
            question_number_label.Visible = true;
            timer_count_label.Visible = true;
            timer1.Enabled = true;
            question_label_title.Visible = true;
            question_label.Visible = true;
			question_richtextbox.Visible = true;
			Answer_label.Visible = true;
            answer_1.Visible = true;
            answer_2.Visible = true;
            answer_3.Visible = true;
            answer_4.Visible = true;
        }

        private void Medium_picturebox_Click(object sender, EventArgs e)
        {
            connection.Open();
            queryselect = "SELECT * FROM Table4 WHERE levelPlayed=" + 2 + " AND username='" + username + "'";
            OleDbCommand cmd2 = new OleDbCommand(queryselect, connection);
            OleDbDataReader rdr2 = cmd2.ExecuteReader();
            countplays = 0;
            while (rdr2.Read())
            {
                countplays++;
            }
            connection.Close();
            if (countplays < 2)
            {
                connection.Open();
                query2 = "SELECT * FROM Table3";
                cmd2 = new OleDbCommand(query2, connection);
                rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    if (rdr2.GetString(7) == "theory")
                    {
                        theorylist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "syntax")
                    {
                        syntaxlist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "logic")
                    {
                        logiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "typographic")
                    {
                        typographiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                }



                connection.Close();
                level = "medium";
                Random r = new Random();
                int k = 0;
                int lentheory = theorylist.Count;

                for (int i = 0; i < 3; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lentheory);
                        if (!x.Contains(theorylist[k]))
                        {
                            x[i] = theorylist[k];
                            f = true;
                        }
                    }
                }
                int lensyntax = syntaxlist.Count;

                for (int i = 3; i < 6; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lensyntax);
                        if (!x.Contains(syntaxlist[k]))
                        {
                            x[i] = syntaxlist[k];
                            f = true;
                        }
                    }
                }
                int lenlogic = logiclist.Count;

                for (int i = 6; i < 9; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lenlogic);
                        if (!x.Contains(logiclist[k]))
                        {
                            x[i] = logiclist[k];
                            f = true;
                        }
                    }
                }

                int lentypographic = typographiclist.Count;

                for (int i = 9; i < 12; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lentypographic);
                        if (!x.Contains(typographiclist[k]))
                        {
                            x[i] = typographiclist[k];
                            f = true;
                        }
                    }
                }
            }
            else
            {
                connection.Open();
                querytime = "SELECT TOP 2 * FROM Table4 WHERE levelPlayed=" + 2 + " AND username='" + username + "' ORDER BY datePlayed DESC";
                cmd2 = new OleDbCommand(querytime, connection);
                rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    sumtheory1 = sumtheory1 + Int32.Parse(rdr2.GetString(6));
                    sumsyntax1 = sumsyntax1 + Int32.Parse(rdr2.GetString(7));
                    sumlogic1 = sumlogic1 + Int32.Parse(rdr2.GetString(8));
                    sumtypographic1 = sumtypographic1 + Int32.Parse(rdr2.GetString(9));
                }
                connection.Close();
                sums1[0] = sumtheory1;
                sums1[1] = sumsyntax1;
                sums1[2] = sumlogic1;
                sums1[3] = sumtypographic1;
                int minvalue = sums1.Min();
                int minindex = sums1.ToList().IndexOf(minvalue);

                if (minindex == 0)
                {
                    mincategory1 = "theory";

                }
                else if (minindex == 1)
                {
                    mincategory1 = "syntax";


                }
                else if (minindex == 2)
                {
                    mincategory1 = "logic";

                }
                else if (minindex == 3)
                {
                    mincategory1 = "typographic";
                }
                connection.Open();
                query2 = "SELECT * FROM Table3";
                cmd2 = new OleDbCommand(query2, connection);
                rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    if (rdr2.GetString(7) == "theory")
                    {
                        theorylist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "syntax")
                    {
                        syntaxlist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "logic")
                    {
                        logiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                    else if (rdr2.GetString(7) == "typographic")
                    {
                        typographiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                    }
                }


                connection.Close();
                level = "medium";
                Random r = new Random();
                int k = 0;
                int lentheory = theorylist.Count;

                for (int i = 0; i < 2; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lentheory);
                        if (!x.Contains(theorylist[k]))
                        {
                            x[i] = theorylist[k];
                            f = true;
                        }
                    }
                }
                int lensyntax = syntaxlist.Count;

                for (int i = 2; i < 4; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lensyntax);
                        if (!x.Contains(syntaxlist[k]))
                        {
                            x[i] = syntaxlist[k];
                            f = true;
                        }
                    }
                }
                int lenlogic = logiclist.Count;

                for (int i = 4; i < 6; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lenlogic);
                        if (!x.Contains(logiclist[k]))
                        {
                            x[i] = logiclist[k];
                            f = true;
                        }
                    }
                }

                int lentypographic = typographiclist.Count;

                for (int i = 6; i < 8; i++)
                {
                    bool f = false;
                    while (f == false)
                    {
                        k = r.Next(0, lentypographic);
                        if (!x.Contains(typographiclist[k]))
                        {
                            x[i] = typographiclist[k];
                            f = true;
                        }
                    }
                }
                if (mincategory1 == "theory")
                {
                    for (int i = 8; i < 12; i++)
                    {
                        bool f = false;
                        while (f == false)
                        {
                            k = r.Next(0, lentheory);
                            if (!x.Contains(theorylist[k]))
                            {
                                x[i] = theorylist[k];
                                f = true;
                            }
                        }
                    }
                }
                else if (mincategory1 == "syntax")
                {
                    for (int i = 8; i < 12; i++)
                    {
                        bool f = false;
                        while (f == false)
                        {
                            k = r.Next(0, lensyntax);
                            if (!x.Contains(syntaxlist[k]))
                            {
                                x[i] = syntaxlist[k];
                                f = true;
                            }
                        }
                    }
                }
                else if (mincategory1 == "logic")
                {
                    for (int i = 8; i < 12; i++)
                    {
                        bool f = false;
                        while (f == false)
                        {
                            k = r.Next(0, lenlogic);
                            if (!x.Contains(logiclist[k]))
                            {
                                x[i] = logiclist[k];
                                f = true;
                            }
                        }
                    }
                }
                else if (mincategory1 == "typographic")
                {
                    for (int i = 8; i < 12; i++)
                    {
                        bool f = false;
                        while (f == false)
                        {
                            k = r.Next(0, lentypographic);
                            if (!x.Contains(typographiclist[k]))
                            {
                                x[i] = typographiclist[k];
                                f = true;
                            }
                        }
                    }
                }




            }



            connection.Open();
            query = "SELECT * FROM Table3 where ID=" + x[0] + "";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                question_richtextbox.Text = rdr.GetString(1);
                answer_1.Text = rdr.GetString(2);
                answer_2.Text = rdr.GetString(3);
                answer_3.Text = rdr.GetString(4);
                answer_4.Text = rdr.GetString(5);
                correctAnswers[0] = Int32.Parse(rdr.GetString(6));
				category[0] = rdr.GetString(7);
			}
            connection.Close();
            timer1.Start();

            // do function to start the test !
            Select_difficulty_label.Text = "Difficulty : " + level;
            Easy_label.Visible = false;
            Medium_label.Visible = false;
            Hard_label.Visible = false;
            Easy_picturebox.Visible = false;
            Medium_picturebox.Visible = false;
            Hard_picturebox.Visible = false;
            Next_picturebox.Visible = true;
            Previous_picturebox.Visible = false;
            question_number_label.Visible = true;
            timer_count_label.Visible = true;
            timer1.Enabled = true;
            question_label_title.Visible = true;
            question_label.Visible = true;
			question_richtextbox.Visible = true;
			Answer_label.Visible = true;
            answer_1.Visible = true;
            answer_2.Visible = true;
            answer_3.Visible = true;
            answer_4.Visible = true;
        }
        
        private void Hard_picturebox_Click(object sender, EventArgs e)
        {
            connection.Open();
            query2 = "SELECT * FROM Table2";
            OleDbCommand cmd2 = new OleDbCommand(query2, connection);
            OleDbDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                if (rdr2.GetString(7) == "theory")
                {
                    theorylist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                }
                else if (rdr2.GetString(7) == "syntax")
                {
                    syntaxlist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                }
                else if (rdr2.GetString(7) == "logic")
                {
                    logiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                }
                else if (rdr2.GetString(7) == "typographic")
                {
                    typographiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                }
            }


            connection.Close();
            level = "hard";
            Random r = new Random();
            int k = 0;
            int lentheory = theorylist.Count;

            for (int i = 0; i < 1; i++)
            {
                bool f = false;
                while (f == false)
                {
                    k = r.Next(0, lentheory);
                    if (!x1.Contains(theorylist[k]))
                    {
                        x1[i] = theorylist[k];
                        f = true;
                    }
                }
            }
            int lensyntax = syntaxlist.Count;

            for (int i = 1; i < 2; i++)
            {
                bool f = false;
                while (f == false)
                {
                    k = r.Next(0, lensyntax);
                    if (!x1.Contains(syntaxlist[k]))
                    {
                        x1[i] = syntaxlist[k];
                        f = true;
                    }
                }
            }
            int lenlogic = logiclist.Count;

            for (int i = 2; i < 3; i++)
            {
                bool f = false;
                while (f == false)
                {
                    k = r.Next(0, lenlogic);
                    if (!x1.Contains(logiclist[k]))
                    {
                        x1[i] = logiclist[k];
                        f = true;
                    }
                }
            }

            int lentypographic = typographiclist.Count;

            for (int i = 3; i < 4; i++)
            {
                bool f = false;
                while (f == false)
                {
                    k = r.Next(0, lentypographic);
                    if (!x1.Contains(typographiclist[k]))
                    {
                        x1[i] = typographiclist[k];
                        f = true;
                    }
                }
            }
            connection.Open();
            query2 = "SELECT * FROM Table3";
            cmd2 = new OleDbCommand(query2, connection);
            rdr2 = cmd2.ExecuteReader();
            theorylist.Clear();
            syntaxlist.Clear();
            logiclist.Clear();
            typographiclist.Clear();
            while (rdr2.Read())
            {
                if (rdr2.GetString(7) == "theory")
                {
                    theorylist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                }
                else if (rdr2.GetString(7) == "syntax")
                {
                    syntaxlist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                }
                else if (rdr2.GetString(7) == "logic")
                {
                    logiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                }
                else if (rdr2.GetString(7) == "typographic")
                {
                    typographiclist.Add(Int32.Parse(rdr2.GetValue(0).ToString()));
                }
            }


            connection.Close();
           
            r = new Random();
            k = 0;
            lentheory = theorylist.Count;

            for (int i = 4; i < 6; i++)
            {
                bool f = false;
                while (f == false)
                {
                    k = r.Next(0, lentheory);
                    if (!x2.Contains(theorylist[k]))
                    {
                        x2[i - 4 ] = theorylist[k];
                        f = true;
                    }
                }
            }
            lensyntax = syntaxlist.Count;

            for (int i = 6; i < 8; i++)
            {
                bool f = false;
                while (f == false)
                {
                    k = r.Next(0, lensyntax);
                    if (!x2.Contains(syntaxlist[k]))
                    {
                        x2[i - 4] = syntaxlist[k];
                        f = true;
                    }
                }
            }
            lenlogic = logiclist.Count;

            for (int i = 8; i < 10; i++)
            {
                bool f = false;
                while (f == false)
                {
                    k = r.Next(0, lenlogic);
                    if (!x2.Contains(logiclist[k]))
                    {
                        x2[i - 4] = logiclist[k];
                        f = true;
                    }
                }
            }

            lentypographic = typographiclist.Count;

            for (int i = 10; i < 12; i++)
            {
                bool f = false;
                while (f == false)
                {
                    k = r.Next(0, lentypographic);
                    if (!x2.Contains(typographiclist[k]))
                    {
                        x2[i - 4] = typographiclist[k];
                        f = true;
                    }
                }
            }
            for (k = 0; k < 12; k++)
            {
                if (k < 4)
                {
                    x[k] = x1[k];

                }
                else
                {
                    x[k] = x2[k - 4];
                }


            }
            connection.Open();
            query = "SELECT * FROM Table2 where ID=" + x[0] + "";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                question_richtextbox.Text = rdr.GetString(1);
                answer_1.Text = rdr.GetString(2);
                answer_2.Text = rdr.GetString(3);
                answer_3.Text = rdr.GetString(4);
                answer_4.Text = rdr.GetString(5);
                correctAnswers[0] = Int32.Parse(rdr.GetString(6));
                category[0] = rdr.GetString(7);
            }
            connection.Close();
            
            timer1.Start();

            // do function to start the test !
            Select_difficulty_label.Text = "Difficulty : " + level;
            Easy_label.Visible = false;
            Medium_label.Visible = false;
            Hard_label.Visible = false;
            Easy_picturebox.Visible = false;
            Medium_picturebox.Visible = false;
            Hard_picturebox.Visible = false;
            Next_picturebox.Visible = true;
            Previous_picturebox.Visible = false ;
            question_number_label.Visible = true;
            timer_count_label.Visible = true;
            timer1.Enabled = true;
            question_label_title.Visible = true;
            question_label.Visible = true;
			question_richtextbox.Visible = true;
			Answer_label.Visible = true;
            answer_1.Visible = true;
            answer_2.Visible = true;
            answer_3.Visible = true;
            answer_4.Visible = true;
        }
        int[] tag_answer = new int[12];
        int metritis = 0;
        bool readyForsubmit;
        int score = 0;
		int syntaxerror = 0;
		int logicerror = 0;
		int theoryerror = 0;
		int typographicerror = 0;
		int syntaxquestions = 0;
		int logicquestions = 0;
		int theoryquestions = 0;
        double posostotheory;
        double posostosyntax;
        double posostologic;
        double posostotypographic;
        int typographicquestions = 0;
		int[] correctAnswers = new int[12];
		
        private void Next_picturebox_Click(object sender, EventArgs e)
        {
            /* BEFORE GOES TO NEXT LEVEL */

            //Put it in array
            foreach (RadioButton btn in quiz_panel.Controls.OfType<RadioButton>())
            {
                if (btn.Checked == true)
                {
                    tag_answer[metritis] = Int32.Parse(btn.Tag.ToString());
                    btn.Checked = false; //uncheck
                }
            }

            if (readyForsubmit)
            {
                timer1.Stop();
                Next_picturebox.Enabled = false;
                Previous_picturebox.Enabled = false;
                MessageBox.Show("Quiz successfully completed !");
                //submit score and bla bla
                time = timer_count_label.Text;
                int pointer = 0;
                foreach (int correctAnswer in correctAnswers)
                {
					if (correctAnswer == tag_answer[pointer])
						score++;
					else
					{
						if (category[pointer] == "syntax")
							syntaxerror++;
						else if (category[pointer] == "logic")
							logicerror++;
						else if (category[pointer] == "theory")
							theoryerror++;
						else if (category[pointer] == "typographic")
							typographicerror++;
					}
					if (category[pointer] == "syntax")
						syntaxquestions++;
					else if (category[pointer] == "logic")
						logicquestions++;
					else if (category[pointer] == "theory")
						theoryquestions++;
					else if (category[pointer] == "typographic")
						typographicquestions++;

					pointer++;
                }
                posostosyntax = (int)((1 - (double)syntaxerror / syntaxquestions) * 100);
                posostologic = (int)((1 - (double)logicerror / logicquestions) * 100);
                posostotheory = (int)((1 - (double)theoryerror / theoryquestions) * 100);
                posostotypographic =(int) ((1 - (double)typographicerror / typographicquestions) * 100);
                MessageBox.Show("Syntax Success rate " + posostosyntax + " %" + "\n" +
                    "Logic Success rate " + posostologic + " %" + "\n" +
                    "Theory Success rate " + posostotheory + " %" + "\n" +
                    "Typographic Success rate " + posostotypographic + " %" );
                if (score == 12)
                {
                    MessageBox.Show("Your score is : " + score.ToString() + "/12 !" + "\n" +
                        "YOU ARE AMAZING");
                }
                else
                {
                    if (level != "hard")
                    {
                        MessageBox.Show("Your score is : " + score.ToString() + "/12 !" + "\n" +
                        "Next time we will focus on your least favourite category!");
                    }
                    else
                    {
                        MessageBox.Show("Your score is : " + score.ToString() + "/12 !");
                    }

                }
                 
					
                int lvl = 0;
                DateTime now = DateTime.Now;
                String last = now.ToString();
                connection.Open();
                OleDbCommand cmd1 = new OleDbCommand();//+score+" '" + password_textbox.Text + "','" + email_textbox.Text + "')";
                cmd1.Connection = connection;
                if (level == "easy")
                {
                    lvl = 1;
                    cmd1.CommandText = "insert into Table4(username,score,levelPlayed,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic) values('" + username + "'," + score + "," + lvl + ",'" + last + "','" + time + "','" + posostotheory + "','" + posostosyntax + "','" + posostologic + "','" + posostotypographic + "')";
                }
                else if (level == "medium")
                {
                    lvl = 2;
                    cmd1.CommandText = "insert into Table4(username,score,levelPlayed,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic) values('" + username + "'," + score + "," + lvl + ",'" + last + "','" + time + "','" + posostotheory + "','" + posostosyntax + "','" + posostologic + "','" + posostotypographic + "')";
                }
                else
                {
                    lvl = 3;
                    cmd1.CommandText = "insert into Table4(username,score,levelPlayed,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic) values('" + username + "'," + score + "," + lvl + ",'" + last + "','" + time + "','" + posostotheory + "','" + posostosyntax + "','" + posostologic + "','" + posostotypographic + "')";
                }
                cmd1.ExecuteNonQuery();
                connection.Close();
				syntaxerror = 0;
				logicerror = 0;
				theoryerror = 0;
				typographicerror = 0;
				syntaxquestions = 0;
				logicquestions = 0;
				theoryquestions = 0;
				typographicquestions = 0;
			}

            //goes next
            if (question_number < 12)
            {
                Next_picturebox.Visible = true;
                question_number++;
                question_number_label.Text = question_number + "/12";
            }
            if (question_number == 12)
            {
                Next_picturebox.Image = Properties.Resources.check;
                readyForsubmit = true;
            }
            if (question_number != 1)
            {
                Previous_picturebox.Visible = true;
            }
            

            metritis++;
			connection.Open();
			if (metritis >= 0 && metritis < 12)
			{
                if (level == "easy")
                {
                    query = "SELECT * FROM Table2 where ID=" + x[metritis] + "";
                }
                else if (level == "medium")
                {
                    query = "SELECT * FROM Table3 where ID=" + x[metritis] + "";
                }
                else if (level == "hard")
                {
                    if (metritis >= 0 && metritis < 4)
                    {
                        query = "SELECT * FROM Table2 where ID=" + x[metritis] + "";
                    }
                    else
                    {
                        query = "SELECT * FROM Table3 where ID=" + x[metritis] + "";
                    }
                }
                OleDbCommand cmd = new OleDbCommand(query, connection);
                OleDbDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    question_richtextbox.Text = rdr.GetString(1);
                    answer_1.Text = rdr.GetString(2);
                    answer_2.Text = rdr.GetString(3);
                    answer_3.Text = rdr.GetString(4);
                    answer_4.Text = rdr.GetString(5);
                    correctAnswers[metritis] = Int32.Parse(rdr.GetString(6));
					category[metritis] = rdr.GetString(7);
				}
            }
            connection.Close();

            //next level show the answer if it was answered before
            if (!readyForsubmit)
            {
                if (tag_answer[metritis] == 1)
                    answer_1.Checked = true;
                else if (tag_answer[metritis] == 2)
                    answer_2.Checked = true;
                else if (tag_answer[metritis] == 3)
                    answer_3.Checked = true;
                else if (tag_answer[metritis] == 4)
                    answer_4.Checked = true;
            }
        }

        private void Previous_picturebox_Click(object sender, EventArgs e)
        {
            if (question_number == 12)
            {
                Next_picturebox.Image = Properties.Resources.Right_arrow;
                readyForsubmit = false;
            }
            //uncheck
            foreach (RadioButton btn in quiz_panel.Controls.OfType<RadioButton>())
            {
                if (btn.Checked == true)
                    btn.Checked = false; //uncheck
            }

            if (question_number>1)
            {
                Previous_picturebox.Visible = true;
                question_number--;
                question_number_label.Text = question_number + "/12";
            }
            if (question_number == 1)
            {
                Previous_picturebox.Visible = false;
            }
            if (question_number != 12)
            {
                Next_picturebox.Visible = true;
            }
            metritis--;
			connection.Open();
			if (metritis >= 0 && metritis < 12)
			{
                if (level == "easy")
                {
                    query = "SELECT * FROM Table2 where ID=" + x[metritis] + "";
                }
                else if (level == "medium")
                {
                    query = "SELECT * FROM Table3 where ID=" + x[metritis] + "";
                }
                else if (level == "hard")
                {
                    if (metritis >= 0 && metritis < 5)
                    {
                        query = "SELECT * FROM Table2 where ID=" + x[metritis] + "";
                    }
                    else
                    {
                        query = "SELECT * FROM Table3 where ID=" + x[metritis] + "";
                    }
                }
                OleDbCommand cmd = new OleDbCommand(query, connection);
                OleDbDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    question_richtextbox.Text = rdr.GetString(1);
                    answer_1.Text = rdr.GetString(2);
                    answer_2.Text = rdr.GetString(3);
                    answer_3.Text = rdr.GetString(4);
                    answer_4.Text = rdr.GetString(5);
                }
            }
            connection.Close();
            if (!readyForsubmit)
            {
                if (tag_answer[metritis] == 1)
                    answer_1.Checked = true;
                else if (tag_answer[metritis] == 2)
                    answer_2.Checked = true;
                else if (tag_answer[metritis] == 3)
                    answer_3.Checked = true;
                else if (tag_answer[metritis] == 4)
                    answer_4.Checked = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //set up timer 
            seconds++;
            if(seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            if (seconds < 10 && minutes < 10)
            {
                timer_count_label.Text = "0"+minutes+ " : "+ "0"+ seconds;
            }
            else if (seconds <10 && minutes >= 10)
            {
                timer_count_label.Text = minutes + " : " + "0" + seconds;
            }
            else if (seconds >= 10 && minutes <10)
            {
                timer_count_label.Text = "0" + minutes + " : "+ seconds;
            }
            else if (seconds >= 10 && minutes >=10)
            {
                timer_count_label.Text = minutes + " : " + seconds;
            }
        }

		private void question_richtextbox_TextChanged(object sender, EventArgs e)
		{

		}

        private void quiz_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Theory_button_Click(object sender, EventArgs e)
        {
            About_panel.Visible = false;
            instructions_label.Visible = false;
            back_arrow_for_theory.Visible = false;
            pdf_reader.Visible = false;
            quiz_panel.Visible = false;
            My_Scores_panel.Visible = false;
            Theory_panel.Visible = true;
            First_theory_label.Visible = true;
            first_theory_picturebox.Visible = true;
            Second_theory_label.Visible = true;
            second_theory_picturebox.Visible = true;
        }
        //Events for picturebox clicks from theory panel!
        private void first_theory_picturebox_Click(object sender, EventArgs e)
        {
            pdf_reader.LoadFile("Theory_first_level.pdf");
            instructions_label.Visible = true;
            back_arrow_for_theory.Visible = true;
            pdf_reader.Visible = true;
            First_theory_label.Visible = false;
            first_theory_picturebox.Visible = false;
            Second_theory_label.Visible = false;
            second_theory_picturebox.Visible = false;
        }

        private void second_theory_picturebox_Click(object sender, EventArgs e)
        {
            pdf_reader.LoadFile("Theory_second_level.pdf");
            instructions_label.Visible = true;
            back_arrow_for_theory.Visible = true;
            pdf_reader.Visible = true;
            First_theory_label.Visible = false;
            first_theory_picturebox.Visible = false;
            Second_theory_label.Visible = false;
            second_theory_picturebox.Visible = false;
        }

        private void back_arrow_for_theory_Click(object sender, EventArgs e)
        {
            instructions_label.Visible = false;
            back_arrow_for_theory.Visible = false;
            pdf_reader.Visible = false;
            First_theory_label.Visible = true;
            first_theory_picturebox.Visible = true;
            Second_theory_label.Visible = true;
            second_theory_picturebox.Visible = true;
        }
		

        private void Score_button_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            listView1.Visible = true;
            My_Scores_panel.Visible = true;
            quiz_panel.Visible = false;
            Theory_panel.Visible = false;
            About_panel.Visible = false;
            Calculate(current_mode, current_level);
        }

        private void About_button_Click(object sender, EventArgs e)
        {
            About_panel.Visible = true;
            quiz_panel.Visible = false;
            Theory_panel.Visible = false;
            My_Scores_panel.Visible = false;
        }
        private void Calculate(int mode, int level)
        {
            dataGridView1.Visible = false;
            listView1.Items.Clear();
            connection.Open();

            //OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            if (mode == 1 && level == 1)
            {
                query = "SELECT username,score,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic FROM Table4 where levelPlayed=" + 1 + " AND username = '" + username + "' ORDER BY score DESC";
                //MessageBox.Show(username);
            }

            else if (mode == 1 && level == 2)
            {
                query = "SELECT username,score,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic FROM Table4 where levelPlayed=" + 2 + " AND username = '" + username + "' ORDER BY score DESC";
            }
            else if (mode == 1 && level == 3)
            {
                query = "SELECT username,score,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic FROM Table4 where levelPlayed=" + 3 + " AND username = '" + username + "' ORDER BY score DESC";
            }
            else if (mode == 2 && level == 1)
            {
                query = "SELECT username,score,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic FROM Table4 where levelPlayed=" + 1 + " ORDER BY score DESC";
            }
            else if (mode == 2 && level == 2)
            {
                query = "SELECT username,score,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic FROM Table4 where levelPlayed=" + 2 + " ORDER BY score DESC";
            }
            else if (mode == 2 && level == 3)
            {
                query = "SELECT username,score,datePlayed,timescore1,score_theory,score_syntax,score_logic,score_typographic FROM Table4 where levelPlayed=" + 3 + " ORDER BY score DESC";
            }
            cmd.CommandText = query;
            //OleDbDataReader rdr = cmd.ExecuteReader();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i=0;i<dataGridView1.Rows.Count-1;i++)
            {
                var item1 = new ListViewItem(new[] { dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString() + "/12", dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[6].Value.ToString(), dataGridView1.Rows[i].Cells[7].Value.ToString() });
                listView1.Items.Add(item1);
            }
            connection.Close();
        }

        private void personal_bt_Click(object sender, EventArgs e)
        {
            global_bt.BackColor = Color.FromArgb(26,32,40);
            personal_bt.BackColor = Color.FromArgb(22, 50, 90);
            current_mode = 1;
            Calculate(current_mode, current_level);
        }

        private void global_bt_Click(object sender, EventArgs e)
        {
            global_bt.BackColor = Color.FromArgb(22, 50, 90);
            personal_bt.BackColor = Color.FromArgb(26, 32, 40);
            current_mode = 2;
            Calculate(current_mode, current_level);
        }

        private void easy_bt_Click(object sender, EventArgs e)
        {
            easy_bt.BackColor = Color.FromArgb(22, 50, 90);
            med_bt.BackColor  = Color.FromArgb(26, 32, 40);
            hard_bt.BackColor = Color.FromArgb(26, 32, 40);
            current_level = 1;
            Calculate(current_mode, current_level);
        }

        private void med_bt_Click(object sender, EventArgs e)
        {
            easy_bt.BackColor = Color.FromArgb(26, 32, 40);
            med_bt.BackColor = Color.FromArgb(22, 50, 90);
            hard_bt.BackColor = Color.FromArgb(26, 32, 40);
            current_level = 2;
            Calculate(current_mode, current_level);
        }

        private void hard_bt_Click(object sender, EventArgs e)
        {
            easy_bt.BackColor = Color.FromArgb(26, 32, 40);
            med_bt.BackColor  = Color.FromArgb(26, 32, 40);
            hard_bt.BackColor = Color.FromArgb(22, 50, 90);
            current_level = 3;
            Calculate(current_mode, current_level);
        }

		private void Help_button_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, "user_manual.htm");
		}
	}
}
