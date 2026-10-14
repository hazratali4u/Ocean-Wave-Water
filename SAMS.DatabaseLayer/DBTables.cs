using System;
using System.Data;
using System.Net;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;
using System.IO;
using System.Collections;
using System.Windows.Forms;
//using System.Data;

using System.Data.SqlClient;
using System.Data.OleDb;
//using FtpLib;
namespace SAMS.DatabaseLayer.Classes
{	
	/// <summary>
	/// DBTables
	/// <author>Rizwan Ansari</author>
	/// <date></date>
	/// </summary>
	public class DBTables
	{
		public static bool IDENTITY_SET (string pTableName , string pValue, IDbConnection mConnection)
		{
			try
			{
				IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandText = "SET IDENTITY_INSERT " + pTableName + " " + pValue;
				cmd.Connection =   mConnection;
				cmd.ExecuteNonQuery();
				
				return true;
			}
			catch(Exception ex)
			{
				//mConnection.Close();
				return false;
			}
			finally
			{
				//mConnection.Close();
			}
		}
		public static bool TRUNCATE_TABLE(string pTableName , IDbConnection mConnection,IDbTransaction mTransaction)
		{
			try
			{
				IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandText = "TRUNCATE TABLE " + pTableName;
				cmd.Connection =   mConnection;
				cmd.Transaction = mTransaction;
				cmd.ExecuteNonQuery();
				
				return true;
			}
			catch(Exception ex)
			{
				//mConnection.Close();
				return false;
			}
			finally
			{
				//mConnection.Close();
			}
		}
		public static bool IDENTITY_SET (string pTableName , string pValue, IDbConnection mConnection,IDbTransaction mTransaction )
		{
			try
			{
				IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandText = "SET IDENTITY_INSERT " + pTableName + " " + pValue;
				cmd.Transaction = mTransaction;
				cmd.Connection =   mConnection;
				cmd.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException( ex );
				return false;
			}
			finally
			{
				//mConnection.Close();
			}
		}
		
