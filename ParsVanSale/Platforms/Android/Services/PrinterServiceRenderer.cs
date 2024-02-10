using Android.Bluetooth;
using Android.Graphics;
using Java.Util;
using ParsVanSale.Services;
using System.Text;

namespace ParsVanSale.Platforms.Android.Services
{
	public class PrinterServiceRenderer:IPrintServices
	{ 
		public IList<string> GetDeviceList()
		{
			using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
			{
				var btdevice = bluetoothAdapter?.BondedDevices.Select(i => i.Name).ToList();
				return btdevice;
			}
		}
		public async Task Print(string deviceName, byte[]? imageData,string text)
		{
			using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
			{
				MemoryStream stream = new MemoryStream();
				BluetoothDevice device = (from bd in bluetoothAdapter?.BondedDevices
										  where bd?.Name == deviceName
										  select bd).FirstOrDefault();
				try
				{
					using (BluetoothSocket bluetoothSocket = device?.
						CreateRfcommSocketToServiceRecord(
						UUID.FromString("00001101-0000-1000-8000-00805f9b34fb")))
					{
						bluetoothSocket?.Connect();
						//byte[] imageCommands = GenerateImageCommands(imageData);
						//bluetoothSocket?.OutputStream.Write(imageCommands, 0, imageCommands.Length);
						
						byte[] buffer = Encoding.UTF8.GetBytes(text);
						bluetoothSocket?.OutputStream.Write(buffer, 0, buffer.Length);
						bluetoothSocket.Close();
					}
				}
				catch (Exception exp)
				{
					throw exp;
				}
			}
		}

		private byte[] GenerateImageCommands(byte[] bitmapData)
		{
			string commandsString = string.Concat(new string[] {
            	"\u001B*r" + bitmapData.Length + "\u001B*p" + Encoding.ASCII.GetString(bitmapData) + "\u001B*r0"
            });
			byte[] commands = Encoding.ASCII.GetBytes(commandsString);
			return commands;
		}
	}
}
