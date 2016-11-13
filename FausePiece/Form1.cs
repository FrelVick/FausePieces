using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FausePiece.Properties;

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
            Refresh.Enabled = true;
            _ourBags = new Bags((int)numberOfBags.Value);
            _ourBags.MaxValue = (int)maxPieces.Value + 1;
            if ((int) numberOfBags.Value == 10) Load10Sate();
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
            LocalMax.Text = _ourBags.MaxValue.ToString();
            Answer.Text = _ourBags.GetBagsAsString();
            progressBar1.Value=100*(_ourBags.BagsValue[0]/ _ourBags.MaxValue + _ourBags.BagsValue[0] / (_ourBags.MaxValue* _ourBags.MaxValue));
            if (!_calculateThread.IsAlive)
            {
                button1.Text = @"Start";
                button1.Enabled = true;
                progressBar1.Value = 0;
                if ((int)numberOfBags.Value == 10) Save10State();
                Settings.Default.Save();
                Refresh.Enabled = false;
            }
            
            Refresh();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _calculateThread.Abort();
            if ((int)numberOfBags.Value == 10) Save10State();
            Settings.Default.Save();
        }

        private void Save10State()
        {
            Settings.Default.Calcul10 = string.Join(",", _ourBags.BagsValue.Select(i => i.ToString()).ToArray());
            Settings.Default.Max10 = _ourBags.MaxValue;
            Settings.Default.MaxValue10 = _ourBags.GetBagsAsString();
        }

        private void Load10Sate()
        {
            var prevState = Settings.Default.Calcul10.Split(',').Select(int.Parse).ToArray();
            if ((int) numberOfBags.Value != 10) return;
            _ourBags.BagsValue = prevState;
            _ourBags.MaxValue = Settings.Default.Max10;
            _ourBags.SetBagsAsString(Settings.Default.MaxValue10);
        }
    }
}

public class Bags
{
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

    public void SetBagsAsString(string bagValue)
    {
        _bagsAsString = bagValue;
    }

    public int MaxBagValue()
    {
        return BagsValue.Max();
    }

    public bool BagsFullUniqTest()
    {
        var weightValue = new SortedSet<int>();
        for (var i = 1; i < (int)Math.Pow(2, BagsValue.Length); i++)
        {
            var currNumber = BagsValue.Select((t, j) => t*((i >> j)%2)).Sum();
            if (!weightValue.Add(currNumber)) return false;
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