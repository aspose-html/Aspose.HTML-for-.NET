using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.HTML.Live.Demos.UI.Models
{
	///<Summary>
	/// License class to set apose products license
	///</Summary>
	public static class License
	{
		private static string _licenseFileName = "Aspose.Total.Product.Family.lic";

		///<Summary>
		/// SetAsposeHTMLLicense method to Aspose.ThreeD License
		///</Summary>
		public static void SetAsposeHTMLLicense()
		{
			try
			{

				//Aspose.HTML.License lic = new Aspose.HTML.License();
				//lic.SetLicense(_licenseFileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}	
		
	}
}
