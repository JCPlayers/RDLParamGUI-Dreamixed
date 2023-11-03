using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IniParser;
using IniParser.Exceptions;
using IniParser.Model;
using IniParser.Parser;

namespace RDLParamGUI
{
    public enum Endianness
    {
        Little,
        Big
    }

    public partial class Form1 : Form
    {
        Endianness endianness;
        uint unkXbin;
        Dictionary<string, uint[]> paramData;
        Dictionary<string, uint[]> refData;
        IniData labelData = new IniData();
        string filepath, refPath, tempPath;
        Process proc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tempPath = Directory.GetCurrentDirectory() + @"\Temp.bin";
            if (File.Exists(tempPath)) File.Delete(tempPath);
            refPath = Directory.GetCurrentDirectory() + @"\Reference.bin";
            autocompressOnSaveToolStripMenuItem.Checked = RDLParamGUI.Properties.Settings.Default.autocompress;
            UpdateINI();
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            if (File.Exists(tempPath)) File.Delete(tempPath);
        }
        private void autocompressOnSaveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            RDLParamGUI.Properties.Settings.Default.autocompress = autocompressOnSaveToolStripMenuItem.Checked;
            RDLParamGUI.Properties.Settings.Default.Save();
        }

        public void UpdateINI()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\labels.ini"))
            {
                labelData = new FileIniDataParser().ReadFile(Directory.GetCurrentDirectory() + "\\labels.ini");
            }
            if (paramData != null)
                UpdateFileList();
        }

        public uint[] ReadParams(byte[] file)
        {
            List<uint> uintList = new List<uint>();
            BinaryReader reader = new BinaryReader(new MemoryStream(file));
            if (endianness == Endianness.Big)
            {
                reader.Close();
                reader.Dispose();
                reader = new BigEndianBinaryReader(new MemoryStream(file));
            } 

            reader.BaseStream.Seek(0x10, SeekOrigin.Begin);
            while (reader.BaseStream.Position < reader.BaseStream.Length - 3)
            {
                uintList.Add(reader.ReadUInt32());
            }
            reader.Close();
            reader.Dispose();
            return uintList.ToArray();
        }

        public void UpdateFileList()
        {
            fileList.Items.Clear();
            fileList.BeginUpdate();
            foreach (KeyValuePair<string, uint[]> file in paramData)
            {
                fileList.Items.Add(file.Key);
            }
            fileList.EndUpdate();
        }

        public void Save()
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            List<byte[]> files = new List<byte[]>();
            List<string> fileNames = new List<string>();
            BinaryWriter writer;

            foreach (KeyValuePair<string, uint[]> pair in paramData)
            {
                MemoryStream paramFile = new MemoryStream();
                if (endianness == Endianness.Big)
                    writer = new BigEndianBinaryWriter(paramFile);
                else
                    writer = new BinaryWriter(paramFile);

                writer.Write("XBIN".ToCharArray());
                writer.Write((short)0x1234);
                writer.Write(new byte[] { 2, 0 });
                writer.Write(0);
                writer.Write(unkXbin);

                for (int i = 0; i < pair.Value.Length; i++)
                {
                    writer.Write(pair.Value[i]);
                }

                writer.BaseStream.Seek(0x8, SeekOrigin.Begin);
                writer.Write((uint)writer.BaseStream.Length);
                paramFile.SetLength(writer.BaseStream.Length);

                fileNames.Add(pair.Key);
                files.Add(paramFile.GetBuffer().Take((int)writer.BaseStream.Length).ToArray());

                writer.Close();
                writer.Dispose();
            }

            if (endianness == Endianness.Big)
                writer = new BigEndianBinaryWriter(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write));
            else
                writer = new BinaryWriter(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write));

            writer.Write("XBIN".ToCharArray());
            writer.Write((short)0x1234);
            writer.Write(new byte[] { 2, 0 });
            writer.Write(0);
            writer.Write(unkXbin);

            writer.Write((int)paramData.Count);

            List<uint> fileOffsets = new List<uint>();
            List<uint> nameOffsets = new List<uint>();
            for (int i = 0; i < files.Count; i++)
            {
                writer.Write((long)0);
            }
            for (int i = 0; i < files.Count; i++)
            {
                fileOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(files[i]);
                //Console.WriteLine($"Wrote {files[i].Length} bytes of file {fileNames[i]}");
            }
            for (int i = 0; i < fileNames.Count; i++)
            {
                Console.WriteLine($"Writing string {fileNames[i]}");
                long o = writer.BaseStream.Position;
                nameOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(fileNames[i].Length);
                writer.Write(Encoding.UTF8.GetBytes(fileNames[i]));
                writer.Write(0);

                while (!writer.BaseStream.Position.ToString("X").EndsWith("0")
                    && !writer.BaseStream.Position.ToString("X").EndsWith("4")
                    && !writer.BaseStream.Position.ToString("X").EndsWith("8")
                    && !writer.BaseStream.Position.ToString("X").EndsWith("C"))
                {
                    writer.Write((byte)0);
                }
                //Console.WriteLine($"Wrote {writer.BaseStream.Position - o} bytes");
            }
            writer.BaseStream.Seek(0x14, SeekOrigin.Begin);
            for (int i = 0; i < files.Count; i++)
            {
                writer.Write(nameOffsets[i]);
                writer.Write(fileOffsets[i]);
            }

            writer.BaseStream.Seek(0x8, SeekOrigin.Begin);
            writer.Write((uint)writer.BaseStream.Length);

            writer.Close();
            writer.Dispose();

            if (filepath.EndsWith(".cmp") && autocompressOnSaveToolStripMenuItem.Checked)
            {
                proc = new Process();
                Compress(filepath);
                proc.WaitForExit();
                proc.Dispose();
            }

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XBIN Binary Archives|*.bin;*.cmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                filepath = open.FileName;
                if (filepath.EndsWith(".cmp"))
                {
                    Console.WriteLine("Decompressing...");
                    proc = new Process();
                    Decompress(filepath);
                    proc.WaitForExit();
                    proc.Close();
                    proc.Dispose();
                }

                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                paramData = new Dictionary<string, uint[]>();
                BinaryReader reader = new BinaryReader(new FileStream(filepath, FileMode.Open, FileAccess.Read));

                if (Encoding.UTF8.GetString(reader.ReadBytes(4)) != "XBIN")
                {
                    MessageBox.Show("Invalid XBIN header!", this.Text, MessageBoxButtons.OK);
                    return;
                }

                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                endianness = Endianness.Little;
                if (reader.ReadBytes(2).SequenceEqual(new byte[] { 0x12, 0x34 }))
                {
                    reader = new BigEndianBinaryReader(new FileStream(filepath, FileMode.Open, FileAccess.Read));
                    endianness = Endianness.Big;
                }

                reader.BaseStream.Seek(0xC, SeekOrigin.Begin);
                unkXbin = reader.ReadUInt32();

                uint fileCount = reader.ReadUInt32();
                for (int i = 0; i < fileCount; i++)
                {
                    long pos = reader.BaseStream.Position;

                    reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
                    string name = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));

                    reader.BaseStream.Seek(pos + 0x4, SeekOrigin.Begin);
                    reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
                    int len = reader.ReadInt32();
                    reader.BaseStream.Seek(-0xC, SeekOrigin.Current);
                    byte[] file = reader.ReadBytes(len);

                    paramData.Add(name, ReadParams(file));

                    reader.BaseStream.Seek(pos + 0x8, SeekOrigin.Begin);
                }

                reader.Close();
                reader.Dispose();

                if (filepath.EndsWith(".cmp"))
                {
                    Console.WriteLine("Recompressing...");
                    proc = new Process();
                    Compress(filepath);
                    proc.WaitForExit();
                    proc.Close();
                    proc.Dispose();
                }

                UpdateFileList();
                this.Cursor = Cursors.Default;
                this.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                parameterPatchingToolStripMenuItem.Enabled = true;
                updateLabelsToolStripMenuItem.Enabled = true;
                RefreshReference();
            }
        }
        private void openReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XBIN Binary Archives|*.bin;*.cmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                File.Copy(open.FileName, refPath, true);
                if (open.FileName.EndsWith(".cmp"))
                {
                    Console.WriteLine("Decompressing...");
                    proc = new Process();
                    Decompress(refPath);
                    proc.WaitForExit();
                    proc.Close();
                    proc.Dispose();
                }
                RefreshReference();
            }
        }
        private void RefreshReference()
        {
            if (File.Exists(refPath))
            {
                refData = new Dictionary<string, uint[]>();
                refPath = Directory.GetCurrentDirectory() + @"\Reference.bin";
                BinaryReader reader = new BinaryReader(new FileStream(refPath, FileMode.Open, FileAccess.Read));
                if (Encoding.UTF8.GetString(reader.ReadBytes(4)) != "XBIN")
                {
                    MessageBox.Show("Invalid XBIN header!", this.Text, MessageBoxButtons.OK);
                    return;
                }
                endianness = Endianness.Little;
                if (reader.ReadBytes(2).SequenceEqual(new byte[] { 0x12, 0x34 }))
                {
                    reader = new BigEndianBinaryReader(new FileStream(refPath, FileMode.Open, FileAccess.Read));
                    endianness = Endianness.Big;
                }

                reader.BaseStream.Seek(0xC, SeekOrigin.Begin);
                unkXbin = reader.ReadUInt32();

                uint fileCount = reader.ReadUInt32();
                for (int i = 0; i < fileCount; i++)
                {
                    long pos = reader.BaseStream.Position;

                    reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
                    string name = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));

                    reader.BaseStream.Seek(pos + 0x4, SeekOrigin.Begin);
                    reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
                    int len = reader.ReadInt32();
                    reader.BaseStream.Seek(-0xC, SeekOrigin.Current);
                    byte[] file = reader.ReadBytes(len);

                    refData.Add(name, ReadParams(file));

                    reader.BaseStream.Seek(pos + 0x8, SeekOrigin.Begin);
                }

                reader.Close();
                reader.Dispose();
                generatePatchToolStripMenuItem.Enabled = true;
            }
            else
            {
                refData = new Dictionary<string, uint[]>();
                generatePatchToolStripMenuItem.Enabled = false;
            }
        }
        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueList.Items.Clear();
            hexData.Text = "";
            intData.Text = "";
            floatData.Text = "";
            hexDataOrig.Text = "";
            intDataOrig.Text = "";
            floatDataOrig.Text = "";
            string filename = fileList.SelectedItem.ToString();
            uint[] values = paramData[filename];
            for (int i = 0; i < values.Length; i++)
            {
                if (labelData.Sections.ContainsSection(filename))
                {
                    if (labelData.Sections[filename].ContainsKey(i.ToString()))
                    {
                        valueList.Items.Add(labelData.Sections[filename][i.ToString()]);
                    }
                    else
                    {
                        valueList.Items.Add("Entry " + i);
                    }
                }
                else
                {
                    valueList.Items.Add("Entry " + i);
                }
            }
        }

        private void valueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = valueList.SelectedIndex;
            if (refData != null)
            {
                try
                {
                    uint[] origData = refData[fileList.SelectedItem.ToString()];
                    byte[] origFloatBytes = BitConverter.GetBytes(origData[index]);
                    hexDataOrig.Text = origData[index].ToString("X8");
                    intDataOrig.Text = origData[index].ToString();
                    floatDataOrig.Text = BitConverter.ToSingle(origFloatBytes, 0).ToString();
                }
                catch 
                {
                    hexDataOrig.Text = "";
                    intDataOrig.Text = "";
                    floatDataOrig.Text = "";
                }
            }
            try
            {
                uint[] data = paramData[fileList.SelectedItem.ToString()];
                byte[] floatBytes = BitConverter.GetBytes(data[index]);
                hexData.Text = data[index].ToString("X8");
                intData.Text = data[index].ToString();
                floatData.Text = BitConverter.ToSingle(floatBytes, 0).ToString();
            }
            catch 
            {
                hexData.Text = "";
                intData.Text = "";
                floatData.Text = "";
            }

            labelBox.Text = "";
            discriptionBox.Text = "";
            try
            {
                string f = fileList.SelectedItem.ToString();
                string v = valueList.SelectedIndex.ToString();
                if (labelData.Sections.ContainsSection(f))
                {
                    if (labelData.Sections[f].ContainsKey(v))
                    {
                        labelBox.Text = labelData.Sections[f][v];
                    }
                    if (labelData.Sections[f].ContainsKey(v + "D"))
                    {
                        discriptionBox.Text = labelData.Sections[f][v + "D"];
                    }
                }
            } catch { }
        }

        private void updateLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateINI();
            RefreshReference();
            valueList.Items.Clear();
            hexData.Text = "";
            intData.Text = "";
            floatData.Text = "";
            hexDataOrig.Text = "";
            intDataOrig.Text = "";
            floatDataOrig.Text = "";
        }

        private void hexData_TextChanged(object sender, EventArgs e)
        {
            if (hexData.Text != "" && intData.Text != "" && floatData.Text != "" && hexData.Focused)
            {
                int index = valueList.SelectedIndex;
                uint[] data = paramData[fileList.SelectedItem.ToString()];
                byte[] floatBytes = BitConverter.GetBytes(uint.Parse(hexData.Text, System.Globalization.NumberStyles.HexNumber));
                intData.Text = uint.Parse(hexData.Text, System.Globalization.NumberStyles.HexNumber).ToString();
                floatData.Text = BitConverter.ToSingle(floatBytes, 0).ToString();
                data[index] = uint.Parse(hexData.Text, System.Globalization.NumberStyles.HexNumber);
                paramData[fileList.SelectedItem.ToString()] = data;
            }
        }

        private void intData_TextChanged(object sender, EventArgs e)
        {
            if (hexData.Text != "" && intData.Text != "" && floatData.Text != "" && intData.Focused)
            {
                int index = valueList.SelectedIndex;
                uint[] data = paramData[fileList.SelectedItem.ToString()];
                byte[] floatBytes = BitConverter.GetBytes(uint.Parse(intData.Text));
                hexData.Text = uint.Parse(intData.Text).ToString("X8");
                floatData.Text = BitConverter.ToSingle(floatBytes, 0).ToString();
                data[index] = uint.Parse(intData.Text);
                paramData[fileList.SelectedItem.ToString()] = data;
            }
        }

        private void floatData_TextChanged(object sender, EventArgs e)
        {
            if (hexData.Text != "" && intData.Text != "" && floatData.Text != "" && floatData.Focused)
            {
                try
                {
                    int index = valueList.SelectedIndex;
                    uint[] data = paramData[fileList.SelectedItem.ToString()];
                    byte[] floatBytes = BitConverter.GetBytes(float.Parse(floatData.Text));
                    uint parsedFloat = BitConverter.ToUInt32(floatBytes, 0);
                    hexData.Text = parsedFloat.ToString("X8");
                    intData.Text = parsedFloat.ToString();
                    data[index] = uint.Parse(hexData.Text, System.Globalization.NumberStyles.HexNumber);
                    paramData[fileList.SelectedItem.ToString()] = data;
                } catch { }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.AddExtension = true;
            save.Filter = "LZ11 Compressed XBIN Binary Archives|*.cmp|XBIN Binary Archives|*.bin";
            save.DefaultExt = ".cmp";
            if (save.ShowDialog() == DialogResult.OK)
            {
                filepath = save.FileName;
                Save();
            }
        }

        private void importPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Parameter Patch File|*.ini";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string importPath = open.FileName;
                IniData patchData = new FileIniDataParser().ReadFile(importPath);

                for (int i = 0; i < fileList.Items.Count; i++)
                {
                    if (patchData.Sections.ContainsSection(fileList.Items[i].ToString()))
                    {
                        string filename = fileList.Items[i].ToString();
                        uint[] values = paramData[filename];
                        for (int j = 0; j < values.Length; j++)
                        {
                            if (patchData.Sections[filename].ContainsKey(j.ToString()))
                            {
                                uint[] data = paramData[filename];
                                data[j] = uint.Parse(patchData.Sections[filename][j.ToString()], System.Globalization.NumberStyles.HexNumber);
                                paramData[filename] = data;
                            }
                        }
                    }
                }
                UpdateINI();
                RefreshReference();
                valueList.Items.Clear();
                hexData.Text = "";
                intData.Text = "";
                floatData.Text = "";
                hexDataOrig.Text = "";
                intDataOrig.Text = "";
                floatDataOrig.Text = "";
            }
        }
        private void generatePatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "New Patch";
            save.AddExtension = true;
            save.Filter = "Parameter Patch File|*.ini";
            if (save.ShowDialog() == DialogResult.OK)
            {
                IniData patch = new IniData();

                for (int i = 0; i < fileList.Items.Count; i++)
                {
                    string filename = fileList.Items[i].ToString();
                    uint[] values = paramData[filename];
                    for (int j = 0; j < values.Length; j++)
                    {
                        if (paramData[filename][j] != refData[filename][j])
                        {
                            if (!patch.Sections.ContainsSection(filename))
                            {
                                patch.Sections.AddSection(filename);
                            }
                            patch.Sections[filename].AddKey(j.ToString(), paramData[filename][j].ToString("X8"));
                        }
                    }
                }
                new FileIniDataParser().WriteFile(save.FileName, patch);
            }
        }
        private void decompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "LZ11 Compressed File|*.cmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                proc = new Process();
                Decompress(open.FileName);
                proc.WaitForExit();
                proc.Dispose();
                string newPath = open.FileName;
                if (open.FileName.EndsWith(".cmp"))
                {
                    newPath = open.FileName.Substring(0, open.FileName.Length - 4);
                    File.Copy(open.FileName, newPath, true);
                    File.Delete(open.FileName);
                }
            }
        }

        private void recompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                proc = new Process();
                Compress(open.FileName);
                proc.WaitForExit();
                proc.Dispose();
                string newPath = open.FileName;
                if (!open.FileName.EndsWith(".cmp"))
                {
                    newPath = open.FileName + ".cmp";
                    File.Copy(open.FileName, newPath, true);
                    File.Delete(open.FileName);
                }
            }
        }

        private void setLabel_Click(object sender, EventArgs e)
        {
            // Get Selected Param Group and Entry, remove the existing labels if they exist
            string f = fileList.SelectedItem.ToString();
            string v = valueList.SelectedIndex.ToString();
            if (!labelData.Sections.ContainsSection(f))
                labelData.Sections.AddSection(f);
            if (labelData.Sections[f].ContainsKey(v))
                labelData.Sections[f].RemoveKey(v);
            if (labelData.Sections[f].ContainsKey(v + "D"))
                labelData.Sections[f].RemoveKey(v + "D");

            // Set new labels
            if (!String.IsNullOrEmpty(labelBox.Text))
                labelData.Sections[f].AddKey(v, labelBox.Text);
            if (!String.IsNullOrEmpty(discriptionBox.Text))
                labelData.Sections[f].AddKey(v + "D", discriptionBox.Text);

            // Write to labels.ini
            new FileIniDataParser().WriteFile(Directory.GetCurrentDirectory() + "\\labels.ini", labelData);

            int prevF = fileList.SelectedIndex;
            int prevV = valueList.SelectedIndex;
            valueList.Items.Clear();
            UpdateFileList();
            fileList.SelectedIndex = prevF;
            valueList.SelectedIndex = prevV;
        }

        private void clrLabel_Click(object sender, EventArgs e)
        {
            string f = fileList.SelectedItem.ToString();
            string v = valueList.SelectedIndex.ToString();
            if (labelData.Sections.ContainsSection(f))
            {
                if (labelData.Sections[f].ContainsKey(v))
                    labelData.Sections[f].RemoveKey(v);
                if (labelData.Sections[f].ContainsKey(v + "D"))
                    labelData.Sections[f].RemoveKey(v + "D");
            }

            // Write to labels.ini
            new FileIniDataParser().WriteFile(Directory.GetCurrentDirectory() + "\\labels.ini", labelData);

            int prevF = fileList.SelectedIndex;
            int prevV = valueList.SelectedIndex;
            valueList.Items.Clear();
            UpdateFileList();
            fileList.SelectedIndex = prevF;
            valueList.SelectedIndex = prevV;
        }

        private void Decompress(string path)
        {
            // Decompress Archive
            proc.StartInfo.FileName = Directory.GetCurrentDirectory() + $"//lzx.exe";
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.Arguments = " -d " + path;
            proc.Start();
        }
        private void Compress(string path)
        {
            // Recompress Archive
            proc.StartInfo.FileName = Directory.GetCurrentDirectory() + $"//lzx.exe";
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.Arguments = " -evb " + path;
            proc.Start();
        }
    }
}
