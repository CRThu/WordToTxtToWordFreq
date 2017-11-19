using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Word = Microsoft.Office.Interop.Word;

namespace WordToTxt
{
    struct WordFreq
    {
        public string Word;
        public int Freq;
    }
    public partial class Form1 : Form
    {
        Word.Application WordApp;
        Word.Document WordDoc;
        List<WordFreq> DecodeList = new List<WordFreq>();

        void Chartinit()
        {
            // Chart Clear Param
            chtFreq.Annotations.Clear();
            chtFreq.ChartAreas.Clear();
            chtFreq.Legends.Clear();
            chtFreq.Series.Clear();
            chtFreq.Titles.Clear();

            // Title
            Title chtDataTitle = new Title("Freq");
            chtFreq.Titles.Add(chtDataTitle);
            // ChartArea
            ChartArea chtDataChartArea = new ChartArea("ChartArea");
            chtFreq.ChartAreas.Add(chtDataChartArea);

            chtFreq.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;   // 设置滚动条外部显示
            chtFreq.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chtFreq.ChartAreas[0].AxisX.Minimum = 0;

            // Series
            Series chtDataSeries = new Series("chtDataSeries");
            chtDataSeries.Font = new Font("微软雅黑", 14, FontStyle.Bold);
            chtDataSeries.ChartType = SeriesChartType.Column;
            chtFreq.Series.Add(chtDataSeries);
            // Legend
            Legend chtDataLegend = new Legend("chtDataLegend");
            chtFreq.Legends.Add(chtDataLegend);

            chtFreq.ChartAreas[0].AxisX.ScaleView.Size = 5;           // 可见数据点数
            chtFreq.ChartAreas[0].AxisX.ScaleView.MinSize = 1;       // 步进
            chtFreq.ChartAreas[0].AxisX.Interval = 1;                       // 设置X轴间隔

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                if (string.IsNullOrWhiteSpace(openFileDialog1.FileName))
                    throw new FileNotFoundException();
                lbFilePath.Text = openFileDialog1.FileName;
                Chartinit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnProc_Click(object sender, EventArgs e)
        {
            try
            {
                // 新建应用类
                WordApp = new Word.ApplicationClass();
                WordApp.Visible = true;
                //新建文件类
                //WordDoc = WordApp.Documents.Open(@"C:\Users\YummyCarrot\Desktop\a.docx");
                WordDoc = WordApp.Documents.Open(openFileDialog1.FileName);
                WordDoc.Activate();

                tbGetText.Text = WordDoc.Content.Text.Replace("\r", "\r\n");
                System.IO.File.WriteAllText("temp.txt", WordDoc.Content.Text.Replace("\r", "\r\n"), System.Text.Encoding.GetEncoding("GB2312"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            try
            {
                TxtToWordFreq.Start();

                if (!TxtToWordFreq.WaitForExit(10000))
                    throw new TimeoutException();

                string DecodeStr;
                DecodeStr = System.IO.File.ReadAllText("log.txt", System.Text.Encoding.GetEncoding("GB2312"));

                string[] DecodeStrArray;
                DecodeStrArray = DecodeStr.Split(new char[] { ' ' });

                WordFreq Temp;

                for (int i = 0; i < DecodeStrArray.Length; i += 2)
                {
                    if (DecodeStrArray[i] != "")
                    {
                        Temp.Word = DecodeStrArray[i];
                        Temp.Freq = Convert.ToInt32(DecodeStrArray[i + 1].Replace(",", ""));

                        DecodeList.Add(Temp);
                    }
                }

                // order

                DecodeList.Sort(delegate (WordFreq x, WordFreq y)
                {
                    return y.Freq.CompareTo(x.Freq);
                });


                // ToChart

                for (int i = 0; i < DecodeList.Count; i++)
                {
                    DataPoint DataPointTemp = new DataPoint();
                    DataPointTemp.Label = DecodeList[i].Word + ":" + DecodeList[i].Freq;
                    DataPointTemp.SetValueXY(i + 1, DecodeList[i].Freq);
                    chtFreq.Series[0].Points.Add(DataPointTemp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                WordDoc.Close();
                WordApp.Quit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
