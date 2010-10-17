using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CafeInformationHelper
/// </summary>
public class CafeInformationHelper
{
	private const string tableName = "cafe_information";
	private const string columnId = "id";
	private const string columnName = "name";
	private const string columnTelephone = "telephone";
	private const string columnContact = "contact";
	private const string columnMobile = "mobile";
	private const string columnMainServerType = "main_server_type";
	private const string columnSecondaryServerType = "secondary_server_type";
	private const string columnCashServerType = "cash_register_server_type";
	private const string columnMovieServerType = "movie_server_type";
	private const string columnRouterServerType = "router_server_type";

	private string id = "";
	private string name = "";
	private string telephone = "";
	private string contact = "";
	private string mobile = "";
	private string mainServerType = "";
	private string secondaryServerType = "";
	private string cashServerType = "";
	private string movieServerType = "";
	private string routerServerType = "";

	private Dictionary<string, string> parameters = new Dictionary<string, string>();
	public Dictionary<string, string> Parameters
	{
		get { return parameters; }
	}

	public CafeInformationHelper()
	{
		parameters.Add(columnId, id);
		parameters.Add(columnName, name);
		parameters.Add(columnTelephone, telephone);
		parameters.Add(columnContact, contact);
		parameters.Add(columnMobile, mobile);
		parameters.Add(columnMainServerType, mainServerType);
		parameters.Add(columnSecondaryServerType, secondaryServerType);
		parameters.Add(columnCashServerType, cashServerType);
		parameters.Add(columnMovieServerType, movieServerType);
		parameters.Add(columnRouterServerType, routerServerType);
	}
	public static CafeInformationHelper GetCafeInformationHelper(string id)
	{
		CafeInformationHelper helper = null;
		string selectString = "select * from cafe_information";
		selectString += " where id=" + id;
		DataSet ds = DBAccess.GetDataSet(selectString, tableName);
		if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
		{
			DataTable dt = ds.Tables[tableName];
			helper = new CafeInformationHelper();

			foreach (string field in new List<string>(helper.Parameters.Keys))
			{
				//kvp.Value = dt.Rows[0][kvp.Key].ToString();
				helper.Parameters[field] = dt.Rows[0][field].ToString();
			}
		}
		return helper;
	}
}
