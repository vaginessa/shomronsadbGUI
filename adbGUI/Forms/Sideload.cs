﻿using System;
using System.Windows.Forms;
using adbGUI.Methods;

namespace adbGUI.Forms
{
	public partial class Sideload : ExtForm
	{
		public Sideload()
		{
			InitializeComponent();
		}

		private void Btn_SideloadStart_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_SideloadPath.Text))
			{
				var s = "adb sideload \"" + txt_SideloadPath.Text + "\"";
				HelperClass.Execute(s);
			}
			else
			{
				MessageBox.Show(@"Please select a file!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Btn_SideloadBrowse_Click(object sender, EventArgs e)
		{
			openFileDialog.FileName = "";
			openFileDialog.Filter = @" .zip|*.zip";

			if (openFileDialog.ShowDialog() == DialogResult.OK) txt_SideloadPath.Text = openFileDialog.FileName;
		}

        private void Sideload_DragDrop(object sender, DragEventArgs e)
        {
			string[] files = ((string[])e.Data.GetData(DataFormats.FileDrop));
			txt_SideloadPath.Text = files[0];
		}

        private void Sideload_DragEnter(object sender, DragEventArgs e)
        {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}
    }
}