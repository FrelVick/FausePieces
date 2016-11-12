using System;
using System.Linq;
using System.Windows.Forms;

namespace FausePiece
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ourBags = new Bags((int) numberOfBags.Value);
            var prevState = new[] {1, 2, 3, 4, 6, 44, 48, 134, 190, 489};
            if ((int) numberOfBags.Value == 10) ourBags.BagsValue = prevState;
            ourBags.MaxValue = (int) maxPieces.Value + 1;

            while (ourBags.BagsValue[0] != ourBags.MaxValue - (int) numberOfBags.Value)
            {
                if (ourBags.BagsFullUniqTest() && (ourBags.MaxBagValue() < ourBags.MaxValue))
                {
                    Log.Text += ourBags.GetBagsAsString() + @";
";
                    ourBags.MaxValue = ourBags.MaxBagValue();
                    LocalMax.Text = ourBags.MaxValue.ToString();
                    Answer.Text = ourBags.GetBagsAsString();
                    Refresh();
                }
                var dubPos = (int) numberOfBags.Value-1;

                while (dubPos != -1 && ourBags.BagsValue[0] != ourBags.MaxValue - (int)numberOfBags.Value)
                {
                    ourBags.IncrementBag(dubPos);
                    dubPos = ourBags.BagsLittleUniqTest();
                }
            }
        }
    }
}

public class Bags
{
    private int[] _weightValue;

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
        return BagsValue.Aggregate("", (current, i) => current + (i + " "));
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