using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ezHashCheck
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// This enum lists all the hashing methods this program supports.
        /// </summary>
        enum HashMethod
        {
            SHA1,
            SHA256,
            SHA512,
            MD5
        }

        /// <summary>
        /// This string should be used as the all title of all message windows shown to the user.
        /// </summary>
        const String MessageTitle = "ezHashCheck";

        /// <summary>
        /// CTOR
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            //Center the main form.
            this.StartPosition = FormStartPosition.CenterScreen;

            //Add selectable hash methods in the drop down.
            HashMethodsComboBox.Items.Add(HashMethod.MD5);
            HashMethodsComboBox.Items.Add(HashMethod.SHA1);
            HashMethodsComboBox.Items.Add(HashMethod.SHA256);
            HashMethodsComboBox.Items.Add(HashMethod.SHA512);

            //give the drop down a default value.
            HashMethodsComboBox.SelectedIndex = 0;
        }

        #region Event Handlers

        /// <summary>
        /// This method runs when the user presses the 'Check Hash' button.
        /// </summary>
        private void CheckHashButton_Click(object sender, EventArgs e)
        {
            //check user input.
            if (String.IsNullOrEmpty(FileToHashTextBox.Text) || String.IsNullOrEmpty(HashStringTextBox.Text))
            {
                MessageBox.Show("Make sure you have entered a hash string AND chosen a file to check the hash of!", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!OnlyHexInString(HashStringTextBox.Text))
            {
                MessageBox.Show("Hash string must be hexadecimal!", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else //user input sane, continue hash check.
            {
                byte[] oldHash = StringToByteArray(HashStringTextBox.Text);

                byte[] newHash = CalculateHashOfFile();

                if (newHash != null && oldHash.SequenceEqual(newHash))
                {
                    MessageBox.Show("Hash matches the chosen file.", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hash does not match the chosen file!", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// This method runs when the user clicks the 'Generate Hash' button. It generates a string hash of the file and prints it to the HashStringTextBox.
        /// </summary>
        private void GenerateHashButton_Click(object sender, EventArgs e)
        {
            //check user input.
            if (String.IsNullOrEmpty(FileToHashTextBox.Text))
            {
                MessageBox.Show("Make sure you have chosen a file to generate a hash for!", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] newHash = CalculateHashOfFile();

            if (newHash != null)
            {
                HashMethod selectedHashMethod = (HashMethod)HashMethodsComboBox.SelectedItem;
                String hashString = ByteArrayToString(newHash);
                HashStringTextBox.Text = hashString.ToLower(); //make sure the user sees the hash in lower case as this is expected.
            }
            else
            {
                MessageBox.Show("Hash generation has failed!", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// This method runs when the user clicks the 'Find File' button (...) - uses an OpenFileDialog.
        /// </summary>
        private void FindFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileToHashTextBox.Text = openFileDialog.FileName;
                }
            }
        }


        /// <summary>
        /// This method runs when the link label is clicked and navigates to my home page.
        /// </summary>
        private void HomePageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process.Start("http://edwinjones.me.uk")) { }
        }

        #endregion

        #region Helper Functions

        /// <summary>
        /// This function takes a string and returns it as a byte array. The string must have an even number of chars!
        /// </summary>
        private byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }


        /// <summary>
        /// This function takes a string and returns it as a byte array. The string must have an even number of chars!
        /// </summary>
        private String ByteArrayToString(byte[] data)
        {
            string hex = BitConverter.ToString(data);
            return hex.Replace("-", String.Empty);
        }


        /// <summary>
        /// This function checks to see if a string is hex. The string must have an even number of chars!
        /// </summary>
        private Boolean OnlyHexInString(String test)
        {
            return test.Count() % 2 == 0 && System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }


        /// <summary>
        /// This function calculate the hash of the chosen file with the chosen method and returns it as an array of bytes
        /// </summary>
        private byte[] CalculateHashOfFile()
        {
            HashAlgorithm hashAlgorithm = null;
            HashMethod selectedHashMethod = (HashMethod)HashMethodsComboBox.SelectedItem;

            //select hash method based on user input.
            switch (selectedHashMethod)
            {
                case HashMethod.SHA1:
                    hashAlgorithm = SHA1.Create();
                    break;

                case HashMethod.SHA256:
                    hashAlgorithm = SHA256.Create();
                    break;

                case HashMethod.SHA512:
                    hashAlgorithm = SHA512.Create();
                    break;

                case HashMethod.MD5:
                    hashAlgorithm = MD5.Create();
                    break;
            }

            byte[] newHash = null;

            //assuming a hash algorithm has been selected, use it to compare the hash string  and the selected file.
            if (hashAlgorithm != null)
            {
                using (var stream = File.OpenRead(FileToHashTextBox.Text))
                {
                    newHash = hashAlgorithm.ComputeHash(stream);
                }

                hashAlgorithm.Dispose();
            }

            return newHash;
        }

        #endregion
    }
}
