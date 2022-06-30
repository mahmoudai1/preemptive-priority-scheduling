namespace ProjectOS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.num_arrival = new System.Windows.Forms.NumericUpDown();
            this.num_priority = new System.Windows.Forms.NumericUpDown();
            this.num_burst = new System.Windows.Forms.NumericUpDown();
            this.label_process = new System.Windows.Forms.Label();
            this.lbl_arrival_l = new System.Windows.Forms.Label();
            this.lbl_burst_l = new System.Windows.Forms.Label();
            this.lbl_priority_l = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ResultFlow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_arrival)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_priority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_burst)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(894, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "Preemptive Priority Scheduling Algorithm";
            // 
            // num_arrival
            // 
            this.num_arrival.BackColor = System.Drawing.Color.White;
            this.num_arrival.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_arrival.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_arrival.Location = new System.Drawing.Point(758, 170);
            this.num_arrival.Margin = new System.Windows.Forms.Padding(6);
            this.num_arrival.Name = "num_arrival";
            this.num_arrival.Size = new System.Drawing.Size(122, 63);
            this.num_arrival.TabIndex = 66;
            this.num_arrival.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // num_priority
            // 
            this.num_priority.BackColor = System.Drawing.Color.White;
            this.num_priority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_priority.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_priority.Location = new System.Drawing.Point(588, 170);
            this.num_priority.Margin = new System.Windows.Forms.Padding(6);
            this.num_priority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_priority.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_priority.Name = "num_priority";
            this.num_priority.Size = new System.Drawing.Size(120, 63);
            this.num_priority.TabIndex = 61;
            this.num_priority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_priority.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_burst
            // 
            this.num_burst.BackColor = System.Drawing.Color.White;
            this.num_burst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_burst.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_burst.Location = new System.Drawing.Point(408, 170);
            this.num_burst.Margin = new System.Windows.Forms.Padding(6);
            this.num_burst.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_burst.Name = "num_burst";
            this.num_burst.Size = new System.Drawing.Size(120, 63);
            this.num_burst.TabIndex = 56;
            this.num_burst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_burst.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_burst.ValueChanged += new System.EventHandler(this.num_p1_burst_ValueChanged);
            // 
            // label_process
            // 
            this.label_process.AutoSize = true;
            this.label_process.BackColor = System.Drawing.Color.White;
            this.label_process.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_process.ForeColor = System.Drawing.Color.Gray;
            this.label_process.Location = new System.Drawing.Point(249, 183);
            this.label_process.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_process.Name = "label_process";
            this.label_process.Size = new System.Drawing.Size(123, 36);
            this.label_process.TabIndex = 74;
            this.label_process.Text = "Process 0";
            // 
            // lbl_arrival_l
            // 
            this.lbl_arrival_l.AutoSize = true;
            this.lbl_arrival_l.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_arrival_l.ForeColor = System.Drawing.Color.Gray;
            this.lbl_arrival_l.Location = new System.Drawing.Point(730, 123);
            this.lbl_arrival_l.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_arrival_l.Name = "lbl_arrival_l";
            this.lbl_arrival_l.Size = new System.Drawing.Size(201, 36);
            this.lbl_arrival_l.TabIndex = 73;
            this.lbl_arrival_l.Text = "Arrival time (ms)";
            // 
            // lbl_burst_l
            // 
            this.lbl_burst_l.AutoSize = true;
            this.lbl_burst_l.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_burst_l.ForeColor = System.Drawing.Color.Gray;
            this.lbl_burst_l.Location = new System.Drawing.Point(370, 123);
            this.lbl_burst_l.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_burst_l.Name = "lbl_burst_l";
            this.lbl_burst_l.Size = new System.Drawing.Size(188, 36);
            this.lbl_burst_l.TabIndex = 71;
            this.lbl_burst_l.Text = "Burst time (ms)";
            // 
            // lbl_priority_l
            // 
            this.lbl_priority_l.AutoSize = true;
            this.lbl_priority_l.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_priority_l.ForeColor = System.Drawing.Color.Gray;
            this.lbl_priority_l.Location = new System.Drawing.Point(595, 123);
            this.lbl_priority_l.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_priority_l.Name = "lbl_priority_l";
            this.lbl_priority_l.Size = new System.Drawing.Size(97, 36);
            this.lbl_priority_l.TabIndex = 72;
            this.lbl_priority_l.Text = "Priority";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(976, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(286, 68);
            this.button1.TabIndex = 79;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 31);
            this.label2.TabIndex = 80;
            this.label2.Text = "Number of Processes: 0";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(928, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 63);
            this.button2.TabIndex = 81;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ResultFlow
            // 
            this.ResultFlow.AutoSize = true;
            this.ResultFlow.Enabled = false;
            this.ResultFlow.Location = new System.Drawing.Point(13, 20);
            this.ResultFlow.Name = "ResultFlow";
            this.ResultFlow.Size = new System.Drawing.Size(70, 25);
            this.ResultFlow.TabIndex = 82;
            this.ResultFlow.Text = "label3";
            this.ResultFlow.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1286, 386);
            this.Controls.Add(this.ResultFlow);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_process);
            this.Controls.Add(this.lbl_arrival_l);
            this.Controls.Add(this.lbl_burst_l);
            this.Controls.Add(this.lbl_priority_l);
            this.Controls.Add(this.num_arrival);
            this.Controls.Add(this.num_priority);
            this.Controls.Add(this.num_burst);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " OS Mahmoud\'s Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_arrival)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_priority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_burst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_arrival;
        private System.Windows.Forms.NumericUpDown num_priority;
        private System.Windows.Forms.NumericUpDown num_burst;
        private System.Windows.Forms.Label label_process;
        private System.Windows.Forms.Label lbl_arrival_l;
        private System.Windows.Forms.Label lbl_burst_l;
        private System.Windows.Forms.Label lbl_priority_l;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ResultFlow;
    }
}

