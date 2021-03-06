﻿using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public const string CLIENT_ID = "4f2dfd6d40018d4";
        public const string CLIENT_SECRET = "edb012d5aeda108335089de54b9f8c913e142aef";
        public string[] files = null;
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var file = files[0];
                var client = new ImgurClient(CLIENT_ID, CLIENT_SECRET);
                var endpoint = new ImageEndpoint(client);
                IImage image;
                using (var fs = new FileStream(@"C:\Users\Tuy\Desktop\Capture.png", FileMode.Open))
                {
                    image = await endpoint.UploadImageStreamAsync(fs);
                }
                Debug.Write("Image uploaded. Image Url: " + image.Link);
            }
            catch (ImgurException imgurEx)
            {
                Debug.Write("An error occurred uploading an image to Imgur.");
                Debug.Write(imgurEx.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath);
                    button1.Enabled = true;
                    label2.Text = fbd.SelectedPath;
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = Directory.GetFiles(fbd.SelectedPath);
                    button1.Enabled = true;
                    label4.Text = fbd.SelectedPath;
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
    }
}
