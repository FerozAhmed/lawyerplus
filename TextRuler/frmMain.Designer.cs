namespace TextRuler
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node10");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            ExtendedRichTextBox.CharStyle charStyle1 = new ExtendedRichTextBox.CharStyle();
            ExtendedRichTextBox.ParaLineSpacing paraLineSpacing1 = new ExtendedRichTextBox.ParaLineSpacing();
            ExtendedRichTextBox.ParaListStyle paraListStyle1 = new ExtendedRichTextBox.ParaListStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree = new TextRuler.frmMain.MyTreeView();
            this.menuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuBtnAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnAddSubNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBtnDeleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBtnEditNode = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUp = new System.Windows.Forms.ToolStripButton();
            this.btnDown = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bthAddNode = new System.Windows.Forms.ToolStripButton();
            this.btnAddSubNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteNode = new System.Windows.Forms.ToolStripButton();
            this.btnEditNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextEditor = new ExtendedRichTextBox();
            this.menuRT = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.Ruler = new TextRuler.TextRulerControl.TextRuler();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Toolbox_Formatting = new System.Windows.Forms.ToolStrip();
            this.cmbFontName = new System.Windows.Forms.ToolStripComboBox();
            this.cmbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.sepTBFormatting1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.btnStrikeThrough = new System.Windows.Forms.ToolStripButton();
            this.sepTBFormatting2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.btnAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.btnAlignRight = new System.Windows.Forms.ToolStripButton();
            this.btnJustify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNumberedList = new System.Windows.Forms.ToolStripButton();
            this.btnBulletedList = new System.Windows.Forms.ToolStripButton();
            this.Toolbox_Main = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.sepTBMain1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.sepTBMain2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.sepTBMain3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.TextEditorMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPageSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormatting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertDateTime = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbDateTimeFormats = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtCustom = new System.Windows.Forms.ToolStripTextBox();
            this.mnuFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFont = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColors = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHighlightColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUnderlineStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuULineDashDotDot = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuULWave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintWnd = new System.Windows.Forms.PrintDialog();
            this.prtDoc = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PageSettings = new System.Windows.Forms.PageSetupDialog();
            this.DocPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvSearchresult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuTree.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuRT.SuspendLayout();
            this.Toolbox_Formatting.SuspendLayout();
            this.Toolbox_Main.SuspendLayout();
            this.TextEditorMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.Toolbox_Formatting);
            this.splitContainer1.Panel2.Controls.Add(this.Toolbox_Main);
            this.splitContainer1.Panel2.Controls.Add(this.TextEditorMenu);
            this.splitContainer1.Size = new System.Drawing.Size(745, 562);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.BackColor = System.Drawing.Color.White;
            this.tree.ContextMenuStrip = this.menuTree;
            this.tree.Cursor = System.Windows.Forms.Cursors.Default;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tree.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tree.FullRowSelect = true;
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.imageList1;
            this.tree.ItemHeight = 18;
            this.tree.LabelEdit = true;
            this.tree.Location = new System.Drawing.Point(0, 50);
            this.tree.Name = "tree";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Node3";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Node4";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Node0";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Node5";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Node6";
            treeNode6.Name = "Node1";
            treeNode6.Text = "Node1";
            treeNode7.Name = "Node7";
            treeNode7.Text = "Node7";
            treeNode8.Name = "Node8";
            treeNode8.Text = "Node8";
            treeNode9.Name = "Node9";
            treeNode9.Text = "Node9";
            treeNode10.Name = "Node10";
            treeNode10.Text = "Node10";
            treeNode11.Name = "Node2";
            treeNode11.Text = "Node2";
            this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode11});
            this.tree.SelectedImageIndex = 2;
            this.tree.Size = new System.Drawing.Size(160, 512);
            this.tree.TabIndex = 0;
            this.tree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tree_AfterLabelEdit);
            this.tree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeVirt2_AfterExpand);
            this.tree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.tree_DrawNode);
            this.tree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_ItemDrag);
            this.tree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeSelect);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            this.tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
            this.tree.DragEnter += new System.Windows.Forms.DragEventHandler(this.tree_DragEnter);
            // 
            // menuTree
            // 
            this.menuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBtnAddNode,
            this.menuBtnAddSubNode,
            this.menuBtnDeleteNode,
            this.toolStripMenuItem6,
            this.menuBtnEditNode});
            this.menuTree.Name = "menuTree";
            this.menuTree.Size = new System.Drawing.Size(238, 98);
            // 
            // menuBtnAddNode
            // 
            this.menuBtnAddNode.Image = global::TextRuler.Properties.Resources._1348630973_address_book_new;
            this.menuBtnAddNode.Name = "menuBtnAddNode";
            this.menuBtnAddNode.Size = new System.Drawing.Size(237, 22);
            this.menuBtnAddNode.Text = "Добавить новый раздел";
            this.menuBtnAddNode.Click += new System.EventHandler(this.bthAddNode_Click);
            // 
            // menuBtnAddSubNode
            // 
            this.menuBtnAddSubNode.Image = global::TextRuler.Properties.Resources._1348631049_stock_new_drawing;
            this.menuBtnAddSubNode.Name = "menuBtnAddSubNode";
            this.menuBtnAddSubNode.Size = new System.Drawing.Size(237, 22);
            this.menuBtnAddSubNode.Text = "Добавить новый подраздел";
            this.menuBtnAddSubNode.Click += new System.EventHandler(this.btnAddSubNode_Click);
            // 
            // menuBtnDeleteNode
            // 
            this.menuBtnDeleteNode.Image = ((System.Drawing.Image)(resources.GetObject("menuBtnDeleteNode.Image")));
            this.menuBtnDeleteNode.Name = "menuBtnDeleteNode";
            this.menuBtnDeleteNode.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuBtnDeleteNode.Size = new System.Drawing.Size(237, 22);
            this.menuBtnDeleteNode.Text = "Удалить выбранный узел";
            this.menuBtnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(234, 6);
            // 
            // menuBtnEditNode
            // 
            this.menuBtnEditNode.Image = global::TextRuler.Properties.Resources._1348633818_doc_edit;
            this.menuBtnEditNode.Name = "menuBtnEditNode";
            this.menuBtnEditNode.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuBtnEditNode.Size = new System.Drawing.Size(237, 22);
            this.menuBtnEditNode.Text = "Редактировать";
            this.menuBtnEditNode.Click += new System.EventHandler(this.btnEditNode_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book_closed.png");
            this.imageList1.Images.SetKeyName(1, "1349155862_Flag1LeftBlack.png");
            this.imageList1.Images.SetKeyName(2, "book_open.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReload,
            this.toolStripSeparator10,
            this.btnUp,
            this.btnDown});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(160, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = global::TextRuler.Properties.Resources._1350030178_Reload_05;
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "Перечитать дерево";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUp
            // 
            this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUp.Image = global::TextRuler.Properties.Resources._1350030289_br_up;
            this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 22);
            this.btnUp.Text = "Переместить вверх";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDown.Image = global::TextRuler.Properties.Resources._1350030293_br_down;
            this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 22);
            this.btnDown.Text = "Переместить вниз";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bthAddNode,
            this.btnAddSubNode,
            this.toolStripSeparator7,
            this.btnDeleteNode,
            this.btnEditNode,
            this.toolStripSeparator8,
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(160, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bthAddNode
            // 
            this.bthAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bthAddNode.Image = ((System.Drawing.Image)(resources.GetObject("bthAddNode.Image")));
            this.bthAddNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bthAddNode.Name = "bthAddNode";
            this.bthAddNode.Size = new System.Drawing.Size(23, 22);
            this.bthAddNode.Text = "Создать новый раздел";
            this.bthAddNode.Click += new System.EventHandler(this.bthAddNode_Click);
            // 
            // btnAddSubNode
            // 
            this.btnAddSubNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddSubNode.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSubNode.Image")));
            this.btnAddSubNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddSubNode.Name = "btnAddSubNode";
            this.btnAddSubNode.Size = new System.Drawing.Size(23, 22);
            this.btnAddSubNode.Text = "Создать новый подраздел";
            this.btnAddSubNode.Click += new System.EventHandler(this.btnAddSubNode_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteNode.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteNode.Image")));
            this.btnDeleteNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteNode.Text = "Удалить выбранный узел";
            this.btnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click);
            // 
            // btnEditNode
            // 
            this.btnEditNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditNode.Image = global::TextRuler.Properties.Resources._1348633818_doc_edit;
            this.btnEditNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditNode.Name = "btnEditNode";
            this.btnEditNode.Size = new System.Drawing.Size(23, 22);
            this.btnEditNode.Text = "Редактировать имя узла";
            this.btnEditNode.Click += new System.EventHandler(this.btnEditNode_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.CheckOnClick = true;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TextRuler.Properties.Resources._1349171372_application_search_result;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Результаты поиска";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TextRuler.Properties.Resources._1349125863_zoom;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Поиск";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextEditor);
            this.panel1.Controls.Add(this.Ruler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(14, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 488);
            this.panel1.TabIndex = 10;
            // 
            // TextEditor
            // 
            this.TextEditor.AcceptsTab = true;
            this.TextEditor.ContextMenuStrip = this.menuRT;
            this.TextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextEditor.EnableAutoDragDrop = true;
            this.TextEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextEditor.HideSelection = false;
            this.TextEditor.Location = new System.Drawing.Point(0, 20);
            this.TextEditor.Name = "TextEditor";
            charStyle1.Bold = false;
            charStyle1.Italic = false;
            charStyle1.Link = false;
            charStyle1.Strikeout = false;
            charStyle1.Underline = false;
            this.TextEditor.SelectionCharStyle = charStyle1;
            this.TextEditor.SelectionFont2 = new System.Drawing.Font("Microsoft Sans Serif", 2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch);
            paraLineSpacing1.ExactSpacing = 0;
            paraLineSpacing1.SpacingStyle = ExtendedRichTextBox.ParaLineSpacing.LineSpacingStyle.Unknown;
            this.TextEditor.SelectionLineSpacing = paraLineSpacing1;
            paraListStyle1.BulletCharCode = ((short)(0));
            paraListStyle1.NumberingStart = ((short)(0));
            paraListStyle1.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;
            paraListStyle1.Type = ExtendedRichTextBox.ParaListStyle.ListType.None;
            this.TextEditor.SelectionListType = paraListStyle1;
            this.TextEditor.SelectionOffsetType = ExtendedRichTextBox.OffsetType.None;
            this.TextEditor.SelectionSpaceAfter = 0;
            this.TextEditor.SelectionSpaceBefore = 0;
            this.TextEditor.Size = new System.Drawing.Size(554, 468);
            this.TextEditor.TabIndex = 7;
            this.TextEditor.Text = "";
            // 
            // menuRT
            // 
            this.menuRT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopy,
            this.menuPaste});
            this.menuRT.Name = "menuRT";
            this.menuRT.Size = new System.Drawing.Size(140, 48);
            // 
            // menuCopy
            // 
            this.menuCopy.Image = global::TextRuler.Properties.Resources._1349810598_copy;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(139, 22);
            this.menuCopy.Text = "Копировать";
            this.menuCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Image = global::TextRuler.Properties.Resources._1349810552_paste_16x16;
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.Size = new System.Drawing.Size(139, 22);
            this.menuPaste.Text = "Вставить";
            this.menuPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // Ruler
            // 
            this.Ruler.BackColor = System.Drawing.Color.Transparent;
            this.Ruler.BackgroundImage = global::TextRuler.Properties.Resources.фон;
            this.Ruler.Dock = System.Windows.Forms.DockStyle.Top;
            this.Ruler.Font = new System.Drawing.Font("Arial", 7.25F);
            this.Ruler.LeftHangingIndent = 19;
            this.Ruler.LeftIndent = 19;
            this.Ruler.LeftMargin = 1;
            this.Ruler.Location = new System.Drawing.Point(0, 0);
            this.Ruler.Name = "Ruler";
            this.Ruler.NoMargins = true;
            this.Ruler.RightIndent = 14;
            this.Ruler.RightMargin = 1;
            this.Ruler.Size = new System.Drawing.Size(554, 20);
            this.Ruler.TabIndex = 9;
            this.Ruler.TabsEnabled = true;
            this.Ruler.LeftHangingIndentChanging += new TextRuler.TextRulerControl.TextRuler.IndentChangedEventHandler(this.Ruler_LeftHangingIndentChanging);
            this.Ruler.LeftIndentChanging += new TextRuler.TextRulerControl.TextRuler.IndentChangedEventHandler(this.Ruler_LeftIndentChanging);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::TextRuler.Properties.Resources.fon2;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(568, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 488);
            this.panel3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.BackgroundImage = global::TextRuler.Properties.Resources.fon2;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 488);
            this.panel2.TabIndex = 11;
            // 
            // Toolbox_Formatting
            // 
            this.Toolbox_Formatting.BackColor = System.Drawing.Color.Transparent;
            this.Toolbox_Formatting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbFontName,
            this.cmbFontSize,
            this.sepTBFormatting1,
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.btnStrikeThrough,
            this.sepTBFormatting2,
            this.btnAlignLeft,
            this.btnAlignCenter,
            this.btnAlignRight,
            this.btnJustify,
            this.toolStripSeparator2,
            this.btnNumberedList,
            this.btnBulletedList});
            this.Toolbox_Formatting.Location = new System.Drawing.Point(0, 49);
            this.Toolbox_Formatting.Name = "Toolbox_Formatting";
            this.Toolbox_Formatting.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Toolbox_Formatting.Size = new System.Drawing.Size(582, 25);
            this.Toolbox_Formatting.TabIndex = 4;
            this.Toolbox_Formatting.Text = "toolStrip1";
            // 
            // cmbFontName
            // 
            this.cmbFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFontName.DropDownHeight = 300;
            this.cmbFontName.IntegralHeight = false;
            this.cmbFontName.Name = "cmbFontName";
            this.cmbFontName.Size = new System.Drawing.Size(170, 25);
            this.cmbFontName.SelectedIndexChanged += new System.EventHandler(this.cmbFontName_SelectedIndexChanged);
            this.cmbFontName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFontName_KeyUp);
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.AutoSize = false;
            this.cmbFontSize.DropDownHeight = 200;
            this.cmbFontSize.IntegralHeight = false;
            this.cmbFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "30",
            "36",
            "48",
            "60",
            "72",
            "85",
            "100"});
            this.cmbFontSize.MaxDropDownItems = 20;
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(50, 23);
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            this.cmbFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFontSize_KeyDown);
            this.cmbFontSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFontSize_KeyUp);
            // 
            // sepTBFormatting1
            // 
            this.sepTBFormatting1.Name = "sepTBFormatting1";
            this.sepTBFormatting1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBold
            // 
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 22);
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 22);
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderline.Image")));
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(23, 22);
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnStrikeThrough
            // 
            this.btnStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStrikeThrough.Image = ((System.Drawing.Image)(resources.GetObject("btnStrikeThrough.Image")));
            this.btnStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStrikeThrough.Name = "btnStrikeThrough";
            this.btnStrikeThrough.Size = new System.Drawing.Size(23, 22);
            this.btnStrikeThrough.Click += new System.EventHandler(this.btnStrikeThrough_Click);
            // 
            // sepTBFormatting2
            // 
            this.sepTBFormatting2.Name = "sepTBFormatting2";
            this.sepTBFormatting2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAlignLeft
            // 
            this.btnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignLeft.Image")));
            this.btnAlignLeft.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnAlignLeft.Name = "btnAlignLeft";
            this.btnAlignLeft.Size = new System.Drawing.Size(23, 22);
            this.btnAlignLeft.Click += new System.EventHandler(this.btnAlignLeft_Click);
            // 
            // btnAlignCenter
            // 
            this.btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignCenter.Image")));
            this.btnAlignCenter.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnAlignCenter.Name = "btnAlignCenter";
            this.btnAlignCenter.Size = new System.Drawing.Size(23, 22);
            this.btnAlignCenter.Click += new System.EventHandler(this.btnAlignCenter_Click);
            // 
            // btnAlignRight
            // 
            this.btnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignRight.Image")));
            this.btnAlignRight.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnAlignRight.Name = "btnAlignRight";
            this.btnAlignRight.Size = new System.Drawing.Size(23, 22);
            this.btnAlignRight.Click += new System.EventHandler(this.btnAlignRight_Click);
            // 
            // btnJustify
            // 
            this.btnJustify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnJustify.Image = ((System.Drawing.Image)(resources.GetObject("btnJustify.Image")));
            this.btnJustify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJustify.Name = "btnJustify";
            this.btnJustify.Size = new System.Drawing.Size(23, 22);
            this.btnJustify.Click += new System.EventHandler(this.btnJustify_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNumberedList
            // 
            this.btnNumberedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNumberedList.Image = ((System.Drawing.Image)(resources.GetObject("btnNumberedList.Image")));
            this.btnNumberedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNumberedList.Name = "btnNumberedList";
            this.btnNumberedList.Size = new System.Drawing.Size(23, 22);
            this.btnNumberedList.Text = "toolStripButton1";
            this.btnNumberedList.Click += new System.EventHandler(this.btnNumberedList_Click);
            // 
            // btnBulletedList
            // 
            this.btnBulletedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBulletedList.Image = ((System.Drawing.Image)(resources.GetObject("btnBulletedList.Image")));
            this.btnBulletedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBulletedList.Name = "btnBulletedList";
            this.btnBulletedList.Size = new System.Drawing.Size(23, 22);
            this.btnBulletedList.Text = "toolStripButton2";
            this.btnBulletedList.Click += new System.EventHandler(this.btnBulletedList_Click);
            // 
            // Toolbox_Main
            // 
            this.Toolbox_Main.BackColor = System.Drawing.Color.Transparent;
            this.Toolbox_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.sepTBMain1,
            this.btnPrint,
            this.btnPrintPreview,
            this.sepTBMain2,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.sepTBMain3,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator6,
            this.btnFind,
            this.toolStripSeparator9,
            this.btnSave});
            this.Toolbox_Main.Location = new System.Drawing.Point(0, 24);
            this.Toolbox_Main.Name = "Toolbox_Main";
            this.Toolbox_Main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Toolbox_Main.Size = new System.Drawing.Size(582, 25);
            this.Toolbox_Main.TabIndex = 2;
            this.Toolbox_Main.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // sepTBMain1
            // 
            this.sepTBMain1.Name = "sepTBMain1";
            this.sepTBMain1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.Image")));
            this.btnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(23, 22);
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // sepTBMain2
            // 
            this.sepTBMain2.Name = "sepTBMain2";
            this.sepTBMain2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Image = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(23, 22);
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(23, 22);
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // sepTBMain3
            // 
            this.sepTBMain3.Name = "sepTBMain3";
            this.sepTBMain3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(23, 22);
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFind
            // 
            this.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFind.Image = global::TextRuler.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(23, 22);
            this.btnFind.Text = "Поиск по тексту";
            this.btnFind.Click += new System.EventHandler(this.mnuFind_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::TextRuler.Properties.Resources._1348634392_disk;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton3";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TextEditorMenu
            // 
            this.TextEditorMenu.BackColor = System.Drawing.Color.Transparent;
            this.TextEditorMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuInsert,
            this.mnuFormat});
            this.TextEditorMenu.Location = new System.Drawing.Point(0, 0);
            this.TextEditorMenu.Name = "TextEditorMenu";
            this.TextEditorMenu.Size = new System.Drawing.Size(582, 24);
            this.TextEditorMenu.TabIndex = 1;
            this.TextEditorMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.toolStripMenuItem1,
            this.mnuPrint,
            this.mnuPrintPreview,
            this.mnuPageSettings});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(48, 20);
            this.mnuFile.Text = "Файл";
            // 
            // mnuNew
            // 
            this.mnuNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuNew.Image")));
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(184, 22);
            this.mnuNew.Text = "Очистить";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrint.Image")));
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPrint.Size = new System.Drawing.Size(184, 22);
            this.mnuPrint.Text = "Печать...";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            // 
            // mnuPrintPreview
            // 
            this.mnuPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrintPreview.Image")));
            this.mnuPrintPreview.Name = "mnuPrintPreview";
            this.mnuPrintPreview.Size = new System.Drawing.Size(184, 22);
            this.mnuPrintPreview.Text = "Просмотр печати...";
            this.mnuPrintPreview.Click += new System.EventHandler(this.mnuPrintPreview_Click);
            // 
            // mnuPageSettings
            // 
            this.mnuPageSettings.Name = "mnuPageSettings";
            this.mnuPageSettings.Size = new System.Drawing.Size(184, 22);
            this.mnuPageSettings.Text = "Настройки печати...";
            this.mnuPageSettings.Click += new System.EventHandler(this.mnuPageSettings_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUndo,
            this.mnuRedo,
            this.toolStripMenuItem2,
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste,
            this.toolStripMenuItem3,
            this.mnuFind});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(99, 20);
            this.mnuEdit.Text = "Редактировать";
            // 
            // mnuUndo
            // 
            this.mnuUndo.Image = ((System.Drawing.Image)(resources.GetObject("mnuUndo.Image")));
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuUndo.Size = new System.Drawing.Size(212, 22);
            this.mnuUndo.Text = "Отменить";
            this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
            // 
            // mnuRedo
            // 
            this.mnuRedo.Image = ((System.Drawing.Image)(resources.GetObject("mnuRedo.Image")));
            this.mnuRedo.Name = "mnuRedo";
            this.mnuRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuRedo.Size = new System.Drawing.Size(212, 22);
            this.mnuRedo.Text = "Redo";
            this.mnuRedo.Click += new System.EventHandler(this.mnuRedo_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuCut
            // 
            this.mnuCut.Image = ((System.Drawing.Image)(resources.GetObject("mnuCut.Image")));
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Size = new System.Drawing.Size(212, 22);
            this.mnuCut.Text = "Вырезать";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopy.Image")));
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(212, 22);
            this.mnuCopy.Text = "Копировать";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = ((System.Drawing.Image)(resources.GetObject("mnuPaste.Image")));
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(212, 22);
            this.mnuPaste.Text = "Вставить";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuFind
            // 
            this.mnuFind.Image = ((System.Drawing.Image)(resources.GetObject("mnuFind.Image")));
            this.mnuFind.Name = "mnuFind";
            this.mnuFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuFind.Size = new System.Drawing.Size(212, 22);
            this.mnuFind.Text = "Поиск по тексту...";
            this.mnuFind.Click += new System.EventHandler(this.mnuFind_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRuler,
            this.mnuMainToolbar,
            this.mnuFormatting});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(76, 20);
            this.mnuView.Text = "Просмотр";
            // 
            // mnuRuler
            // 
            this.mnuRuler.Name = "mnuRuler";
            this.mnuRuler.Size = new System.Drawing.Size(142, 22);
            this.mnuRuler.Text = "Ruler";
            this.mnuRuler.Click += new System.EventHandler(this.mnuRuler_Click);
            // 
            // mnuMainToolbar
            // 
            this.mnuMainToolbar.Name = "mnuMainToolbar";
            this.mnuMainToolbar.Size = new System.Drawing.Size(142, 22);
            this.mnuMainToolbar.Text = "Main toolbar";
            this.mnuMainToolbar.Click += new System.EventHandler(this.mnuMainToolbar_Click);
            // 
            // mnuFormatting
            // 
            this.mnuFormatting.Name = "mnuFormatting";
            this.mnuFormatting.Size = new System.Drawing.Size(142, 22);
            this.mnuFormatting.Text = "Formatting";
            this.mnuFormatting.Click += new System.EventHandler(this.mnuFormatting_Click);
            // 
            // mnuInsert
            // 
            this.mnuInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertPicture,
            this.mnuInsertDateTime});
            this.mnuInsert.Name = "mnuInsert";
            this.mnuInsert.Size = new System.Drawing.Size(61, 20);
            this.mnuInsert.Text = "Вставка";
            // 
            // mnuInsertPicture
            // 
            this.mnuInsertPicture.Image = ((System.Drawing.Image)(resources.GetObject("mnuInsertPicture.Image")));
            this.mnuInsertPicture.Name = "mnuInsertPicture";
            this.mnuInsertPicture.Size = new System.Drawing.Size(159, 22);
            this.mnuInsertPicture.Text = "Изображение...";
            this.mnuInsertPicture.Click += new System.EventHandler(this.mnuInsertPicture_Click);
            // 
            // mnuInsertDateTime
            // 
            this.mnuInsertDateTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbDateTimeFormats,
            this.toolStripSeparator1,
            this.txtCustom});
            this.mnuInsertDateTime.Image = ((System.Drawing.Image)(resources.GetObject("mnuInsertDateTime.Image")));
            this.mnuInsertDateTime.Name = "mnuInsertDateTime";
            this.mnuInsertDateTime.Size = new System.Drawing.Size(159, 22);
            this.mnuInsertDateTime.Text = "Дата";
            this.mnuInsertDateTime.DropDownOpening += new System.EventHandler(this.mnuInsertDateTime_DropDownOpening);
            // 
            // cmbDateTimeFormats
            // 
            this.cmbDateTimeFormats.AutoSize = false;
            this.cmbDateTimeFormats.BackColor = System.Drawing.Color.OldLace;
            this.cmbDateTimeFormats.DropDownHeight = 200;
            this.cmbDateTimeFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateTimeFormats.IntegralHeight = false;
            this.cmbDateTimeFormats.Name = "cmbDateTimeFormats";
            this.cmbDateTimeFormats.Size = new System.Drawing.Size(200, 23);
            this.cmbDateTimeFormats.SelectedIndexChanged += new System.EventHandler(this.cmbDateTimeFormats_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(257, 6);
            // 
            // txtCustom
            // 
            this.txtCustom.AutoSize = false;
            this.txtCustom.BackColor = System.Drawing.Color.OldLace;
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(200, 21);
            this.txtCustom.Text = "specify custom date/time format";
            this.txtCustom.Enter += new System.EventHandler(this.txtCustom_Enter);
            this.txtCustom.Leave += new System.EventHandler(this.txtCustom_Leave);
            this.txtCustom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustom_KeyUp);
            this.txtCustom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCustom_MouseDown);
            // 
            // mnuFormat
            // 
            this.mnuFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFont,
            this.mnuColors,
            this.toolStripMenuItem4,
            this.mnuUnderlineStyle,
            this.toolStripMenuItem5});
            this.mnuFormat.Name = "mnuFormat";
            this.mnuFormat.Size = new System.Drawing.Size(62, 20);
            this.mnuFormat.Text = "Формат";
            // 
            // mnuFont
            // 
            this.mnuFont.Image = ((System.Drawing.Image)(resources.GetObject("mnuFont.Image")));
            this.mnuFont.Name = "mnuFont";
            this.mnuFont.Size = new System.Drawing.Size(152, 22);
            this.mnuFont.Text = "Шрифт...";
            this.mnuFont.Click += new System.EventHandler(this.mnuFont_Click);
            // 
            // mnuColors
            // 
            this.mnuColors.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTextColor,
            this.mnuHighlightColor});
            this.mnuColors.Name = "mnuColors";
            this.mnuColors.Size = new System.Drawing.Size(152, 22);
            this.mnuColors.Text = "Цвет";
            // 
            // mnuTextColor
            // 
            this.mnuTextColor.Image = ((System.Drawing.Image)(resources.GetObject("mnuTextColor.Image")));
            this.mnuTextColor.Name = "mnuTextColor";
            this.mnuTextColor.Size = new System.Drawing.Size(163, 22);
            this.mnuTextColor.Text = "Text color...";
            this.mnuTextColor.Click += new System.EventHandler(this.mnuTextColor_Click);
            // 
            // mnuHighlightColor
            // 
            this.mnuHighlightColor.Image = ((System.Drawing.Image)(resources.GetObject("mnuHighlightColor.Image")));
            this.mnuHighlightColor.Name = "mnuHighlightColor";
            this.mnuHighlightColor.Size = new System.Drawing.Size(163, 22);
            this.mnuHighlightColor.Text = "Highlight color...";
            this.mnuHighlightColor.Click += new System.EventHandler(this.mnuHighlightColor_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuUnderlineStyle
            // 
            this.mnuUnderlineStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuULineDashDotDot,
            this.mnuULWave});
            this.mnuUnderlineStyle.Name = "mnuUnderlineStyle";
            this.mnuUnderlineStyle.Size = new System.Drawing.Size(152, 22);
            this.mnuUnderlineStyle.Text = "Underline style";
            // 
            // mnuULineDashDotDot
            // 
            this.mnuULineDashDotDot.Name = "mnuULineDashDotDot";
            this.mnuULineDashDotDot.Size = new System.Drawing.Size(144, 22);
            this.mnuULineDashDotDot.Text = "Dash Dot Dot";
            this.mnuULineDashDotDot.Click += new System.EventHandler(this.mnuULineSolid_Click);
            // 
            // mnuULWave
            // 
            this.mnuULWave.Name = "mnuULWave";
            this.mnuULWave.Size = new System.Drawing.Size(144, 22);
            this.mnuULWave.Text = "Wave";
            this.mnuULWave.Click += new System.EventHandler(this.mnuULWave_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(149, 6);
            // 
            // PrintWnd
            // 
            this.PrintWnd.Document = this.prtDoc;
            this.PrintWnd.UseEXDialog = true;
            // 
            // prtDoc
            // 
            this.prtDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prtDoc_BeginPrint);
            this.prtDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDoc_PrintPage);
            // 
            // PageSettings
            // 
            this.PageSettings.Document = this.prtDoc;
            // 
            // DocPreview
            // 
            this.DocPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.DocPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.DocPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.DocPreview.Document = this.prtDoc;
            this.DocPreview.Enabled = true;
            this.DocPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("DocPreview.Icon")));
            this.DocPreview.Name = "DocPreview";
            this.DocPreview.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(141, 6);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(743, 200);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvSearchresult);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(735, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Результаты поиска    X";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvSearchresult
            // 
            this.lvSearchresult.BackgroundImageTiled = true;
            this.lvSearchresult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.lvSearchresult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSearchresult.FullRowSelect = true;
            this.lvSearchresult.GridLines = true;
            this.lvSearchresult.Location = new System.Drawing.Point(3, 3);
            this.lvSearchresult.Name = "lvSearchresult";
            this.lvSearchresult.Size = new System.Drawing.Size(729, 168);
            this.lvSearchresult.TabIndex = 1;
            this.lvSearchresult.UseCompatibleStateImageBehavior = false;
            this.lvSearchresult.View = System.Windows.Forms.View.Details;
            this.lvSearchresult.DoubleClick += new System.EventHandler(this.lvSearchresult_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Узел";
            this.columnHeader3.Width = 305;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Описание";
            this.columnHeader2.Width = 344;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(745, 562);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.tabControl1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 360);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(745, 202);
            this.pnlBottom.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 357);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(745, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Юрист+";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(745, 562);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Юрист+";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuTree.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuRT.ResumeLayout(false);
            this.Toolbox_Formatting.ResumeLayout(false);
            this.Toolbox_Formatting.PerformLayout();
            this.Toolbox_Main.ResumeLayout(false);
            this.Toolbox_Main.PerformLayout();
            this.TextEditorMenu.ResumeLayout(false);
            this.TextEditorMenu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bthAddNode;
        private System.Windows.Forms.ToolStripButton btnAddSubNode;
        private System.Windows.Forms.ToolStripButton btnDeleteNode;
        private System.Windows.Forms.ContextMenuStrip menuTree;
        private System.Windows.Forms.ToolStripMenuItem menuBtnAddNode;
        private System.Windows.Forms.ToolStripMenuItem menuBtnAddSubNode;
        private System.Windows.Forms.ToolStripMenuItem menuBtnDeleteNode;
        private System.Windows.Forms.ToolStripButton btnEditNode;
        private System.Windows.Forms.ToolStripMenuItem menuBtnEditNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PrintDialog PrintWnd;
        private System.Drawing.Printing.PrintDocument prtDoc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PageSetupDialog PageSettings;
        private System.Windows.Forms.PrintPreviewDialog DocPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView lvSearchresult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private frmMain.MyTreeView tree;
        private System.Windows.Forms.ToolStrip Toolbox_Formatting;
        private System.Windows.Forms.ToolStripComboBox cmbFontName;
        private System.Windows.Forms.ToolStripComboBox cmbFontSize;
        private System.Windows.Forms.ToolStripSeparator sepTBFormatting1;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripButton btnStrikeThrough;
        private System.Windows.Forms.ToolStripSeparator sepTBFormatting2;
        private System.Windows.Forms.ToolStripButton btnAlignLeft;
        private System.Windows.Forms.ToolStripButton btnAlignCenter;
        private System.Windows.Forms.ToolStripButton btnAlignRight;
        private System.Windows.Forms.ToolStripButton btnJustify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnNumberedList;
        private System.Windows.Forms.ToolStripButton btnBulletedList;
        private System.Windows.Forms.MenuStrip TextEditorMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintPreview;
        private System.Windows.Forms.ToolStripMenuItem mnuPageSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuFind;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuRuler;
        private System.Windows.Forms.ToolStripMenuItem mnuMainToolbar;
        private System.Windows.Forms.ToolStripMenuItem mnuFormatting;
        private System.Windows.Forms.ToolStripMenuItem mnuInsert;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertPicture;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertDateTime;
        private System.Windows.Forms.ToolStripComboBox cmbDateTimeFormats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox txtCustom;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat;
        private System.Windows.Forms.ToolStripMenuItem mnuFont;
        private System.Windows.Forms.ToolStripMenuItem mnuColors;
        private System.Windows.Forms.ToolStripMenuItem mnuTextColor;
        private System.Windows.Forms.ToolStripMenuItem mnuHighlightColor;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuUnderlineStyle;
        private System.Windows.Forms.ToolStripMenuItem mnuULineDashDotDot;
        private System.Windows.Forms.ToolStripMenuItem mnuULWave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStrip Toolbox_Main;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator sepTBMain1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnPrintPreview;
        private System.Windows.Forms.ToolStripSeparator sepTBMain2;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator sepTBMain3;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ContextMenuStrip menuRT;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private TextRulerControl.TextRuler Ruler;
        internal ExtendedRichTextBox TextEditor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnUp;
        private System.Windows.Forms.ToolStripButton btnDown;
        private System.Windows.Forms.NotifyIcon notifyIcon1;



    }
}