		public class CLAIM_DETAIL
		{
			public static string CLAIM_DETAIL_ID = "CLAIM_DETAIL_ID";
			public static string CLAIM_ID = "CLAIM_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
		}
		public class WAREHOUSE_STOCK
		{
			public static string WAREHOUSE_STOCK_ID = "WAREHOUSE_STOCK_ID";
		}
		public class CLAIM_APPROVAL
		{
			public static string CLAIM_APPROVAL_ID = "CLAIM_APPROVAL_ID";
			public static string CLAIM_ID = "CLAIM_ID";
			public static string CLAIM_STATUS_ID = "CLAIM_STATUS_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string REMARKS = "REMARKS";
			public static string USER_ID = "USER_ID";
		}
		public class WAREHOUSE_DISTRIBUTORS
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string WAREHOUSE_ID = "WAREHOUSE_ID";
		}
		public class BASKET_MASTER
		{
			public static string BASKET_ID = "BASKET_ID";
			public static string BASKET_ON = "BASKET_ON";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string IS_AND = "IS_AND";
			public static string IS_BASKET = "IS_BASKET";
			public static string IS_MULTIPLE = "IS_MULTIPLE";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string SCHEME_ID = "SCHEME_ID";
		}
		public class USER_TERRITORY
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string TERRITORY_ID = "TERRITORY_ID";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string USER_ID = "USER_ID";
		}
		public class SAMS_SYNC_SETTINGS
		{
			public static string SAMS_SYNC_SETTINGS_ID = "SAMS_SYNC_SETTINGS_ID";
			public static string SYNC_ON_DELETE = "SYNC_ON_DELETE";
			public static string SYNC_ON_INSERT = "SYNC_ON_INSERT";
			public static string SYNC_ON_UPDATE = "SYNC_ON_UPDATE";
			public static string TABLE_NAME = "TABLE_NAME";
		}
		public class USER_ATTENDANCE
		{
			public static string ATTENDANCE_DATE = "ATTENDANCE_DATE";
			public static string ATTENDANCE_FOR = "ATTENDANCE_FOR";
			public static string ATTENDANCE_ID = "ATTENDANCE_ID";
			public static string ATTENDANCE_MARKED_BY = "ATTENDANCE_MARKED_BY";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string HOLIDAY = "HOLIDAY";
			public static string IS_PRESENT = "IS_PRESENT";
			public static string L_C_A = "L_C_A";
			public static string L_O_S = "L_O_S";
			public static string MAINTENANCE = "MAINTENANCE";
			public static string MILEAGE = "MILEAGE";
			public static string O_S = "O_S";
			public static string TIME_IN = "TIME_IN";
			public static string TIME_OUT = "TIME_OUT";
		}
		public class USER_AREA
		{
			public static string AREA_ID = "AREA_ID";
			public static string DAY_OF_WEEK = "DAY_OF_WEEK";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string USER_AREA_ID = "USER_AREA_ID";
			public static string USER_ID = "USER_ID";
		}
		public class UOMS
		{
			public static string STATUS = "STATUS";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string UOM_DESC = "UOM_DESC";
			public static string UOM_ID = "UOM_ID";
		}
		public class SYNC_LOG
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string IS_CLOSED = "IS_CLOSED";
			public static string LOG_DATE = "LOG_DATE";
			public static string SYNC_LOG_ID = "SYNC_LOG_ID";
		}
		public class TA_DA_SLABS
		{
			public static string DESIGNATION_ID = "DESIGNATION_ID";
			public static string FARE = "FARE";
			public static string HOLIDAY = "HOLIDAY";
			public static string LCA = "LCA";
			public static string LOS = "LOS";
			public static string MAINTENENCE = "MAINTENENCE";
			public static string OS = "OS";
			public static string SLAB_NAME = "SLAB_NAME";
			public static string TA_DA_SLAB_ID = "TA_DA_SLAB_ID";
		}
		public class SAMS_USER
		{
			public static string ADDRESS1 = "ADDRESS1";
			public static string ADDRESS2 = "ADDRESS2";
			public static string C_USER_ID = "C_USER_ID";
			public static string DESIGNATION_ID = "DESIGNATION_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string DIVISION_ID = "DIVISION_ID";
			public static string EMAIL_ADDRESS = "EMAIL_ADDRESS";
			public static string FAX = "FAX";
			public static string HOME_TOWN_ID = "HOME_TOWN_ID";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string IS_DEFAULT = "IS_DEFAULT";
			public static string IS_DELETED = "IS_DELETED";
			public static string IS_DISTRIBUTOR_LOGIN = "IS_DISTRIBUTOR_LOGIN";
			public static string IS_PPC_LOGIN = "IS_PPC_LOGIN";
			public static string IS_SERVER_LOGIN = "IS_SERVER_LOGIN";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string LOGIN_ID = "LOGIN_ID";
			public static string MOBILE = "MOBILE";
			public static string PASSWORD = "PASSWORD";
			public static string PHONE = "PHONE";
			public static string REGION_ID = "REGION_ID";
			public static string ROLE_ID = "ROLE_ID";
			public static string SUBZONE_ID = "SUBZONE_ID";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string USER_CODE = "USER_CODE";
			public static string USER_ID = "USER_ID";
			public static string USER_NAME = "USER_NAME";
			public static string USER_TYPE_ID = "USER_TYPE_ID";
			public static string ZONE_ID = "ZONE_ID";
		}
		public class SAMS_CODES
		{
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string PARENT_REF_ID = "PARENT_REF_ID";
			public static string REF_ID = "REF_ID";
			public static string SAMS_CODE = "SAMS_CODE";
			public static string SAMS_DESC = "SAMS_DESC";
			public static string STATUS = "STATUS";
			public static string TIME_STAMP = "TIME_STAMP";
		}
		public class GEO_HIERARCHY
		{
			public static string COMPANY_ID = "COMPANY_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string GEO_CODE = "GEO_CODE";
			public static string GEO_ID = "GEO_ID";
			public static string GEO_NAME = "GEO_NAME";
			public static string GEO_TYPE_ID = "GEO_TYPE_ID";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string ISCURRENT = "ISCURRENT";
			public static string ISDELETED = "ISDELETED";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string PARENT_GEO_ID = "PARENT_GEO_ID";
			public static string STATUS = "STATUS";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string USER_ID = "USER_ID";
		}
		public class SKUS
		{
			public static string BRAND_ID = "BRAND_ID";
			public static string CATEGORY_ID = "CATEGORY_ID";
			public static string DIVISION_ID = "DIVISION_ID";
			public static string GST_ON = "GST_ON";
			public static string GST_RATE_REG = "GST_RATE_REG";
			public static string GST_RATE_UNREG = "GST_RATE_UNREG";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string ISACTIVE = "ISACTIVE";
			public static string ISEXEMPTED = "ISEXEMPTED";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string PRODUCTLINE_ID = "PRODUCTLINE_ID";
			public static string SKU_CODE = "SKU_CODE";
			public static string SKU_ID = "SKU_ID";
			public static string SKU_NAME = "SKU_NAME";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string UNITS_IN_CASE = "UNITS_IN_CASE";
		}
		public class ROLE_MASTER
		{
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string ROLE_ID = "ROLE_ID";
			public static string ROLE_NAME = "ROLE_NAME";
			public static string TIME_STAMP = "TIME_STAMP";
		}
		public class dtproperties
		{
			public static string id = "id";
			public static string lvalue = "lvalue";
			public static string objectid = "objectid";
			public static string property = "property";
			public static string uvalue = "uvalue";
			public static string value = "value";
			public static string version = "version";
		}
		public class SKU_PRICES
		{
			public static string DISTRIBUTOR_PRICE = "DISTRIBUTOR_PRICE";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string RETAIL_PRICE = "RETAIL_PRICE";
			public static string SKU_ID = "SKU_ID";
			public static string SKU_PRICE_ID = "SKU_PRICE_ID";
			public static string TAX_PRICE = "TAX_PRICE";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string TRADE_PRICE = "TRADE_PRICE";
			public static string UOM_ID = "UOM_ID";
		}
		public class SKU_MAPPING
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string MAPPING_CODE = "MAPPING_CODE";
			public static string SKU_ID = "SKU_ID";
			public static string SKU_MAPPING_ID = "SKU_MAPPING_ID";
			public static string TIME_STAMP = "TIME_STAMP";
		}
		public class SKU_HIERARCHY
		{
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string PARENT_SKU_HIE_ID = "PARENT_SKU_HIE_ID";
			public static string SKU_HIE_CODE = "SKU_HIE_CODE";
			public static string SKU_HIE_ID = "SKU_HIE_ID";
			public static string SKU_HIE_NAME = "SKU_HIE_NAME";
			public static string SKU_HIE_TYPE_ID = "SKU_HIE_TYPE_ID";
			public static string TIME_STAMP = "TIME_STAMP";
		}
		public class SKU_GROUP_DETAIL
		{
			public static string SKU_GROUP_DETAIL_ID = "SKU_GROUP_DETAIL_ID";
			public static string SKU_GROUP_ID = "SKU_GROUP_ID";
			public static string SKU_ID = "SKU_ID";
		}
		public class SKU_GROUP
		{
			public static string GROUP_NAME = "GROUP_NAME";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string SKU_GROUP_ID = "SKU_GROUP_ID";
			public static string TIME_STAMP = "TIME_STAMP";
		}
		public class SCHEME
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string SCHEME_CODE = "SCHEME_CODE";
			public static string SCHEME_DATE = "SCHEME_DATE";
			public static string SCHEME_DESC = "SCHEME_DESC";
			public static string SCHEME_ID = "SCHEME_ID";
		}
		public class SALE_ORDER_PROMOTION
		{
			public static string BASKET_DETAIL_ID = "BASKET_DETAIL_ID";
			public static string BASKET_ID = "BASKET_ID";
			public static string CLAIM_AMOUNT = "CLAIM_AMOUNT";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string GST_AMOUNT = "GST_AMOUNT";
			public static string GST_RATE = "GST_RATE";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string PROMOTION_OFFER_ID = "PROMOTION_OFFER_ID";
			public static string QUANTITY = "QUANTITY";
			public static string RETAIL_PRICE = "RETAIL_PRICE";
			public static string SALE_ORDER_DETAIL_ID = "SALE_ORDER_DETAIL_ID";
			public static string SALE_ORDER_PROMOTION_ID = "SALE_ORDER_PROMOTION_ID";
			public static string SCHEME_ID = "SCHEME_ID";
			public static string SKU_ID = "SKU_ID";
			public static string UNIT_PRICE = "UNIT_PRICE";
		}
		public class SALE_ORDER_MASTER
		{
			public static string AREA_ID = "AREA_ID";
			public static string DELIVERYMAN_ID = "DELIVERYMAN_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string DOCUMENT_DATE = "DOCUMENT_DATE";
			public static string EXTRA_DISCOUNT_AMOUNT = "EXTRA_DISCOUNT_AMOUNT";
			public static string GST_AMOUNT = "GST_AMOUNT";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string ORDERBOOKER_ID = "ORDERBOOKER_ID";
			public static string SALE_ORDER_ID = "SALE_ORDER_ID";
			public static string SHIP_TO = "SHIP_TO";
			public static string SHIPMENT_DATE = "SHIPMENT_DATE";
			public static string SOLD_TO = "SOLD_TO";
			public static string STANDARD_DISCOUNT_AMOUNT = "STANDARD_DISCOUNT_AMOUNT";
			public static string STATUS_ID = "STATUS_ID";
			public static string TERRITORY_ID = "TERRITORY_ID";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string TOTAL_AMOUNT = "TOTAL_AMOUNT";
			public static string TOTAL_CLAIM_AMOUNT = "TOTAL_CLAIM_AMOUNT";
			public static string TOTAL_NET_AMOUNT = "TOTAL_NET_AMOUNT";
		}
		public class SKU_STOCK_REGISTER
		{
			public static string CLOSING_STOCK = "CLOSING_STOCK";
			public static string DAMAGED_STOCK = "DAMAGED_STOCK";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string FREE_STOCK = "FREE_STOCK";
			public static string OPENING_STOCK = "OPENING_STOCK";
			public static string PURCHASE_RETURN = "PURCHASE_RETURN";
			public static string PURCHASED = "PURCHASED";
			public static string SALE_RETURN = "SALE_RETURN";
			public static string SALED = "SALED";
			public static string SKU_ID = "SKU_ID";
			public static string STOCK_DATE = "STOCK_DATE";
		}
		public class SALE_ORDER_DETAIL
		{
			public static string AMOUNT = "AMOUNT";
			public static string BATCH_NO = "BATCH_NO";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string EXTRA_DISCOUNT = "EXTRA_DISCOUNT";
			public static string GST_ON = "GST_ON";
			public static string GST_RATE = "GST_RATE";
			public static string IS_DELETED = "IS_DELETED";
			public static string NET_AMOUNT = "NET_AMOUNT";
			public static string QUANTITY_UNIT = "QUANTITY_UNIT";
			public static string RETAIL_PRICE = "RETAIL_PRICE";
			public static string SALE_ORDER_DETAIL_ID = "SALE_ORDER_DETAIL_ID";
			public static string SALE_ORDER_ID = "SALE_ORDER_ID";
			public static string SKU_ID = "SKU_ID";
			public static string STANDARD_DISCOUNT = "STANDARD_DISCOUNT";
			public static string TAX_PRICE = "TAX_PRICE";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string UNIT_PRICE = "UNIT_PRICE";
		}
		public class SALE_INVOICE_PROMOTION
		{
			public static string BASKET_DETAIL_ID = "BASKET_DETAIL_ID";
			public static string BASKET_ID = "BASKET_ID";
			public static string CLAIM_AMOUNT = "CLAIM_AMOUNT";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string GST_AMOUNT = "GST_AMOUNT";
			public static string GST_RATE = "GST_RATE";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string PROMOTION_OFFER_ID = "PROMOTION_OFFER_ID";
			public static string QUANTITY = "QUANTITY";
			public static string RETAIL_PRICE = "RETAIL_PRICE";
			public static string SALE_INVOICE_DETAIL_ID = "SALE_INVOICE_DETAIL_ID";
			public static string SALE_INVOICE_PROMOTION_ID = "SALE_INVOICE_PROMOTION_ID";
			public static string SALE_ORDER_PROMOTION_ID = "SALE_ORDER_PROMOTION_ID";
			public static string SCHEME_ID = "SCHEME_ID";
			public static string UNIT_PRICE = "UNIT_PRICE";
		}
		public class SALE_INVOICE_MASTER
		{
			public static string AREA_ID = "AREA_ID";
			public static string DELIVERYMAN_ID = "DELIVERYMAN_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string DOCUMENT_DATE = "DOCUMENT_DATE";
			public static string EXTRA_DISCOUNT_AMOUNT = "EXTRA_DISCOUNT_AMOUNT";
			public static string GST_AMOUNT = "GST_AMOUNT";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string ORDERBOOKER_ID = "ORDERBOOKER_ID";
			public static string SALE_INVOICE_ID = "SALE_INVOICE_ID";
			public static string SALE_ORDER_ID = "SALE_ORDER_ID";
			public static string SHIP_TO = "SHIP_TO";
			public static string SHIPMENT_DATE = "SHIPMENT_DATE";
			public static string SOLD_TO = "SOLD_TO";
			public static string STANDARD_DISCOUNT_AMOUNT = "STANDARD_DISCOUNT_AMOUNT";
			public static string TERRITORY_ID = "TERRITORY_ID";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string TOTAL_AMOUNT = "TOTAL_AMOUNT";
			public static string TOTAL_CLAIM_AMOUNT = "TOTAL_CLAIM_AMOUNT";
			public static string TOTAL_NET_AMOUNT = "TOTAL_NET_AMOUNT";
		}
		public class SALE_INVOICE_DETAIL
		{
			public static string AMOUNT = "AMOUNT";
			public static string BATCH_NO = "BATCH_NO";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string EXTRA_DISCOUNT = "EXTRA_DISCOUNT";
			public static string GST_ON = "GST_ON";
			public static string GST_RATE = "GST_RATE";
			public static string IS_DELETED = "IS_DELETED";
			public static string NET_AMOUNT = "NET_AMOUNT";
			public static string QUANTITY_UNIT = "QUANTITY_UNIT";
			public static string RETAIL_PRICE = "RETAIL_PRICE";
			public static string SALE_INVOICE_DETAIL_ID = "SALE_INVOICE_DETAIL_ID";
			public static string SALE_INVOICE_ID = "SALE_INVOICE_ID";
			public static string SALE_ORDER_DETAIL_ID = "SALE_ORDER_DETAIL_ID";
			public static string SKU_ID = "SKU_ID";
			public static string STANDARD_DISCOUNT = "STANDARD_DISCOUNT";
			public static string TAX_PRICE = "TAX_PRICE";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string UNIT_PRICE = "UNIT_PRICE";
		}
		public class ROLE_DETAIL
		{
			public static string CAN_ADD = "CAN_ADD";
			public static string CAN_DELETE = "CAN_DELETE";
			public static string CAN_UPDATE = "CAN_UPDATE";
			public static string CAN_VIEW = "CAN_VIEW";
			public static string MODULE_ID = "MODULE_ID";
			public static string ROLE_DETAIL_ID = "ROLE_DETAIL_ID";
			public static string ROLE_ID = "ROLE_ID";
		}
		public class PROMOTION_OFFER
		{
			public static string BASKET_DETAIL_ID = "BASKET_DETAIL_ID";
			public static string BASKET_ID = "BASKET_ID";
			public static string DISCOUNT = "DISCOUNT";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string IS_AND = "IS_AND";
			public static string OFFER_VALUE = "OFFER_VALUE";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string PROMOTION_OFFER_ID = "PROMOTION_OFFER_ID";
			public static string QUANTITY = "QUANTITY";
			public static string SCHEME_ID = "SCHEME_ID";
			public static string SKU_ID = "SKU_ID";
		}
		public class PROMOTION_FOR
		{
			public static string ASSIGNED_DISTRIBUTOR_ID = "ASSIGNED_DISTRIBUTOR_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string PROMOTION_FOR_ID = "PROMOTION_FOR_ID";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string SCHEME_ID = "SCHEME_ID";
		}
		public class BASKET_DETAIL
		{
			public static string BASKET_DETAIL_ID = "BASKET_DETAIL_ID";
			public static string BASKET_ID = "BASKET_ID";
			public static string BRAND_ID = "BRAND_ID";
			public static string CATEGORY_ID = "CATEGORY_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string DIVISION_ID = "DIVISION_ID";
			public static string MAX_VAL = "MAX_VAL";
			public static string MIN_VAL = "MIN_VAL";
			public static string MULTIPLE_OF = "MULTIPLE_OF";
			public static string PRODUCTLINE_ID = "PRODUCTLINE_ID";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string SCHEME_ID = "SCHEME_ID";
			public static string SKU_GROUP_ID = "SKU_GROUP_ID";
			public static string SKU_ID = "SKU_ID";
		}
		public class DAILY_CLOSE
		{
			public static string CLOSING_DATE = "CLOSING_DATE";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string OPENING_CASH = "OPENING_CASH";
		}
		public class PROMOTION
		{
			public static string CLAIMABLE = "CLAIMABLE";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string END_DATE = "END_DATE";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string PROMO_DATE = "PROMO_DATE";
			public static string PROMOTION_CODE = "PROMOTION_CODE";
			public static string PROMOTION_DESCRIPTION = "PROMOTION_DESCRIPTION";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string PROMOTION_TYPE = "PROMOTION_TYPE";
			public static string SCHEME_ID = "SCHEME_ID";
			public static string START_DATE = "START_DATE";
		}
		public class PROMOTION_FOR_CUSTOMER
		{
			public static string CUSTOMER_ID = "CUSTOMER_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string PROMOTION_FOR_ID = "PROMOTION_FOR_ID";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string SCHEME_ID = "SCHEME_ID";
		}
		public class MODULES
		{
			public static string MODULE_ID = "MODULE_ID";
			public static string MODULE_NAME = "MODULE_NAME";
			public static string MODULE_TYPE_ID = "MODULE_TYPE_ID";
		}
		public class LEDGER
		{
			public static string ACCOUNT_HEAD_ID = "ACCOUNT_HEAD_ID";
			public static string CREDIT = "CREDIT";
			public static string DEBIT = "DEBIT";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string LEDGER_DATE = "LEDGER_DATE";
			public static string LEDGER_ID = "LEDGER_ID";
			public static string PAYMENT_MODE_ID = "PAYMENT_MODE_ID";
			public static string REMARKS = "REMARKS";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string TRANSACTION_TYPE_ID = "TRANSACTION_TYPE_ID";
		}
		public class INCENTIVES_SKU
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string INCENTIVE_DETAIL_ID = "INCENTIVE_DETAIL_ID";
			public static string INCENTIVE_FOR_ID = "INCENTIVE_FOR_ID";
			public static string INCENTIVE_ID = "INCENTIVE_ID";
			public static string INCENTIVE_MASTER_ID = "INCENTIVE_MASTER_ID";
			public static string INCENTIVE_SKU_ID = "INCENTIVE_SKU_ID";
			public static string SKU_ID = "SKU_ID";
			public static string TARGET_QTY = "TARGET_QTY";
		}
		public class INCENTIVE_OFFER
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string INCENTIVE_DETAIL_ID = "INCENTIVE_DETAIL_ID";
			public static string INCENTIVE_FOR_ID = "INCENTIVE_FOR_ID";
			public static string INCENTIVE_ID = "INCENTIVE_ID";
			public static string INCENTIVE_MASTER_ID = "INCENTIVE_MASTER_ID";
			public static string INCENTIVE_OFFER_ID = "INCENTIVE_OFFER_ID";
			public static string INCENTIVE_VALUE = "INCENTIVE_VALUE";
			public static string TARGET_SLAB = "TARGET_SLAB";
		}
		public class DISTRIBUTOR_USER
		{
			public static string ADDRESS1 = "ADDRESS1";
			public static string ADDRESS2 = "ADDRESS2";
			public static string C_USER_ID = "C_USER_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string DIVISION_ID = "DIVISION_ID";
			public static string EMAIL_ADDRESS = "EMAIL_ADDRESS";
			public static string FAX = "FAX";
			public static string HOME_TOWN_ID = "HOME_TOWN_ID";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string IS_DELETED = "IS_DELETED";
			public static string IS_DISTRIBUTOR_LOGIN = "IS_DISTRIBUTOR_LOGIN";
			public static string IS_PPC_LOGIN = "IS_PPC_LOGIN";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string LOGIN_ID = "LOGIN_ID";
			public static string MOBILE = "MOBILE";
			public static string PASSWORD = "PASSWORD";
			public static string PHONE = "PHONE";
			public static string REGION_ID = "REGION_ID";
			public static string ROLE_ID = "ROLE_ID";
			public static string SUBZONE_ID = "SUBZONE_ID";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string USER_CODE = "USER_CODE";
			public static string USER_ID = "USER_ID";
			public static string USER_NAME = "USER_NAME";
			public static string USER_TYPE_ID = "USER_TYPE_ID";
			public static string ZONE_ID = "ZONE_ID";
		}
		public class INCENTIVE_MASTER
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string INCENTIVE_FOR_ID = "INCENTIVE_FOR_ID";
			public static string INCENTIVE_ID = "INCENTIVE_ID";
			public static string INCENTIVE_MASTER_ID = "INCENTIVE_MASTER_ID";
			public static string INCENTIVE_TYPE_ID = "INCENTIVE_TYPE_ID";
		}
		public class INCENTIVE_FOR
		{
			public static string ASSIGNED_DISTRIBUTOR_ID = "ASSIGNED_DISTRIBUTOR_ID";
			public static string ASSIGNED_USER_ID = "ASSIGNED_USER_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string INCENTIVE_FOR_ID = "INCENTIVE_FOR_ID";
			public static string INCENTIVE_ID = "INCENTIVE_ID";
			public static string INCENTIVE_MASTER_ID = "INCENTIVE_MASTER_ID";
		}
		public class PROMOTION_CUSTOMER_TYPE
		{
			public static string CUSTOMER_TYPE_ID = "CUSTOMER_TYPE_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string PROMOTION_CUSTOMER_TYPE_ID = "PROMOTION_CUSTOMER_TYPE_ID";
			public static string PROMOTION_ID = "PROMOTION_ID";
			public static string SCHEME_ID = "SCHEME_ID";
		}
		public class INCENTIVE_DETAIL
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string INCENTIVE_DETAIL_ID = "INCENTIVE_DETAIL_ID";
			public static string INCENTIVE_FOR_ID = "INCENTIVE_FOR_ID";
			public static string INCENTIVE_ID = "INCENTIVE_ID";
			public static string INCENTIVE_MASTER_ID = "INCENTIVE_MASTER_ID";
			public static string TARGET_SHOPS = "TARGET_SHOPS";
			public static string TARGET_VALUE = "TARGET_VALUE";
		}
		public class INCENTIVE
		{
			public static string CLAIMABLE = "CLAIMABLE";
			public static string CUSTOMER_TYPE_ID = "CUSTOMER_TYPE_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string END_DATE = "END_DATE";
			public static string INCENTIVE_CODE = "INCENTIVE_CODE";
			public static string INCENTIVE_DATE = "INCENTIVE_DATE";
			public static string INCENTIVE_DESCRIPTION = "INCENTIVE_DESCRIPTION";
			public static string INCENTIVE_FREQUENCY_ID = "INCENTIVE_FREQUENCY_ID";
			public static string INCENTIVE_ID = "INCENTIVE_ID";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string START_DATE = "START_DATE";
		}
		public class SKU_STOCK
		{
			public static string BATCH_NO = "BATCH_NO";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string EXPIRY_DATE = "EXPIRY_DATE";
			public static string SKU_ID = "SKU_ID";
			public static string UNITS_IN_STOCK = "UNITS_IN_STOCK";
		}
		public class ACCOUNT_HEAD
		{
			public static string ACCOUNT_HEAD_ID = "ACCOUNT_HEAD_ID";
			public static string ACCOUNT_NAME = "ACCOUNT_NAME";
			public static string ACCOUNT_TYPE_ID = "ACCOUNT_TYPE_ID";
			public static string BALANCE = "BALANCE";
			public static string CUSTOMER_ID = "CUSTOMER_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string TIME_STAMP = "TIME_STAMP";
		}
		public class DISTRIBUTOR_USER_TERRITORY
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string TERRITORY_ID = "TERRITORY_ID";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string USER_ID = "USER_ID";
		}
		public class DISTRIBUTOR_TOWN
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string TOWN_ID = "TOWN_ID";
			public static string USER_ID = "USER_ID";
		}
		public class DISTRIBUTOR_TERRITORY
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string TERRITORY_ID = "TERRITORY_ID";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string USER_ID = "USER_ID";
		}
		public class DISTRIBUTOR_SKU
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string MIN_STOCK_LEVEL = "MIN_STOCK_LEVEL";
			public static string SKU_ID = "SKU_ID";
		}
		public class DISTRIBUTOR_SETTINGS
		{
			public static string CAN_ADD_NEW_TO = "CAN_ADD_NEW_TO";
			public static string CAN_DISABLE_SERVER_TO = "CAN_DISABLE_SERVER_TO";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string DISTRIBUTOR_SETTINGS_ID = "DISTRIBUTOR_SETTINGS_ID";
			public static string ISGST_PAID_BY_DIST = "ISGST_PAID_BY_DIST";
			public static string ISRP_UPDATE = "ISRP_UPDATE";
			public static string ISTAXPRICE_UPDATE = "ISTAXPRICE_UPDATE";
			public static string ISTP_UPDATE = "ISTP_UPDATE";
			public static string TRANSFER_TIME = "TRANSFER_TIME";
		}
		public class DISTRIBUTOR_AREA
		{
			public static string AREA_CODE = "AREA_CODE";
			public static string AREA_ID = "AREA_ID";
			public static string AREA_NAME = "AREA_NAME";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string TERRITORY_ID = "TERRITORY_ID";
			public static string TIME_STAMP = "TIME_STAMP";
		}
		public class DISTRIBUTOR
		{
			public static string ADDRESS1 = "ADDRESS1";
			public static string ADDRESS2 = "ADDRESS2";
			public static string CONTACT_NUMBER = "CONTACT_NUMBER";
			public static string CONTACT_PERSON = "CONTACT_PERSON";
			public static string DIST_CLASS_ID = "DIST_CLASS_ID";
			public static string DISTRIBUTOR_CODE = "DISTRIBUTOR_CODE";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string DISTRIBUTOR_NAME = "DISTRIBUTOR_NAME";
			public static string DIVISION_ID = "DIVISION_ID";
			public static string GST_NUMBER = "GST_NUMBER";
			public static string IP_ADDRESS = "IP_ADDRESS";
			public static string ISDELETED = "ISDELETED";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string PASSWORD = "PASSWORD";
			public static string REGION_ID = "REGION_ID";
			public static string SUBZONE_ID = "SUBZONE_ID";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string USER_ID = "USER_ID";
			public static string ZONE_ID = "ZONE_ID";
		}
		public class CUSTOMER_PROXIMITY
		{
			public static string CUSTOMER_ID = "CUSTOMER_ID";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string PROXIMITY_ID = "PROXIMITY_ID";
			public static string SEQUENCE_NUMBER = "SEQUENCE_NUMBER";
		}
		public class SYNC_LOG_DETAIL
		{
			public static string PARAMETERS = "PARAMETERS";
			public static string SP_NAME = "SP_NAME";
			public static string SYNC_LOG_DETAIL_ID = "SYNC_LOG_DETAIL_ID";
			public static string SYNC_LOG_ID = "SYNC_LOG_ID";
		}
		public class CUSTOMER
		{
			public static string ADDRESS = "ADDRESS";
			public static string AREA_ID = "AREA_ID";
			public static string BALANCE = "BALANCE";
			public static string BUSINESS_TYPE_ID = "BUSINESS_TYPE_ID";
			public static string CHANNEL_TYPE_ID = "CHANNEL_TYPE_ID";
			public static string CONTACT_NUMBER = "CONTACT_NUMBER";
			public static string CONTACT_PERSON = "CONTACT_PERSON";
			public static string CREDIT_LIMIT = "CREDIT_LIMIT";
			public static string CUSTOMER_CODE = "CUSTOMER_CODE";
			public static string CUSTOMER_ID = "CUSTOMER_ID";
			public static string CUSTOMER_NAME = "CUSTOMER_NAME";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string EMAIL_ADDRESS = "EMAIL_ADDRESS";
			public static string GST_NUMBER = "GST_NUMBER";
			public static string IS_ACTIVE = "IS_ACTIVE";
			public static string IS_DELETED = "IS_DELETED";
			public static string IS_GST_REGISTERED = "IS_GST_REGISTERED";
			public static string LASTUPDATE_DATE = "LASTUPDATE_DATE";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string TOWN_ID = "TOWN_ID";
			public static string USER_ID = "USER_ID";
			public static string VOLUME_CLASS_ID = "VOLUME_CLASS_ID";
		}
		public class COMPANY
		{
			public static string ADDRESS1 = "ADDRESS1";
			public static string ADDRESS2 = "ADDRESS2";
			public static string COMPANY_ID = "COMPANY_ID";
			public static string COMPANY_NAME = "COMPANY_NAME";
			public static string EMAIL_ADDRESS = "EMAIL_ADDRESS";
			public static string FAX = "FAX";
			public static string ISCURRENT = "ISCURRENT";
			public static string ISDELETED = "ISDELETED";
			public static string PHONE = "PHONE";
			public static string STATUS = "STATUS";
			public static string WEBSITE = "WEBSITE";
		}
		public class CLAIM_MASTER
		{
			public static string CLAIM_AMOUNT = "CLAIM_AMOUNT";
			public static string CLAIM_ID = "CLAIM_ID";
			public static string CLAIM_STATUS_ID = "CLAIM_STATUS_ID";
			public static string CLAIM_TYPE_ID = "CLAIM_TYPE_ID";
			public static string DATE_FROM = "DATE_FROM";
			public static string DATE_TO = "DATE_TO";
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string REMARKS = "REMARKS";
		}
		public class WAREHOUSES
		{
			public static string DISTRIBUTOR_ID = "DISTRIBUTOR_ID";
			public static string ISDELETED = "ISDELETED";
			public static string TIME_STAMP = "TIME_STAMP";
			public static string USER_ID = "USER_ID";
			public static string WAREHOUSE_CODE = "WAREHOUSE_CODE";
			public static string WAREHOUSE_ID = "WAREHOUSE_ID";
			public static string WAREHOUSE_NAME = "WAREHOUSE_NAME";
		}
	}
}
