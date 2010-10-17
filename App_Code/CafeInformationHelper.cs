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

	private string id;
	private string name;
	private string telephone;
	private string contact;
	private string mobile;
	private string mainServerType;
	private string secondaryServerType;
	private string cashServerType;
	private string movieServerType;
	private string routerServerType;

	public CafeInformationHelper()
	{
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
			helper.id = dt.Rows[0][columnId].ToString();
			helper.name = dt.Rows[0][columnId].ToString();
			helper.telephone = dt.Rows[0][columnId].ToString();
			helper.contact = dt.Rows[0][columnId].ToString();
			helper.mobile = dt.Rows[0][columnId].ToString();
			helper.mainServerType = dt.Rows[0][columnId].ToString();
			helper.secondaryServerType = dt.Rows[0][columnId].ToString();
			helper.cashServerType = dt.Rows[0][columnId].ToString();
			helper.movieServerType = dt.Rows[0][columnId].ToString();
			helper.routerServerType = dt.Rows[0][columnId].ToString();
		}
		return helper;
	}
}
