namespace CST211GradeMe
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
            this.btnGradeMe = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIndexOf = new System.Windows.Forms.Button();
            this.btnGetAt = new System.Windows.Forms.Button();
            this.btnListSetAt = new System.Windows.Forms.Button();
            this.txtListSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboListType = new System.Windows.Forms.ComboBox();
            this.txtListIndex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtListValue = new System.Windows.Forms.TextBox();
            this.btnListAddAt = new System.Windows.Forms.Button();
            this.btnListRemove = new System.Windows.Forms.Button();
            this.btnListAddToEnd = new System.Windows.Forms.Button();
            this.txtListContents = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtExpressionValue = new System.Windows.Forms.TextBox();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.txtPostfixExpression = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStackPush = new System.Windows.Forms.Button();
            this.btnStackPop = new System.Windows.Forms.Button();
            this.btnStackPeek = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStackEmpty = new System.Windows.Forms.TextBox();
            this.txtStackValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBankSeed = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBankAvgWaitTime = new System.Windows.Forms.TextBox();
            this.txtBankCustsWaiting = new System.Windows.Forms.TextBox();
            this.txtBankCustsServed = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBankRun = new System.Windows.Forms.Button();
            this.txtBankRunTime = new System.Windows.Forms.TextBox();
            this.txtBankTellerCount = new System.Windows.Forms.TextBox();
            this.txtBankProcessingTime = new System.Windows.Forms.TextBox();
            this.txtBankArrivalRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnQueueRemove = new System.Windows.Forms.Button();
            this.btnQueueInsert = new System.Windows.Forms.Button();
            this.btnQueuePeek = new System.Windows.Forms.Button();
            this.txtQueueEmpty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQueueSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQueueValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboOrderedType = new System.Windows.Forms.ComboBox();
            this.btnOrderedFind = new System.Windows.Forms.Button();
            this.txtOrderedSize = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtOrderedContents = new System.Windows.Forms.TextBox();
            this.btnOrderedAdd = new System.Windows.Forms.Button();
            this.txtOrderedValue = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnOrderedRemove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGradeMe
            // 
            this.btnGradeMe.Location = new System.Drawing.Point(12, 12);
            this.btnGradeMe.Name = "btnGradeMe";
            this.btnGradeMe.Size = new System.Drawing.Size(75, 23);
            this.btnGradeMe.TabIndex = 0;
            this.btnGradeMe.Text = "Grade Me!";
            this.btnGradeMe.UseVisualStyleBackColor = true;
            this.btnGradeMe.Click += new System.EventHandler(this.btnGradeMe_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIndexOf);
            this.groupBox1.Controls.Add(this.btnGetAt);
            this.groupBox1.Controls.Add(this.btnListSetAt);
            this.groupBox1.Controls.Add(this.txtListSize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboListType);
            this.groupBox1.Controls.Add(this.txtListIndex);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtListValue);
            this.groupBox1.Controls.Add(this.btnListAddAt);
            this.groupBox1.Controls.Add(this.btnListRemove);
            this.groupBox1.Controls.Add(this.btnListAddToEnd);
            this.groupBox1.Controls.Add(this.txtListContents);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List ADT:";
            // 
            // btnIndexOf
            // 
            this.btnIndexOf.Location = new System.Drawing.Point(72, 192);
            this.btnIndexOf.Name = "btnIndexOf";
            this.btnIndexOf.Size = new System.Drawing.Size(75, 23);
            this.btnIndexOf.TabIndex = 10;
            this.btnIndexOf.Text = "Index Of";
            this.btnIndexOf.UseVisualStyleBackColor = true;
            this.btnIndexOf.Click += new System.EventHandler(this.btnIndexOf_Click);
            // 
            // btnGetAt
            // 
            this.btnGetAt.Location = new System.Drawing.Point(72, 162);
            this.btnGetAt.Name = "btnGetAt";
            this.btnGetAt.Size = new System.Drawing.Size(75, 23);
            this.btnGetAt.TabIndex = 9;
            this.btnGetAt.Text = "Get At";
            this.btnGetAt.UseVisualStyleBackColor = true;
            this.btnGetAt.Click += new System.EventHandler(this.btnGetAt_Click);
            // 
            // btnListSetAt
            // 
            this.btnListSetAt.Location = new System.Drawing.Point(72, 132);
            this.btnListSetAt.Name = "btnListSetAt";
            this.btnListSetAt.Size = new System.Drawing.Size(75, 23);
            this.btnListSetAt.TabIndex = 8;
            this.btnListSetAt.Text = "Set At";
            this.btnListSetAt.UseVisualStyleBackColor = true;
            this.btnListSetAt.Click += new System.EventHandler(this.btnListSetAt_Click);
            // 
            // txtListSize
            // 
            this.txtListSize.Location = new System.Drawing.Point(190, 195);
            this.txtListSize.Name = "txtListSize";
            this.txtListSize.ReadOnly = true;
            this.txtListSize.Size = new System.Drawing.Size(107, 20);
            this.txtListSize.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Size:";
            // 
            // comboListType
            // 
            this.comboListType.FormattingEnabled = true;
            this.comboListType.Items.AddRange(new object[] {
            "ArrayList",
            "LinkedList"});
            this.comboListType.Location = new System.Drawing.Point(153, 20);
            this.comboListType.Name = "comboListType";
            this.comboListType.Size = new System.Drawing.Size(144, 21);
            this.comboListType.TabIndex = 0;
            this.comboListType.SelectedValueChanged += new System.EventHandler(this.comboListType_SelectedValueChanged);
            // 
            // txtListIndex
            // 
            this.txtListIndex.Location = new System.Drawing.Point(6, 92);
            this.txtListIndex.Name = "txtListIndex";
            this.txtListIndex.Size = new System.Drawing.Size(59, 20);
            this.txtListIndex.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Index:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value:";
            // 
            // txtListValue
            // 
            this.txtListValue.Location = new System.Drawing.Point(6, 43);
            this.txtListValue.Name = "txtListValue";
            this.txtListValue.Size = new System.Drawing.Size(59, 20);
            this.txtListValue.TabIndex = 2;
            // 
            // btnListAddAt
            // 
            this.btnListAddAt.Location = new System.Drawing.Point(72, 73);
            this.btnListAddAt.Name = "btnListAddAt";
            this.btnListAddAt.Size = new System.Drawing.Size(75, 23);
            this.btnListAddAt.TabIndex = 6;
            this.btnListAddAt.Text = "Add At";
            this.btnListAddAt.UseVisualStyleBackColor = true;
            this.btnListAddAt.Click += new System.EventHandler(this.btnListAddAt_Click);
            // 
            // btnListRemove
            // 
            this.btnListRemove.Location = new System.Drawing.Point(72, 102);
            this.btnListRemove.Name = "btnListRemove";
            this.btnListRemove.Size = new System.Drawing.Size(75, 23);
            this.btnListRemove.TabIndex = 7;
            this.btnListRemove.Text = "Remove";
            this.btnListRemove.UseVisualStyleBackColor = true;
            this.btnListRemove.Click += new System.EventHandler(this.btnListRemove_Click);
            // 
            // btnListAddToEnd
            // 
            this.btnListAddToEnd.Location = new System.Drawing.Point(72, 43);
            this.btnListAddToEnd.Name = "btnListAddToEnd";
            this.btnListAddToEnd.Size = new System.Drawing.Size(75, 23);
            this.btnListAddToEnd.TabIndex = 5;
            this.btnListAddToEnd.Text = "Add to End";
            this.btnListAddToEnd.UseVisualStyleBackColor = true;
            this.btnListAddToEnd.Click += new System.EventHandler(this.btnListAddToEnd_Click);
            // 
            // txtListContents
            // 
            this.txtListContents.Location = new System.Drawing.Point(153, 43);
            this.txtListContents.Multiline = true;
            this.txtListContents.Name = "txtListContents";
            this.txtListContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtListContents.Size = new System.Drawing.Size(144, 142);
            this.txtListContents.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtExpressionValue);
            this.groupBox2.Controls.Add(this.btnEvaluate);
            this.groupBox2.Controls.Add(this.txtPostfixExpression);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnStackPush);
            this.groupBox2.Controls.Add(this.btnStackPop);
            this.groupBox2.Controls.Add(this.btnStackPeek);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtStackEmpty);
            this.groupBox2.Controls.Add(this.txtStackValue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(322, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 225);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stack ADT:";
            // 
            // txtExpressionValue
            // 
            this.txtExpressionValue.Location = new System.Drawing.Point(89, 177);
            this.txtExpressionValue.Name = "txtExpressionValue";
            this.txtExpressionValue.ReadOnly = true;
            this.txtExpressionValue.Size = new System.Drawing.Size(63, 20);
            this.txtExpressionValue.TabIndex = 10;
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Location = new System.Drawing.Point(7, 175);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(75, 23);
            this.btnEvaluate.TabIndex = 9;
            this.btnEvaluate.Text = "Evaluate";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // txtPostfixExpression
            // 
            this.txtPostfixExpression.Location = new System.Drawing.Point(7, 149);
            this.txtPostfixExpression.Name = "txtPostfixExpression";
            this.txtPostfixExpression.Size = new System.Drawing.Size(146, 20);
            this.txtPostfixExpression.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Post-fix Expression:";
            // 
            // btnStackPush
            // 
            this.btnStackPush.Location = new System.Drawing.Point(78, 103);
            this.btnStackPush.Name = "btnStackPush";
            this.btnStackPush.Size = new System.Drawing.Size(75, 23);
            this.btnStackPush.TabIndex = 6;
            this.btnStackPush.Text = "Push";
            this.btnStackPush.UseVisualStyleBackColor = true;
            this.btnStackPush.Click += new System.EventHandler(this.btnStackPush_Click);
            // 
            // btnStackPop
            // 
            this.btnStackPop.Location = new System.Drawing.Point(78, 73);
            this.btnStackPop.Name = "btnStackPop";
            this.btnStackPop.Size = new System.Drawing.Size(75, 23);
            this.btnStackPop.TabIndex = 5;
            this.btnStackPop.Text = "Pop";
            this.btnStackPop.UseVisualStyleBackColor = true;
            this.btnStackPop.Click += new System.EventHandler(this.btnStackPop_Click);
            // 
            // btnStackPeek
            // 
            this.btnStackPeek.Location = new System.Drawing.Point(77, 43);
            this.btnStackPeek.Name = "btnStackPeek";
            this.btnStackPeek.Size = new System.Drawing.Size(75, 23);
            this.btnStackPeek.TabIndex = 4;
            this.btnStackPeek.Text = "Peek";
            this.btnStackPeek.UseVisualStyleBackColor = true;
            this.btnStackPeek.Click += new System.EventHandler(this.btnStackPeek_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Empty:";
            // 
            // txtStackEmpty
            // 
            this.txtStackEmpty.Location = new System.Drawing.Point(9, 84);
            this.txtStackEmpty.Name = "txtStackEmpty";
            this.txtStackEmpty.ReadOnly = true;
            this.txtStackEmpty.Size = new System.Drawing.Size(62, 20);
            this.txtStackEmpty.TabIndex = 3;
            // 
            // txtStackValue
            // 
            this.txtStackValue.Location = new System.Drawing.Point(9, 41);
            this.txtStackValue.Name = "txtStackValue";
            this.txtStackValue.Size = new System.Drawing.Size(62, 20);
            this.txtStackValue.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Value:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBankSeed);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtBankAvgWaitTime);
            this.groupBox3.Controls.Add(this.txtBankCustsWaiting);
            this.groupBox3.Controls.Add(this.txtBankCustsServed);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.btnBankRun);
            this.groupBox3.Controls.Add(this.txtBankRunTime);
            this.groupBox3.Controls.Add(this.txtBankTellerCount);
            this.groupBox3.Controls.Add(this.txtBankProcessingTime);
            this.groupBox3.Controls.Add(this.txtBankArrivalRate);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnQueueRemove);
            this.groupBox3.Controls.Add(this.btnQueueInsert);
            this.groupBox3.Controls.Add(this.btnQueuePeek);
            this.groupBox3.Controls.Add(this.txtQueueEmpty);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtQueueSize);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtQueueValue);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(489, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 381);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Queue ADT:";
            // 
            // txtBankSeed
            // 
            this.txtBankSeed.Location = new System.Drawing.Point(133, 253);
            this.txtBankSeed.Name = "txtBankSeed";
            this.txtBankSeed.Size = new System.Drawing.Size(55, 20);
            this.txtBankSeed.TabIndex = 18;
            this.txtBankSeed.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 256);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Seed:";
            // 
            // txtBankAvgWaitTime
            // 
            this.txtBankAvgWaitTime.Location = new System.Drawing.Point(133, 352);
            this.txtBankAvgWaitTime.Name = "txtBankAvgWaitTime";
            this.txtBankAvgWaitTime.ReadOnly = true;
            this.txtBankAvgWaitTime.Size = new System.Drawing.Size(55, 20);
            this.txtBankAvgWaitTime.TabIndex = 25;
            // 
            // txtBankCustsWaiting
            // 
            this.txtBankCustsWaiting.Location = new System.Drawing.Point(133, 326);
            this.txtBankCustsWaiting.Name = "txtBankCustsWaiting";
            this.txtBankCustsWaiting.ReadOnly = true;
            this.txtBankCustsWaiting.Size = new System.Drawing.Size(55, 20);
            this.txtBankCustsWaiting.TabIndex = 23;
            // 
            // txtBankCustsServed
            // 
            this.txtBankCustsServed.Location = new System.Drawing.Point(133, 300);
            this.txtBankCustsServed.Name = "txtBankCustsServed";
            this.txtBankCustsServed.ReadOnly = true;
            this.txtBankCustsServed.Size = new System.Drawing.Size(55, 20);
            this.txtBankCustsServed.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 355);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Avg Wait Time (Min):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 329);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Customers Waiting:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Customers Served:";
            // 
            // btnBankRun
            // 
            this.btnBankRun.Location = new System.Drawing.Point(10, 273);
            this.btnBankRun.Name = "btnBankRun";
            this.btnBankRun.Size = new System.Drawing.Size(75, 23);
            this.btnBankRun.TabIndex = 19;
            this.btnBankRun.Text = "Run";
            this.btnBankRun.UseVisualStyleBackColor = true;
            this.btnBankRun.Click += new System.EventHandler(this.btnBankRun_Click);
            // 
            // txtBankRunTime
            // 
            this.txtBankRunTime.Location = new System.Drawing.Point(133, 228);
            this.txtBankRunTime.Name = "txtBankRunTime";
            this.txtBankRunTime.Size = new System.Drawing.Size(55, 20);
            this.txtBankRunTime.TabIndex = 16;
            // 
            // txtBankTellerCount
            // 
            this.txtBankTellerCount.Location = new System.Drawing.Point(133, 202);
            this.txtBankTellerCount.Name = "txtBankTellerCount";
            this.txtBankTellerCount.Size = new System.Drawing.Size(55, 20);
            this.txtBankTellerCount.TabIndex = 14;
            // 
            // txtBankProcessingTime
            // 
            this.txtBankProcessingTime.Location = new System.Drawing.Point(133, 176);
            this.txtBankProcessingTime.Name = "txtBankProcessingTime";
            this.txtBankProcessingTime.Size = new System.Drawing.Size(55, 20);
            this.txtBankProcessingTime.TabIndex = 12;
            // 
            // txtBankArrivalRate
            // 
            this.txtBankArrivalRate.Location = new System.Drawing.Point(133, 149);
            this.txtBankArrivalRate.Name = "txtBankArrivalRate";
            this.txtBankArrivalRate.Size = new System.Drawing.Size(55, 20);
            this.txtBankArrivalRate.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Teller Count:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Processing Time (min):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Arrival Rate (cust/hr):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Run Time (min):";
            // 
            // btnQueueRemove
            // 
            this.btnQueueRemove.Location = new System.Drawing.Point(71, 73);
            this.btnQueueRemove.Name = "btnQueueRemove";
            this.btnQueueRemove.Size = new System.Drawing.Size(75, 23);
            this.btnQueueRemove.TabIndex = 7;
            this.btnQueueRemove.Text = "Remove";
            this.btnQueueRemove.UseVisualStyleBackColor = true;
            this.btnQueueRemove.Click += new System.EventHandler(this.btnQueueRemove_Click);
            // 
            // btnQueueInsert
            // 
            this.btnQueueInsert.Location = new System.Drawing.Point(71, 103);
            this.btnQueueInsert.Name = "btnQueueInsert";
            this.btnQueueInsert.Size = new System.Drawing.Size(75, 23);
            this.btnQueueInsert.TabIndex = 8;
            this.btnQueueInsert.Text = "Insert";
            this.btnQueueInsert.UseVisualStyleBackColor = true;
            this.btnQueueInsert.Click += new System.EventHandler(this.btnQueueInsert_Click);
            // 
            // btnQueuePeek
            // 
            this.btnQueuePeek.Location = new System.Drawing.Point(71, 40);
            this.btnQueuePeek.Name = "btnQueuePeek";
            this.btnQueuePeek.Size = new System.Drawing.Size(75, 23);
            this.btnQueuePeek.TabIndex = 6;
            this.btnQueuePeek.Text = "Peek";
            this.btnQueuePeek.UseVisualStyleBackColor = true;
            this.btnQueuePeek.Click += new System.EventHandler(this.btnQueuePeek_Click);
            // 
            // txtQueueEmpty
            // 
            this.txtQueueEmpty.Location = new System.Drawing.Point(7, 124);
            this.txtQueueEmpty.Name = "txtQueueEmpty";
            this.txtQueueEmpty.ReadOnly = true;
            this.txtQueueEmpty.Size = new System.Drawing.Size(57, 20);
            this.txtQueueEmpty.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Empty:";
            // 
            // txtQueueSize
            // 
            this.txtQueueSize.Location = new System.Drawing.Point(7, 84);
            this.txtQueueSize.Name = "txtQueueSize";
            this.txtQueueSize.ReadOnly = true;
            this.txtQueueSize.Size = new System.Drawing.Size(57, 20);
            this.txtQueueSize.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Size:";
            // 
            // txtQueueValue
            // 
            this.txtQueueValue.Location = new System.Drawing.Point(7, 40);
            this.txtQueueValue.Name = "txtQueueValue";
            this.txtQueueValue.Size = new System.Drawing.Size(57, 20);
            this.txtQueueValue.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Value:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOrderedRemove);
            this.groupBox4.Controls.Add(this.comboOrderedType);
            this.groupBox4.Controls.Add(this.btnOrderedFind);
            this.groupBox4.Controls.Add(this.txtOrderedSize);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtOrderedContents);
            this.groupBox4.Controls.Add(this.btnOrderedAdd);
            this.groupBox4.Controls.Add(this.txtOrderedValue);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(18, 283);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(297, 150);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ordered List:";
            // 
            // comboOrderedType
            // 
            this.comboOrderedType.FormattingEnabled = true;
            this.comboOrderedType.Location = new System.Drawing.Point(147, 17);
            this.comboOrderedType.Name = "comboOrderedType";
            this.comboOrderedType.Size = new System.Drawing.Size(144, 21);
            this.comboOrderedType.TabIndex = 7;
            this.comboOrderedType.SelectedValueChanged += new System.EventHandler(this.comboOrderedType_SelectedValueChanged);
            // 
            // btnOrderedFind
            // 
            this.btnOrderedFind.Location = new System.Drawing.Point(66, 74);
            this.btnOrderedFind.Name = "btnOrderedFind";
            this.btnOrderedFind.Size = new System.Drawing.Size(75, 23);
            this.btnOrderedFind.TabIndex = 6;
            this.btnOrderedFind.Text = "Find";
            this.btnOrderedFind.UseVisualStyleBackColor = true;
            this.btnOrderedFind.Click += new System.EventHandler(this.btnOrderedFind_Click);
            // 
            // txtOrderedSize
            // 
            this.txtOrderedSize.Location = new System.Drawing.Point(180, 121);
            this.txtOrderedSize.Name = "txtOrderedSize";
            this.txtOrderedSize.ReadOnly = true;
            this.txtOrderedSize.Size = new System.Drawing.Size(100, 20);
            this.txtOrderedSize.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(144, 124);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Size:";
            // 
            // txtOrderedContents
            // 
            this.txtOrderedContents.Location = new System.Drawing.Point(148, 42);
            this.txtOrderedContents.Multiline = true;
            this.txtOrderedContents.Name = "txtOrderedContents";
            this.txtOrderedContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOrderedContents.Size = new System.Drawing.Size(143, 73);
            this.txtOrderedContents.TabIndex = 3;
            // 
            // btnOrderedAdd
            // 
            this.btnOrderedAdd.Location = new System.Drawing.Point(66, 44);
            this.btnOrderedAdd.Name = "btnOrderedAdd";
            this.btnOrderedAdd.Size = new System.Drawing.Size(75, 23);
            this.btnOrderedAdd.TabIndex = 2;
            this.btnOrderedAdd.Text = "Add";
            this.btnOrderedAdd.UseVisualStyleBackColor = true;
            this.btnOrderedAdd.Click += new System.EventHandler(this.btnOrderedAdd_Click);
            // 
            // txtOrderedValue
            // 
            this.txtOrderedValue.Location = new System.Drawing.Point(7, 44);
            this.txtOrderedValue.Name = "txtOrderedValue";
            this.txtOrderedValue.Size = new System.Drawing.Size(52, 20);
            this.txtOrderedValue.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Value:";
            // 
            // btnOrderedRemove
            // 
            this.btnOrderedRemove.Location = new System.Drawing.Point(66, 104);
            this.btnOrderedRemove.Name = "btnOrderedRemove";
            this.btnOrderedRemove.Size = new System.Drawing.Size(75, 23);
            this.btnOrderedRemove.TabIndex = 8;
            this.btnOrderedRemove.Text = "Remove";
            this.btnOrderedRemove.UseVisualStyleBackColor = true;
            this.btnOrderedRemove.Click += new System.EventHandler(this.btnOrderedRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 472);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGradeMe);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGradeMe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtListContents;
        private System.Windows.Forms.Button btnListRemove;
        private System.Windows.Forms.Button btnListAddToEnd;
        private System.Windows.Forms.TextBox txtListValue;
        private System.Windows.Forms.Button btnListAddAt;
        private System.Windows.Forms.TextBox txtListIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboListType;
        private System.Windows.Forms.TextBox txtListSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListSetAt;
        private System.Windows.Forms.Button btnGetAt;
        private System.Windows.Forms.Button btnIndexOf;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStackPush;
        private System.Windows.Forms.Button btnStackPop;
        private System.Windows.Forms.Button btnStackPeek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStackEmpty;
        private System.Windows.Forms.TextBox txtStackValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExpressionValue;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.TextBox txtPostfixExpression;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtQueueSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQueueValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnQueueInsert;
        private System.Windows.Forms.Button btnQueuePeek;
        private System.Windows.Forms.TextBox txtQueueEmpty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnQueueRemove;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnBankRun;
        private System.Windows.Forms.TextBox txtBankRunTime;
        private System.Windows.Forms.TextBox txtBankTellerCount;
        private System.Windows.Forms.TextBox txtBankProcessingTime;
        private System.Windows.Forms.TextBox txtBankArrivalRate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBankAvgWaitTime;
        private System.Windows.Forms.TextBox txtBankCustsWaiting;
        private System.Windows.Forms.TextBox txtBankCustsServed;
        private System.Windows.Forms.TextBox txtBankSeed;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtOrderedSize;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtOrderedContents;
        private System.Windows.Forms.Button btnOrderedAdd;
        private System.Windows.Forms.TextBox txtOrderedValue;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnOrderedFind;
        private System.Windows.Forms.ComboBox comboOrderedType;
        private System.Windows.Forms.Button btnOrderedRemove;
    }
}

