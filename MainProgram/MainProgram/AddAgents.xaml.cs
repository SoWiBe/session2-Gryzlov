using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MainProgram
{
    /// <summary>
    /// Логика взаимодействия для AddAgents.xaml
    /// </summary>
    public partial class AddAgents : Window
    {
        agents _agent = new agents();
        VW_AgentDetails details = new VW_AgentDetails();
        public AddAgents(agents agent)
        {
            InitializeComponent();
            if(agent != null)
            {
                _agent = agent;
            }
            cmbMain.ItemsSource = user6Entities2.GetContext().type_agents.ToList();
            DataContext = _agent;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (txtAddress.Text == "")
            {
                stringBuilder.Append("\nВведите адрес!");
            }
            if (txtINN.Text == "")
            {
                stringBuilder.Append("\nВведите ИНН!");
            }
            if (txtKPP.Text == "")
            {
                stringBuilder.Append("\nВведите КПП!");
            }
            if (txtName.Text == "")
            {
                stringBuilder.Append("\nВведите Имя!");
            }
            if (txtPriority.Text == "")
            {
                stringBuilder.Append("\nВведите Приоритет!");
            }
            if(stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }
            if(_agent.IDAgent == 0)
            {
                user6Entities2.GetContext().agents.Add(_agent);
                MessageBox.Show("Всё успешно!");
            }
            user6Entities2.GetContext().SaveChanges();
        }
    }
}
