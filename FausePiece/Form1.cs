using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FausePiece
{
    public partial class Form1 : Form
    {
        private Bags _ourBags;

        private Thread _calculateThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ourBags = new Bags((int)numberOfBags.Value);
            var prevState = new[] { 1, 2, 4, 7, 10, 13, 53, 215, 252, 269 };
            if ((int) numberOfBags.Value == 10) _ourBags.BagsValue = prevState;
            _ourBags.MaxValue = (int) maxPieces.Value + 1;
            _calculateThread = new Thread(Bags.FindMinimalBags);
            _calculateThread.Start(_ourBags);
            button1.Text = @"Working...";
            button1.Enabled = false;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            foreach (var i in _ourBags.BagsValue)
            {
                Log.Text += i+@", ";
            }
            Log.Text += @"; actual
";
            Log.Text += _ourBags.GetBagsAsString() + @"; minimal
";
            LocalMax.Text = _ourBags.MaxValue.ToString();
            Answer.Text = _ourBags.GetBagsAsString();
            progressBar1.Value=_ourBags.BagsValue[0]/ _ourBags.MaxValue + _ourBags.BagsValue[0] / (_ourBags.MaxValue* _ourBags.MaxValue);
            if (!_calculateThread.IsAlive)
            {
                button1.Text = @"Start";
                button1.Enabled = true;
                progressBar1.Value = 0;
            }
            
            Refresh();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _calculateThread.Abort();
        }
    }
}

public class Bags
{
    private int[] _weightValue;

    private string _bagsAsString;

    public int MaxValue { get; set; }

    public int[] BagsValue { get; set; }

    public Bags(int size)
    {
        BagsValue = new int[size];
        for (var i = 0; i < size; i++)
            BagsValue[i] = 1;
    }

    public Bags(int[] arr)
    {
        BagsValue = arr;
    }

    public string GetBagsAsString()
    {
        return _bagsAsString;
    }

    public int MaxBagValue()
    {
        return BagsValue.Max();
    }

    public bool BagsFullUniqTest()
    {
        _weightValue = new int[(int) Math.Pow(2, BagsValue.Length)];
        for (var i = 1; i < _weightValue.Length; i++)
        {
            var currNumber = BagsValue.Select((t, j) => t*((i >> j)%2)).Sum();
            if (Array.IndexOf(_weightValue, currNumber) == -1)
                _weightValue[i] = currNumber;
            else
                return false;
        }
        return true;
    }

    public int BagsLittleUniqTest()
    {
        for (var i = 0; i < BagsValue.Length - 2; i++)
            for (var j = i + 1; j < BagsValue.Length - 1; j++)
                for (var k = j + 1; k < BagsValue.Length; k++)
                    if (BagsValue[i] + BagsValue[j] == BagsValue[k]) return k;
        return -1;
    }

    public static void FindMinimalBags(object input)
    {
        var ourBags = (Bags) input;
        while (ourBags.BagsValue[0] != ourBags.MaxValue - ourBags.BagsValue.Length)
        {
            if (ourBags.BagsFullUniqTest() && (ourBags.MaxBagValue() < ourBags.MaxValue))
            {
                ourBags._bagsAsString = ourBags.BagsValue.Aggregate("", (current, i) => current + (i + " "));
                ourBags.MaxValue = ourBags.MaxBagValue();
            }
            var dubPos = ourBags.BagsValue.Length - 1;

            while (dubPos != -1 && ourBags.BagsValue[0] != ourBags.MaxValue - ourBags.BagsValue.Length)
            {
                ourBags.IncrementBag(dubPos);
                dubPos = ourBags.BagsLittleUniqTest();
            }
        }
    }

    public void IncrementBag(int elem)
    {
        while (true)
        {
            if ((BagsValue[elem] == MaxValue - (BagsValue.Length - elem - 1)) && elem != 0)
            {
                elem = elem - 1;
                continue;
            }
            BagsValue[elem]++;
            for (var i = elem + 1; i < BagsValue.Length; i++) BagsValue[i] = BagsValue[i - 1] + 1;
            break;
        }
    }
}