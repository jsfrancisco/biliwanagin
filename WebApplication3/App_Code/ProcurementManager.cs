using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

//using Biliwanagin.Entities;

//namespace WebApplication3.App_Code
namespace Biliwanagin
{
    public class ProcurementManager
    {
        public ProcurementManager()
        {
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString_Local"].ConnectionString;
        }

        /*For Dropdowns*/

        public static List<Agency> GetAllAgencies()
        {
            List<Agency> agencies = new List<Agency>();
            string query = @"select org_id, org_name
                                from dbo.Organizations
                                where member_type='Buyer'
                                order by org_name asc";

            SqlDataReader dr = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, query);

            while (dr.Read())
            {
                Agency agency = new Agency();
                agency.AgencyId = Convert.ToInt32(dr["org_id"].ToString());
                agency.AgencyName = dr["org_name"].ToString();

                agencies.Add(agency);
            }

            return agencies;
        }

        public static List<Location> GetAllProjectLocations()
        {
            List<Location> projectLocations = new List<Location>();
            string query = @"select distinct location
                                from dbo.ProjectLocations
                                order by location asc";

            SqlDataReader dr = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, query);

            while (dr.Read())
            {
                Location projectLocation = new Location();
                //projectLocation.LocationId = Convert.ToInt32(dr["or_id"].ToString());
                projectLocation.LocationName = dr["location"].ToString();

                projectLocations.Add(projectLocation);
            }

