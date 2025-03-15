// Проєкт 1: Конвертер миль в кілометри

using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

public class MileToKmConverter : Form
{
    private TextBox inputMiles;
    private Button convertButton;
    private Label resultLabel;

    public MileToKmConverter()
    {
        this.Text = "Конвертер миль в кілометри";

        inputMiles = new TextBox { Left = 20, Top = 20, Width = 100 };
        convertButton = new Button { Text = "Конвертувати", Left = 130, Top = 20 };
        resultLabel = new Label { Left = 20, Top = 60, Width = 200 };

        convertButton.Click += (sender, e) =>
        {
            if (double.TryParse(inputMiles.Text, out double miles))
            {
                double km = miles * 1.60934;
                resultLabel.Text = $"{miles} миль = {km:F2} км";
            }
            else
            {
                resultLabel.Text = "Некоректне значення";
            }
        };

        this.Controls.Add(inputMiles);
        this.Controls.Add(convertButton);
        this.Controls.Add(resultLabel);
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new MileToKmConverter());
    }
}


// Проєкт 2: Форма реєстрації

public class MyRegistrationForm : Form
{
    private TextBox firstNameBox, lastNameBox, birthYearBox, addressBox, outputBox;
    private Button okButton, closeButton;

    public MyRegistrationForm()
    {
        this.Text = "Лаб. 1";

        var labels = new string[] { "Ім’я:", "Прізвище:", "Рік народження:", "Поштова адреса:" };
        var textBoxes = new TextBox[4];

        for (int i = 0; i < labels.Length; i++)
        {
            var label = new Label { Text = labels[i], Left = 20, Top = 20 + (i * 30), Width = 120 };
            var textBox = new TextBox { Left = 150, Top = 20 + (i * 30), Width = 200 };
            this.Controls.Add(label);
            this.Controls.Add(textBox);
            textBoxes[i] = textBox;
        }

        firstNameBox = textBoxes[0];
        lastNameBox = textBoxes[1];
        birthYearBox = textBoxes[2];
        addressBox = textBoxes[3];

        okButton = new Button { Text = "OK", Left = 50, Top = 160 };
        closeButton = new Button { Text = "Close", Left = 150, Top = 160 };
        outputBox = new TextBox { Left = 20, Top = 200, Width = 330, Height = 100, Multiline = true };

        okButton.Click += (sender, e) =>
        {
            if (int.TryParse(birthYearBox.Text, out int year))
            {
                outputBox.Text = $"Ім’я: {firstNameBox.Text}\nПрізвище: {lastNameBox.Text}\nРік народження: {year}\nПоштова адреса: {addressBox.Text}";
            }
            else
            {
                MessageBox.Show("Некоректний рік народження", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        closeButton.Click += (sender, e) => this.Close();

        this.Controls.Add(okButton);
        this.Controls.Add(closeButton);
        this.Controls.Add(outputBox);
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new MyRegistrationForm());
    }
}
