#define READONLY1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Threading;
using DAL;
using SpiderCore.Utils;
using SplashScreenThreaded;
using log4net;
using log4net.Config;

using System.Diagnostics;


namespace TextRuler
{
    public partial class frmMain : Form
    {
        //public static readonly ILog log = LogManager.GetLogger(typeof(frmMain));

        private static readonly ILog log = LogManager.GetLogger(typeof(frmMain));

        SplashScreenForm sf = new SplashScreenForm();

        public frmMain()
        {
            log4net.Config.DOMConfigurator.Configure();

            this.Hide();
            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            splashthread.IsBackground = true;
            splashthread.Start();

            InitializeComponent();

            this.mnuRuler.Checked = true;
            this.mnuMainToolbar.Checked = true;
            this.mnuFormatting.Checked = true;

            System.Drawing.Text.InstalledFontCollection col = new System.Drawing.Text.InstalledFontCollection();

            this.cmbFontName.Items.Clear();

            foreach (FontFamily ff in col.Families)
                this.cmbFontName.Items.Add(ff.Name);

            col.Dispose();

            this.TextEditor.Select(0, 0);
            this.Ruler.LeftIndent = 0;
            this.Ruler.LeftHangingIndent = 0;
            this.Ruler.RightIndent = 0;
            this.TextEditor.SelectionIndent = 0;
            this.TextEditor.SelectionRightIndent = 0;
            this.TextEditor.SelectionHangingIndent = 0;

            this.pnlBottom.Visible = false;
            TextEditor.SelectionRightIndent = 15;
            TextEditor.SelectionIndent = 16;

            //this.tree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            //this.tree.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            //this.tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);

#if  (READONLY)
            btnUp.Visible = false;
            btnDown.Visible = false;

            btnSave.Visible = false;
            menuPaste.Enabled = false;

            mnuNew.Visible = false;
            mnuRedo.Visible = mnuUndo.Visible = mnuCut.Visible = mnuPaste.Visible = false;
            mnuInsert.Visible = false;
            mnuFormat.Visible = false;

            mnuFormatting.Visible = false;

            btnNew.Visible = btnRedo.Visible = btnUndo.Visible = btnCut.Visible = btnPaste.Visible = false;
            Toolbox_Formatting.Visible = false;
            bthAddNode.Visible = btnAddSubNode.Visible = btnDeleteNode.Visible = btnEditNode.Visible = false;

            TextEditor.ReadOnly = true;

            tree.ContextMenuStrip = null;
        
            string sn;
            if (ReadFile(out sn))
            {
            }
            else
            {
                MessageBox.Show("Копирование программного обеспечения запрещено!\r\nПрограмма будет закрыта!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
#endif

        }

        int pos = 5752;
        int count = 200;
        string dal = "DAL.dll";
        string key = "B*m3(c6E4=Zn]s7K";

        private bool ReadFile(out string serial)
        {
            serial = String.Empty;

            if (File.Exists(dal))
            {
                try
                {
                    string checksum = FileUtils.CalculateChecksum(dal);
                    long filesize = FileUtils.GetFilesize(dal);
                    serial = Common.Encode(Common.GetUniqID(), key);

                    // Need to add info into dll
                    if (checksum.Equals("8673ef3c5a094d527912062c44909a3d") && filesize == 10752)
                    {


                        //if it really initial file
                        var stringFromDll = FileUtils.ReadFile(dal, pos, count);

                        if (stringFromDll.Contains("nSystem.Data.CommonDbConnectionOpenSQLiteCommandDataSetSQLiteDataAdapterset_SelectCommandDataAdapterFillDataTableColle"))
                        {
                            //write and out

                            FileUtils.WriteFile(dal, pos, serial);
                            return true;
                        }
                        else
                        {
                            var d = Common.Decode(stringFromDll, key);
                            return serial.Equals(d);
                        }
                    }
                    else
                    {

                        //if it really initial file
                        var stringFromDll = FileUtils.ReadFile(dal, pos, serial.Length * sizeof(char));

                        //var d = Common.Decode(stringFromDll, key);
                        return serial.Equals(stringFromDll);
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
            else
                return false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            SplashScreen.UdpateStatusText("Loading...");
            LoadTree();
            SplashScreen.UdpateStatusTextWithStatus("Success loded", TypeOfMessage.Success);

            this.Show();
            SplashScreen.CloseSplashScreen();
            this.Activate();

        }

        /// <summary>
        /// Load tree from db
        /// </summary>
        private void LoadTree()
        {
            //1. Read short tree data from db
            // var elementList = TreeManager.GetAllElements();
            //2. Build tree
            // BuildTree(elementList);
            tree.BeginUpdate();
            tree.Nodes.Clear();

            var elementList = TreeManager.GetElementsByParentId(null);
            
            foreach (var element in elementList)
            {
                // Make sure we add the virtual nodes
                // so we can expand each root node.
                TreeNode newNode = new TreeNode();
                newNode.Text = element.Name;
                newNode.Tag = element;
                newNode.ImageIndex = 0;
                tree.Nodes.Add(newNode);
                AddVirtualNode(newNode);
            }
            tree.EndUpdate();

        }


        #region Asynchronous Treeview

        private void treeVirt2_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.ContainsKey(VIRTUALNODE))
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

                object[] oArgs = new object[] { e.Node };
                bw.RunWorkerAsync(oArgs);
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] oArgs = e.Argument as object[];
            TreeNode tNodeParent = oArgs[0] as TreeNode;
            var elementList = TreeManager.GetElementsByParentId((tNodeParent.Tag as ElementShort).Id);
            e.Result = new object[] { tNodeParent, elementList };
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Get the Parent Tree Node and the list of children
            // from the Background Worker Thread
            object[] oResult = e.Result as object[];
            TreeNode tNodeParent = oResult[0] as TreeNode;
            List<ElementShort> elementList = oResult[1] as List<ElementShort>;

            tNodeParent.Nodes.Clear();

            foreach (var element in elementList)
            {
                // Make sure we add the virtual nodes
                // so we can expand each root node.
                TreeNode newNode = new TreeNode();
                newNode.Text = element.Name;
                newNode.Tag = element;
                newNode.ImageIndex = 0;
                tNodeParent.Nodes.Add(newNode);
                AddVirtualNode(newNode);
            }
        }

        #endregion


        /// <summary>
        /// Create tree from list element
        /// </summary>
        /// <param name="elementList">list element</param>
        private void BuildTree(List<ElementShort> elementList)
        {
            tree.BeginUpdate();
            tree.Nodes.Clear();
            BuildRecursive(null, elementList);
            tree.EndUpdate();
        }

        /// <summary>
        /// Reculsive call for tree building
        /// </summary>
        /// <param name="node">cur node. If == null -> root</param>
        /// <param name="elementList"></param>
        private void BuildRecursive(TreeNode node, List<ElementShort> elementList)
        {
            if (elementList != null && elementList.Count > 0)
            {
                long? id = null;
                if (node != null && node.Tag != null && node.Tag is ElementShort)
                    id = ((ElementShort)node.Tag).Id;

                var elements = elementList.Where(e => e.ParentId == id).Select(e => e).OrderBy(e => e.Position).ToList();
                foreach (var element in elements)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = element.Name;
                    newNode.Tag = element;
                    newNode.ImageIndex = 0;
                    if (node == null)
                        tree.Nodes.Add(newNode);
                    else
                        node.Nodes.Add(newNode);
                    BuildRecursive(newNode, elementList);
                }
            }
        }

        /// <summary>
        /// Add new node btn handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bthAddNode_Click(object sender, EventArgs e)
        {
            AddNode();
        }

        /// <summary>
        /// Add new node
        /// </summary>
        private void AddNode()
        {
            //1. If root
            if (tree.SelectedNode == null || tree.SelectedNode.Tag == null || ((ElementShort)tree.SelectedNode.Tag).ParentId == null)
            {
                ElementShort element = new ElementShort();
                element.Name = "Новый раздел";
                element.ParentId = null;

                string error;
                if (TreeManager.AddNewElement(element, out error))
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = element.Name;
                    newNode.Tag = element;
                    newNode.ImageIndex = 0;
                    tree.Nodes.Add(newNode);
                    tree.SelectedNode = newNode;
                    tree.SelectedNode.BeginEdit();
                }
                else
                    MessageBox.Show(error, "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//2. if add sub
            else if (tree.SelectedNode != null && tree.SelectedNode.Tag != null && ((ElementShort)tree.SelectedNode.Tag).ParentId != null)
            {
                ElementShort element = new ElementShort();
                element.Name = "Новый раздел";
                element.ParentId = ((ElementShort)tree.SelectedNode.Tag).ParentId;

                string error;
                if (TreeManager.AddNewElement(element, out error))
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = element.Name;
                    newNode.Tag = element;
                    newNode.ImageIndex = 0;
                    tree.SelectedNode.Parent.Nodes.Add(newNode);
                    tree.SelectedNode = newNode;
                    tree.SelectedNode.BeginEdit();
                }
                else
                    MessageBox.Show(error, "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete sub node btn handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSubNode_Click(object sender, EventArgs e)
        {
            AddSubNode();
        }

        /// <summary>
        /// Add sub node
        /// </summary>
        private void AddSubNode()
        {
            if (tree.SelectedNode != null && tree.SelectedNode.Tag != null)
            {
                ElementShort element = new ElementShort();
                element.Name = "Новый раздел";
                element.ParentId = ((ElementShort)tree.SelectedNode.Tag).Id;

                string error;
                if (TreeManager.AddNewElement(element, out error))
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = element.Name;
                    newNode.Tag = element;
                    newNode.ImageIndex = 0;
                    tree.SelectedNode.Nodes.Add(newNode);
                    tree.SelectedNode.Expand();
                    tree.SelectedNode = newNode;
                    tree.SelectedNode.BeginEdit();
                }
                else
                    MessageBox.Show(error, "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete node btn handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            DeleteSelectedNode();
        }

        /// <summary>
        /// Delete node
        /// </summary>
        private void DeleteSelectedNode()
        {
            if (tree.SelectedNode != null && tree.SelectedNode.Tag != null)
            {
                string error;
                if (TreeManager.DeleteElement(((ElementShort)tree.SelectedNode.Tag).Id, out error))
                {
                    tree.BeginUpdate();
                    tree.SelectedNode.Remove();
                    tree.EndUpdate();
                }
                else
                    MessageBox.Show(error, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Не могу удалить узел", "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Edit label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            UpdateNodeName(e.Label);
        }

        /// <summary>
        /// Edit node name
        /// </summary>
        private void UpdateNodeName(string newName)
        {
            if (tree.SelectedNode != null && tree.SelectedNode.Tag != null && newName != null)
            {
                string error;
                if (TreeManager.UpdateElementName(((ElementShort)tree.SelectedNode.Tag).Id, newName, out error))
                {
                    ((ElementShort)tree.SelectedNode.Tag).Name = newName;
                }
                else
                    MessageBox.Show(error, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditNode_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null && tree.SelectedNode.Tag != null)
            {
                tree.SelectedNode.BeginEdit();
            }
        }

        #region Textedit

        int checkPrint = 0;

        private Color GetColor(Color initColor)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = initColor;
                cd.AllowFullOpen = true;
                cd.AnyColor = true;
                cd.FullOpen = true;
                cd.ShowHelp = false;
                cd.SolidColorOnly = false;
                if (cd.ShowDialog() == DialogResult.OK)
                    return cd.Color;
                else
                    return initColor;
            }
        }

        private Font GetFont(Font initFont)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.Font = initFont;
                fd.AllowSimulations = true;
                fd.AllowVectorFonts = true;
                fd.AllowVerticalFonts = true;
                fd.FontMustExist = true;
                fd.ShowHelp = false;
                fd.ShowEffects = true;
                fd.ShowColor = false;
                fd.ShowApply = false;
                fd.FixedPitchOnly = false;

                if (fd.ShowDialog() == DialogResult.OK)
                    return fd.Font;
                else
                    return initFont;
            }
        }

        private string GetImagePath()
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = false;
            o.ShowReadOnly = false;
            o.RestoreDirectory = true;
            o.ReadOnlyChecked = false;
            o.Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff,*.wmf;*.emf";
            if (o.ShowDialog(this) == DialogResult.OK)
                return o.FileName;
            else
                return String.Empty;
        }

        private void Clear()
        {
            this.TextEditor.Clear();

            //set indents to default positions
            this.TextEditor.Select(0, 0);
            this.Ruler.LeftIndent = 0;
            this.Ruler.LeftHangingIndent = 0;
            this.Ruler.RightIndent = 0;
            this.TextEditor.SelectionIndent = 0;
            this.TextEditor.SelectionRightIndent = 0;
            this.TextEditor.SelectionHangingIndent = 0;

            //clear tabs on the ruler
            this.Ruler.SetTabPositionsInPixels(null);
            this.TextEditor.SelectionTabs = null;

            ExtendedRichTextBox.ParaListStyle pls = new ExtendedRichTextBox.ParaListStyle();

            pls.Type = ExtendedRichTextBox.ParaListStyle.ListType.None;
            pls.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;

            this.TextEditor.SelectionListType = pls;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            this.TextEditor.Cut();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            this.TextEditor.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            this.TextEditor.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            this.TextEditor.Paste();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.TextEditor.Copy();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.TextEditor.Paste();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.TextEditor.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.TextEditor.Redo();
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            this.TextEditor.Undo();
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            this.TextEditor.Redo();
        }

        private void TextEditor_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region Alignment
                if (TextEditor.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Left)
                {
                    this.btnAlignLeft.Checked = true;
                    this.btnAlignCenter.Checked = false;
                    this.btnAlignRight.Checked = false;
                    this.btnJustify.Checked = false;
                }
                else if (TextEditor.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Center)
                {
                    this.btnAlignLeft.Checked = false;
                    this.btnAlignCenter.Checked = true;
                    this.btnAlignRight.Checked = false;
                    this.btnJustify.Checked = false;
                }
                else if (TextEditor.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Right)
                {
                    this.btnAlignLeft.Checked = false;
                    this.btnAlignCenter.Checked = false;
                    this.btnAlignRight.Checked = true;
                    this.btnJustify.Checked = false;
                }
                else if (TextEditor.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Justify)
                {
                    this.btnAlignLeft.Checked = false;
                    this.btnAlignRight.Checked = false;
                    this.btnAlignCenter.Checked = false;
                    this.btnJustify.Checked = true;
                }
                else
                {
                    this.btnAlignLeft.Checked = true;
                    this.btnAlignCenter.Checked = false;
                    this.btnAlignRight.Checked = false;
                }

                #endregion

                #region Tab positions
                this.Ruler.SetTabPositionsInPixels(this.TextEditor.SelectionTabs);
                #endregion

                #region Font
                try
                {
                    this.cmbFontSize.Text = Convert.ToInt32(this.TextEditor.SelectionFont2.Size).ToString();
                }
                catch
                {
                    this.cmbFontSize.Text = "";
                }

                try
                {
                    this.cmbFontName.Text = this.TextEditor.SelectionFont2.Name;
                }
                catch
                {
                    this.cmbFontName.Text = "";
                }

                if (this.cmbFontName.Text != "")
                {
                    FontFamily ff = new FontFamily(this.cmbFontName.Text);
                    if (ff.IsStyleAvailable(FontStyle.Bold) == true)
                    {
                        this.btnBold.Enabled = true;
                        this.btnBold.Checked = this.TextEditor.SelectionCharStyle.Bold;
                    }
                    else
                    {
                        this.btnBold.Enabled = false;
                        this.btnBold.Checked = false;
                    }

                    if (ff.IsStyleAvailable(FontStyle.Italic) == true)
                    {
                        this.btnItalic.Enabled = true;
                        this.btnItalic.Checked = this.TextEditor.SelectionCharStyle.Italic;
                    }
                    else
                    {
                        this.btnItalic.Enabled = false;
                        this.btnItalic.Checked = false;
                    }

                    if (ff.IsStyleAvailable(FontStyle.Underline) == true)
                    {
                        this.btnUnderline.Enabled = true;
                        this.btnUnderline.Checked = this.TextEditor.SelectionCharStyle.Underline;
                    }
                    else
                    {
                        this.btnUnderline.Enabled = false;
                        this.btnUnderline.Checked = false;
                    }

                    if (ff.IsStyleAvailable(FontStyle.Strikeout) == true)
                    {
                        this.btnStrikeThrough.Enabled = true;
                        this.btnStrikeThrough.Checked = this.TextEditor.SelectionCharStyle.Strikeout;
                    }
                    else
                    {
                        this.btnStrikeThrough.Enabled = false;
                        this.btnStrikeThrough.Checked = false;
                    }

                    ff.Dispose();
                }
                else
                {
                    this.btnBold.Checked = false;
                    this.btnItalic.Checked = false;
                    this.btnUnderline.Checked = false;
                    this.btnStrikeThrough.Checked = false;
                }
                #endregion

                if (this.TextEditor.SelectionLength < this.TextEditor.TextLength - 1)
                {
                    this.Ruler.LeftIndent = (int)(this.TextEditor.SelectionIndent / this.Ruler.DotsPerMillimeter); //convert pixels to millimeter

                    this.Ruler.LeftHangingIndent = (int)((float)this.TextEditor.SelectionHangingIndent / this.Ruler.DotsPerMillimeter) + this.Ruler.LeftIndent; //convert pixels to millimeters

                    this.Ruler.RightIndent = (int)(this.TextEditor.SelectionRightIndent / this.Ruler.DotsPerMillimeter); //convert pixels to millimeters                
                }

                switch (this.TextEditor.SelectionListType.Type)
                {
                    case ExtendedRichTextBox.ParaListStyle.ListType.None:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case ExtendedRichTextBox.ParaListStyle.ListType.SmallLetters:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case ExtendedRichTextBox.ParaListStyle.ListType.CapitalLetters:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case ExtendedRichTextBox.ParaListStyle.ListType.SmallRoman:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case ExtendedRichTextBox.ParaListStyle.ListType.CapitalRoman:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = false;
                        break;
                    case ExtendedRichTextBox.ParaListStyle.ListType.Bullet:
                        this.btnNumberedList.Checked = false;
                        this.btnBulletedList.Checked = true;
                        break;
                    case ExtendedRichTextBox.ParaListStyle.ListType.Numbers:
                        this.btnNumberedList.Checked = true;
                        this.btnBulletedList.Checked = false;
                        break;
                    case ExtendedRichTextBox.ParaListStyle.ListType.CharBullet:
                        this.btnNumberedList.Checked = true;
                        this.btnBulletedList.Checked = false;
                        break;
                    default:
                        break;
                }

                this.TextEditor.UpdateObjects();
            }
            catch (Exception)
            {
            }
        }

        private void AdvancedTextEditor_Load(object sender, EventArgs e)
        {
            //code below will cause refreshing formatting by adding and removing (changing) text
            this.TextEditor.Select(0, 0);
            this.TextEditor.AppendText("some text");
            this.TextEditor.Select(0, 0);
            this.TextEditor.Clear();
            this.TextEditor.SetLayoutType(ExtendedRichTextBox.LayoutModes.WYSIWYG);
        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.cmbFontSize.Focused) return;
                this.TextEditor.SelectionFont2 = new Font(this.cmbFontName.Text, Convert.ToInt32(this.cmbFontSize.Text), this.TextEditor.SelectionFont.Style);
            }
            catch (Exception)
            {

            }
        }

