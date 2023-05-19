using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class BaseView : Form
    {
        public void Message(bool result)
        {
            if (result)
                MessageBox.Show($"Operação realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao realizar operação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult MessageDelete(int id)
        {
            return MessageBox.Show("Deseja realmente excluir o registro de código: " + id.ToString() + "?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
