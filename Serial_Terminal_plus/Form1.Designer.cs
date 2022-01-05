using System.Windows.Forms;

namespace Serial_Terminal_plus
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxLocalEcho = new System.Windows.Forms.CheckBox();
            this.cboxTimeStamp = new System.Windows.Forms.CheckBox();
            this.tboxTextToSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tboxReceivedText = new System.Windows.Forms.TextBox();
            this.cmbLBSend = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLBReceive = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxCleartext = new System.Windows.Forms.CheckBox();
            this.buttonsavebuttons = new System.Windows.Forms.Button();
            this.buttonloadbuttons = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(14, 27);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(63, 20);
            this.cmbPortName.TabIndex = 0;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(94, 27);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(63, 20);
            this.cmbBaudRate.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(754, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(105, 34);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud";
            // 
            // cboxLocalEcho
            // 
            this.cboxLocalEcho.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.cboxLocalEcho.AutoSize = true;
            this.cboxLocalEcho.Location = new System.Drawing.Point(186, 10);
            this.cboxLocalEcho.Name = "cboxLocalEcho";
            this.cboxLocalEcho.Size = new System.Drawing.Size(80, 16);
            this.cboxLocalEcho.TabIndex = 6;
            this.cboxLocalEcho.Text = "Local Echo";
            this.cboxLocalEcho.UseVisualStyleBackColor = true;
            // 
            // cboxTimeStamp
            // 
            this.cboxTimeStamp.AutoSize = true;
            this.cboxTimeStamp.Location = new System.Drawing.Point(186, 31);
            this.cboxTimeStamp.Name = "cboxTimeStamp";
            this.cboxTimeStamp.Size = new System.Drawing.Size(85, 16);
            this.cboxTimeStamp.TabIndex = 7;
            this.cboxTimeStamp.Text = "Time Stamp";
            this.cboxTimeStamp.UseVisualStyleBackColor = true;
            // 
            // tboxTextToSend
            // 
            this.tboxTextToSend.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tboxTextToSend.Location = new System.Drawing.Point(12, 77);
            this.tboxTextToSend.Name = "tboxTextToSend";
            this.tboxTextToSend.Size = new System.Drawing.Size(708, 22);
            this.tboxTextToSend.TabIndex = 8;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(740, 65);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(119, 34);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tboxReceivedText
            // 
            this.tboxReceivedText.Location = new System.Drawing.Point(18, 300);
            this.tboxReceivedText.MaxLength = 307199;
            this.tboxReceivedText.Multiline = true;
            this.tboxReceivedText.Name = "tboxReceivedText";
            this.tboxReceivedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxReceivedText.Size = new System.Drawing.Size(841, 402);
            this.tboxReceivedText.TabIndex = 10;
            // 
            // cmbLBSend
            // 
            this.cmbLBSend.FormattingEnabled = true;
            this.cmbLBSend.Location = new System.Drawing.Point(304, 27);
            this.cmbLBSend.Name = "cmbLBSend";
            this.cmbLBSend.Size = new System.Drawing.Size(72, 20);
            this.cmbLBSend.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Line Breaks in Sending";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Line Breaks in Receiving";
            // 
            // cmbLBReceive
            // 
            this.cmbLBReceive.FormattingEnabled = true;
            this.cmbLBReceive.Location = new System.Drawing.Point(448, 27);
            this.cmbLBReceive.Name = "cmbLBReceive";
            this.cmbLBReceive.Size = new System.Drawing.Size(72, 20);
            this.cmbLBReceive.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Text to Send";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Text Received";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(752, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 34);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save log";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(647, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 34);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear log";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "Shift + Click to set the button";
            // 
            // checkBoxCleartext
            // 
            this.checkBoxCleartext.AutoSize = true;
            this.checkBoxCleartext.Location = new System.Drawing.Point(186, 60);
            this.checkBoxCleartext.Name = "checkBoxCleartext";
            this.checkBoxCleartext.Size = new System.Drawing.Size(152, 16);
            this.checkBoxCleartext.TabIndex = 20;
            this.checkBoxCleartext.Text = "Clear Text After Sending";
            this.checkBoxCleartext.UseVisualStyleBackColor = true;
            this.checkBoxCleartext.CheckedChanged += new System.EventHandler(this.checkBoxCleartext_CheckedChanged);
            // 
            // buttonsavebuttons
            // 
            this.buttonsavebuttons.Location = new System.Drawing.Point(597, 10);
            this.buttonsavebuttons.Name = "buttonsavebuttons";
            this.buttonsavebuttons.Size = new System.Drawing.Size(134, 23);
            this.buttonsavebuttons.TabIndex = 21;
            this.buttonsavebuttons.Text = "Save Button Setting";
            this.buttonsavebuttons.UseVisualStyleBackColor = true;
            this.buttonsavebuttons.Click += new System.EventHandler(this.buttonsavebuttons_Click);
            // 
            // buttonloadbuttons
            // 
            this.buttonloadbuttons.Location = new System.Drawing.Point(597, 31);
            this.buttonloadbuttons.Name = "buttonloadbuttons";
            this.buttonloadbuttons.Size = new System.Drawing.Size(134, 23);
            this.buttonloadbuttons.TabIndex = 22;
            this.buttonloadbuttons.Text = "Load Button Setting";
            this.buttonloadbuttons.UseVisualStyleBackColor = true;
            this.buttonloadbuttons.Click += new System.EventHandler(this.buttonloadbuttons_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 714);
            this.Controls.Add(this.buttonloadbuttons);
            this.Controls.Add(this.buttonsavebuttons);
            this.Controls.Add(this.checkBoxCleartext);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbLBReceive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLBSend);
            this.Controls.Add(this.tboxReceivedText);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tboxTextToSend);
            this.Controls.Add(this.cboxTimeStamp);
            this.Controls.Add(this.cboxLocalEcho);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbBaudRate);
            this.Controls.Add(this.cmbPortName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Serial Terminal plus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPortName;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private Button btnConnect;
        private Label label1;
        private Label label2;
        private CheckBox cboxLocalEcho;
        private CheckBox cboxTimeStamp;
        private TextBox tboxTextToSend;
        private Button btnSend;
        private TextBox tboxReceivedText;
        private ComboBox cmbLBSend;
        private Label label3;
        private Label label4;
        private ComboBox cmbLBReceive;
        private Label label5;
        private Label label6;
        private Button btnSave;
        private Button btnClear;
        private Label label7;
        private CheckBox checkBoxCleartext;
        private Button buttonsavebuttons;
        private Button buttonloadbuttons;
        private Timer timer1;
    }
}

