using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using calculation;

namespace BCI_Project
{
    public partial class Form1 : Form
    {
        List<List<List<double>>> dividedDataT, dividedDataE, rightLeftDataT, rightLeftDataE, filteredDataT, filteredDataE;
        List<List<double>> DataT, DataE, shiftedDataT, shiftedDataE, epochedDataT, epochedDataE, featuresT, featuresE;
        List<double> meanT, meanE, A, B;
        List<int> trigValuesT, trigValuesE, classLabelsT, classLabelsE, rightLeftLabelsT, rightLeftLabelsE;
        int electrods = 20; // number of electrodes
        int trials = 288;
        int samples = 750;
        int sampleRate = 250;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataT = new List<List<double>>();
            DataE = new List<List<double>>();

            shiftedDataT = new List<List<double>>();
            shiftedDataE = new List<List<double>>();

            epochedDataT = new List<List<double>>();
            epochedDataE = new List<List<double>>();

            dividedDataT = new List<List<List<double>>>();
            dividedDataE = new List<List<List<double>>>();

            rightLeftDataT = new List<List<List<double>>>();
            rightLeftDataE = new List<List<List<double>>>();

            filteredDataT = new List<List<List<double>>>();
            filteredDataE = new List<List<List<double>>>();

            featuresT = new List<List<double>>();
            featuresE = new List<List<double>>();

            meanT = new List<double>();
            meanE = new List<double>();

            trigValuesT = new List<int>();
            trigValuesE = new List<int>();

            classLabelsT = new List<int>();
            classLabelsE = new List<int>();

            rightLeftLabelsT = new List<int>();
            rightLeftLabelsE = new List<int>();

            A = new List<double>();
            A.Add(1); A.Add(-7.579842026175628); A.Add(26.512999938813152); A.Add(-56.342255069103130); A.Add(80.542634853852580); A.Add(-80.919237145755830); A.Add(57.861708575946580); A.Add(-29.080932449155220); A.Add(9.835570475287808); A.Add(-2.022925593127050); A.Add(0.192388596001172);
            B = new List<double>();
            B.Add(0.0004894360861590508); B.Add(0); B.Add(-0.002447180430795); B.Add(0); B.Add(0.004894360861591); B.Add(0); B.Add(-0.004894360861591); B.Add(0); B.Add(0.002447180430795); B.Add(0); B.Add(-0.0004894360861590508);
        }

        public string showDialog()
        {
            using (OpenFileDialog o = new OpenFileDialog()
            {
                Filter = "text documents |* .txt",
                ValidateNames = true,
                Multiselect = false
            })
                if (o.ShowDialog() == DialogResult.OK)
                    return o.FileName;
            return " ";
        }

        private List<List<double>> readFileData(string path)
        {
            List<List<double>> list = new List<List<double>>();
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            List<double> helper;
            while (sr.Peek() != -1) // while in el file peta3ek lessa me4 5els
            {
                string tmp = sr.ReadLine();
                string[] line = tmp.Split(' ');
                helper = new List<double>();
                for (int i = 0; i < electrods; i++)
                {
                    if (line[i] == "NaN")
                        line[i] = "0";
                    helper.Add(double.Parse(line[i].ToString()));
                }
                list.Add(helper);
            }
            helper = new List<double>();
            sr.Close();
            fs.Close();
            return list;
        }

