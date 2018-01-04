namespace HtmlAgilityPackWindowsFormsApp1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.dataListView = new System.Windows.Forms.ListView();
            this.homepageButton = new System.Windows.Forms.Button();
            this.previouspageButton = new System.Windows.Forms.Button();
            this.nextpageButton = new System.Windows.Forms.Button();
            this.endpageButton = new System.Windows.Forms.Button();
            this.goLabel = new System.Windows.Forms.Label();
            this.pLabel = new System.Windows.Forms.Label();
            this.gotextBox = new System.Windows.Forms.TextBox();
            this.totalcountLabel = new System.Windows.Forms.Label();
            this.pagesizeLabel = new System.Windows.Forms.Label();
            this.pageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dataListView
            // 
            this.dataListView.Location = new System.Drawing.Point(12, 109);
            this.dataListView.Name = "dataListView";
            this.dataListView.Size = new System.Drawing.Size(842, 281);
            this.dataListView.TabIndex = 0;
            this.dataListView.UseCompatibleStateImageBehavior = false;
            // 
            // homepageButton
            // 
            this.homepageButton.Location = new System.Drawing.Point(363, 414);
            this.homepageButton.Name = "homepageButton";
            this.homepageButton.Size = new System.Drawing.Size(75, 23);
            this.homepageButton.TabIndex = 1;
            this.homepageButton.Text = "首页";
            this.homepageButton.UseVisualStyleBackColor = true;
            this.homepageButton.Click += new System.EventHandler(this.homepageButton_Click);
            // 
            // previouspageButton
            // 
            this.previouspageButton.Location = new System.Drawing.Point(444, 414);
            this.previouspageButton.Name = "previouspageButton";
            this.previouspageButton.Size = new System.Drawing.Size(75, 23);
            this.previouspageButton.TabIndex = 2;
            this.previouspageButton.Text = "上一页";
            this.previouspageButton.UseVisualStyleBackColor = true;
            this.previouspageButton.Click += new System.EventHandler(this.previouspageButton_Click);
            // 
            // nextpageButton
            // 
            this.nextpageButton.Location = new System.Drawing.Point(525, 414);
            this.nextpageButton.Name = "nextpageButton";
            this.nextpageButton.Size = new System.Drawing.Size(75, 23);
            this.nextpageButton.TabIndex = 3;
            this.nextpageButton.Text = "下一页";
            this.nextpageButton.UseVisualStyleBackColor = true;
            this.nextpageButton.Click += new System.EventHandler(this.nextpageButton_Click);
            // 
            // endpageButton
            // 
            this.endpageButton.Location = new System.Drawing.Point(606, 414);
            this.endpageButton.Name = "endpageButton";
            this.endpageButton.Size = new System.Drawing.Size(75, 23);
            this.endpageButton.TabIndex = 4;
            this.endpageButton.Text = "尾页";
            this.endpageButton.UseVisualStyleBackColor = true;
            this.endpageButton.Click += new System.EventHandler(this.endpageButton_Click);
            // 
            // goLabel
            // 
            this.goLabel.AutoSize = true;
            this.goLabel.Location = new System.Drawing.Point(757, 420);
            this.goLabel.Name = "goLabel";
            this.goLabel.Size = new System.Drawing.Size(29, 12);
            this.goLabel.TabIndex = 5;
            this.goLabel.Text = "前往";
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(832, 421);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(17, 12);
            this.pLabel.TabIndex = 6;
            this.pLabel.Text = "页";
            // 
            // gotextBox
            // 
            this.gotextBox.Location = new System.Drawing.Point(788, 416);
            this.gotextBox.Name = "gotextBox";
            this.gotextBox.Size = new System.Drawing.Size(41, 21);
            this.gotextBox.TabIndex = 7;
            this.gotextBox.Text = "0";
            // 
            // totalcountLabel
            // 
            this.totalcountLabel.AutoSize = true;
            this.totalcountLabel.Location = new System.Drawing.Point(257, 421);
            this.totalcountLabel.Name = "totalcountLabel";
            this.totalcountLabel.Size = new System.Drawing.Size(47, 12);
            this.totalcountLabel.TabIndex = 8;
            this.totalcountLabel.Text = "共100条";
            // 
            // pagesizeLabel
            // 
            this.pagesizeLabel.AutoSize = true;
            this.pagesizeLabel.Location = new System.Drawing.Point(310, 421);
            this.pagesizeLabel.Name = "pagesizeLabel";
            this.pagesizeLabel.Size = new System.Drawing.Size(47, 12);
            this.pagesizeLabel.TabIndex = 9;
            this.pagesizeLabel.Text = "10条/页";
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(694, 421);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(59, 12);
            this.pageLabel.TabIndex = 10;
            this.pageLabel.Text = "当前第1页";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 606);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.pagesizeLabel);
            this.Controls.Add(this.totalcountLabel);
            this.Controls.Add(this.gotextBox);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.goLabel);
            this.Controls.Add(this.endpageButton);
            this.Controls.Add(this.nextpageButton);
            this.Controls.Add(this.previouspageButton);
            this.Controls.Add(this.homepageButton);
            this.Controls.Add(this.dataListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView dataListView;
        private System.Windows.Forms.Button homepageButton;
        private System.Windows.Forms.Button previouspageButton;
        private System.Windows.Forms.Button nextpageButton;
        private System.Windows.Forms.Button endpageButton;
        private System.Windows.Forms.Label goLabel;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.TextBox gotextBox;
        private System.Windows.Forms.Label totalcountLabel;
        private System.Windows.Forms.Label pagesizeLabel;
        private System.Windows.Forms.Label pageLabel;
    }
}