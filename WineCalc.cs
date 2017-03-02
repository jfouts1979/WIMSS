using System.Data;

protected void Button21_Click(object sender, EventArgs e)
{
 DisplayTextBox1.Text = DisplayTextBox1.Text + "(";
}

protected void Button22_Click(object sender, EventArgs e)
{
    DisplayTextBox1.Text = DisplayTextBox1.Text + ")";
}


protected void Button25_Click(object sender, EventArgs e)
{
    DisplayTextBox1.Text = "";
    Answer.Text = "";
}

protected void Button24_Click(object sender, EventArgs e)
{
    string DisplayText = DisplayTextBox1.Text;
    int LastIndex = DisplayText.Length;
    DisplayTextBox1.Text = DisplayTextBox1.Text.Remove(LastIndex - 1);

}

protected void ButtonNumberEqual_Click(object sender, EventArgs e)
{

    try
    {
        string Input = DisplayTextBox1.Text;
        DataTable table = new DataTable();
        Object answer;
        answer = table.Compute(Input, null);
        Answer.Text = answer.ToString();
    }

    catch
    {
        Answer.Text = "ERROR :(";
    }
}