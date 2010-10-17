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
	public const string columnId = "id";
	public const string columnName = "name";
	public const string columnTelephone = "telephone";
	public const string columnContact = "contact";
	public const string columnMobile = "mobile";
	public const string columnMainServerType = "main_server_type";
	public const string columnSecondaryServerType = "secondary_server_type";
	public const string columnCashServerType = "cash_register_server_type";
	public const string columnMovieServerType = "movie_server_type";
	public const string columnRouterServerType = "router_server_type";

	//private string id = "";
	public string Id
	{
		get { return Parameters[columnId]; }
		set { Parameters[columnId] = value; }
	}
	//private string name = "";
	public string Name
	{
		get { return Parameters[columnName]; }
		set { Parameters[columnName] = value; }
	}
	//private string telephone = "";
	public string Telephone
	{
		get { return Parameters[columnTelephone]; }
		set { Parameters[columnTelephone] = value; }
	}
	//private string contact = "";
	public string Contact
	{
		get { return Parameters[columnContact]; }
		set { Parameters[columnContact] = value; }
	}
	//private string mobile = "";
	public string Mobile
	{
		get { return Parameters[columnMobile]; }
		set { Parameters[columnMobile] = value; }
	}
	//private string mainServerType = "";
	public string MainServerType
	{
		get { return Parameters[columnMainServerType]; }
		set { Parameters[columnMainServerType] = value; }
	}
	//private string secondaryServerType = "";
	public string SecondaryServerType
	{
		get { return Parameters[columnSecondaryServerType]; }
		set { Parameters[columnSecondaryServerType] = value; }
	}
	//private string cashServerType = "";
	public string CashServerType
	{
		get { return Parameters[columnCashServerType]; }
		set { Parameters[columnCashServerType] = value; }
	}
	//private string movieServerType = "";
	public string MovieServerType
	{
		get { return Parameters[columnMovieServerType]; }
		set { Parameters[columnMovieServerType] = value; }
	}
	//private string routerServerType = "";
	public string RouterServerType
	{
		get { return Parameters[columnRouterServerType]; }
		set { Parameters[columnRouterServerType] = value; }
	}
	private Dictionary<string, string> parameters = new Dictionary<string, string>()
	{
		{columnId, ""},
		{columnName, ""},
		{columnTelephone, ""},
		{columnContact, ""},
		{columnMobile, ""},
		{columnMainServerType, ""},
		{columnSecondaryServerType, ""},
		{columnCashServerType, ""},
		{columnMovieServerType, ""},
		{columnRouterServerType, ""},
	};
	public Dictionary<string, string> Parameters
	{
		get { return parameters; }
	}

	private CafeInformationHelper() { }
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
