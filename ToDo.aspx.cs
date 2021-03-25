using System;
using System.Data;
using System.Diagnostics;

namespace ToDoApp
{
    public partial class ToDo : System.Web.UI.Page
    {
        private int iData = 0;
        public bool InputCheckFlag;

        public bool ToDoCheck()
        {
            if ((ToDoTextBox.Text == null) || (ToDoTextBox.Text.Length == 0))//.NET Framework 1.xの場合
            {
                ErrorTodo.Text = "ToDoを入力してください";
                InputCheckFlag = false;
            } 
            else
            {
                ErrorTodo.Text = "";
            }
            return InputCheckFlag;
        }
        public bool DeadlineCheck()
        {
            if (string.IsNullOrEmpty(DeadlineTextBox.Text))//.NET Framework 2.0以降の場合
            {
                ErrorDeadline.Text = "期限を入力してください";
                InputCheckFlag = false;
            } 
            else
            {
                ErrorDeadline.Text = "";
            }
            return InputCheckFlag;
        }
        public bool BugetCheck()
        {
            string sBudget = TextBoxBudget.Text;
            bool bBugetFlag = int.TryParse(sBudget, out iData);
            if ((TextBoxBudget.Text == null) || (TextBoxBudget.Text.Trim().Length == 0))//空白文字列も含まない
            {
                ErrorBudget.Text = "予算を入力してください";
                InputCheckFlag = false;
            } 
            else if (bBugetFlag == false)
            {
                ErrorBudget.Text = "数値を入力してください";
                InputCheckFlag = false;
            }
            else if (bBugetFlag == true)
            {
                ErrorBudget.Text = "";
            }
            return InputCheckFlag;
        }
        public bool PeopleNumberCheck()
        {
            string sPeopleNumberText = sPeopleNumberTextBox.Text;
            bool bPeopleNumberFlag = int.TryParse(sPeopleNumberText, out iData);
            if (sPeopleNumberTextBox.Text == "")
            {
                ErrorPeopleNumber.Text = "人数を入力してください";
                InputCheckFlag = false;
            }
            else if (bPeopleNumberFlag == false)
            {
                ErrorPeopleNumber.Text = "数値を入力してください";
                InputCheckFlag = false;
            }
            else if (sPeopleNumberTextBox.Text == "0")
            {
                ErrorPeopleNumber.Text = "0以外の数値を入力してください";
                InputCheckFlag = false;
            }
            else if (bPeopleNumberFlag == true)
            {
                ErrorPeopleNumber.Text = "";
            }
            return InputCheckFlag;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                InputCheckFlag = true;
                ToDoCheck();
                DeadlineCheck();
                BugetCheck();
                PeopleNumberCheck();

                if (InputCheckFlag)
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
