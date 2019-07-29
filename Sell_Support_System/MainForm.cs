using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;

namespace Sell_Support_System
{
    public partial class MainForm : Form
    {
        List<Product> productsList = new List<Product>();
        Product topSimProduct;
        float similarityThreshold = 0.85f;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;

        ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            productsList.Add(new Product(Properties.Resources.Kartka, "Kartka", 1));
            productsList.Add(new Product(Properties.Resources.Kalkulator, "Kalkulator", 5.5));
            productsList.Add(new Product(Properties.Resources.Marker, "Marker", 11));

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count != 0)
            {
                foreach (FilterInfo device in videoDevices)
                {
                    cBoxDevices.Items.Add(device.Name);
                }
            }
            else
            {
                cBoxDevices.Items.Add("Nie znaleziono urzadzen DirectShow");
            }

            cBoxDevices.SelectedIndex = 0;

            SwitchControls(true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void SwitchControls(bool enable)
        {
            cBoxDevices.Enabled = enable;

            btnConnect.Enabled = enable;
            btnDisconnect.Enabled = !enable;
            
            btnStartBill.Enabled = !enable;
        }

        private void cBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(
                    videoDevices[cBoxDevices.SelectedIndex].MonikerString);
                EnumeratedSupportedFrameSizes(videoDevice);
            }
        }

        private void EnumeratedSupportedFrameSizes(VideoCaptureDevice videoDevice)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                videoCapabilities = videoDevice.VideoCapabilities;
                snapshotCapabilities = videoDevice.SnapshotCapabilities;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (videoDevice != null)
            {
                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    videoDevice.VideoResolution = videoCapabilities[0];
                }

                if ((snapshotCapabilities != null) && (snapshotCapabilities.Length != 0))
                {
                    videoDevice.ProvideSnapshots = true;
                    videoDevice.SnapshotResolution = snapshotCapabilities[0];
                    videoDevice.SnapshotFrame += new NewFrameEventHandler(
                        videoDevice_SnapshotFrame);
                }
                
                videoSourcePlayer.VideoSource = videoDevice;
                videoSourcePlayer.Start();

                this.Cursor = Cursors.WaitCursor;

                for (int i = 0; i < 3; i++)
                {
                    btnStartBill.Text = (3 - i).ToString() + " uruchamianie kamery.";
                    this.Update();
                    System.Threading.Thread.Sleep(1000);

                    if (3 - i == 1)
                    {
                        btnStartBill.Text = "Otwórz rachunek";
                    }
                }

                this.Cursor = Cursors.Default;
                SwitchControls(false);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;

                if (videoDevice.ProvideSnapshots)
                {
                    videoDevice.SnapshotFrame -= new NewFrameEventHandler(videoDevice_SnapshotFrame);
                }

                SwitchControls(true);
            }
        }

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            if ((videoDevice != null) && (videoDevice.ProvideSnapshots))
            {
                videoDevice.SimulateTrigger();
            }

            if (btnStartBill.Enabled)
            {
                btnStartBill.Enabled = false;
            }
        }

        private void videoDevice_SnapshotFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Frame.Size);

            MatchSnapshot((Bitmap)eventArgs.Frame.Clone());
        }

        private void MatchSnapshot(Bitmap snapshot)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Bitmap>(MatchSnapshot), snapshot);
            }
            else
            {
                bool productFound = false;
                

                foreach (var product in productsList)
                {
                    TemplateMatch[] matchings = tm.ProcessImage(snapshot, product.image);
                    

                    if (matchings[0].Similarity >= similarityThreshold)
                    {
                        topSimProduct = product;
                        similarityThreshold = matchings[0].Similarity;
                        productFound = true;
                    }
                }


                if (!productFound)
                {
                    ToolTip t = new ToolTip();

                    int VisibleTime = 2000;  //in milliseconds
                    t.IsBalloon = true;
                    t.Show("Produkt nieznaleziony.", this.videoSourcePlayer, 0, 0, VisibleTime);
                }
                else
                {
                    int amount = 1;
                    
                    var item = lvProductList.FindItemWithText(topSimProduct.name);

                    if (item != null)
                    {
                        
                        amount += Convert.ToInt32(item.SubItems[1].Text);
                        lvProductList.Items.Remove(item);
                    }

                    AddListViewItem(topSimProduct.name, amount, topSimProduct.prize);
                }
            }
        }

        private void btnCloseBill_Click(object sender, EventArgs e)
        {
            double summary = 0;

            if (lvProductList.Items.Count > 0)
            {
                for (int i = 0; i < lvProductList.Items.Count; i++)
                {
                    summary += Convert.ToDouble(lvProductList.Items[0].SubItems[3].Text);
                }

                lvProductList.Items.Clear();
                btnCloseBill.Enabled = false;
                btnRemoveProduct.Enabled = false;
                btnTrigger.Enabled = false;
                btnStartBill.Enabled = true;
                btnDisconnect.Enabled = true;

                MessageBox.Show("Do zapłaty: " + summary.ToString("F") + " zł.", "Twój rachunek");
            }
            else
            {
                MessageBox.Show("Przed zamknięciem rachunku zeskanuj swoje produkty.", "Błąd");
            }
        }

        public void AddListViewItem(string productName, int amount, double price)
        {
            ListViewItem item = new ListViewItem(productName);
            item.SubItems.Add(amount.ToString());
            item.SubItems.Add(price.ToString());
            item.SubItems.Add((amount * price).ToString());
            lvProductList.Items.Add(item);
        }

        private void btnStartBill_Click(object sender, EventArgs e)
        {
            btnTrigger.Enabled = true;
            btnStartBill.Enabled = false;
            btnCloseBill.Enabled = true;
            btnRemoveProduct.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lvProductList.SelectedItems.Count > 0 && lvProductList.SelectedItems.Count < 2)
            {
                var selectedItem = lvProductList.SelectedItems[0];

                if (Convert.ToInt32(lvProductList.SelectedItems[0].SubItems[1].Text)>1)
                {
                    int amount = Convert.ToInt32(lvProductList.SelectedItems[0].SubItems[1].Text);
                    double prize = Convert.ToDouble(lvProductList.SelectedItems[0].SubItems[2].Text);
                    
                    amount--;
                    selectedItem.SubItems[1].Text = amount.ToString();
                    selectedItem.SubItems[3].Text = (amount * prize).ToString();
                }
                else
                {
                    selectedItem.Remove();
                }
            }
            else
            {
                MessageBox.Show("Kliknij jeden produkt do usunięcia.", "Błąd");
            }
        }
    }
}
