using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainProgram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> sortList = new List<string>();
        private IEnumerable<VW_AgentDetails> agentsSort;
        public int takeNumber = 10;
        public int skipNumber = 0;
        public int maxElements;
        private IEnumerable<VW_AgentDetails> agentsMain;
        public MainWindow()
        {
            InitializeComponent();
            
            try
            {
                sortList.Add("Наименование (взрст)");
                sortList.Add("Наименование (уб)");
                sortList.Add("Размер скидки (взрст)");
                sortList.Add("Размер скидки (уб)");
                sortList.Add("Приоритет (взрст)");
                sortList.Add("Приоритет (уб)");
                MainListView.ItemsSource = user6Entities2.GetContext().VW_AgentDetails.Take(takeNumber).ToList();
                cmbFilter.ItemsSource = user6Entities2.GetContext().type_agents.ToList();
                cmbSort.ItemsSource = sortList;
                agentsSort = user6Entities2.GetContext().VW_AgentDetails.ToList();
                agentsMain = user6Entities2.GetContext().VW_AgentDetails.ToList();
                maxElements = agentsMain.Count();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtSearch.Text != "")
            {
                agentsSort = agentsMain.ToList().Where(x => x.Name.ToLower().Contains(txtSearch.Text.ToLower()) || x.Phone.Contains(txtSearch.Text));
                MainListView.ItemsSource = agentsSort;
            } else
            {
                MainListView.ItemsSource = user6Entities2.GetContext().VW_AgentDetails.ToList();
            }
            
        }
        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbFilter.SelectedIndex)
            {
                case 0:
                    agentsSort = agentsSort.ToList().Where(x => x.Тип == "ЗАО");
                    break;
                case 1:
                    agentsSort = agentsMain.ToList().Where(x => x.Тип == "МКК");
                    break;
                case 2:
                    agentsSort = agentsMain.ToList().Where(x => x.Тип == "МФО");
                    break;
                case 3:
                    agentsSort = agentsMain.ToList().Where(x => x.Тип == "ОАО");
                    break;
                case 4:
                    agentsSort = agentsMain.ToList().Where(x => x.Тип == "ООО");
                    break;
                case 5:
                    agentsSort = agentsMain.ToList().Where(x => x.Тип == "ПАО");
                    break;
            }
            MainListView.ItemsSource = agentsSort;
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    agentsSort = agentsSort.ToList().OrderBy(x => x.Name);
                    break;
                case 1:
                    agentsSort = agentsMain.ToList().OrderByDescending(x => x.Name);
                    break;
                case 2:
                    agentsSort = agentsMain.ToList().OrderBy(x => x.Скидка);
                    break;
                case 3:
                    agentsSort = agentsMain.ToList().OrderByDescending(x => x.Скидка);
                    break;
                case 4:
                    agentsSort = agentsMain.ToList().OrderBy(x => x.Priority);
                    break;
                case 5:
                    agentsSort = agentsMain.ToList().OrderByDescending(x => x.Priority);
                    break;
            }
            MainListView.ItemsSource = agentsSort;
        }

        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {
            agentsSort = user6Entities2.GetContext().VW_AgentDetails.ToList();
            MainListView.ItemsSource = agentsSort;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MainListView.SelectedItem == null)
            {
                MessageBox.Show("Выберите агента!");
                return;
            }
            VW_AgentDetails detailAgent = MainListView.SelectedItem as VW_AgentDetails;
            agents agent = user6Entities2.GetContext().agents.ToList().Where(x => x.IDAgent == detailAgent.IDAgent).First();
            user6Entities2.GetContext().agents.Remove(agent);
            user6Entities2.GetContext().VW_AgentDetails.Remove(detailAgent);
            user6Entities2.GetContext().SaveChanges();
            MessageBox.Show("Агент с именем " + agent.Name + " удален!");
            MainListView.ItemsSource = user6Entities2.GetContext().VW_AgentDetails.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddAgents addAgents = new AddAgents(null);
            addAgents.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            VW_AgentDetails one = MainListView.SelectedItem as VW_AgentDetails;
            agents agent = user6Entities2.GetContext().agents.ToList().Where(x => x.IDAgent == one.IDAgent).ToList().First();
            AddAgents addAgents = new AddAgents(agent);
            addAgents.Show();
        }


        private void TxtGoForward_MouseDown(object sender, MouseButtonEventArgs e)
        {
            skipNumber += 10;
            if (skipNumber >= maxElements)
            {
                skipNumber = maxElements - 10;

            }
            MainListView.ItemsSource = user6Entities2.GetContext().VW_AgentDetails.OrderBy(x => x.IDAgent).Skip(skipNumber).Take(takeNumber).ToList();
            
        }

        private void TxtGoToBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            skipNumber -= 10;
            if(skipNumber < 0)
            {
                skipNumber = 0;
            }
            MainListView.ItemsSource = user6Entities2.GetContext().VW_AgentDetails.OrderBy(x => x.IDAgent).Skip(skipNumber).Take(takeNumber).ToList();
        }
    }
}