            return projectLocations;
        }

        public int GetCurrentProjectStage(int ref_id)
        {
            int currentStage = 0;

            //if-else from highest to lowest stage
            if (GetIsShortList(ref_id))
            {
                currentStage = 3;
            }
            else if (GetPublishDate(ref_id) != null)
            {
                currentStage = 1;
            }

            return currentStage;
        }

        //public int GetRefNo(int ref_id)
        //{
        //    int refNo = 0;

        //    return refNo;
        //}

        public DateTime? GetPublishDate(int ref_id)
        {
            DateTime? publishDate = null;
            string query = string.Format(@"select publish_date
                                                    from dbo.Bids
                                                    Where ref_no={0}", ref_id);

            SqlDataReader dr = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, query);

            if (dr.Read())
            {
                publishDate = ConvertToNullableDate(dr["publish_date"].ToString());
            }

            return publishDate;
        }

        public bool GetIsShortList(int ref_id)
        {
            bool isShortList = false;
            string query = string.Format(@"select is_short_list
                                                    from dbo.Awards
                                                    Where ref_id={0}", ref_id);

            SqlDataReader dr = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, query);

            if (dr.Read())
            {
                isShortList = Convert.ToBoolean(dr["is_short_list"].ToString());
            }

            return isShortList;
        }

        /*For Procurement Stages*/

        public BidInformation GetBidInfo(int ref_id)
        {
            BidInformation bidInfo = new BidInformation();
//            string query = string.Format(@"select ref_no 
//                                            ,budget 
//                                            ,is_amp 
//                                            ,is_reAward 
//                                            ,item_description 
//                                            ,item_name 
//                                            ,previous_award_ id 
//                                            ,approved_budget 
//                                            ,tender_title
//                                            ,business_category 
//                                            ,classification 
//                                            ,client_agency_org 
//                                            ,client_agency_orgid 
//                                            ,org_id 
//                                            ,procurement_mode 
//                                            ,procuring_entity_org 
//                                            ,procuring_entity_org_id 
//                                            ,ref_id
//                                            ,funding_source
//                                            ,tender_status
//                                            ,stage 
//                                    from bid_information
//                                    where ref_id={0}", ref_id);

            string query = string.Format(@"select ref_no,
                                            tender_title,
                                            approved_budget,
                                            procurement_mode,
                                            classification,
                                            business_category,
                                            procuring_entity_org,
                                            client_agency_org,
                                            location,
                                            tender_status,
                                            stage
                                    from dbo.Bids b
                                    inner join dbo.ProjectLocations p
                                    on b.ref_no = p.refid
                                    where ref_id={0}", ref_id);

            SqlDataReader dr = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, query);

            while (dr.Read())
            {
                bidInfo.approved_budget = Convert.ToDouble(dr["approved_budget"].ToString());
                bidInfo.budget = Convert.ToDouble(dr["budget"].ToString());
                bidInfo.business_category = dr["business_category"].ToString();
                bidInfo.classification = dr["classification"].ToString();
                bidInfo.client_agency_org = dr["client_agency_org"].ToString();
                bidInfo.client_agency_orgid = Convert.ToInt32(dr["client_agency_orgid"].ToString());
                //bidInfo.closing_date = ConvertToNullableDate(dr["closing_date"].ToString());
                //bidInfo.contact_person = dr["contact_person"].ToString();
                //bidInfo.contact_person_address = dr["contact_person_address"].ToString();
                //bidInfo.contract_duration = Convert.ToInt32(dr["contract_duration"].ToString());
                //bidInfo.description = dr["description"].ToString();
                bidInfo.funding_source = dr["funding_source"].ToString();
                bidInfo.is_amp = Convert.ToBoolean(dr["is_amp"].ToString());
                bidInfo.is_reAward = Convert.ToBoolean(dr["is_reAward"].ToString());
                bidInfo.item_description = dr["item_description"].ToString();
                bidInfo.item_name = dr["item_name"].ToString();
                bidInfo.org_id = Convert.ToInt32(dr["org_id"].ToString());
                //bidInfo.pre_bid_date = ConvertToNullableDate(dr["pre_bid_date"].ToString());
                //bidInfo.pre_bid_venue = dr["pre_bid_venue"].ToString();
                bidInfo.previous_award_id = Convert.ToInt32(dr["previous_award_id"].ToString());
                bidInfo.procurement_mode = dr["procurement_mode"].ToString();
                bidInfo.procuring_entity_org = dr["procuring_entity_org"].ToString();
                bidInfo.procuring_entity_org_id = Convert.ToInt32(dr["procuring_entity_org_id"].ToString());
                //bidInfo.publish_date = ConvertToNullableDate(dr["publish_date"].ToString());
                //bidInfo.reason = dr["reason"].ToString();
                bidInfo.ref_id = Convert.ToInt32(dr["ref_id"].ToString());
                //bidInfo.ref_no = Convert.ToInt32(dr["ref_no"].ToString());
                //bidInfo.solicitation_no = dr["solicitation_no"].ToString();
                bidInfo.stage = dr["stage"].ToString();
                bidInfo.tender_status = dr["tender_status"].ToString();
                bidInfo.tender_title = dr["tender_title"].ToString();
            }

            return bidInfo;
        }

        public BidInformation GetAdvertisement(string ref_id)
        {
            BidInformation bidInfo = new BidInformation();
            string query = string.Format(@"select publish_date 
                                            ,solicitation_no 
                                            ,closing_date 
                                            ,contract_duration 
                                            ,description 
                                            ,pre_bid_date 
                                            ,pre_bid_venue 
                                            ,reason 
                                            ,contact_person 
                                            ,contact_person_address 
                                    where ref_id={0}", ref_id);

            SqlDataReader dr = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, query);

            while (dr.Read())
            {
                bidInfo.closing_date = ConvertToNullableDate(dr["closing_date"].ToString());
                bidInfo.contact_person = dr["contact_person"].ToString();
                bidInfo.contact_person_address = dr["contact_person_address"].ToString();
                bidInfo.contract_duration = Convert.ToInt32(dr["contract_duration"].ToString());
                bidInfo.description = dr["description"].ToString();
                bidInfo.pre_bid_date = ConvertToNullableDate(dr["pre_bid_date"].ToString());
                bidInfo.pre_bid_venue = dr["pre_bid_venue"].ToString();
                bidInfo.publish_date = ConvertToNullableDate(dr["publish_date"].ToString());
                bidInfo.reason = dr["reason"].ToString();
                bidInfo.ref_no = Convert.ToInt32(dr["ref_no"].ToString());
                bidInfo.solicitation_no = dr["solicitation_no"].ToString();
            }

            return bidInfo;
        }

        /*For Gridviews*/

        public static List<Project> GetExistingProjects(string filter)
        {
            List<Project> projects = new List<Project>();

            string query = @"select ref_no,
                                    tender_title,
                                    procuring_entity_org,
                                    location,
                                    approved_budget,
                                    procurement_mode,
                                    tender_status,
                                    awardee,
                                    contract_amt
                                from dbo.Bids b
                                left join dbo.ProjectLocations p
                                    on b.ref_no = p.refid
                                left join dbo.Awards a
                                    on b.ref_no = a.ref_id
                                where ref_no is not null";
            
            string orderby = "order by ref_no asc";

            if (!string.IsNullOrEmpty(filter))
            {
                query = String.Format("{0} and {1} {2}", query, filter, orderby);
            }
            else
            {
                query = String.Format("{0} {1}", query, orderby);
            }

            SqlDataReader dr = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, query);

            while (dr.Read())
            {
                Project project = new Project();
                project.ref_no = Convert.ToInt32(dr["ref_no"].ToString());
                project.tender_title = dr["tender_title"].ToString();
                project.procuring_entity_org = dr["procuring_entity_org"].ToString();
                project.LocationName = dr["location"].ToString();
                project.approved_budget = Convert.ToDouble(dr["approved_budget"].ToString());
                project.procurement_mode = dr["procurement_mode"].ToString();
                project.tender_status = dr["tender_status"].ToString();
                project.contract_amt = ConvertStringToDouble(dr["contract_amt"].ToString());

                projects.Add(project);
            }

            return projects;
        }

        /*Utilities*/

        public static Double ConvertStringToDouble(string stringToConvert)
        {
            Double convertedString;
            if (Double.TryParse(stringToConvert, out convertedString))
                return convertedString;
            else
                return 0;
        }

        public int ConverStringToInt(string stringToConvert)
        {
            int convertedString;
            if (Int32.TryParse(stringToConvert, out convertedString))
                return convertedString;
            else
                return 0;
        }

        public static DateTime? ConvertToNullableDate(string dateString)
        {
            DateTime? nullableDate;
            DateTime result;
            if (DateTime.TryParse(dateString, out result))
                nullableDate = result;
            else
                nullableDate = null;

            return nullableDate;
        }
    }
}