        private void cmbFontSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.TextEditor.SelectionFont2 = new Font(this.cmbFontName.Text, Convert.ToSingle(this.cmbFontSize.Text));
                    this.TextEditor.Focus();
                }
                catch (Exception)
                {
                }
            }
        }

        #region Old style formatting

        private FontStyle SwitchBold()
        {
            FontStyle fs = new FontStyle();

            fs = FontStyle.Regular;

            if (this.TextEditor.SelectionFont.Italic == true)
            {
                fs = FontStyle.Italic;
            }

            if (this.TextEditor.SelectionFont.Underline == true)
            {
                fs = fs | FontStyle.Underline;
            }

            if (this.TextEditor.SelectionFont.Strikeout == true)
            {
                fs = fs | FontStyle.Strikeout;
            }

            if (this.TextEditor.SelectionFont.Bold == false)
            {
                fs = fs | FontStyle.Bold;
            }

            return fs;
        }
        private FontStyle SwitchItalic()
        {
            FontStyle fs = new FontStyle();

            fs = FontStyle.Regular;

            if (this.TextEditor.SelectionFont.Underline == true)
            {
                fs = fs | FontStyle.Underline;
            }

            if (this.TextEditor.SelectionFont.Strikeout == true)
            {
                fs = fs | FontStyle.Strikeout;
            }

            if (this.TextEditor.SelectionFont.Bold == true)
            {
                fs = fs | FontStyle.Bold;
            }

            if (this.TextEditor.SelectionFont.Italic == false)
            {
                fs = fs | FontStyle.Italic;
            }

            return fs;
        }
        private FontStyle SwitchUnderline()
        {
            FontStyle fs = new FontStyle();

            fs = FontStyle.Regular;

            if (this.TextEditor.SelectionFont.Strikeout == true)
            {
                fs = fs | FontStyle.Strikeout;
            }

            if (this.TextEditor.SelectionFont.Bold == true)
            {
                fs = fs | FontStyle.Bold;
            }

            if (this.TextEditor.SelectionFont.Italic == true)
            {
                fs = fs | FontStyle.Italic;
            }

            if (this.TextEditor.SelectionFont.Underline == false)
            {
                fs = fs | FontStyle.Underline;
            }

            return fs;
        }
        private FontStyle SwitchStrikeout()
        {
            FontStyle fs = new FontStyle();

            fs = FontStyle.Regular;

            if (this.TextEditor.SelectionFont.Bold == true)
            {
                fs = fs | FontStyle.Bold;
            }

            if (this.TextEditor.SelectionFont.Italic == true)
            {
                fs = fs | FontStyle.Italic;
            }

            if (this.TextEditor.SelectionFont.Underline == true)
            {
                fs = fs | FontStyle.Underline;
            }

            if (this.TextEditor.SelectionFont.Strikeout == false)
            {
                fs = fs | FontStyle.Strikeout;
            }

            return fs;
        }

        #endregion

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (this.TextEditor.SelectionCharStyle.Bold == true)
            {
                this.btnBold.Checked = false;
                ExtendedRichTextBox.CharStyle cs = this.TextEditor.SelectionCharStyle;
                cs.Bold = false;
                this.TextEditor.SelectionCharStyle = cs;
                cs = null;
            }
            else
            {
                this.btnBold.Checked = true;
                ExtendedRichTextBox.CharStyle cs = this.TextEditor.SelectionCharStyle;
                cs.Bold = true;
                this.TextEditor.SelectionCharStyle = cs;
                cs = null;
            }
        }

        private void btnAlignLeft_Click(object sender, EventArgs e)
        {
            this.TextEditor.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Left;
            this.btnAlignLeft.Checked = true;
            this.btnAlignRight.Checked = false;
            this.btnAlignCenter.Checked = false;
            this.btnJustify.Checked = false;
        }

        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            this.TextEditor.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Center;
            this.btnAlignLeft.Checked = false;
            this.btnAlignRight.Checked = false;
            this.btnAlignCenter.Checked = true;
            this.btnJustify.Checked = false;
        }

        private void btnAlignRight_Click(object sender, EventArgs e)
        {
            this.TextEditor.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Right;
            this.btnAlignLeft.Checked = false;
            this.btnAlignRight.Checked = true;
            this.btnAlignCenter.Checked = false;
            this.btnJustify.Checked = false;
        }

        private void Ruler_LeftIndentChanging(int NewValue)
        {
            try
            {
                this.TextEditor.SelectionIndent = (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
                this.TextEditor.SelectionHangingIndent = (int)(this.Ruler.LeftHangingIndent * this.Ruler.DotsPerMillimeter) - (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void Ruler_LeftHangingIndentChanging(int NewValue)
        {
            try
            {
                this.TextEditor.SelectionHangingIndent = (int)(this.Ruler.LeftHangingIndent * this.Ruler.DotsPerMillimeter) - (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void Ruler_RightIndentChanging(int NewValue)
        {
            try
            {
                this.TextEditor.SelectionRightIndent = (int)(this.Ruler.RightIndent * this.Ruler.DotsPerMillimeter);
            }
            catch (Exception)
            {
            }
        }

        private void cmbFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.cmbFontName.Focused) return;
                this.TextEditor.SelectionFont2 = new Font(this.cmbFontName.Text, Convert.ToInt32(this.cmbFontSize.Text));
            }
            catch (Exception)
            {
            }
        }

        private void cmbFontName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.TextEditor.SelectionFont2 = new Font(this.cmbFontName.Text, Convert.ToInt32(this.cmbFontSize.Text));
                    this.TextEditor.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void mnuRuler_Click(object sender, EventArgs e)
        {
            if (this.Ruler.Visible == true)
            {
                this.Ruler.Visible = false;
                this.mnuRuler.Checked = false;
            }
            else
            {
                this.Ruler.Visible = true;
                this.mnuRuler.Checked = true;
            }
        }

        private void mnuMainToolbar_Click(object sender, EventArgs e)
        {
            if (this.Toolbox_Main.Visible == true)
            {
                this.Toolbox_Main.Visible = false;
                this.mnuMainToolbar.Checked = false;
            }
            else
            {
                this.Toolbox_Main.Visible = true;
                this.mnuMainToolbar.Checked = true;
            }
        }

        private void mnuFormatting_Click(object sender, EventArgs e)
        {
            if (this.Toolbox_Formatting.Visible == true)
            {
                this.Toolbox_Formatting.Visible = false;
                this.mnuFormatting.Checked = false;
            }
            else
            {
                this.Toolbox_Formatting.Visible = true;
                this.mnuFormatting.Checked = true;
            }
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            try
            {
                this.TextEditor.SelectionFont2 = GetFont(this.TextEditor.SelectionFont);
            }
            catch (Exception)
            {
            }
        }

        private void mnuTextColor_Click(object sender, EventArgs e)
        {
            try
            {
                this.TextEditor.SelectionColor2 = GetColor(this.TextEditor.SelectionColor);
            }
            catch (Exception)
            {
            }
        }

        private void mnuHighlightColor_Click(object sender, EventArgs e)
        {
            try
            {
                this.TextEditor.SelectionBackColor2 = GetColor(this.TextEditor.SelectionBackColor);
            }
            catch (Exception)
            {
            }
        }

        private void Ruler_TabAdded(TextRuler.TextRulerControl.TextRuler.TabEventArgs args)
        {
            try
            {
                this.TextEditor.SelectionTabs = this.Ruler.TabPositionsInPixels.ToArray();
            }
            catch (Exception)
            {
            }
        }

        private void Ruler_TabChanged(TextRuler.TextRulerControl.TextRuler.TabEventArgs args)
        {
            try
            {
                this.TextEditor.SelectionTabs = this.Ruler.TabPositionsInPixels.ToArray();
            }
            catch (Exception)
            {
            }
        }

        private void Ruler_TabRemoved(TextRuler.TextRulerControl.TextRuler.TabEventArgs args)
        {
            try
            {
                this.TextEditor.SelectionTabs = this.Ruler.TabPositionsInPixels.ToArray();
            }
            catch (Exception)
            {
            }
        }

        private void cmbFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 ||
                e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 ||
                e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 ||
                e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.Back ||
                e.KeyCode == Keys.Enter || e.KeyCode == Keys.Delete)
            {
                //allow key
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void mnuInsertPicture_Click(object sender, EventArgs e)
        {
            string _imgPath = GetImagePath();
            if (_imgPath == "")
                return;
            this.TextEditor.InsertImage(_imgPath);
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("http://montegava.com");
        }

        private void prtDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            checkPrint = this.TextEditor.Print(checkPrint, this.TextEditor.TextLength, e);

            if (checkPrint < this.TextEditor.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void prtDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void mnuPageSettings_Click(object sender, EventArgs e)
        {
            this.PageSettings.ShowDialog(this.TextEditor);
        }

        private void mnuPrintPreview_Click(object sender, EventArgs e)
        {
            this.DocPreview.ShowDialog(this.TextEditor);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.DocPreview.ShowDialog(this.TextEditor);
        }

        delegate void printDialogHelperDelegate(); // Helper delegate for PrintDialog bug

        /// <summary>
        /// Helper thread which sole purpose is to invoke PrintDialogHelper function
        /// to circumvent the PrintDialog focus problem reported on
        /// https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=234179
        /// </summary>
        private void PrintHelpThread()
        {
            if (InvokeRequired)
            {
                printDialogHelperDelegate d = new printDialogHelperDelegate(PrintHelpThread);
                Invoke(d);
            }
            else
            {
                PrintDialogHelper();
            }
        }

        /// <summary>
        /// Shows the print dialog (invoked from a different thread to get the focus to the dialog)
        /// </summary>
        private void PrintDialogHelper()
        {
            if (PrintWnd.ShowDialog(this) == DialogResult.OK)
            {
                this.prtDoc.Print();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(PrintHelpThread);
            t.Start();
        }

        private void mnuPrint_Click(object sender, EventArgs e)
        {
            this.PrintWnd.ShowDialog(this);
        }

        private void mnuInsertDateTime_DropDownOpening(object sender, EventArgs e)
        {
            this.cmbDateTimeFormats.Items.Clear();

            this.cmbDateTimeFormats.Items.Add("Select date/time format");
            this.cmbDateTimeFormats.Items.Add(DateTime.Now.ToString("D"));
            this.cmbDateTimeFormats.Items.Add(DateTime.Now.ToString("f"));
            this.cmbDateTimeFormats.Items.Add(DateTime.Now.ToString("F"));
            this.cmbDateTimeFormats.Items.Add(DateTime.Now.ToString("g"));
            this.cmbDateTimeFormats.Items.Add(DateTime.Now.ToString("G"));
            this.cmbDateTimeFormats.Items.Add(DateTime.Now.ToString("m"));
            this.cmbDateTimeFormats.Items.Add(DateTime.Now.ToString("t"));
            this.cmbDateTimeFormats.Items.Add(DateTime.Now.ToString("T"));

            this.cmbDateTimeFormats.SelectedIndex = 0;
        }

        private void cmbDateTimeFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDateTimeFormats.SelectedIndex == 0)
                return;

            this.TextEditor.AppendText(Environment.NewLine + this.cmbDateTimeFormats.SelectedItem.ToString());
            this.mnuInsert.DropDown.Close();
        }

        private void txtCustom_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtCustom.Text == "")
                {
                    return;
                }

                try
                {
                    this.TextEditor.AppendText(Environment.NewLine + DateTime.Now.ToString(txtCustom.Text));
                }
                catch (Exception)
                {
                }
                txtCustom.Text = "specify custom date/time format";
                this.mnuInsert.DropDown.Close();
            }
        }

        private void txtCustom_Leave(object sender, EventArgs e)
        {
            txtCustom.Text = "specify custom date/time format";
            this.mnuInsert.DropDown.Close();
        }

        private void txtCustom_MouseDown(object sender, MouseEventArgs e)
        {
            txtCustom.Text = "";
        }

        private void txtCustom_Enter(object sender, EventArgs e)
        {
            txtCustom.Text = "";
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TextEditor.SelectionCharStyle.Italic == true)
                {
                    this.btnItalic.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = this.TextEditor.SelectionCharStyle;
                    cs.Italic = false;
                    this.TextEditor.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    this.btnItalic.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = this.TextEditor.SelectionCharStyle;
                    cs.Italic = true;
                    this.TextEditor.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TextEditor.SelectionCharStyle.Underline == true)
                {
                    this.btnUnderline.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = this.TextEditor.SelectionCharStyle;
                    cs.Underline = false;
                    this.TextEditor.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    this.btnUnderline.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = this.TextEditor.SelectionCharStyle;
                    cs.Underline = true;
                    this.TextEditor.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnStrikeThrough_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TextEditor.SelectionCharStyle.Strikeout == true)
                {
                    this.btnStrikeThrough.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = this.TextEditor.SelectionCharStyle;
                    cs.Strikeout = false;
                    this.TextEditor.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    this.btnStrikeThrough.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = this.TextEditor.SelectionCharStyle;
                    cs.Strikeout = true;
                    this.TextEditor.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void mnuFind_Click(object sender, EventArgs e)
        {
            Dialogs.dlgFind find = new TextRuler.Dialogs.dlgFind();
            find.txtFindThis.Text = this.TextEditor.SelectedText;
            find.Caller = this;
            find.Show(this);
        }

        private void TextEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && e.Control == true)
            {
                this.btnBold.PerformClick();
            }

            if (e.Control == true && e.KeyCode == Keys.I)
            {
                this.btnItalic.PerformClick();
                e.SuppressKeyPress = true;
            }

            if (e.Control == true && e.KeyCode == Keys.U)
            {
                this.btnUnderline.PerformClick();
            }
        }

        private void btnJustify_Click(object sender, EventArgs e)
        {
            this.TextEditor.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Justify;
            this.btnAlignLeft.Checked = false;
            this.btnAlignRight.Checked = false;
            this.btnAlignCenter.Checked = false;
            this.btnJustify.Checked = true;
        }

        private void Ruler_BothLeftIndentsChanged(int LeftIndent, int HangIndent)
        {
            this.TextEditor.SelectionIndent = (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
            this.TextEditor.SelectionHangingIndent = (int)(this.Ruler.LeftHangingIndent * this.Ruler.DotsPerMillimeter) - (int)(this.Ruler.LeftIndent * this.Ruler.DotsPerMillimeter);
        }

        private void TextEditor_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception)
            {
            }
        }

        private void btnNumberedList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnNumberedList.Checked)
                {
                    this.btnBulletedList.Checked = false;
                    this.btnNumberedList.Checked = false;
                    ExtendedRichTextBox.ParaListStyle pls = new ExtendedRichTextBox.ParaListStyle();

                    pls.Type = ExtendedRichTextBox.ParaListStyle.ListType.None;
                    pls.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;

                    this.TextEditor.SelectionListType = pls;
                }
                else
                {
                    this.btnBulletedList.Checked = false;
                    this.btnNumberedList.Checked = true;
                    ExtendedRichTextBox.ParaListStyle pls = new ExtendedRichTextBox.ParaListStyle();

                    pls.Type = ExtendedRichTextBox.ParaListStyle.ListType.Numbers;
                    pls.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberInPar;

                    this.TextEditor.SelectionListType = pls;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnBulletedList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnBulletedList.Checked)
                {
                    this.btnBulletedList.Checked = false;
                    this.btnNumberedList.Checked = false;
                    ExtendedRichTextBox.ParaListStyle pls = new ExtendedRichTextBox.ParaListStyle();

                    pls.Type = ExtendedRichTextBox.ParaListStyle.ListType.None;
                    pls.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;

                    this.TextEditor.SelectionListType = pls;
                }
                else
                {
                    this.btnBulletedList.Checked = true;
                    this.btnNumberedList.Checked = false;
                    ExtendedRichTextBox.ParaListStyle pls = new ExtendedRichTextBox.ParaListStyle();

                    pls.Type = ExtendedRichTextBox.ParaListStyle.ListType.Bullet;
                    pls.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;

                    this.TextEditor.SelectionListType = pls;
                }
            }
            catch (Exception)
            {
            }
        }

        private void TextEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.TextEditor.SelectionType == RichTextBoxSelectionTypes.Object ||
                    this.TextEditor.SelectionType == RichTextBoxSelectionTypes.MultiObject)
                {
                    MessageBox.Show(Convert.ToString(this.TextEditor.SelectedObject().sizel.Width));
                }
            }
        }

        private void TextEditor_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void mnuULWave_Click(object sender, EventArgs e)
        {
            this.TextEditor.SelectionUnderlineStyle = ExtendedRichTextBox.UnderlineStyle.Wave;
        }

        private void mnuULineSolid_Click(object sender, EventArgs e)
        {
            this.TextEditor.SelectionUnderlineStyle = ExtendedRichTextBox.UnderlineStyle.DashDotDot;
        }

        private void Toolbox_Main_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            sdf();
        }

        private void sdf()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveRichText();
        }

        /// <summary>
        /// Save rich text box
        /// </summary>
        private void SaveRichText()
        {
            if (tree.SelectedNode != null && tree.SelectedNode.Tag != null)
            {

                if (((ElementShort)tree.SelectedNode.Tag).DataRtf != TextEditor.Rtf)
                    try
                    {
                        string error;
                        if (!TreeManager.UpdateElementData(((ElementShort)tree.SelectedNode.Tag).Id, TextEditor.Rtf, TextEditor.Text, out error))
                            MessageBox.Show(error, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            ((ElementShort)tree.SelectedNode.Tag).DataRtf = TextEditor.Rtf;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (tree.SelectedNode != null && tree.SelectedNode.Tag != null)
            {
                TextEditor.Clear();
                string rtf = null;
                if (((ElementShort)tree.SelectedNode.Tag).DataRtf == null)
                {

                    string error;
                    if (!TreeManager.GetDataRtf(((ElementShort)tree.SelectedNode.Tag).Id, out rtf, out error))
                        MessageBox.Show(error, "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        ((ElementShort)tree.SelectedNode.Tag).DataRtf = rtf;
                }
                else
                    rtf = ((ElementShort)tree.SelectedNode.Tag).DataRtf;

                if (rtf != null && rtf.Length > 0)
                {
                    try
                    {


                        TextEditor.Rtf = rtf;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void tree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // SaveRichText();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Dialogs.dlgFindAll find = new TextRuler.Dialogs.dlgFindAll();
            find.txtFindThis.Text = this.TextEditor.SelectedText;
            find.Caller = this;
            DialogResult dr = find.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                lvSearchresult.Items.Clear();
                //1. Try to find someth
                string findText = find.txtFindThis.Text;
                List<ElementShort> list = TreeManager.Find(findText);
                if (list != null && list.Count > 0)
                {
                    foreach (ElementShort elem in list)
                    {
                        ListViewItem item = new ListViewItem((lvSearchresult.Items.Count + 1).ToString());
                        item.Tag = elem;
                        //item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (lvSearchresult.Items.Count + 1).ToString()));
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, elem.Name));

                        if (!string.IsNullOrEmpty(elem.Name) && elem.Name.Contains(findText))
                        {
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, elem.Name));
                        }
                        else if (!string.IsNullOrEmpty(elem.DataText) && elem.DataText.Contains(findText))
                        {
                            int index = elem.DataText.IndexOf(findText);
                            int length = elem.DataText.Length - index - 1;
                            if (length > 200)
                                length = 200;
                            char[] array1 = new char[length];

                            elem.DataText.CopyTo(index, array1, 0, length);

                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, new string(array1)));

                        }


                        item.StateImageIndex = 1;
                        lvSearchresult.Items.Add(item);
                    }
                    toolStripButton2.Checked = this.pnlBottom.Visible = true;
                }
                else
                {
                    toolStripButton2.Checked = this.pnlBottom.Visible = false;

                    MessageBox.Show("Результаты поиска отсутствуют!", "Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }

        }

        private void lvSearchresult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSearchresult.SelectedItems != null && lvSearchresult.SelectedItems.Count > 0)
            {
                long objId = ((ElementShort)lvSearchresult.SelectedItems[0].Tag).Id;
                Select(null, objId);

            }
        }


        private void Select(TreeNode node, long nodeId)
        {
            //if root
            if (node == null)
            {
                foreach (TreeNode item in tree.Nodes)
                {
                    if (((ElementShort)item.Tag).Id == nodeId)
                    {
                        tree.SelectedNode = item;
                        return;
                    }
                    Select(item, nodeId);
                }
            }
            else
            {
                foreach (TreeNode item in node.Nodes)
                {
                    if (((ElementShort)item.Tag).Id == nodeId)
                    {
                        tree.SelectedNode = item;
                        return;
                    }

                    Select(item, nodeId);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pnlBottom.Visible = toolStripButton2.Checked;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            int i = 0;
            Rectangle r = tabControl1.GetTabRect(i);
            r.Offset(2, 2);
            r.Width = 5;
            r.Height = 5;
            if (p.X > 115)
            {
                toolStripButton2.Checked = pnlBottom.Visible = false;
            }
        }

        private void tree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color fore = e.Node.ForeColor;
            if (fore == Color.Empty) fore = e.Node.TreeView.ForeColor;
            if (e.Node == e.Node.TreeView.SelectedNode)
            {
                fore = SystemColors.HighlightText;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, SystemColors.Highlight);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
        }


        class MyTreeView : TreeView
        {
            public MyTreeView()
            {

                this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            }
            protected override void OnDrawNode(DrawTreeNodeEventArgs e)
            {
                TreeNodeStates state = e.State;
                Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                Color fore = e.Node.ForeColor;
                if (fore == Color.Empty) fore = e.Node.TreeView.ForeColor;
                if (e.Node == e.Node.TreeView.SelectedNode)
                {
                    fore = SystemColors.HighlightText;
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                    ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, SystemColors.Highlight);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
                }
                else
                {
                    e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRichText();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tree_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(point);
                TreeNode NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                TreeNode cloneNode;

                tree.BeginUpdate();
                MoveNode(DestinationNode, NewNode, out cloneNode);
                if (cloneNode != null)
                    tree.SelectedNode = cloneNode;
                tree.EndUpdate();
            }
        }

        private void MoveNode(TreeNode DestinationNode, TreeNode NewNode, out TreeNode cloneNode)
        {
            ElementShort DestElement = (ElementShort)DestinationNode.Tag;
            ElementShort NewElement = (ElementShort)NewNode.Tag;
            cloneNode = NewNode;

            if (DestElement.Id != NewElement.Id)
            {
                //if the save parent
                string error;
                long destPosition = DestElement.Position;
                TreeNodeCollection collectionForChange = (DestinationNode.Parent == null) ? tree.Nodes : DestinationNode.Parent.Nodes;

                int index = collectionForChange.IndexOf(DestinationNode);
                TreeNode tn = (TreeNode)NewNode.Clone();
                cloneNode = tn;

                if (DestElement.ParentId == NewElement.ParentId)
                {
                    //if move up
                    if (DestElement.Position < NewElement.Position)
                    {
                        TreeManager.UpdateElementPositionMuveUp(destPosition, DestElement.ParentId, out error);
                        foreach (TreeNode item in collectionForChange)
                            if (((ElementShort)item.Tag).Position >= destPosition)
                                ((ElementShort)item.Tag).Position++;
                        collectionForChange.Insert(index, tn);
                        NewNode.Remove();
                    }
                    else //move down
                    {
                        TreeManager.UpdateElementPositionMuveDown(destPosition, DestElement.ParentId, out error);
                        foreach (TreeNode item in collectionForChange)
                            if (((ElementShort)item.Tag).Position <= destPosition)
                                ((ElementShort)item.Tag).Position--;
                        NewNode.Remove();
                        collectionForChange.Insert(index, tn);
                    }


                }
                else //if parent is diff
                {
                    TreeManager.UpdateElementPositionMuveUp(destPosition, DestElement.ParentId, out error);
                    foreach (TreeNode item in collectionForChange)
                        if (((ElementShort)item.Tag).Position >= destPosition)
                            ((ElementShort)item.Tag).Position++;
                    collectionForChange.Insert(index, tn);
                    NewNode.Remove();
                }

                TreeManager.UpdateElementPosition(NewElement.Id, destPosition, DestElement.ParentId, out error);
                NewElement.Position = destPosition;

            }
        }

        private void tree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                TreeNodeCollection collectionForChange = (tree.SelectedNode.Parent == null) ? tree.Nodes : tree.SelectedNode.Parent.Nodes;
                TreeNode cloneNode;
                int index = collectionForChange.IndexOf(tree.SelectedNode);
                if (index != 0)
                {
                    tree.BeginUpdate();
                    MoveNode(collectionForChange[index - 1], tree.SelectedNode, out cloneNode);
                    tree.SelectedNode = cloneNode;
                    tree.EndUpdate();
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                TreeNodeCollection collectionForChange = (tree.SelectedNode.Parent == null) ? tree.Nodes : tree.SelectedNode.Parent.Nodes;
                int index = collectionForChange.IndexOf(tree.SelectedNode);
                TreeNode cloneNode;
                if (index != collectionForChange.Count - 1)
                {
                    tree.BeginUpdate();
                    MoveNode(collectionForChange[index + 1], tree.SelectedNode, out cloneNode);
                    tree.SelectedNode = cloneNode;
                    tree.EndUpdate();
                }
            }
        }

        private const string VIRTUALNODE = "VIRT";

        private void AddVirtualNode(TreeNode tNode)
        {
            TreeNode tVirt = new TreeNode();
            tVirt.Text = "Loading...";
            tVirt.Name = VIRTUALNODE;
            tVirt.ForeColor = Color.Blue;
            tVirt.NodeFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline);
            tNode.Nodes.Add(tVirt);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
