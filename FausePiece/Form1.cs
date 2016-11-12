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
            var tekBags = new int[(int) numberOfBags.Value];
            var prevState = new[] {1, 2, 3, 4, 5, 39, 97, 139, 247, 478};
            if ((int) numberOfBags.Value != 10)
                for (var i = 0; i < (int) numberOfBags.Value; i++)
                    tekBags[i] = i + 1;
            else
                tekBags = prevState;
            var localMaximum = (int) maxPieces.Value + 1;
            var ourBags = new Bags((int) numberOfBags.Value);

            while (tekBags[0] != localMaximum - (int) numberOfBags.Value)
            {
                ourBags.SetBags(tekBags);

                if (ourBags.BagsUniqTest() && (ourBags.MaxBagValue() < localMaximum))
                {
                    Log.Text += ourBags.GetBagsAsString() + @";
";
                    localMaximum = ourBags.MaxBagValue();
                    Answer.Text = ourBags.GetBagsAsString();
                    Refresh();
                }

                if (tekBags[(int) numberOfBags.Value - 1] >= localMaximum)
                {
                    var i = (int) numberOfBags.Value - 1;
                    while ((i > 0) && (tekBags[i] - 1 == tekBags[i - 1])) i--;
                    tekBags[i - 1]++;
                    for (var j = i; j < (int) numberOfBags.Value; j++) tekBags[j] = tekBags[j - 1] + 1;
                }
                else
                {
                    tekBags[(int) numberOfBags.Value - 1]++;
                }
            }
            LocalMax.Text = localMaximum.ToString();
        }
    }

    public class Bags
    {
        private int[] _bagsValue;
        private int[] _weightValue;

        public Bags(int size)
        {
            _bagsValue = new int[size];
            for (var i = 0; i < size; i++)
                _bagsValue[i] = 1;
        }

        public Bags(int[] arr)
        {
            _bagsValue = arr;
        }

        public void SetBags(int[] arr)
        {
            _bagsValue = arr;
        }

        public int[] GetBags()
        {
            return _bagsValue;
        }

        public string GetBagsAsString()
        {
            return _bagsValue.Aggregate("", (current, i) => current + (i + " "));
        }

        public int MaxBagValue()
        {
            return _bagsValue.Max();
        }

        public bool BagsUniqTest()
        {
            for (var i = 0; i < _bagsValue.Length - 2; i++)
                for (var j = 1; i < _bagsValue.Length - 1; i++)
                    for (var k = 2; i < _bagsValue.Length; i++)
                        if (_bagsValue[i] + _bagsValue[j] == _bagsValue[k])
                            return false;


            _weightValue = new int[(int) Math.Pow(2, _bagsValue.Length)];
            for (var i = 1; i < _weightValue.Length; i++)
            {
                var currNumber = _bagsValue.Select((t, j) => t*((i >> j)%2)).Sum();
                if (Array.IndexOf(_weightValue, currNumber) == -1)
                    _weightValue[i] = currNumber;
                else
                    return false;
            }
            return true;
        }
    }
}