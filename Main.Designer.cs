namespace ProjectsManager
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.AddIDE = new System.Windows.Forms.Button();
            this.AddProject = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LaunchProject = new System.Windows.Forms.Button();
            this.RemoveIDE = new System.Windows.Forms.Button();
            this.RemoveProject = new System.Windows.Forms.Button();
            this.IDES = new System.Windows.Forms.Panel();
            this.Projetos = new System.Windows.Forms.Panel();
            this.AboutMePanel = new System.Windows.Forms.Panel();
            this.AboutMe = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.AboutMePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddIDE
            // 
            this.AddIDE.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AddIDE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddIDE.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddIDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddIDE.ForeColor = System.Drawing.Color.White;
            this.AddIDE.Location = new System.Drawing.Point(0, 0);
            this.AddIDE.Name = "AddIDE";
            this.AddIDE.Size = new System.Drawing.Size(115, 32);
            this.AddIDE.TabIndex = 4;
            this.AddIDE.Text = "Add IDE";
            this.AddIDE.UseVisualStyleBackColor = false;
            this.AddIDE.Click += new System.EventHandler(this.ButtonAddIDE_Click);
            // 
            // AddProject
            // 
            this.AddProject.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AddProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddProject.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddProject.ForeColor = System.Drawing.Color.White;
            this.AddProject.Location = new System.Drawing.Point(115, 0);
            this.AddProject.Name = "AddProject";
            this.AddProject.Size = new System.Drawing.Size(115, 32);
            this.AddProject.TabIndex = 5;
            this.AddProject.Text = "Add Project";
            this.AddProject.UseVisualStyleBackColor = false;
            this.AddProject.Click += new System.EventHandler(this.ButtonAddProject_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopPanel.Controls.Add(this.LaunchProject);
            this.TopPanel.Controls.Add(this.RemoveIDE);
            this.TopPanel.Controls.Add(this.RemoveProject);
            this.TopPanel.Controls.Add(this.AddProject);
            this.TopPanel.Controls.Add(this.AddIDE);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1105, 34);
            this.TopPanel.TabIndex = 6;
            // 
            // LaunchProject
            // 
            this.LaunchProject.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LaunchProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LaunchProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LaunchProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LaunchProject.ForeColor = System.Drawing.Color.White;
            this.LaunchProject.Location = new System.Drawing.Point(230, 0);
            this.LaunchProject.Name = "LaunchProject";
            this.LaunchProject.Size = new System.Drawing.Size(615, 32);
            this.LaunchProject.TabIndex = 10;
            this.LaunchProject.Text = "Launch Project";
            this.LaunchProject.UseVisualStyleBackColor = false;
            this.LaunchProject.Click += new System.EventHandler(this.LaunchProject_Click);
            // 
            // RemoveIDE
            // 
            this.RemoveIDE.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RemoveIDE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveIDE.Dock = System.Windows.Forms.DockStyle.Right;
            this.RemoveIDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RemoveIDE.ForeColor = System.Drawing.Color.White;
            this.RemoveIDE.Location = new System.Drawing.Point(845, 0);
            this.RemoveIDE.Name = "RemoveIDE";
            this.RemoveIDE.Size = new System.Drawing.Size(129, 32);
            this.RemoveIDE.TabIndex = 7;
            this.RemoveIDE.Text = "Remove IDE";
            this.RemoveIDE.UseVisualStyleBackColor = false;
            this.RemoveIDE.Click += new System.EventHandler(this.RemoveIde_Click);
            // 
            // RemoveProject
            // 
            this.RemoveProject.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RemoveProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveProject.Dock = System.Windows.Forms.DockStyle.Right;
            this.RemoveProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RemoveProject.ForeColor = System.Drawing.Color.White;
            this.RemoveProject.Location = new System.Drawing.Point(974, 0);
            this.RemoveProject.Name = "RemoveProject";
            this.RemoveProject.Size = new System.Drawing.Size(129, 32);
            this.RemoveProject.TabIndex = 6;
            this.RemoveProject.Text = "Remove Project";
            this.RemoveProject.UseVisualStyleBackColor = false;
            this.RemoveProject.Click += new System.EventHandler(this.RemoveProject_Click);
            // 
            // IDES
            // 
            this.IDES.BackColor = System.Drawing.SystemColors.ControlDark;
            this.IDES.Dock = System.Windows.Forms.DockStyle.Top;
            this.IDES.Location = new System.Drawing.Point(0, 34);
            this.IDES.Name = "IDES";
            this.IDES.Size = new System.Drawing.Size(1105, 118);
            this.IDES.TabIndex = 7;
            // 
            // Projetos
            // 
            this.Projetos.BackColor = System.Drawing.Color.Gray;
            this.Projetos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Projetos.Location = new System.Drawing.Point(0, 152);
            this.Projetos.Name = "Projetos";
            this.Projetos.Size = new System.Drawing.Size(1105, 486);
            this.Projetos.TabIndex = 8;
            // 
            // AboutMePanel
            // 
            this.AboutMePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AboutMePanel.Controls.Add(this.AboutMe);
            this.AboutMePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AboutMePanel.Location = new System.Drawing.Point(0, 621);
            this.AboutMePanel.Name = "AboutMePanel";
            this.AboutMePanel.Size = new System.Drawing.Size(1105, 17);
            this.AboutMePanel.TabIndex = 9;
            // 
            // AboutMe
            // 
            this.AboutMe.AutoSize = true;
            this.AboutMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutMe.Location = new System.Drawing.Point(0, 0);
            this.AboutMe.Name = "AboutMe";
            this.AboutMe.Size = new System.Drawing.Size(164, 13);
            this.AboutMe.TabIndex = 0;
            this.AboutMe.Text = "Project Manager by David Fialho.";
            this.AboutMe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 638);
            this.Controls.Add(this.AboutMePanel);
            this.Controls.Add(this.Projetos);
            this.Controls.Add(this.IDES);
            this.Controls.Add(this.TopPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Project Manager";
            this.Load += new System.EventHandler(this.Main_Load);
            this.TopPanel.ResumeLayout(false);
            this.AboutMePanel.ResumeLayout(false);
            this.AboutMePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddIDE;
        private System.Windows.Forms.Button AddProject;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button RemoveIDE;
        private System.Windows.Forms.Button RemoveProject;
        private System.Windows.Forms.Panel IDES;
        private System.Windows.Forms.Panel Projetos;
        private System.Windows.Forms.Panel AboutMePanel;
        private System.Windows.Forms.Label AboutMe;
        private System.Windows.Forms.Button LaunchProject;
    }
}

