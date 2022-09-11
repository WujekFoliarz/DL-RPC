using System.Windows.Forms;

namespace DL_RPC
{
    class Program
    {
        static void Main(string[] args)
        {
            functions.findDuplicate();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main_form());
        }
    }
}
