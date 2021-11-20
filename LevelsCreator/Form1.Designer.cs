
namespace LevelsCreator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gamesComboBox = new System.Windows.Forms.ComboBox();
            this.wordsGridView = new System.Windows.Forms.DataGridView();
            this.WordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WordText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complexity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wordlang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.entittiesGridView = new System.Windows.Forms.DataGridView();
            this.EntityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PictureFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entitiesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.addWordToLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.levelWordsGridView = new System.Windows.Forms.DataGridView();
            this.levelWordText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelwordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelWordComplexity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelwordCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelWordsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.REmoveFromLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.langWordsGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.landWordsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addlangwordtolevel = new System.Windows.Forms.ToolStripMenuItem();
            this.levelsGridView = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLockedLevel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.levelsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddLevelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.levelWordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.langWordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.levelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wordsGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entittiesGridView)).BeginInit();
            this.entitiesMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelWordsGridView)).BeginInit();
            this.levelWordsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.langWordsGridView)).BeginInit();
            this.landWordsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelsGridView)).BeginInit();
            this.levelsMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelWordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.langWordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesComboBox
            // 
            this.gamesComboBox.FormattingEnabled = true;
            this.gamesComboBox.Location = new System.Drawing.Point(6, 26);
            this.gamesComboBox.Name = "gamesComboBox";
            this.gamesComboBox.Size = new System.Drawing.Size(256, 28);
            this.gamesComboBox.TabIndex = 0;
            this.gamesComboBox.SelectedIndexChanged += new System.EventHandler(this.GamesComboBox_SelectedIndexChanged);
            // 
            // wordsGridView
            // 
            this.wordsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.wordsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WordId,
            this.WordText,
            this.Complexity,
            this.Wordlang,
            this.AudioFileName});
            this.wordsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordsGridView.Location = new System.Drawing.Point(0, 0);
            this.wordsGridView.Name = "wordsGridView";
            this.wordsGridView.RowHeadersWidth = 51;
            this.wordsGridView.RowTemplate.Height = 29;
            this.wordsGridView.Size = new System.Drawing.Size(1201, 334);
            this.wordsGridView.TabIndex = 2;
            this.wordsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.LevelWordsGridView_CellValueChanged);
            // 
            // WordId
            // 
            this.WordId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WordId.DataPropertyName = "Id";
            this.WordId.HeaderText = "Id";
            this.WordId.MinimumWidth = 6;
            this.WordId.Name = "WordId";
            this.WordId.Width = 51;
            // 
            // WordText
            // 
            this.WordText.DataPropertyName = "Text";
            this.WordText.HeaderText = "Text";
            this.WordText.MinimumWidth = 6;
            this.WordText.Name = "WordText";
            // 
            // Complexity
            // 
            this.Complexity.DataPropertyName = "Complexity";
            this.Complexity.HeaderText = "Complexity";
            this.Complexity.MinimumWidth = 6;
            this.Complexity.Name = "Complexity";
            // 
            // Wordlang
            // 
            this.Wordlang.DataPropertyName = "Lang";
            this.Wordlang.HeaderText = "Language";
            this.Wordlang.MinimumWidth = 6;
            this.Wordlang.Name = "Wordlang";
            // 
            // AudioFileName
            // 
            this.AudioFileName.DataPropertyName = "AudioFileName";
            this.AudioFileName.HeaderText = "Audio File Name";
            this.AudioFileName.MinimumWidth = 6;
            this.AudioFileName.Name = "AudioFileName";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1207, 692);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Слова";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 23);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.entittiesGridView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.wordsGridView);
            this.splitContainer2.Size = new System.Drawing.Size(1201, 666);
            this.splitContainer2.SplitterDistance = 328;
            this.splitContainer2.TabIndex = 3;
            // 
            // entittiesGridView
            // 
            this.entittiesGridView.AllowUserToAddRows = false;
            this.entittiesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.entittiesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entittiesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntityId,
            this.PictureFileName});
            this.entittiesGridView.ContextMenuStrip = this.entitiesMenu;
            this.entittiesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entittiesGridView.Location = new System.Drawing.Point(0, 0);
            this.entittiesGridView.Name = "entittiesGridView";
            this.entittiesGridView.RowHeadersWidth = 51;
            this.entittiesGridView.RowTemplate.Height = 29;
            this.entittiesGridView.Size = new System.Drawing.Size(1201, 328);
            this.entittiesGridView.TabIndex = 0;
            this.entittiesGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntittiesGridView_CellValueChanged);
            this.entittiesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.entittiesGridView_ColumnHeaderMouseClick);
            this.entittiesGridView.SelectionChanged += new System.EventHandler(this.EntittiesGridView_SelectionChanged);
            this.entittiesGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.entittiesGridView_SortCompare);
            // 
            // EntityId
            // 
            this.EntityId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EntityId.DataPropertyName = "Id";
            this.EntityId.HeaderText = "Id";
            this.EntityId.MinimumWidth = 6;
            this.EntityId.Name = "EntityId";
            this.EntityId.ReadOnly = true;
            this.EntityId.Width = 51;
            // 
            // PictureFileName
            // 
            this.PictureFileName.DataPropertyName = "PictureFileName";
            this.PictureFileName.HeaderText = "Picture File Name";
            this.PictureFileName.MinimumWidth = 6;
            this.PictureFileName.Name = "PictureFileName";
            // 
            // entitiesMenu
            // 
            this.entitiesMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.entitiesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEntity,
            this.addWordToLevel});
            this.entitiesMenu.Name = "entitiesMenu";
            this.entitiesMenu.Size = new System.Drawing.Size(203, 52);
            // 
            // addNewEntity
            // 
            this.addNewEntity.Name = "addNewEntity";
            this.addNewEntity.Size = new System.Drawing.Size(202, 24);
            this.addNewEntity.Text = "Add new Entity";
            this.addNewEntity.Click += new System.EventHandler(this.addNewEntity_Click);
            // 
            // addWordToLevel
            // 
            this.addWordToLevel.Name = "addWordToLevel";
            this.addWordToLevel.Size = new System.Drawing.Size(202, 24);
            this.addWordToLevel.Text = "Add Word to Level";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Controls.Add(this.levelsGridView);
            this.groupBox2.Controls.Add(this.gamesComboBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1207, 692);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Уровни игры";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(268, 26);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.levelWordsGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.langWordsGridView);
            this.splitContainer1.Size = new System.Drawing.Size(934, 660);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 5;
            // 
            // levelWordsGridView
            // 
            this.levelWordsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.levelWordsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.levelWordsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.levelWordText,
            this.levelwordId,
            this.levelWordComplexity,
            this.levelwordCategory});
            this.levelWordsGridView.ContextMenuStrip = this.levelWordsMenu;
            this.levelWordsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelWordsGridView.Location = new System.Drawing.Point(0, 0);
            this.levelWordsGridView.Name = "levelWordsGridView";
            this.levelWordsGridView.RowHeadersWidth = 51;
            this.levelWordsGridView.RowTemplate.Height = 29;
            this.levelWordsGridView.Size = new System.Drawing.Size(934, 288);
            this.levelWordsGridView.TabIndex = 2;
            // 
            // levelWordText
            // 
            this.levelWordText.DataPropertyName = "Text";
            this.levelWordText.HeaderText = "Text";
            this.levelWordText.MinimumWidth = 6;
            this.levelWordText.Name = "levelWordText";
            this.levelWordText.ReadOnly = true;
            // 
            // levelwordId
            // 
            this.levelwordId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.levelwordId.DataPropertyName = "Id";
            this.levelwordId.HeaderText = "Id";
            this.levelwordId.MinimumWidth = 6;
            this.levelwordId.Name = "levelwordId";
            this.levelwordId.ReadOnly = true;
            this.levelwordId.Width = 51;
            // 
            // levelWordComplexity
            // 
            this.levelWordComplexity.DataPropertyName = "Complexity";
            this.levelWordComplexity.HeaderText = "Complexity";
            this.levelWordComplexity.MinimumWidth = 6;
            this.levelWordComplexity.Name = "levelWordComplexity";
            // 
            // levelwordCategory
            // 
            this.levelwordCategory.DataPropertyName = "Category";
            this.levelwordCategory.HeaderText = "Category";
            this.levelwordCategory.MinimumWidth = 6;
            this.levelwordCategory.Name = "levelwordCategory";
            // 
            // levelWordsMenu
            // 
            this.levelWordsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.levelWordsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.REmoveFromLevel});
            this.levelWordsMenu.Name = "entitiesMenu";
            this.levelWordsMenu.Size = new System.Drawing.Size(209, 28);
            // 
            // REmoveFromLevel
            // 
            this.REmoveFromLevel.Name = "REmoveFromLevel";
            this.REmoveFromLevel.Size = new System.Drawing.Size(208, 24);
            this.REmoveFromLevel.Text = "Удалить из уровня";
            this.REmoveFromLevel.Click += new System.EventHandler(this.REmoveFromLevel_Click);
            // 
            // langWordsGridView
            // 
            this.langWordsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.langWordsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.langWordsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.langWordsGridView.ContextMenuStrip = this.landWordsMenu;
            this.langWordsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.langWordsGridView.Location = new System.Drawing.Point(0, 0);
            this.langWordsGridView.Name = "langWordsGridView";
            this.langWordsGridView.RowHeadersWidth = 51;
            this.langWordsGridView.RowTemplate.Height = 29;
            this.langWordsGridView.Size = new System.Drawing.Size(934, 368);
            this.langWordsGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 51;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Text";
            this.dataGridViewTextBoxColumn2.HeaderText = "Text";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Complexity";
            this.dataGridViewTextBoxColumn3.HeaderText = "Complexity";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn4.HeaderText = "Category";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // landWordsMenu
            // 
            this.landWordsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.landWordsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addlangwordtolevel});
            this.landWordsMenu.Name = "entitiesMenu";
            this.landWordsMenu.Size = new System.Drawing.Size(163, 28);
            // 
            // addlangwordtolevel
            // 
            this.addlangwordtolevel.Name = "addlangwordtolevel";
            this.addlangwordtolevel.Size = new System.Drawing.Size(162, 24);
            this.addlangwordtolevel.Text = "Add to Level";
            this.addlangwordtolevel.Click += new System.EventHandler(this.addlangwordtolevel_Click);
            // 
            // levelsGridView
            // 
            this.levelsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.levelsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.levelsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.levelsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.LevelId,
            this.IsLockedLevel});
            this.levelsGridView.ContextMenuStrip = this.levelsMenu;
            this.levelsGridView.Location = new System.Drawing.Point(6, 60);
            this.levelsGridView.Name = "levelsGridView";
            this.levelsGridView.RowHeadersWidth = 51;
            this.levelsGridView.RowTemplate.Height = 29;
            this.levelsGridView.Size = new System.Drawing.Size(256, 626);
            this.levelsGridView.TabIndex = 3;
            this.levelsGridView.SelectionChanged += new System.EventHandler(this.levelsGridView_SelectionChanged);
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "Number";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            // 
            // LevelId
            // 
            this.LevelId.DataPropertyName = "Id";
            this.LevelId.HeaderText = "Id";
            this.LevelId.MinimumWidth = 6;
            this.LevelId.Name = "LevelId";
            // 
            // IsLockedLevel
            // 
            this.IsLockedLevel.DataPropertyName = "Locked";
            this.IsLockedLevel.HeaderText = "Locked";
            this.IsLockedLevel.MinimumWidth = 6;
            this.IsLockedLevel.Name = "IsLockedLevel";
            this.IsLockedLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsLockedLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // levelsMenu
            // 
            this.levelsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.levelsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLevelMenuItem});
            this.levelsMenu.Name = "entitiesMenu";
            this.levelsMenu.Size = new System.Drawing.Size(208, 28);
            // 
            // AddLevelMenuItem
            // 
            this.AddLevelMenuItem.Name = "AddLevelMenuItem";
            this.AddLevelMenuItem.Size = new System.Drawing.Size(207, 24);
            this.AddLevelMenuItem.Text = "Добавить уровень";
            this.AddLevelMenuItem.Click += new System.EventHandler(this.AddLevelMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1221, 731);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1213, 698);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Игры";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1213, 698);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Слова";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1221, 27);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 757);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Конструктор уровней";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wordsGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entittiesGridView)).EndInit();
            this.entitiesMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.levelWordsGridView)).EndInit();
            this.levelWordsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.langWordsGridView)).EndInit();
            this.landWordsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.levelsGridView)).EndInit();
            this.levelsMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelWordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.langWordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox gamesComboBox;
        private System.Windows.Forms.DataGridView wordsGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView levelWordsGridView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView entittiesGridView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip entitiesMenu;
        private System.Windows.Forms.ToolStripMenuItem addNewEntity;
        private System.Windows.Forms.ToolStripMenuItem addWordToLevel;
        private System.Windows.Forms.DataGridView levelsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLockedLevel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelwordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelWordText;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelWordComplexity;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelwordCategory;
        private System.Windows.Forms.DataGridView langWordsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ContextMenuStrip landWordsMenu;
        private System.Windows.Forms.ToolStripMenuItem addlangwordtolevel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ContextMenuStrip levelWordsMenu;
        private System.Windows.Forms.ToolStripMenuItem REmoveFromLevel;
        private System.Windows.Forms.BindingSource levelWordsBindingSource;
        private System.Windows.Forms.BindingSource langWordsBindingSource;
        private System.Windows.Forms.ContextMenuStrip levelsMenu;
        private System.Windows.Forms.ToolStripMenuItem AddLevelMenuItem;
        private System.Windows.Forms.BindingSource levelsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn WordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WordText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Complexity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wordlang;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PictureFileName;
    }
}

