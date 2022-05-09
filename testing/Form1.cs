using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace testing
{
    public partial class Form1 : Form
    {
        private string Path1;
        private string Text4;

        public Form1()
        {
            InitializeComponent();
        }
        private new void FormClosed(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == false)//textbox není prázdný
            {
                if (Path1 == null)//pokud není uložena cesta
                {
                    var text = MessageBox.Show("Chceš uložit text?", "Text saving", MessageBoxButtons.YesNoCancel);
                    
                    switch(text)
                    {
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        case DialogResult.Yes:
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                            saveFileDialog.FileName = "New text";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string name = saveFileDialog.FileName;
                                File.WriteAllText(name, textBox1.Text);
                                Path1 = Path.GetFullPath(saveFileDialog.FileName);
                                Text4 = textBox1.Text;
                            }
                            break;
                    }
                   


                }
                else if (Text4 == textBox1.Text) //pokud text stejný jako z cesty a textbox1
                {

                }
                else if (Path1 != null) //pokud je uložena cesta
                {
                    File.WriteAllText(Path1, textBox1.Text);
                    Text4 = textBox1.Text;
                }
            }
        }
        public void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FileName = "New text";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox1.Text);
                Path1 = Path.GetFullPath(saveFileDialog.FileName);
                Text4 = textBox1.Text;
            }

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Path1) == false && Text4 != textBox1.Text) //uložení pokud není Path1 prázdná a Text4(starý textbox1) není stejný jako tento textBox1.Text
            {
                File.WriteAllText(Path1, textBox1.Text);
                Text4 = textBox1.Text;
            }
            else
            {
                return;
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(OFD.FileName);
                Path1 = Path.GetFullPath(OFD.FileName);
                Text4 = textBox1.Text;
            }
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog FontDialog = new FontDialog();
            if (FontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = FontDialog.Font;
            }
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog = new ColorDialog();
            if (ColorDialog.ShowDialog() == DialogResult.OK)
                textBox1.ForeColor = ColorDialog.Color;
        }
        private void colorBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog = new ColorDialog();
            if (ColorDialog.ShowDialog() == DialogResult.OK)
                textBox1.BackColor = ColorDialog.Color;
        }

        private void KeysPress(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                if (string.IsNullOrEmpty(textBox1.Text) == false)//textbox není prázdný
                {
                    if (Path1 == null)//pokud není uložena cesta
                    {
                        string message = "Chceš uložit text jako?";
                        string title = "Saving text";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        if (MessageBox.Show(message, title, buttons) == DialogResult.Yes)
                        {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                            saveFileDialog.FileName = "New text";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string name = saveFileDialog.FileName;
                                File.WriteAllText(name, textBox1.Text);
                                Path1 = Path.GetFullPath(saveFileDialog.FileName);
                                Text4 = textBox1.Text;
                            }
                        }
                    }
                    else if (Text4 == textBox1.Text) //pokud text stejný jako z cesty a textbox1
                    {

                    }
                    else if (Path1 != null) //pokud je uložena cesta
                    {
                        File.WriteAllText(Path1, textBox1.Text);
                        Text4 = textBox1.Text;
                    }
                }
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q) //shortcut pro vypnutí nebo save
            {
                Close();
                if (string.IsNullOrEmpty(textBox1.Text) == false)//textbox není prázdný
                {
                    if (Path1 == null)//pokud není uložena cesta
                    {
                        string message = "Chceš uložit text jako?";
                        string title = "Saving text";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        if (MessageBox.Show(message, title, buttons) == DialogResult.Yes)
                        {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string name = saveFileDialog.FileName;
                                File.WriteAllText(name, textBox1.Text);
                                Path1 = Path.GetFullPath(saveFileDialog.FileName);
                                Text4 = textBox1.Text;
                                Close();
                            }
                        }
                    }
                    else if (Text4 == textBox1.Text) //pokud text stejný jako z cesty a textbox1
                    {
                        Close();
                    }
                    else if (Path1 != null) //pokud je uložena cesta
                    {
                        File.WriteAllText(Path1, textBox1.Text);
                        Text4 = textBox1.Text;
                        Close();
                    }
                }
            }
            if (e.KeyCode == Keys.Space) //html nápovědy
            { 
                string text = textBox1.Text;
                switch (textBox1.Text)
                {
                    case string a when a.Contains("!htmlc"):
                        textBox1.Text = "<!DOCTYPE html>\r\n<html lang = \"en\" >\r\n<head>\r\n    <meta charset = \"UTF - 8\" >\r\n    <meta http - equiv = \"X - UA - Compatible\" content = \"IE = edge\">\r\n    <meta name=\"viewport\" content =\"width = device - width, initial - scale = 1.0\">\r\n<title>Document</title>\r\n</head>\r\n<body>\r\n\r\n</body>\r\n</html> ";
                        break;
                    case string a when a.Contains("!html"):
                        textBox1.Text = text.Replace("!html", "<html>\r\n\r\n</html>");
                        break;
                    case string a when a.Contains("!body"):
                        textBox1.Text = text.Replace("!body", "<body>\r\n\r\n</body>");
                        break;
                    case string a when a.Contains("!div"):
                        textBox1.Text = text.Replace("!div", "<div>\r\n\r\n</div>");
                        break;
                }
            }
        }

        private void calculatorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            try
            {
                switch (text)
                {
                    case string a when a.Contains("+"):
                        string oneNumAddition = text.Substring(0,text.IndexOf("+"));
                        string secondNumAddition = text.Substring(text.IndexOf("+") + 1);
                        if (oneNumAddition != null && secondNumAddition != null)
                        {
                            double OneNumAddition = Convert.ToDouble(oneNumAddition);
                            double SecondNumAddition = Convert.ToDouble(secondNumAddition);
                            double result = OneNumAddition + SecondNumAddition;
                            textBox1.Text = Convert.ToString(result);
                        }
                        break;
                    case string a when a.Contains("-"):
                        string oneNumSubtraction = text.Substring(0, text.IndexOf("-"));
                        string secondNumSubtraction = text.Substring(text.IndexOf("-") + 1);
                        if (oneNumSubtraction != null && secondNumSubtraction != null)
                        {
                            double OneNumSubtraction = Convert.ToDouble(oneNumSubtraction);
                            double SecondNumSubtraction = Convert.ToDouble(secondNumSubtraction);
                            double result = OneNumSubtraction - SecondNumSubtraction;
                            textBox1.Text = Convert.ToString(result);
                        }
                        break;
                    case string a when a.Contains("*"):
                        string oneNumMultiplication = text.Substring(0, text.IndexOf("*"));
                        string secondNumMultiplication = text.Substring(text.IndexOf("*") + 1);
                        if (oneNumMultiplication != null && secondNumMultiplication != null)
                        {
                            double OneNumMultiplication = Convert.ToDouble(oneNumMultiplication);
                            double SecondNumMultiplication = Convert.ToDouble(secondNumMultiplication);
                            double result = OneNumMultiplication * SecondNumMultiplication;
                            textBox1.Text = Convert.ToString(result);
                        }
                        break;
                    case string a when a.Contains("/"):
                        string oneNumDivision = text.Substring(0, text.IndexOf("/"));
                        string secondNumDivision = text.Substring(text.IndexOf("/") + 1);
                        if (oneNumDivision != null && secondNumDivision != null)
                        {
                            double OneNumDivision = Convert.ToDouble(oneNumDivision);
                            double SecondNumDivision = Convert.ToDouble(secondNumDivision);
                            double result = OneNumDivision / SecondNumDivision;
                            textBox1.Text = Convert.ToString(result);
                        }
                        break;
                    case string a when a.Contains("%"):
                        string oneNumModulus = text.Substring(0, text.IndexOf("%"));
                        string secondNumModulus = text.Substring(text.IndexOf("%") + 1);
                        if (oneNumModulus != null && secondNumModulus != null)
                        {
                            double OneNumModulus = Convert.ToDouble(oneNumModulus);
                            double SecondNumModulus = Convert.ToDouble(secondNumModulus);
                            double result = OneNumModulus % SecondNumModulus;
                            textBox1.Text = Convert.ToString(result);
                        }
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Zadali jste písmena nebo symboli místo číslic", "Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void calculatorHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Form();
            Button button1 = new Button();
            form2.CancelButton = button1;
            button1.Text = "OK";
            button1.Location = new Point(175, 230);
            Label text = new Label();
            form2.Controls.Add(text);
            text.Text = "Calculator = vložte do čístého textového pole čísla a znaménko\n\n" + "! = programování v html s přidáním \"!\"";
            text.Location = new Point(12, 10);
            text.Font = new Font("Arial", 10);
            text.AutoSize = true;
            form2.Text = "Help";
            form2.FormBorderStyle = FormBorderStyle.FixedDialog;
            form2.MaximizeBox = false;
            form2.MinimizeBox = false;
            form2.Width = 450;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Controls.Add(button1);
            form2.ShowDialog();


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] list ={"January","February","March", "April","May","June", "July", "August", "September", "October", "November", "December"};
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource.AddRange(list);
        }

    }
}







