using System.IO.Ports;
namespace Programables
{
    public partial class Form1 : Form
    {
        SerialPort serialPort = new SerialPort();
        Datos dt= new Datos();
        public Form1()
        {
            InitializeComponent();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SerialPort.GetPortNames().ToList().ForEach(port => cmbPuertos.Items.Add(port));
        }
        private void DataReceive(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            dt.ejecutar($"Insert Into Temperaturas(temperatura,fecha,hora) Values({data}," +
                $"'{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("HH:mm")}');");
            this.Invoke(new MethodInvoker(delegate {
                rtbMenssage.AppendText(data + Environment.NewLine);
            }));
        }
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try {
                serialPort.PortName = cmbPuertos.Text;
                serialPort.BaudRate= 9600;
                serialPort.Open();
                MessageBox.Show("Conectado","Sistema",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex) {  }
        }

        
    }
}
