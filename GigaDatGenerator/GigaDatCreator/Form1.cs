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
using GigaDatCreatorDLL;

namespace GigaDatCreator
{
    public partial class Form1 : Form
    {
        private string scannerModel = "";
        private string m_auxScannerModel = "";
        private string datFilePath = "";
        private string m_auxDatFilePath = "";
        private string configFilePath = "";
        private string m_auxSConfigFilePath = "";
        private bool m_aux_ScannerAdded = false;
        private int m_addedDeviceCounter = 0;
        bool deviceAdded = false;
        bool checkActionAtt = false;

        public Form1()
        {
            InitializeComponent();
            loadComboBox();
        }


        private void loadComboBox()
        {
            string filePath = System.IO.Directory.GetCurrentDirectory() + "\\DAT_Server\\dat.ini";

            if (!(File.Exists(filePath)))
            {
                return;
            }

            string[] lineOfContents = File.ReadAllLines(filePath);
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(':');
                comboBox1.Items.Add(tokens[0]);
            }
        }


        private void btnInputFirmwarePath_Click_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.dat)|*.dat";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFirmwareFilePath.Text = dlg.FileName;
            }
        }


        private void btnInputScncfgPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.scncfg)|*.scncfg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtScncfgFilePath.Text = dlg.FileName;
            }
        }


        private void btnGenerateDAT_Click(object sender, EventArgs e)
        {
            if (deviceAdded == false)
            {
                MessageBox.Show("Please Add the device first", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            targetPID.Update();
            targetEC.Update();
            foreach (DAT_Generator datGen in DAT_GEN_LIST.DatGenerators)
            {
                if (datGen != null)
                {
                    datGen.PIDValue = targetPID.Text;
                    datGen.ECLevel = targetEC.Text;
                    if (datGen.createGigaDat())
                    {
                        if (!datGen.IsAuxScanner)
                        {
                            MessageBox.Show("Created DAT file is avaliable in directory :\n" + DAT_Generator.outputDirectory, "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failiure on Giga DAT File Creation", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            if (DAT_GEN_LIST.DatGenerators.Count > 1)
            {
                if(DAT_Generator.combineGigaDATs(DAT_GEN_LIST.DatGenerators))
                {
                    MessageBox.Show("Created Combined GIGA DAT file is avaliable in directory :\n" + DAT_Generator.outputDirectory+ "CombinedGigaDATs\\", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failure on Combined Giga DAT file creation", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            DAT_Generator.cleanDatServerFolder();
            DAT_Generator.RemoveTempDirectory();
            RefreshUI();
            DAT_GEN_LIST.RemoveAllDevices();
            DAT_Generator.outputDirectory = "";
        }


        private void btnInputAddDevice_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Target Device", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtFirmwareFilePath.Text == "")
            {
                MessageBox.Show("Please Input the Firmware File Path", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtScncfgFilePath.Text == "")
            {
                MessageBox.Show("Please Input the Scncfg File Path", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            scannerModel = comboBox1.SelectedItem.ToString();
            datFilePath = txtFirmwareFilePath.Text;
            configFilePath = txtScncfgFilePath.Text;
            checkActionAtt = actionCheckBox.Checked;

            //Adding Primary Targetted Scanner
            if (DAT_GEN_LIST.AddedDevicesCnt == 0)
            {
                var addDevice_status = DAT_GEN_LIST.AddDevice(scannerModel, configFilePath, datFilePath, false, checkActionAtt);
                switch (addDevice_status)
                {
                    case DAT_GEN_LIST.ERROR_LIST.INVALID_SCANNER_TYPE_ERR:
                        MessageBox.Show("Primary Scanner cannot be a auxiliary type", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case DAT_GEN_LIST.ERROR_LIST.INVALID_TLRN_ERR:
                        MessageBox.Show("Primary Scanner's TLRN is not valid", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case DAT_GEN_LIST.ERROR_LIST.INCORRECT_DAT_SELECTION:
                        MessageBox.Show("Please select correct DAT file or select correct device", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    default: break;
                }
                tgvInputFileDetails.Rows[0].Cells[0].Value = Path.GetFileName(datFilePath);
                tgvInputFileDetails.Rows[0].Cells[1].Value = Path.GetFileName(configFilePath);
            }
            else // adding as an Aux Scanner
            {
                var fileName = Path.GetFileName(datFilePath);

                if (tgvInputFileDetails.Rows[0].Cells[0].Value.ToString() == fileName)
                {
                    MessageBox.Show("Primary and Aux Scanner DATs cannot be Identical,Please check again", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var addDevice_status = DAT_GEN_LIST.AddDevice(scannerModel, configFilePath, datFilePath, true, checkActionAtt);
                switch (addDevice_status)
                {
                    case DAT_GEN_LIST.ERROR_LIST.DEVICE_EXIST_ERR: // This case could not be occurred
                        MessageBox.Show("Scanner Already Exist", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case DAT_GEN_LIST.ERROR_LIST.INVALID_SCANNER_TYPE_ERR:
                        MessageBox.Show("First Scanner should be a Primary Target", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case DAT_GEN_LIST.ERROR_LIST.DEVICE_TLRN_EXIST_ERR:
                        MessageBox.Show("Primary and AUX TLRN cannot be equal", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case DAT_GEN_LIST.ERROR_LIST.INCORRECT_DAT_SELECTION:
                        MessageBox.Show("Please select correct DAT file or select correct device", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case DAT_GEN_LIST.ERROR_LIST.INVALID_TLRN_ERR:
                        MessageBox.Show("Aux Scanner's TLRN is not valid", "Giga DAT Creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    default: break;
                }
                m_auxScannerModel = scannerModel;
                m_auxDatFilePath = datFilePath;
                m_auxSConfigFilePath = configFilePath;
                string[] nxtRow = new string[] { fileName, Path.GetFileName(configFilePath) };
                //tgvInputFileDetails.AllowUserToAddRows = true;

                if (tgvInputFileDetails.Rows.Count == m_addedDeviceCounter)
                {
                    tgvInputFileDetails.Rows.Add();
                    tgvInputFileDetails.Rows[m_addedDeviceCounter - 1].Cells[0].Value = tgvInputFileDetails.Rows[m_addedDeviceCounter].Cells[0].Value;
                    tgvInputFileDetails.Rows[m_addedDeviceCounter - 1].Cells[1].Value = tgvInputFileDetails.Rows[m_addedDeviceCounter].Cells[1].Value;
                }
                tgvInputFileDetails.Rows[m_addedDeviceCounter].Cells[0].Value = fileName;
                tgvInputFileDetails.Rows[m_addedDeviceCounter].Cells[1].Value = Path.GetFileName(configFilePath);
                //tgvInputFileDetails.Update();
            }
            ++m_addedDeviceCounter;
            targetPID.Text = DAT_GEN_LIST.DatGenerators[0].PIDValue;
            targetEC.Text = DAT_GEN_LIST.DatGenerators[0].ECLevel;
            targetEC.Update();
            targetPID.Update();
            deviceAdded = true;
            txtFirmwareFilePath.Clear();
            txtScncfgFilePath.Clear();
        }


        private void RefreshUI()
        {
            scannerModel = "";
            datFilePath = "";
            configFilePath = "";
            deviceAdded = false;
            checkActionAtt = false;

            comboBox1.SelectedIndex = -1;

            comboBox1.Text = "Select Model Name";

            actionCheckBox.Checked = false;

            txtFirmwareFilePath.Text = "";
            txtScncfgFilePath.Text = "";

            m_aux_ScannerAdded = false;
            if (tgvInputFileDetails.Rows[0].Cells[0].Value != null)
            {
                tgvInputFileDetails.Rows[0].Cells[0].Value = "";
                tgvInputFileDetails.Rows[0].Cells[1].Value = "";
            }
            if (tgvInputFileDetails.Rows.Count > 1)
            {
                int rows = tgvInputFileDetails.Rows.Count;
                for (int i = 1; i < rows; ++i)
                {
                    tgvInputFileDetails.Rows[i].Cells[0].Value = "";
                    tgvInputFileDetails.Rows[i].Cells[1].Value = "";
                }
            }
            //tgvInputFileDetails.AllowUserToDeleteRows = true;
            //tgvInputFileDetails.Rows.RemoveAt(1);
            //tgvInputFileDetails.Rows.RemoveAt(2);
            //tgvInputFileDetails.Rows[].Cells[0].Value = "";
            // tgvInputFileDetails.Rows[0].Cells[1].Value = "";
            tgvInputFileDetails.DataSource = null;
            tgvInputFileDetails.Refresh();
            targetPID.Text = "";
            targetEC.Text = "";
            targetPID.Update();
            targetEC.Update();
            m_addedDeviceCounter = 0;
            m_auxDatFilePath = "";
            m_auxScannerModel = "";
            m_auxSConfigFilePath = "";
            m_aux_ScannerAdded = false;

        }

        public static void clean()
        {
            DAT_Generator.cleanDatServerFolder();
            DAT_Generator.RemoveTempDirectory();
        }
        private void btnInputRemoveDevice_Click(object sender, EventArgs e)
        {
            RefreshUI();
            DAT_GEN_LIST.RemoveAllDevices();
        }

        private void targetPID_TextChanged(object sender, EventArgs e)
        {
        }

        private void targetEC_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void windows_close(object sender, FormClosedEventArgs e)
        {
            clean();
        }
    }
}
