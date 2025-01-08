using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class frmPresetList : Form
    {
        private string sortColumn;
        private bool sortAscending;

        public frmPresetList()
        {
            InitializeComponent();
        }

        private void MoveColumnToEnd(string columnName)
        {
            if (dataGridViewPresets.Columns.Contains(columnName))
            {
                // Get the highest DisplayIndex of the current columns
                int maxDisplayIndex = dataGridViewPresets.Columns.Cast<DataGridViewColumn>()
                    .Max(col => col.DisplayIndex);

                // Set the specified column's DisplayIndex to max + 1
                dataGridViewPresets.Columns[columnName].DisplayIndex = maxDisplayIndex;
            }
        }

        private void MoveColumnToPosition(string columnName, int position)
        {
            if (!dataGridViewPresets.Columns.Contains(columnName)) return;
            dataGridViewPresets.Columns[columnName].DisplayIndex = position;
        }

        private void SetupDataGridView()
        {
            dataGridViewPresets.AutoGenerateColumns = true;
            dataGridViewPresets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Handle column sorting
            dataGridViewPresets.ColumnHeaderMouseClick += dataGridViewPresets_ColumnHeaderMouseClick;
        }

        private void dataGridViewPresets_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewPresets.Columns[e.ColumnIndex].DataPropertyName;
            var currentData = (List<PresetInfo>)dataGridViewPresets.DataSource;

            // Toggle sort order
            if(sortColumn == columnName)
            {
                sortAscending = !sortAscending;
            }
            else
            {
                sortAscending = true;
            }
            var sortedData = sortAscending
                ? currentData
                    .OrderBy(p => p.GetType().GetProperty(columnName).GetValue(p))
                    .ThenBy(p => p.Name)
                    .ToList()
                : currentData
                    .OrderByDescending(p => p.GetType().GetProperty(columnName).GetValue(p))
                    .ThenByDescending(p => p.Name)
                    .ToList();

            dataGridViewPresets.DataSource = null; // Clear current binding
            dataGridViewPresets.DataSource = sortedData;
            sortColumn = columnName;

            // Optional: Customize the DataGridView
            dataGridViewPresets.Columns["Description"].Visible = false;
            dataGridViewPresets.Columns["Id"].Visible = false;
            dataGridViewPresets.Columns["Name"].HeaderText = "Name";
            dataGridViewPresets.Columns["KnowledgeCheck"].HeaderText = "Knowledge Required";
            dataGridViewPresets.Columns["TimeFrame"].HeaderText = "Pace";
            dataGridViewPresets.Columns["ModdedLevel"].HeaderText = "Mod Level";
            dataGridViewPresets.Columns["CastleType"].HeaderText = "Castle Type";
            dataGridViewPresets.Columns["TransformEarly"].HeaderText = "Early Transforms";
            dataGridViewPresets.Columns["TransformFocus"].HeaderText = "Transform Focus";
            dataGridViewPresets.Columns["WinCondition"].HeaderText = "Win Condition";
            dataGridViewPresets.Columns["MetaExtension"].HeaderText = "Extension";
            dataGridViewPresets.Columns["MetaComplexity"].HeaderText = "Complexity";
            dataGridViewPresets.Columns["ItemStats"].HeaderText = "Random Stats";
            MoveColumnToEnd("TransformEarly");
            MoveColumnToEnd("TransformFocus");
            MoveColumnToEnd("WinCondition");
            MoveColumnToPosition("MetaComplexity", 2);
            MoveColumnToPosition("MetaExtension", 3);
        }

        private Dictionary<string, PresetInfo> presetDictionary;
        void GetPresets()
        {
            string jsonFilePath = Path.Combine(LauncherClient.GetConfigValue("RandomizerPath"), "Randomizer", "preset-data.json");
            string jsonString = File.ReadAllText(jsonFilePath);
            var presets = JsonConvert.DeserializeObject<List<PresetInfo>>(jsonString);

            // Sort presets by Name
            presets.Sort((preset1, preset2) => string.Compare(preset1.Name, preset2.Name));

            // Store presets in a dictionary for quick lookup
            presetDictionary = presets.ToDictionary(p => p.Name, p => p);
            // Bind DataGridView to the presets
            dataGridViewPresets.DataSource = null; // Clear any previous binding
            dataGridViewPresets.AutoGenerateColumns = true; // Automatically generate columns from properties
            dataGridViewPresets.DataSource = presets;

            // Optional: Customize the DataGridView
            dataGridViewPresets.Columns["Description"].Visible = false;
            dataGridViewPresets.Columns["Id"].Visible = false;
            dataGridViewPresets.Columns["Name"].HeaderText = "Name";
            dataGridViewPresets.Columns["KnowledgeCheck"].HeaderText = "Knowledge Required";
            dataGridViewPresets.Columns["TimeFrame"].HeaderText = "Pace";
            dataGridViewPresets.Columns["ModdedLevel"].HeaderText = "Mod Level";
            dataGridViewPresets.Columns["CastleType"].HeaderText = "Castle Type";
            dataGridViewPresets.Columns["TransformEarly"].HeaderText = "Early Transforms";
            dataGridViewPresets.Columns["TransformFocus"].HeaderText = "Transform Focus";
            dataGridViewPresets.Columns["WinCondition"].HeaderText = "Win Condition";
            dataGridViewPresets.Columns["MetaExtension"].HeaderText = "Extension";
            dataGridViewPresets.Columns["MetaComplexity"].HeaderText = "Complexity";
            dataGridViewPresets.Columns["ItemStats"].HeaderText = "Random Stats";
            MoveColumnToEnd("TransformEarly");
            MoveColumnToEnd("TransformFocus");
            MoveColumnToEnd("WinCondition");
            MoveColumnToPosition("MetaComplexity", 2);
            MoveColumnToPosition("MetaExtension", 3);
        }

        private void frmPresetList_Load(object sender, EventArgs e)
        {
            GetPresets();
            SetupDataGridView();
        }
    }
}
