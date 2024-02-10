using Android.Bluetooth;
using Java.Util;
using ParsVanSale.Platforms.Android.Services;
using ParsVanSale.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ParsVanSale.Platforms.Android.Services
{
	public class BluetoothServiceRenderer : IPrintServices
	{
		public IList<string> GetDeviceList()
		{
			using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
			{
				var btdevice = bluetoothAdapter?.BondedDevices.Select(i => i.Name).ToList();
				return btdevice;
			}
		}

		public async Task Print(string deviceName, byte[] imageData, string text)
		{
			using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
			{
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
						if (imageData != null && imageData.Length > 0)
						{
							bluetoothSocket?.OutputStream.Write(imageData);
						}
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
	}
}