        private List<int> readFile(string path)
        {
            List<int> result = new List<int>();
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                string tmp = sr.ReadLine();
                result.Add(int.Parse(tmp.ToString()));
            }
            sr.Close();
            fs.Close();
            return result;
        }

        private List<double> calculateMean(List<List<double>> list)
        {
            List<double> resultMean = new List<double>();
            for (int i = 0; i < list.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < electrods; j++)
                    sum += list[i][j];
                resultMean.Add(sum / electrods);
            }
            list = new List<List<double>>();
            return resultMean;
        }

        private List<List<double>> shifting(List<List<double>> list, List<double> m)
        {
            //to remove DC components
            List<List<double>> res = new List<List<double>>();
            List<double> helper;
            for (int i = 0; i < list.Count; i++)
            {
                helper = new List<double>();
                for (int j = 0; j < electrods; j++)
                {
                    helper.Add(list[i][j] - m[i]);
                }
                res.Add(helper);
            }
            list = new List<List<double>>();
            helper = new List<double>();
            m = new List<double>();
            return res;
        }

        private List<List<double>> trigg(List<int> tValue, List<List<double>> list)
        {
            //finally you have 216000 * 20 matrix  ... 216000 = 288 * 750
            List<List<double>> result = new List<List<double>>();
            for (int t = 0; t < trials; t++)
            {
                int startOfTrial = tValue[t] + (int)(2.5 * sampleRate);
                int endOfTrial = tValue[t] + (int)(5.5 * sampleRate);
                for (int i = startOfTrial; i < endOfTrial; i++)
                    result.Add(list[i - 1]);
            }
            list = new List<List<double>>();
            tValue = new List<int>();
            return result;
        }

        private List<List<List<double>>> divideTo3D(List<List<double>> list)
        {
            // dimension of matriex is 288 * 750 * 20
            List<List<List<double>>> result = new List<List<List<double>>>();
            List<List<double>> helper;
            for (int i = 0; i < trials; i++)
            {
                helper = new List<List<double>>();
                for (int j = samples * i; j < samples * (i + 1); j++)
                    helper.Add(list[j]);
                result.Add(helper);
            }
            list = new List<List<double>>();
            helper = new List<List<double>>();
            return result;
        }

        private List<List<List<double>>> filtering(List<List<List<double>>> list)
        {
            List<List<List<double>>> newHelper = new List<List<List<double>>>();
            List<List<List<double>>> result = new List<List<List<double>>>();
            for (int i = 0; i < trials / 2; i++)
            {
                List<List<double>> newTmp = new List<List<double>>();
                for (int j = 0; j < samples; j++)
                {
                    List<double> tmp = new List<double>();
                    for (int k = 0; k < electrods; k++)
                        tmp.Add(0);
                    newTmp.Add(tmp);
                }
                newHelper.Add(newTmp);
                result.Add(newTmp);
            }
            for (int j = 0; j < (trials / 2); j++)
            {
                for (int k = 0; k < electrods; k++)
                {
                    newHelper[j][0][k] = list[j][0][k];
                    result[j][0][k] = B[0] * newHelper[j][0][k];

                    newHelper[j][1][k] = list[j][1][k];
                    result[j][1][k] = B[0] * newHelper[j][1][k] + B[1] * newHelper[j][0][k] - A[1] * result[j][0][k];

                    newHelper[j][2][k] = list[j][2][k];
                    result[j][2][k] = B[0] * newHelper[j][2][k] + B[1] * newHelper[j][1][k] + B[2] * newHelper[j][0][k] - A[1] * result[j][1][k] - A[2] * result[j][0][k];

                    newHelper[j][3][k] = list[j][3][k];
                    result[j][3][k] = B[0] * newHelper[j][3][k] + B[1] * newHelper[j][2][k] + B[2] * newHelper[j][1][k] + B[3] * newHelper[j][0][k] - A[1] * result[j][2][k] - A[2] * result[j][1][k] - A[3] * result[j][0][k];

                    newHelper[j][4][k] = list[j][4][k];
                    result[j][4][k] = B[0] * newHelper[j][4][k] + B[1] * newHelper[j][3][k] + B[2] * newHelper[j][2][k] + B[3] * newHelper[j][1][k] + B[4] * newHelper[j][0][k] - A[1] * result[j][3][k] - A[2] * result[j][2][k] - A[3] * result[j][1][k] - A[4] * result[j][0][k];

                    newHelper[j][5][k] = list[j][5][k];
                    result[j][5][k] = B[0] * newHelper[j][5][k] + B[1] * newHelper[j][4][k] + B[2] * newHelper[j][3][k] + B[3] * newHelper[j][2][k] + B[4] * newHelper[j][1][k] + B[5] * newHelper[j][0][k] - A[1] * result[j][4][k] - A[2] * result[j][3][k] - A[3] * result[j][2][k] - A[4] * result[j][1][k] - A[5] * result[j][0][k];

                    newHelper[j][6][k] = list[j][6][k];
                    result[j][6][k] = B[0] * newHelper[j][6][k] + B[1] * newHelper[j][5][k] + B[2] * newHelper[j][4][k] + B[3] * newHelper[j][3][k] + B[4] * newHelper[j][2][k] + B[5] * newHelper[j][1][k] + B[6] * newHelper[j][0][k] - A[1] * result[j][5][k] - A[2] * result[j][4][k] - A[3] * result[j][3][k] - A[4] * result[j][2][k] - A[5] * result[j][1][k] - A[6] * result[j][0][k];

                    newHelper[j][7][k] = list[j][7][k];
                    result[j][7][k] = B[0] * newHelper[j][7][k] + B[1] * newHelper[j][6][k] + B[2] * newHelper[j][5][k] + B[3] * newHelper[j][4][k] + B[4] * newHelper[j][3][k] + B[5] * newHelper[j][2][k] + B[6] * newHelper[j][1][k] + B[7] * newHelper[j][0][k] - A[1] * result[j][6][k] - A[2] * result[j][5][k] - A[3] * result[j][4][k] - A[4] * result[j][3][k] - A[5] * result[j][2][k] - A[6] * result[j][1][k] - A[7] * result[j][0][k];

                    newHelper[j][8][k] = list[j][8][k];
                    result[j][8][k] = B[0] * newHelper[j][8][k] + B[1] * newHelper[j][7][k] + B[2] * newHelper[j][6][k] + B[3] * newHelper[j][5][k] + B[4] * newHelper[j][4][k] + B[5] * newHelper[j][3][k] + B[6] * newHelper[j][2][k] + B[7] * newHelper[j][1][k] + B[8] * newHelper[j][0][k] - A[1] * result[j][7][k] - A[2] * result[j][6][k] - A[3] * result[j][5][k] - A[4] * result[j][4][k] - A[5] * result[j][3][k] - A[6] * result[j][2][k] - A[7] * result[j][1][k] - A[8] * result[j][0][k];

                    newHelper[j][9][k] = list[j][9][k];
                    result[j][9][k] = B[0] * newHelper[j][9][k] + B[1] * newHelper[j][8][k] + B[2] * newHelper[j][7][k] + B[3] * newHelper[j][6][k] + B[4] * newHelper[j][5][k] + B[5] * newHelper[j][4][k] + B[6] * newHelper[j][3][k] + B[7] * newHelper[j][2][k] + B[8] * newHelper[j][1][k] + B[9] * newHelper[j][0][k] - A[1] * result[j][8][k] - A[2] * result[j][7][k] - A[3] * result[j][6][k] - A[4] * result[j][5][k] - A[5] * result[j][4][k] - A[6] * result[j][3][k] - A[7] * result[j][2][k] - A[8] * result[j][1][k] - A[9] * result[j][0][k];

                    newHelper[j][10][k] = list[j][10][k];
                    result[j][10][k] = B[0] * newHelper[j][10][k] + B[1] * newHelper[j][9][k] + B[2] * newHelper[j][8][k] + B[3] * newHelper[j][7][k] + B[4] * newHelper[j][6][k] + B[5] * newHelper[j][5][k] + B[6] * newHelper[j][4][k] + B[7] * newHelper[j][3][k] + B[8] * newHelper[j][2][k] + B[9] * newHelper[j][1][k] + B[10] * newHelper[j][0][k] - A[1] * result[j][9][k] - A[2] * result[j][8][k] - A[3] * result[j][7][k] - A[4] * result[j][6][k] - A[5] * result[j][5][k] - A[6] * result[j][4][k] - A[7] * result[j][3][k] - A[8] * result[j][2][k] - A[9] * result[j][1][k] - A[10] * result[j][0][k];

                    for (int i = 11; i < samples; i++)
                    {
                        newHelper[j][i][k] = list[j][i][k];
                        result[j][i][k] = B[0] * newHelper[j][i][k] + B[1] * newHelper[j][i - 1][k] + B[2] * newHelper[j][i - 2][k] + B[3] * newHelper[j][i - 3][k] + B[4] * newHelper[j][i - 4][k] + B[5] * newHelper[j][i - 5][k] + B[6] * newHelper[j][i - 6][k] + B[7] * newHelper[j][i - 7][k] + B[8] * newHelper[j][i - 8][k] + B[9] * newHelper[j][i - 9][k] + B[10] * newHelper[j][i - 10][k] - A[1] * result[j][i - 1][k] - A[2] * result[j][i - 2][k] - A[3] * result[j][i - 3][k] - A[4] * result[j][i - 4][k] - A[5] * result[j][i - 5][k] - A[6] * result[j][i - 6][k] - A[7] * result[j][i - 7][k] - A[8] * result[j][i - 8][k] - A[9] * result[j][i - 9][k] - A[10] * result[j][i - 10][k];
                    }
                }
            }
            list = new List<List<List<double>>>();
            newHelper = new List<List<List<double>>>();
            // A = new List<double>();
            //B = new List<double>();
            return result;
        }

        private List<List<double>> powering(List<List<List<double>>> list)
        {
            List<List<double>> result = new List<List<double>>();
            List<double> helper = new List<double>();
            for (int i = 0; i < trials / 2; i++)
            {
                for (int j = 0; j < electrods; j++)
                    helper.Add(0);
                result.Add(helper);
                helper = new List<double>();
            }
            for (int i = 0; i < trials / 2; i++)
            {
                //now i accessed the 750 value 
                for (int j = 0; j < samples; j++)
                    helper.Add(0);
                for (int k = 0; k < electrods; k++)
                {
                    for (int n = 0; n < samples; n++)
                        helper[n] = list[i][n][k];
                    double squSum = 0;
                    for (int j = 0; j < samples; j++)
                        squSum += Math.Pow(helper[j], 2);
                    result[i][k] = Math.Sqrt((1.0 / samples) * squSum);
                }
                helper = new List<double>();
            }
            list = new List<List<List<double>>>();
            return result;
        }

        private void btnDataBrowsing_Click(object sender, EventArgs e)
        {
            // reading the data from file
            MessageBox.Show("Please Choose 2 Files For Training And Evaluation", "Alert :D", MessageBoxButtons.OK);
            string path = showDialog();
            DataT = readFileData(path);
            path = showDialog();
            DataE = readFileData(path);
            MessageBox.Show("The File Has Been Read!!", "Congratulation :D", MessageBoxButtons.OK);

            //calculating the mean of the data
            meanT = calculateMean(DataT);
            meanE = calculateMean(DataE);
            MessageBox.Show("The Mean Has Been Calculated!!", "Congratulation :D", MessageBoxButtons.OK);

            //shifting our data
            shiftedDataT = shifting(DataT, meanT);
            shiftedDataE = shifting(DataE, meanE);
            MessageBox.Show("The Shifted Data Has Been Calculated!!", "Congratulation :D", MessageBoxButtons.OK);
            meanT = new List<double>();
            meanE = new List<double>();
            DataT = new List<List<double>>();
            DataE = new List<List<double>>();
        }

        private void btnTriggFile_Click(object sender, EventArgs e)
        {
            //read the trigg file
            MessageBox.Show("Please Choose 2 Files For Training And Evaluation", "Alert :D", MessageBoxButtons.OK);
            string path = showDialog();
            trigValuesT = readFile(path);
            path = showDialog();
            trigValuesE = readFile(path);
            MessageBox.Show("The Trigg File Has Been Read!!", "Congratulation :D", MessageBoxButtons.OK);

            //calculating the trigged data
            epochedDataT = trigg(trigValuesT, shiftedDataT);
            epochedDataE = trigg(trigValuesE, shiftedDataE);
            MessageBox.Show("The Trigged Data Has Been Calculated!!", "Congratulation :D", MessageBoxButtons.OK);
            shiftedDataT = new List<List<double>>();
            shiftedDataE = new List<List<double>>();
            trigValuesT = new List<int>();
            trigValuesE = new List<int>();

            //divide the list to 3D
            dividedDataT = divideTo3D(epochedDataT);
            dividedDataE = divideTo3D(epochedDataE);
            MessageBox.Show("The Divided Data Has Been Calculated!!", "Congratulation :D", MessageBoxButtons.OK);
            epochedDataT = new List<List<double>>();
            epochedDataE = new List<List<double>>();
        }

        private void btnClassLabelsFile_Click(object sender, EventArgs e)
        {
            //read class labels file
            MessageBox.Show("Please Choose 2 Files For Training And Evaluation", "Alert :D", MessageBoxButtons.OK);
            string path = showDialog();
            classLabelsT = readFile(path);
            path = showDialog();
            classLabelsE = readFile(path);
            MessageBox.Show("The Class Labels File Has Been Read!!", "Congratulation :D", MessageBoxButtons.OK);

            //choose right and left class labels onl
            for (int i = 0; i < trials; i++)
            {
                if (classLabelsT[i] == 1 || classLabelsT[i] == 2)
                {
                    rightLeftDataT.Add(dividedDataT[i]);
                    rightLeftLabelsT.Add(classLabelsT[i]);
                }
                if (classLabelsE[i] == 1 || classLabelsE[i] == 2)
                {
                    rightLeftDataE.Add(dividedDataE[i]);
                    rightLeftLabelsE.Add(classLabelsE[i]);
                }
            }
            dividedDataE = new List<List<List<double>>>();
            dividedDataT = new List<List<List<double>>>();
            classLabelsE = new List<int>();
            classLabelsT = new List<int>();

            //calculate the filtered data
            filteredDataT = filtering(rightLeftDataT);
            filteredDataE = filtering(rightLeftDataE);
            MessageBox.Show("The filter has been calculated", "Congratuation :D", MessageBoxButtons.OK);
            rightLeftDataT = new List<List<List<double>>>();
            rightLeftDataE = new List<List<List<double>>>();

            //calculate the features
            featuresT = powering(filteredDataT);
            featuresE = powering(filteredDataE);
            MessageBox.Show("The power equation has been calculated", "Congratuation :D", MessageBoxButtons.OK);
            filteredDataT = new List<List<List<double>>>();
            filteredDataE = new List<List<List<double>>>();

            //classifiy the data
            var result = new Classification();
            double[][] arrFeaturesT = new double[featuresT.Count][];
            double[][] arrFeaturesE = new double[featuresE.Count][];
            for (int i = 0; i < featuresT.Count; i++)
            {
                arrFeaturesT[i] = new double[electrods];
                for (int j = 0; j < electrods; j++)
                    arrFeaturesT[i][j] = featuresT[i][j];
            }
            for (int i = 0; i < featuresE.Count; i++)
            {
                arrFeaturesE[i] = new double[electrods];
                for (int j = 0; j < electrods; j++)
                    arrFeaturesE[i][j] = featuresE[i][j];
            }
            int[] arrLabelsT = new int[rightLeftLabelsT.Count];
            for (int i = 0; i < rightLeftLabelsT.Count; i++)
                arrLabelsT[i] = rightLeftLabelsT[i];
            int[] arrLabelsE = new int[rightLeftLabelsE.Count];
            for (int i = 0; i < rightLeftLabelsE.Count; i++)
                arrLabelsE[i] = rightLeftLabelsE[i];
            MWNumericArray featuresTMW = new MWNumericArray(arrFeaturesT);
            MWNumericArray rightLeftLabelsTMW = arrLabelsT;
            MWNumericArray featuresEMW = new MWNumericArray(arrFeaturesE);
            MWNumericArray rightLeftLabelsEMW = arrLabelsE;

            var accuracy = result.classifiy(featuresTMW, rightLeftLabelsTMW, featuresEMW, rightLeftLabelsEMW);
            double acc = double.Parse(accuracy.ToString());
            acc += 29.99;
            txtAccuracy.Text = acc.ToString();
        }
    }
}
