using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOS
{
    public partial class Form1 : Form
    {
        Bitmap off;
        Timer t = new Timer();

        class ProcessData
        {
            public int burstTime;
            public int priority;
            public int arrivalTime;
            public int waiting = 0;
            public int start;
            public int finish;
            public Color clr;
            public String name;
        }

        public class Process
        {
            public int pid; // Process ID 
            public int bt; // Burst Time 
            public int art; // Arrival Time 

            public Process(int pid, int bt, int art)
            {
                this.pid = pid;
                this.bt = bt;
                this.art = art;
            }
        }

        class RectangleAndLine
        {
            public int X, Y, X1, X2, W, H, number;
            public bool showName;
            public Color clr;
            
        }

        class GanttChart
        {
            public int number;
            public String name;
            public Color clr;
        }

        class CNode
        {
            public String name;
            public int vLeft;
            public int vRight;
        }

        int ctTimer = 0;
        int iWhich = 1;
        int numOfProcesses = 0;
        int walkingNumber = -1;
        int tableHeight = 0;
        double avgTAT = 0.0;
        double avgWT = 0.0;
        int[] arrTAT = new int[10];     // 10 can be changed later to be the count of the processes
        int[] arrWT = new int[10];
        int[] tempArrBurstTime = new int[10];       // Because the burst time is changing in both processList and tempProcessList inside calculateAlgorithm()   dkw
        Color[] clrs = { Color.Red, Color.Orange, Color.Yellow, Color.Lime, Color.Cyan, Color.LightSteelBlue, Color.PaleVioletRed, Color.DeepSkyBlue, Color.Magenta, Color.RosyBrown };
        int iWhichColor = 0;
        int f = 0;

        List<ProcessData> processList = new List<ProcessData>();
        List<ProcessData> tempProcessList = new List<ProcessData>();            // Because the name is changing in the processList inside calculateAlgortihm()      dkw
        List<GanttChart> chartList = new List<GanttChart>();
        List<RectangleAndLine> rectList = new List<RectangleAndLine>();
        List<RectangleAndLine> clrsRectList = new List<RectangleAndLine>();
        List<RectangleAndLine> lineList = new List<RectangleAndLine>();
        List<CNode> arrangedList = new List<CNode>();

        public Form1()
        {
            
            InitializeComponent();]
            this.Paint += Form1_Paint;
            t.Tick += T_Tick;
            t.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.Width, this.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawDouble(e.Graphics);
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if(lineList.Count > 0 && iWhich < lineList.Count)
            {
                startAnimating(iWhich);
                f = 1;
            }
            else
            {
                if(f == 1)
                {
                    DisplayAverages();
                    f = 0;
                }
            }
            ctTimer++;
            drawDouble(this.CreateGraphics());
        }

        private void num_p1_burst_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (processList.Count() > 0)
            {
                numOfProcesses = processList.Count();
                for(int i = 0; i < processList.Count; i++)
                {
                    tempArrBurstTime[i] = processList[i].burstTime;
                }
                iWhichColor = 0;
                addTableOfProcesses();
                calculatingAlgorithm();
                hideEverything();
                createTheRectangle();
                createTheLines();
                createClrsRectangles();
                createGanttChartLabel();
                createArrangedList();
                calculateAvgTAT();
                calculateAvgWT();
                
                

                // MessageBox.Show("" + number_ganttChart);
            }
            else
                MessageBox.Show("No Processes Found");
        }

        public void hideEverything()
        {
           int w = (chartList[chartList.Count - 1].number * 35) + 100;
           this.Size = new Size(w, tableHeight + 200);

            if (this.Size.Width < 1350)
            {
                this.Size = new Size(1350, tableHeight + 250);
            }
            label_process.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            num_burst.Visible = false;
            num_priority.Visible = false;
            num_arrival.Visible = false;
            
            off = new Bitmap(this.Width, this.Height);
        }

        public void createGanttChartLabel()
        {
            Label resultLabel = new Label();
            resultLabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            resultLabel.BackColor = System.Drawing.Color.White;
            resultLabel.ForeColor = System.Drawing.Color.Black;
            resultLabel.AutoSize = true;
            resultLabel.Location = new System.Drawing.Point(rectList[0].X + (rectList[0].W / 2) - 100, rectList[0].Y - 65);
            resultLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            resultLabel.Name = "label_gantt_chart";
            resultLabel.Size = new System.Drawing.Size(123, 36);
            resultLabel.TabIndex = 80;
            resultLabel.Text = "Gantt Chart";
            this.Controls.Add(resultLabel);
        }

        public void addTableOfProcesses()
        {
            int yLocation = 183;
            int xLocation = 260;
            int savedXLocation = 260;
            int spaceBetween = 210;
            lbl_burst_l.Location = new System.Drawing.Point(405, 128);
            lbl_priority_l.Location = new System.Drawing.Point(655, 128);
            lbl_arrival_l.Location = new System.Drawing.Point(825, 128);

            for (int i = 0; i < processList.Count(); i++)
            {
                Label resultLabel = new Label();
                resultLabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                resultLabel.BackColor = System.Drawing.Color.White;
                resultLabel.ForeColor = System.Drawing.Color.Black;
                resultLabel.AutoSize = true;
                resultLabel.Location = new System.Drawing.Point(185, yLocation);
                resultLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
                resultLabel.Name = "label_process" + i;
                resultLabel.Size = new System.Drawing.Size(123, 36);
                resultLabel.TabIndex = 74;
                resultLabel.Text = "Process "+ i;
                this.Controls.Add(resultLabel);
                xLocation += spaceBetween;

                resultLabel = new Label();
                resultLabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                resultLabel.BackColor = System.Drawing.Color.White;
                resultLabel.ForeColor = System.Drawing.Color.Black;
                resultLabel.AutoSize = true;
                resultLabel.Location = new System.Drawing.Point(xLocation, yLocation);
                resultLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
                resultLabel.Name = "label_burst_after" + i;
                resultLabel.Size = new System.Drawing.Size(123, 36);
                resultLabel.TabIndex = 75;
                resultLabel.Text = "" + processList[i].burstTime;
                this.Controls.Add(resultLabel);
                xLocation += spaceBetween;

                resultLabel = new Label();
                resultLabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                resultLabel.BackColor = System.Drawing.Color.White;
                resultLabel.ForeColor = System.Drawing.Color.Black;
                resultLabel.AutoSize = true;
                resultLabel.Location = new System.Drawing.Point(xLocation, yLocation);
                resultLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
                resultLabel.Name = "label_priority_after" + i;
                resultLabel.Size = new System.Drawing.Size(123, 36);
                resultLabel.TabIndex = 76;
                resultLabel.Text = "" + processList[i].priority;
                this.Controls.Add(resultLabel);
                xLocation += spaceBetween;

                resultLabel = new Label();
                resultLabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                resultLabel.BackColor = System.Drawing.Color.White;
                resultLabel.ForeColor = System.Drawing.Color.Black;
                resultLabel.AutoSize = true;
                resultLabel.Location = new System.Drawing.Point(xLocation, yLocation);
                resultLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
                resultLabel.Name = "label_arrival_after" + i;
                resultLabel.Size = new System.Drawing.Size(123, 36);
                resultLabel.TabIndex = 77;
                resultLabel.Text = "" + processList[i].arrivalTime;
                this.Controls.Add(resultLabel);

                yLocation += 70;
                xLocation = savedXLocation;
            }

            tableHeight = 183 + yLocation;
        }

        public void DisplayAverages()
        {
            double whichAvg = avgWT;
            String text = "Average Waiting Time: ";
            double vX = 15;
            for (int i = 0; i < 2; i++)
            {
                Label avgLabel = new Label();
                avgLabel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                avgLabel.BackColor = System.Drawing.Color.White;
                avgLabel.ForeColor = System.Drawing.Color.Black;
                avgLabel.AutoSize = true;
                avgLabel.Location = new System.Drawing.Point(Convert.ToInt32(vX), this.Height - 150);
                avgLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
                avgLabel.Name = "label_avg" + i;
                avgLabel.Size = new System.Drawing.Size(123, 36);
                avgLabel.TabIndex = 80;
                avgLabel.Text = "" + text + Math.Round(whichAvg, 2);
                this.Controls.Add(avgLabel);
                whichAvg = avgTAT;
                text = "Average Turn Around Time: ";
                Font font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Bitmap b = new Bitmap(2200, 2200);
                Graphics g = Graphics.FromImage(b);

                //measure the string
                SizeF sizeOfString = new SizeF();
                sizeOfString = g.MeasureString(text + Math.Round(whichAvg, 2), font);
                vX = this.Width - sizeOfString.Width - 25;
            }
        }

        List<ProcessData> SortListArr(List<ProcessData> list)
        {
            for (int i = 0; i < list.Count; i++)
                list.Sort((x, y) => x.arrivalTime.CompareTo(y.arrivalTime));
            return list;
        }
        List<ProcessData> SortListPrio(List<ProcessData> list)
        {
            for (int i = 0; i < list.Count; i++)
                list.Sort((x, y) => x.priority.CompareTo(y.priority));
            return list;
        }


        public void calculatingAlgorithm()
        {
            List<ProcessData> list = tempProcessList;
            list = SortListArr(list);

            int Time = list[0].arrivalTime;
            list[0].start = Time;
            int j = 0;

            int MaxArrivalTime = list[list.Count - 1].arrivalTime;

            List<ProcessData> ResultList = new List<ProcessData>();
            ResultList.Add(list[j]);

            do
            {
                var myItem = list.Find(item => item.arrivalTime == Time);
                if (myItem != null)
                {
                    if (myItem.priority < ResultList[j].priority)
                    {

                        ResultList[j].burstTime -= Time;
                        ResultList[j].finish = Time;
                        if (ResultList[j].burstTime == 0)
                            list.Remove(ResultList[j]);

                        myItem.start = Time;
                        ResultList.Add(myItem);
                        j = ResultList.FindIndex(a => a.start == Time);
                    }
                }
                //Console.WriteLine(Time + "  " + myItem.arrivalTime + "  " + ResultList[j].arrivalTime + "  " + myItem.priority + "  " + ResultList[j].priority);
                Time++;
                

            } while (Time <= MaxArrivalTime);
            ResultList[j].finish = ResultList[j].start + ResultList[j].burstTime;
            ResultFlow.Text = "";

            //ResultFlow.Text += ResultList[0].start + " " + ResultList[0].name + " " + ResultList[0].finish + " ";

            GanttChart pnn = new GanttChart();
            pnn.name = ResultList[0].name;
            pnn.number = ResultList[0].finish;
            pnn.clr = whichColor(pnn.name);
            chartList.Add(pnn);

            for (int y = 1; y < ResultList.Count; y++)
            {
                //ResultFlow.Text += ResultList[y].name + " " + ResultList[y].finish + " ";
                GanttChart pnn2 = new GanttChart();
                pnn2.name = ResultList[y].name;
                pnn2.number = ResultList[y].finish;
                pnn2.clr = whichColor(pnn2.name);
                chartList.Add(pnn2);
            }

            list = SortListPrio(list);

            List<ProcessData> ResultList2 = new List<ProcessData>();
            for (int k = 1; k < list.Count; k++)
            {
                list[k].start = list[k - 1].finish;
                list[k].finish = list[k - 1].finish + list[k].burstTime;

                ResultList2.Add(list[k]);

            }

            for (int y = 0; y < ResultList2.Count; y++)
            {
                if (y == ResultList2.Count - 1)
                {
                    //ResultFlow.Text += ResultList2[y].name + " " + ResultList2[y].finish;
                    GanttChart pnn2 = new GanttChart();
                    pnn2.name = ResultList2[y].name;
                    pnn2.number = ResultList2[y].finish;
                    pnn2.clr = whichColor(pnn2.name);
                    chartList.Add(pnn2);
                }
                else
                {
                    //ResultFlow.Text += ResultList2[y].name + " " + ResultList2[y].finish + " ";
                    GanttChart pnn2 = new GanttChart();
                    pnn2.name = ResultList2[y].name;
                    pnn2.number = ResultList2[y].finish;
                    pnn2.clr = whichColor(pnn2.name);
                    chartList.Add(pnn2);
                }
            }
            iWhichColor = 0;
        }

        public Color whichColor(String processName)
        {
            for(int i = 0; i < processList.Count; i++)
            {
                if(processName == processList[i].name)
                {
                    return processList[i].clr;
                }
            }
            return Color.Yellow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessData pnn = new ProcessData();
            pnn.burstTime = Convert.ToInt32(num_burst.Value);
            pnn.priority = Convert.ToInt32(num_priority.Value);
            pnn.arrivalTime = Convert.ToInt32(num_arrival.Value);
            //pnn.remainingBurstTime = 0;
            pnn.name = "P" + (processList.Count());
            pnn.clr = clrs[iWhichColor];
            iWhichColor++;
            processList.Add(pnn);
            tempProcessList.Add(pnn);
            label2.Text = "Number of Processes: " + (processList.Count());
            label_process.Text = "Process " + (processList.Count());
        }

        public void createTheRectangle()
        {
            RectangleAndLine pnn = new RectangleAndLine();
            pnn.Y = this.Height - 320;
            pnn.W = (chartList[chartList.Count - 1].number * 35);
            pnn.X = (this.Width / 2) - (pnn.W / 2) - 10;
            pnn.H = 80;
            rectList.Add(pnn);

           
        }

        public void createTheLines()
        {
            RectangleAndLine pnn0 = new RectangleAndLine();
            pnn0.X1 = rectList[0].X  - 2;
            pnn0.Y = this.Height - 320;
            pnn0.W = 5;
            pnn0.H = 100;
            pnn0.number = 0;
            pnn0.showName = false;
            lineList.Add(pnn0);
            for (int i = 0; i < chartList.Count; i++)
            {
                RectangleAndLine pnn = new RectangleAndLine();
                if(i == 0)
                    pnn.X1 = lineList[lineList.Count - 1].X1;
                else
                    pnn.X1 = lineList[lineList.Count - 1].X2;

                pnn.X2 = rectList[0].X + (chartList[i].number * 35) - 2;
                pnn.Y = pnn.Y = this.Height - 320;
                pnn.W = 5;
                pnn.H = 100;
                pnn.showName = false;
                pnn.number = chartList[i].number;
                lineList.Add(pnn);
            }
        }

        public void createClrsRectangles()
        {
            for (int i = 0; i < chartList.Count(); i++)
            {
                RectangleAndLine pnnColors = new RectangleAndLine();
                pnnColors.Y = this.Height - 317;
                pnnColors.W = 0;
                pnnColors.X = lineList[i + 1].X1;
                pnnColors.H = 76;
                pnnColors.clr = chartList[i].clr;
                clrsRectList.Add(pnnColors);
            }

            //Console.WriteLine("clrsRect: " + clrsRectList.Count + "   " + lineList.Count);

        }

        public void startAnimating(int i)
        {
                if (walkingNumber < chartList[i - 1].number && ctTimer % 2 /*or less*/ == 0)
                {
                    //Console.WriteLine(walkingNumber + " " + chartList[i - 1].number);
                    walkingNumber++;
                }

            for (int k = 0; k < 7; k++)
            {
                if (lineList[i].X1 < lineList[i].X2)
                {
                    lineList[i].X1++;
                    clrsRectList[i-1].W++;
                    lineList[i].number = walkingNumber;
                }
                else
                {
                    lineList[i].showName = true;
                    iWhich++;
                    break;
                }
            }

            
        }

        public void createArrangedList()
        {
            for (int i = 0; i < lineList.Count; i++)
            {
                if (i < lineList.Count - 1)
                {
                    CNode pnn = new CNode();
                    pnn.name = chartList[i].name;
                    pnn.vLeft = lineList[i].number;
                    pnn.vRight = lineList[i + 1].number;
                    arrangedList.Add(pnn);
                }
                //if(i < lineList.Count - 1)
                //Console.WriteLine("" + lineList[i].number + "  " + lineList[i + 1].number + "   " + chartList[i].name);
            }

        }

        public void calculateAvgTAT()
        {
            double totalTAT = 0.0;
            int tempTAT = 0;
            for(int i = 0; i < tempProcessList.Count; i++)
            {
                for(int j = 0; j < arrangedList.Count; j++)
                {
                    if (tempProcessList[i].name == arrangedList[j].name)
                    {
                        tempTAT = arrangedList[j].vRight;
                    }
                }
                arrTAT[i] = tempTAT - tempProcessList[i].arrivalTime;
                //Console.WriteLine(tempTAT + " - " + tempProcessList[i].arrivalTime);
                totalTAT += arrTAT[i];
            }
            avgTAT = totalTAT / tempProcessList.Count;
        }

        public void calculateAvgWT()
        {
            double totalWT = 0.0;
            for (int i = 0; i < tempProcessList.Count; i++)
            {
                arrWT[i] = arrTAT[i] - tempArrBurstTime[i];
                totalWT += arrWT[i];
            }
            avgWT = totalWT / tempProcessList.Count;
        }


        void drawScene(Graphics g)
        {
            g.Clear(Color.White);
            Pen P = new Pen(Color.Black, 5);
            for (int i = 0; i < rectList.Count(); i++)
            {
                g.DrawRectangle(P, rectList[i].X, rectList[i].Y, rectList[i].W, rectList[i].H);
                
                
            }

            for (int i = 0; i < clrsRectList.Count; i++)
            {
                SolidBrush Br = new SolidBrush(clrsRectList[i].clr);
                g.FillRectangle(Br, clrsRectList[i].X, clrsRectList[i].Y, clrsRectList[i].W, clrsRectList[i].H);
            }

            int vY = 240;
            for (int i = 0; i < lineList.Count(); i++)
            {
                if (i > 0 && i <= processList.Count)
                {
                    g.FillRectangle(Brushes.Black, 150, vY, 900, 3);
                    vY += 70;
                }


                if (i <= iWhich)
                {
                    g.FillRectangle(Brushes.Black, lineList[i].X1, lineList[i].Y, lineList[i].W, lineList[i].H);
                    g.DrawString(lineList[i].number + "", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, lineList[i].X1 - 10, lineList[i].Y + lineList[i].H + 8);
                    if(lineList[i].showName)
                    {
                        g.DrawString(chartList[i - 1].name + "", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, lineList[i - 1].X1 + ((lineList[i].X2 - lineList[i - 1].X1) / 2) - 18, lineList[i].Y  + 24);
                        P = new Pen(Color.Black, 3);

                        Font font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        SizeF sizeOfString = new SizeF();
                        sizeOfString = g.MeasureString((arrangedList[i - 1].vRight - arrangedList[i - 1].vLeft).ToString(), font);
                        if (arrangedList[i - 1].vRight - arrangedList[i - 1].vLeft < 9)
                        {
                            g.DrawEllipse(P, lineList[i - 1].X1 + ((lineList[i].X2 - lineList[i - 1].X1) / 2) - 11, lineList[i].Y + lineList[i].H - 11, Convert.ToInt32(sizeOfString.Width) + 5, Convert.ToInt32(sizeOfString.Width) + 5);
                            g.DrawString(arrangedList[i - 1].vRight - arrangedList[i - 1].vLeft + "", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, lineList[i - 1].X1 + ((lineList[i].X2 - lineList[i - 1].X1) / 2) - 8, lineList[i].Y + lineList[i].H - 10);
                        }
                        else
                        {
                            g.DrawEllipse(P, lineList[i - 1].X1 + ((lineList[i].X2 - lineList[i - 1].X1) / 2) - 11, lineList[i].Y + lineList[i].H - 11, Convert.ToInt32(sizeOfString.Width) + 3, Convert.ToInt32(sizeOfString.Width) + 3);
                            g.DrawString(arrangedList[i - 1].vRight - arrangedList[i - 1].vLeft + "", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, lineList[i - 1].X1 + ((lineList[i].X2 - lineList[i - 1].X1) / 2) - 9, lineList[i].Y + lineList[i].H - 5);
                        }
                    }

                   
                }
                
            }
        }

        void drawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }

    
}
