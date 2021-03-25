using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace ToDoApp
{
    public partial class ToDo : System.Web.UI.Page
    {
        private int iData = 0;
        public bool InputCheckFlag = true;

        public bool InputCheck()
        {
            var TextBoxes = new Dictionary<string, string>();
            TextBoxes.Add("ToDo", ToDoTextBox.Text);
            TextBoxes.Add("期限", DeadlineTextBox.Text);
            TextBoxes.Add("予算", TextBoxBudget.Text);
            TextBoxes.Add("人数", sPeopleNumberTextBox.Text);
            foreach (var TextBox in TextBoxes)
            {
                BlankTextCheck(TextBox.Key, TextBox.Value);
                if(TextBox.Key == "予算")
                {
                    if (IntCheck(TextBox.Key, TextBox.Value))
                    {
                        ErrorBudget.Text = "";
                    }
                }
                else if(TextBox.Key == "人数")
                {
                    bool bPeopleNumberFlag = int.TryParse(TextBox.Value, out iData);
                    if (IntCheck(TextBox.Key, TextBox.Value))
                    {
                        if (sPeopleNumberTextBox.Text == "0")
                        {
                            ErrorPeopleNumber.Text = "0以外の数値を入力してください";
                            InputCheckFlag = false;
                        }
                        else
                        {
                            ErrorPeopleNumber.Text = "";
                        }
                    }


                }
                
            }
            return InputCheckFlag;
        }

        public void BlankTextCheck(string Key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))//.NET Framework 1.xの場合
            {
                if (Key == "ToDo") ErrorTodo.Text = Key + "を入力してください";
                if (Key == "期限") ErrorDeadline.Text = Key + "を入力してください";
                if (Key == "予算") ErrorBudget.Text = Key + "を入力してください";
                if (Key == "人数") ErrorPeopleNumber.Text = Key + "を入力してください";
                InputCheckFlag = false;
            }
            else
            {
                if (Key == "ToDo") ErrorTodo.Text = "";
                if (Key == "期限") ErrorDeadline.Text = "";
            }
        }
        public bool IntCheck(string Key, string value)
        {
            bool IntFlag = int.TryParse(value, out iData);
            if (IntFlag == false)
            {
                if (Key == "予算") ErrorBudget.Text = "数値を入力してください";
                if (Key == "人数") ErrorPeopleNumber.Text = "数値を入力してください";
                InputCheckFlag = false;
            }
            return InputCheckFlag;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                if (InputCheck())
                {
                    int iBuget = int.Parse(TextBoxBudget.Text);
                    int peoplenumInt = int.Parse(sPeopleNumberTextBox.Text);
                    try
                    {
                        int iPerBudgetNoRound = iBuget / peoplenumInt;
                        double dPerbudgetRound = Math.Round((double)iPerBudgetNoRound, MidpointRounding.AwayFromZero);
                        int iPerBudget = (int)dPerbudgetRound;

                        DataTable dt = (DataTable)Session["data"];
                        dt.Rows.Add(new object[] { ToDoTextBox.Text, DropDownList1.SelectedItem.Text, DeadlineTextBox.Text, TextBoxBudget.Text, sPeopleNumberTextBox.Text, iPerBudget });
                        ToDoGridView.DataSource = dt;
                        Session["data"] = dt;

                        ToDoGridView.DataBind();
                    }
                    catch (DivideByZeroException)
                    {
                        Debug.WriteLine("Division of {0} by zero.", peoplenumInt);
                    }
                }
   
            }
            else
            {
                // 初期にテーブル準備
                DataTable dt = new DataTable(@"Table");
                dt.Columns.Add("Todo");
                dt.Columns.Add("Category");
                dt.Columns.Add("Deadline");
                dt.Columns.Add("Budget");
                dt.Columns.Add("PeopleNumber");
                dt.Columns.Add("PerBudget");
                ToDoGridView.DataSource = dt;
                Session["data"] = dt;
            }

        }
    }
}
