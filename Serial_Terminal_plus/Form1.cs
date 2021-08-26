using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Terminal_plus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ApplicationExitイベントハンドラを追加
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            //! 利用可能なシリアルポート名の配列を取得する.
            this.cmbPortName.Items.Clear();
            string[] PortList = System.IO.Ports.SerialPort.GetPortNames();

            //! シリアルポート名をコンボボックスにセットする.
            //this.cmbPortName.Items.Add("Hello");
            foreach (string portName in PortList)
            {
                this.cmbPortName.Items.Add(portName);
            }
            if (this.cmbPortName.Items.Count > 0)
            {
                this.cmbPortName.SelectedIndex = this.cmbPortName.Items.Count - 1;
            }

            // ボーレート選択コンボボックスに選択項目をセットする.
            this.cmbBaudRate.Items.Clear();
            this.cmbBaudRate.Items.Add("4800");
            this.cmbBaudRate.Items.Add("9600");
            this.cmbBaudRate.Items.Add("19200");
            this.cmbBaudRate.Items.Add("115200");
            this.cmbBaudRate.Items.Add("230400");
            this.cmbBaudRate.Items.Add("460800");
            this.cmbBaudRate.Items.Add("921600");
            this.cmbBaudRate.SelectedIndex = Properties.Settings.Default.baud;

            // 送信時の改行
            this.cmbLBSend.Items.Clear();
            this.cmbLBSend.Items.Add("CR");
            this.cmbLBSend.Items.Add("LF");
            this.cmbLBSend.Items.Add("CR+LF");
            this.cmbLBSend.SelectedIndex = Properties.Settings.Default.linbreakS;

            // 受信時の改行
            this.cmbLBReceive.Items.Clear();
            this.cmbLBReceive.Items.Add("CR");
            this.cmbLBReceive.Items.Add("LF");
            this.cmbLBReceive.Items.Add("CR+LF");
            this.cmbLBReceive.SelectedIndex = Properties.Settings.Default.linebreakR;

            //ローカルエコー
            cboxLocalEcho.Checked = Properties.Settings.Default.localecho;

            //タイムスタンプ
            cboxTimeStamp.Checked = Properties.Settings.Default.timestamp;

            //カスタムボタン
            generateCustumButton();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                //! シリアルポートをクローズする.
                serialPort1.Close();

                //! ボタンの表示を[切断]から[接続]に変える.
                btnConnect.Text = "Connect";
            }
            else
            {
                //! オープンするシリアルポートをコンボボックスから取り出す.
                serialPort1.PortName = cmbPortName.SelectedItem.ToString();

                //! ボーレートをコンボボックスから取り出す.
                String baud = (string)this.cmbBaudRate.SelectedItem;
                serialPort1.BaudRate = Int32.Parse(baud);

                //! データビットをセットする. (データビット = 8ビット)
                serialPort1.DataBits = 8;

                //! パリティビットをセットする. (パリティビット = なし)
                serialPort1.Parity = System.IO.Ports.Parity.None;

                //! ストップビットをセットする. (ストップビット = 1ビット)
                serialPort1.StopBits = System.IO.Ports.StopBits.One;

                //! フロー制御
                serialPort1.Handshake = System.IO.Ports.Handshake.None;

                //! 文字コードをセットする.
                //serialPort1.Encoding = Encoding.Unicode;

                try
                {
                    //! シリアルポートをオープンする.
                    serialPort1.Open();

                    //! ボタンの表示を[接続]から[切断]に変える.
                    btnConnect.Text = "Disconnect";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private String[] linebreaks = { "\r", "\n", "\r\n" };

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendString(tboxTextToSend.Text);
        }

        private void sendString(String texttosend)
        {
            //! シリアルポートをオープンしていない場合、処理を行わない.
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("No Connection!!");
                return;
            }

            //! 送信するテキストがない場合、データ送信は行わない.
            if (string.IsNullOrEmpty(texttosend) == true)
            {
                MessageBox.Show("No Text to send!!");
                return;
            }

            try
            {
                //! シリアルポートからテキストを送信する.
                //serialPort1.Write(texttosend + "\n");
                serialPort1.Write(texttosend + linebreaks[cmbLBSend.SelectedIndex]);

                //Local Echo
                if (cboxLocalEcho.Checked == true)
                {
                    if (cboxTimeStamp.Checked == true)
                    {
                        tboxReceivedText.AppendText(getnowstring() + ": ");
                    }
                    tboxReceivedText.AppendText("$$ " + texttosend + "\r\n");
                }

                //! 送信データを入力するテキストボックスをクリアする.
                tboxTextToSend.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //! シリアルポートをオープンしていない場合、処理を行わない.
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("No Connection!!");
                return;
            }
            try
            {
                //! 受信データを読み込む.
                string data = serialPort1.ReadExisting();

                //! 受信したデータをテキストボックスに書き込む.
                Response(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        delegate void SetTextCallback(string text);

        private Boolean atBeginningOfLine = true;
        private Boolean hasCarry = false;

        private void Response(string text)
        {
            if (tboxReceivedText.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Response);
                BeginInvoke(d, new object[] { text });
            }
            else //★★ここで受信文字列の書き出し★★
            {
                if (cmbLBReceive.SelectedIndex == 0) // \r
                {
                    if (cboxTimeStamp.Checked == true)
                    {
                        if (atBeginningOfLine == true)
                        {
                            tboxReceivedText.AppendText(getnowstring() + ": ");
                        }
                        if (text.Substring(text.Length - 1, 1) == "\r")
                        {
                            text = text.Substring(0, text.Length - 1);
                            text = text.Replace("\r", "\r\n" + getnowstring() + ": ") + "\r\n";
                            tboxReceivedText.AppendText(text);
                            atBeginningOfLine = true;
                        }
                        else
                        {
                            text = text.Replace("\r", "\r\n" + getnowstring() + ": ");
                            tboxReceivedText.AppendText(text);
                            atBeginningOfLine = false;
                        }
                    }
                    else
                    {
                        text = text.Replace("\r", "\r\n");
                        tboxReceivedText.AppendText(text);
                    }
                }
                else if (cmbLBReceive.SelectedIndex == 1) // \n
                {
                    if (cboxTimeStamp.Checked == true)
                    {
                        if (atBeginningOfLine == true)
                        {
                            tboxReceivedText.AppendText(getnowstring() + ": ");
                        }
                        if (hasCarry == true)
                        {
                            text = "\r" + text;
                        }
                        if (text.Substring(text.Length - 1, 1) == "\r")
                        {
                            text = text.Substring(0, text.Length - 1);
                            text = text.Replace("\n", "\r\n" + getnowstring() + ": ");
                            tboxReceivedText.AppendText(text);
                            atBeginningOfLine = false;
                            hasCarry = true;
                        }
                        else if (text.Substring(text.Length - 1, 1) == "\n")
                        {
                            text = text.Substring(0, text.Length - 1);
                            text = text.Replace("\n", "\r\n" + getnowstring() + ": ") + "\r\n";
                            tboxReceivedText.AppendText(text);
                            atBeginningOfLine = true;
                            hasCarry = false;
                        }
                        else
                        {
                            text = text.Replace("\n", "\r\n" + getnowstring() + ": ");
                            tboxReceivedText.AppendText(text);
                            atBeginningOfLine = false;
                            hasCarry = false;
                        }
                    }
                    else
                    {
                        text = text.Replace("\n", "\r\n");
                        tboxReceivedText.AppendText(text);
                    }
                }
                else //\r\n
                {
                    if (cboxTimeStamp.Checked == true)
                    {
                        if (atBeginningOfLine == true)
                        {
                            tboxReceivedText.AppendText(getnowstring() + ": ");
                        }
                        if (hasCarry == true)
                        {
                            text = "\r" + text;
                        }
                        if (text.Substring(text.Length - 1, 1) == "\r")
                        {
                            text = text.Substring(0, text.Length - 1);
                            text = text.Replace("\r\n", "\r\n" + getnowstring() + ": ");
                            tboxReceivedText.AppendText(text);
                            atBeginningOfLine = false;
                            hasCarry = true;
                        }
                        else if (text.Substring(text.Length - 1, 1) == "\n")
                        {
                            text = text.Substring(0, text.Length - 2);
                            text = text.Replace("\r\n", "\r\n" + getnowstring() + ": ") + "\r\n";
                            tboxReceivedText.AppendText(text);
                            atBeginningOfLine = true;
                            hasCarry = false;
                        }
                        else
                        {
                            text = text.Replace("\r\n", "\r\n" + getnowstring() + ": ");
                            tboxReceivedText.AppendText(text);
                            atBeginningOfLine = false;
                            hasCarry = false;
                        }
                    }
                    else
                    {
                        tboxReceivedText.AppendText(text);
                    }

                }
                //text = text.Replace(" ", "#");
                //text = text.Replace("\n", "\nX");
                //tboxReceivedText.AppendText(text);
            }
        }

        private String getnowstring()
        {
            DateTime dt = DateTime.Now;
            String ms = "00" + dt.Millisecond;
            ms = ms.Substring(ms.Length - 3, 3);
            String now = dt.ToString("HH:mm:ss") + "." + ms;
            return now;
        }

        private String getnowstringforfile()
        {
            DateTime dt = DateTime.Now;
            String now = dt.ToString("yyyyMMdd_HHmmss");
            return now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = "SerialTerminalPlus" + getnowstringforfile();
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(saveFileDialog1.FileName);
                File.WriteAllText(saveFileDialog1.FileName, tboxReceivedText.Text);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tboxReceivedText.Clear();
        }

        //ApplicationExitイベントハンドラ
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                //! シリアルポートをクローズする.
                serialPort1.Close();
            }

            Properties.Settings.Default.baud = this.cmbBaudRate.SelectedIndex;
            Properties.Settings.Default.linbreakS = this.cmbLBSend.SelectedIndex;
            Properties.Settings.Default.linebreakR = this.cmbLBReceive.SelectedIndex;
            Properties.Settings.Default.localecho = cboxLocalEcho.Checked;
            Properties.Settings.Default.timestamp = cboxTimeStamp.Checked;
            Properties.Settings.Default.comandstring = this.custumbuttons[0].Text;
            for (int i = 1; i < 36; i++)
            {
                Properties.Settings.Default.comandstring += '\t' + this.custumbuttons[i].Text;
            }
            Properties.Settings.Default.Save();
            //MessageBox.Show("アプリケーションが終了されます。");

            //ApplicationExitイベントハンドラを削除
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
        }

        private Button[] custumbuttons;
        private const String Notsetyet = "Not set yet";
        private void generateCustumButton()
        {
            this.custumbuttons = new Button[36];
            String[] buttontext = new string[36];
            Boolean canrestore = false;
            if (Properties.Settings.Default.comandstring != "none") {
                canrestore = true;
                buttontext = Properties.Settings.Default.comandstring.Split('\t');

            }
            for (int i0 = 0; i0 < custumbuttons.Length; i0++)
            {
                int i = i0 % 12;
                int j = i0 / 12;
                //ボタンコントロールのインスタンス作成
                this.custumbuttons[i0] = new Button();

                //プロパティ設定
                this.custumbuttons[i0].Name = "custumbtn" + (i0 + 1).ToString();
                if (canrestore == true)
                {
                    this.custumbuttons[i0].Text = buttontext[i0];
                }
                else
                {
                    this.custumbuttons[i0].Text = Notsetyet;
                }
                this.custumbuttons[i0].Top = this.tboxTextToSend.Bottom + 27 + j * 45;
                this.custumbuttons[i0].Height = 35;
                this.custumbuttons[i0].Width = 65;
                this.custumbuttons[i0].Left = this.tboxReceivedText.Left + 69 * i + (i / 4) * 9 - 3;

                //コントロールをフォームに追加
                this.Controls.Add(this.custumbuttons[i0]);
                this.custumbuttons[i0].Click += new System.EventHandler(custumbtnclick);
            }
        }

        private void custumbtnclick(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                //MessageBox.Show("Shift + " + btn.Name);
                String tmpstr = Microsoft.VisualBasic.Interaction.InputBox("Key in command string to send.", "Command String Setting", btn.Text, 200, 100);
                if (tmpstr != "") btn.Text = tmpstr;
            }
            else if (btn.Text != Notsetyet)
            {
                //MessageBox.Show(btn.Text);
                sendString(btn.Text);
            }
        }
    }
}

/*
 * if (checkBox2.Checked == true)
 * int index = cmbBaudRate.SelectedIndex;
 */