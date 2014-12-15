using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ezHashCheck
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// This enumation lists all the hashing methods this program supports.
        /// </summary>
        enum HashMethods
        {
            SHA1,
            MD5
        }

        /// <summary>
        /// This string should be used as the all title of all message windows shown to the user.
        /// </summary>
        const String MessageTitle = "ezHashCheck";


        public MainForm()
        {
            InitializeComponent();

            //Center the main form.
            this.StartPosition = FormStartPosition.CenterScreen;

            //Add selectable hash methods in the drop down.
            HashMethodsComboBox.Items.Add(HashMethods.SHA1.ToString());
            HashMethodsComboBox.Items.Add(HashMethods.MD5.ToString());

            //give the drop down a default value.
            HashMethodsComboBox.SelectedIndex = 0;
        }

        #region Event Handlers

        /// <summary>
        /// This method runs when the user presses the 'Check Hash' button.
        /// </summary>
        private void CheckHashButton_Click(object sender, EventArgs e)
        {
            //local vars
            Boolean hashMatch = false;
            String filePath = FileToHashTextBox.Text;
            String hashString = HashStringTextBox.Text;


            //check user input.
            if (String.IsNullOrEmpty(filePath) || String.IsNullOrEmpty(hashString))
            {
                MessageBox.Show("Make sure you have entered a hash string AND chosen a file to check the hash of!", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(!OnlyHexInString(hashString))
            {
                MessageBox.Show("Hash string must be hexadecimal!", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else //user input sane, continue hash check.
            {        
                byte[] newHash = null;
                HashAlgorithm hashAlgorithm = null;

                String selectedHashMethod = HashMethodsComboBox.SelectedItem.ToString();

                //select hash method based on user input.
                if (selectedHashMethod == HashMethods.SHA1.ToString())
                {
                    hashAlgorithm = SHA1.Create();
                }
                else if (selectedHashMethod == HashMethods.MD5.ToString())
                {
                    hashAlgorithm = MD5.Create();
                }

                //assuming a hash algorithm has been selected, use it to compare the hash string  and the selected file.
                if (hashAlgorithm != null)
                {
                    byte[] oldHash = StringToByteArray(hashString);

                    using (var stream = File.OpenRead(filePath))
                    {
                        newHash = hashAlgorithm.ComputeHash(stream);
                    }

                    if (oldHash.SequenceEqual(newHash))
                    {
                        hashMatch = true;
                    }

                    hashAlgorithm.Dispose();
                }
            }

            //tell user if the hash matches or not.
            if (hashMatch)
            {
                MessageBox.Show("Hash matches the chosen file.", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hash does not match the chosen file!", MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// This method runs when the user clicks the 'Find File' button (...) - uses an OpenFileDialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion

        #region Helper Functions

        /// <summary>
        /// This function takes a string and returns it as a byte array. The string must have an even number of chars!
        /// </summary>
        private Byte[] StringToByteArray(String hex)
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
        /// This function checks to see if a string is hex. The string must have an even number of chars!
        /// </summary>
        private Boolean OnlyHexInString(String test)
        {
            return test.Count() % 2 == 0 && System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        #endregion
    }
}
