using ICanRead.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.IO;

namespace LevelsCreator
{
    public partial class Form1 : Form
    {
        const string path = "game.db";
        DataManager _dataManager;
        IList<Word> levelWords, langWords;
        public Form1()
        {
             _dataManager = new DataManager(Path.Combine(Application.StartupPath, @"..\..\..\..\", "game.db"));
            InitializeComponent();
            Load += Form1_Load;
            entittiesGridView.AutoGenerateColumns = false;
            levelWordsGridView.AutoGenerateColumns = false;
            wordsGridView.AutoGenerateColumns = false;
            levelsGridView.AutoGenerateColumns = false;
            langWordsGridView.AutoGenerateColumns = false;
        }

        

        private void EntittiesGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (entittiesGridView.CurrentRow!=null)
                 wordsGridView.DataSource = (entittiesGridView.CurrentRow.DataBoundItem as Entity).Words;

        }


        

        
        private async void GamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var game = gamesComboBox.SelectedItem as GameType;
            if (game == null)
                return;
            levelsGridView.DataSource = levelsBindingSource;
            levelsBindingSource.DataSource =  new BindingList<Level>((await _dataManager.GetGameById(game.Id)).Levels.ToArray());
            langWords  = _dataManager.GetWordsNotInGame(game);
            langWordsBindingSource.DataSource = new BindingList<Word>(langWords);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        

        

        private async void levelsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (levelsGridView.CurrentRow == null)
                return;
            var level = (Level)levelsGridView.CurrentRow.DataBoundItem ;
            levelWords= await _dataManager.GetLevelWords(level.Id);
            levelWordsBindingSource.DataSource = new BindingList<Word>(levelWords);

        }

        private void LoadData()
        {
                var entitiesBindingSource = new BindingSource();
                var wordsBindingSource = new BindingSource();
                entittiesGridView.DataSource = entitiesBindingSource;
                wordsGridView.DataSource = wordsBindingSource;
            levelWordsGridView.DataSource = levelWordsBindingSource;
            langWordsGridView.DataSource = langWordsBindingSource;
                gamesComboBox.DataSource = _dataManager.Context.GameTypes.ToArray();
                _dataManager.Context.Entities.Include(e => e.Words).Load();
                entitiesBindingSource.DataSource = _dataManager.Context.Entities.Local.ToBindingList();
                wordsBindingSource.DataSource = entitiesBindingSource;
                wordsBindingSource.DataMember = nameof(Entity.Words);
            

        }

        //private void entittiesGridView_DoubleClick(object sender, EventArgs e)
        //{
        //    if (entittiesGridView.CurrentRow == null || levelsGridView.CurrentRow==null)
        //        return;

        //    _dataManager.AddWordToLevel((Level)levelsGridView.CurrentRow.DataBoundItem, (Entity) entittiesGridView.CurrentRow.DataBoundItem);
        //    levelWordsGridView.Refresh();
        //    //levelWordsGridView. // levelWordsGridView.Rows.GetLastRow();
        //}

        

        private async void saveToolStripButton_Click(object sender, EventArgs e)
        {
            await _dataManager.SaveChanges();

        }

        private async void  addlangwordtolevel_Click(object sender, EventArgs e)
        {
            if (langWordsGridView.CurrentRow == null || levelsGridView.CurrentRow == null)
                return;
            var word = (Word)langWordsGridView.CurrentRow.DataBoundItem;
            await _dataManager.AddWordToLevel((Level)levelsGridView.CurrentRow.DataBoundItem, word);
            levelWordsBindingSource.Add(word);
            langWordsBindingSource.RemoveAt(langWordsGridView.CurrentRow.Index);
        }

        private async void REmoveFromLevel_Click(object sender, EventArgs e)
        {
            if (levelWordsGridView.CurrentRow == null || levelsGridView.CurrentRow == null)
                return;

            var word = (Word)levelWordsGridView.CurrentRow.DataBoundItem;

            await _dataManager.RemoveLevelWord((Level)levelsGridView.CurrentRow.DataBoundItem, word);
            levelWordsBindingSource.RemoveAt(levelWordsGridView.CurrentRow.Index);
            langWordsBindingSource.Add(word);
        }
        private async void EntittiesGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await _dataManager.SaveChanges();
        }
        private async void LevelWordsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            await _dataManager.SaveChanges();
        }

        private async  void AddLevelMenuItem_Click(object sender, EventArgs e)
        {
            await _dataManager.AddNewLevel((GameType)gamesComboBox.SelectedItem);
        }

        private void entittiesGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void entittiesGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column == PictureFileName)
            {
                e.Handled = true;
                e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
            }
        }

        private async void addNewEntity_Click(object sender, EventArgs e)
        {
            await _dataManager.AddNewWord();
            entittiesGridView.CurrentCell = entittiesGridView.Rows.OfType<DataGridViewRow>().Last().Cells[nameof(PictureFileName)];
        }
    }
}
