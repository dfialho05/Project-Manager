using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjectsManager
{
    public partial class Main : Form
    {
        private List<string> ideFilePaths = new List<string>();
        private List<string> workingProjects = new List<string>();

        private FlowLayoutPanel flowLayoutPanelProjects; // Para projetos
        private FlowLayoutPanel flowLayoutPanelIde; // Para IDEs

        private CheckBox selectedProjectCheckBox = null; // Para armazenar a CheckBox de projeto selecionada
        private CheckBox selectedIdeCheckBox = null; // Para armazenar a CheckBox de IDE selecionada

        public Main()
        {
            InitializeComponent();

            this.Size = new Size(800, 600); // Definir tamanho fixo para a janela principal

            // Configurar FlowLayoutPanel para os projetos
            flowLayoutPanelProjects = new FlowLayoutPanel();
            flowLayoutPanelProjects.Dock = DockStyle.Fill; // Preencher a área disponível no formulário
            Projetos.Controls.Add(flowLayoutPanelProjects); // Adicionar FlowLayoutPanel ao Panel de projetos

            // Configurar FlowLayoutPanel para as IDEs
            flowLayoutPanelIde = new FlowLayoutPanel();
            flowLayoutPanelIde.Dock = DockStyle.Fill; // Preencher a área disponível no formulário
            IDES.Controls.Add(flowLayoutPanelIde); // Adicionar FlowLayoutPanel ao Panel de IDEs

            InitializeDatabase();
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projectsManager.db");
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();

                // Load IDEs
                string selectIdeQuery = "SELECT Path FROM IDEs";
                using (SQLiteCommand cmd = new SQLiteCommand(selectIdeQuery, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ideFilePaths.Add(reader.GetString(0));
                    }
                }

                // Load Projects
                string selectProjectQuery = "SELECT Path FROM Projects";
                using (SQLiteCommand cmd = new SQLiteCommand(selectProjectQuery, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        workingProjects.Add(reader.GetString(0));
                    }
                }
            }

            UpdateIdeUI();
            UpdateProjectsUI();
        }

        private void InitializeDatabase()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projectsManager.db");
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();

                string createIdeTable = @"CREATE TABLE IF NOT EXISTS IDEs (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Path TEXT NOT NULL
                                  );";

                string createProjectsTable = @"CREATE TABLE IF NOT EXISTS Projects (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Path TEXT NOT NULL
                                      );";

                using (SQLiteCommand cmd = new SQLiteCommand(createIdeTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createProjectsTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveIdeToDatabase(string idePath)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projectsManager.db");
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string insertQuery = "INSERT INTO IDEs (Path) VALUES (@Path)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Path", idePath);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveProjectToDatabase(string projectPath)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projectsManager.db");
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Projects (Path) VALUES (@Path)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Path", projectPath);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void RemoveProjectFromDatabase(string projectPath)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projectsManager.db");
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Projects WHERE Path = @Path";
                using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Path", projectPath);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void RemoveIdeFromDatabase(string idePath)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "projectsManager.db");
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM IDEs WHERE Path = @Path";
                using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Path", idePath);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ButtonAddIDE_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Selecionar IDE";
            fileDialog.Filter = "Executáveis|*.exe;*.lnk";
            fileDialog.FilterIndex = 2;
            fileDialog.InitialDirectory = "c:\\";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string txtFileName = fileDialog.FileName;
                if (string.IsNullOrEmpty(txtFileName) || ideFilePaths.Contains(txtFileName))
                {
                    MessageBox.Show("Esta IDE já se encontra na lista ou o caminho é inválido.");
                    return;
                }

                ideFilePaths.Add(txtFileName);
                SaveIdeToDatabase(txtFileName);
                UpdateIdeUI();
            }
        }

        private void ButtonAddProject_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecione a pasta do projeto";
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;
                    if (string.IsNullOrEmpty(folderPath) || workingProjects.Contains(folderPath))
                    {
                        MessageBox.Show("Este Projeto já se encontra na lista de Projetos.");
                        return;
                    }

                    workingProjects.Add(folderPath);
                    SaveProjectToDatabase(folderPath);
                    UpdateProjectsUI();
                }
            }
        }

        private void UpdateProjectsUI()
        {
            // Limpar todos os controles antes de recriá-los
            flowLayoutPanelProjects.Controls.Clear();

            foreach (string projectPath in workingProjects)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = Path.GetFileName(projectPath); // Mostra apenas o nome da pasta
                checkBox.AutoSize = true;
                checkBox.Margin = new Padding(10); // Adicionar margem para espaçamento entre CheckBoxes
                checkBox.CheckedChanged += ProjectCheckBox_CheckedChanged; // Evento para gerenciar seleção

                flowLayoutPanelProjects.Controls.Add(checkBox); // Adicionar CheckBox ao FlowLayoutPanel de projetos
            }
        }

        private void UpdateIdeUI()
        {
            // Limpar todos os controles antes de recriá-los
            flowLayoutPanelIde.Controls.Clear();

            foreach (string idePath in ideFilePaths)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = Path.GetFileName(idePath); // Mostra apenas o nome do arquivo .exe
                checkBox.AutoSize = true;
                checkBox.Margin = new Padding(10); // Adicionar margem para espaçamento entre CheckBoxes
                checkBox.CheckedChanged += IdeCheckBox_CheckedChanged; // Evento para gerenciar seleção

                flowLayoutPanelIde.Controls.Add(checkBox); // Adicionar CheckBox ao FlowLayoutPanel de IDEs
            }
        }

        private void ProjectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            // Se o CheckBox de projeto foi marcado
            if (checkBox.Checked)
            {
                // Aqui você pode fazer algo com o projeto selecionado
                string selectedProjectPath = workingProjects[flowLayoutPanelProjects.Controls.IndexOf(checkBox)];

                // Adicionar à lista de projetos selecionados
                selectedProjectCheckBox = checkBox;
            }
            else
            {
                // Se o CheckBox de projeto foi desmarcado
                selectedProjectCheckBox = null;
            }
        }

        private void IdeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            // Se o CheckBox de IDE foi marcado
            if (checkBox.Checked)
            {
                // Aqui você pode fazer algo com a IDE selecionada
                string selectedIdePath = ideFilePaths[flowLayoutPanelIde.Controls.IndexOf(checkBox)];

                // Adicionar à lista de IDEs selecionadas
                selectedIdeCheckBox = checkBox;
            }
            else
            {
                // Se o CheckBox de IDE foi desmarcado
                selectedIdeCheckBox = null;
            }
        }

        private void RemoveProject_Click(object sender, EventArgs e)
        {
            List<CheckBox> checkBoxesToRemove = new List<CheckBox>();

            foreach (CheckBox checkBox in flowLayoutPanelProjects.Controls)
            {
                if (checkBox.Checked)
                {
                    string projectName = checkBox.Text;
                    string projectPathToRemove = workingProjects.Find(path => Path.GetFileName(path) == projectName);

                    if (projectPathToRemove != null)
                    {
                        workingProjects.Remove(projectPathToRemove);
                        RemoveProjectFromDatabase(projectPathToRemove);
                        checkBoxesToRemove.Add(checkBox);
                    }
                }
            }

            foreach (CheckBox checkBox in checkBoxesToRemove)
            {
                flowLayoutPanelProjects.Controls.Remove(checkBox);
            }

            if (checkBoxesToRemove.Count == 0)
            {
                MessageBox.Show("Nenhum projeto selecionado para remover.");
            }
        }

        private void RemoveIde_Click(object sender, EventArgs e)
        {
            List<CheckBox> checkBoxesToRemove = new List<CheckBox>();

            foreach (CheckBox checkBox in flowLayoutPanelIde.Controls)
            {
                if (checkBox.Checked)
                {
                    string ideName = checkBox.Text;
                    string idePathToRemove = ideFilePaths.Find(path => Path.GetFileName(path) == ideName);

                    if (idePathToRemove != null)
                    {
                        ideFilePaths.Remove(idePathToRemove);
                        RemoveIdeFromDatabase(idePathToRemove);
                        checkBoxesToRemove.Add(checkBox);
                    }
                }
            }

            foreach (CheckBox checkBox in checkBoxesToRemove)
            {
                flowLayoutPanelIde.Controls.Remove(checkBox);
            }

            if (checkBoxesToRemove.Count == 0)
            {
                MessageBox.Show("Nenhuma IDE selecionada para remover.");
            }
        }

        private void OpenIDEWithProject(string idePath, string projectPath)
        {
            try
            {
                // Verificar se o caminho da IDE e do projeto são válidos
                if (!File.Exists(idePath))
                {
                    MessageBox.Show("O arquivo da IDE não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Directory.Exists(projectPath))
                {
                    MessageBox.Show("A pasta do projeto não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir a IDE com o projeto
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = idePath;
                startInfo.Arguments = $"\"{projectPath}\""; // Passar o caminho do projeto como argumento
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir a IDE: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LaunchProject_Click(object sender, EventArgs e)
        {
            // Desmarcar todas as CheckBoxes de IDEs
            foreach (Control control in flowLayoutPanelIde.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }

            // Desmarcar todas as CheckBoxes de Projetos
            foreach (Control control in flowLayoutPanelProjects.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }

            // Aguardar até que uma IDE e um Projeto sejam selecionados
            while (selectedIdeCheckBox == null || selectedProjectCheckBox == null)
            {
                Application.DoEvents(); // Permitir que a aplicação continue respondendo enquanto aguarda a seleção
            }

            // Abrir a IDE selecionada na pasta do projeto
            if (selectedIdeCheckBox != null && selectedProjectCheckBox != null)
            {
                string selectedIdePath = ideFilePaths[flowLayoutPanelIde.Controls.IndexOf(selectedIdeCheckBox)];
                string selectedProjectName = selectedProjectCheckBox.Text;
                string selectedProjectPath = workingProjects.Find(path => Path.GetFileName(path) == selectedProjectName);

                OpenIDEWithProject(selectedIdePath, selectedProjectPath);
            }

            foreach (Control control in flowLayoutPanelIde.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }

            // Desmarcar todas as CheckBoxes de Projetos
            foreach (Control control in flowLayoutPanelProjects.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
