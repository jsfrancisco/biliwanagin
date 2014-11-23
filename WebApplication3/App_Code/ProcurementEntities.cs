using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace WebApplication3.App_Code
namespace Biliwanagin
{
    public class ProcurementEntities
    {
    }

    public class Agency
    {
        public string AgencyName { get; set; }
        public int AgencyId { get; set; }
    }

    public class Location
    {
        public string LocationName { get; set; }
        public int LocationId { get; set; }
    }

    public class BidInformation
    {
        public int ref_no { get; set; }
        public double budget { get; set; } 
        public bool is_amp { get; set; } 
        public bool is_reAward { get; set; }
        public string item_description { get; set; } 
        public string item_name { get; set; }
        public int previous_award_id { get; set; }
        public double approved_budget { get; set; }
        public string tender_title { get; set; }
        public string business_category { get; set; }
        public string classification { get; set; }
        public string client_agency_org { get; set; }
        public int client_agency_orgid { get; set; }
        public int org_id { get; set; }
        public string procurement_mode { get; set; }
        public string procuring_entity_org { get; set; }
        public int procuring_entity_org_id { get; set; }
        public string funding_source { get; set; }
        public string tender_status { get; set; }
        public string stage { get; set; }
        public DateTime? publish_date { get; set; }
        public string solicitation_no { get; set; }
        public DateTime? closing_date { get; set; }
        public int contract_duration { get; set; }
        public string description { get; set; }
        public DateTime? pre_bid_date { get; set; }
        public string pre_bid_venue { get; set; }
        public string reason { get; set; }
        public string contact_person { get; set; }
        public string contact_person_address { get; set; }
        public int ref_id { get; set; }
    }

    public class Bidder
    {
        public string bidder_name { get; set; }
        public int org_id { get; set; }
    }

    public class Award
    {
        public bool is_short_list { get; set; }
        public string award_reason { get; set; }
        public double contract_amt { get; set; }
        public string awardee { get; set; }
        public int awardee_id { get; set; }
        public DateTime? award_date { get; set; }
        public int award_id { get; set; }
        public string award_title { get; set; }
        public string award_type { get; set; }
        public DateTime? contract_end_date { get; set; }
        public int contract_no { get; set; }
        public DateTime? contract_start_date { get; set; }
        public DateTime? proceed_date { get; set; }
        public DateTime? publish_date { get; set; }
        public bool is_amp { get; set; }
        public bool is_reAward { get; set; }
        public int previous_award_id { get; set; }
    }

    public class Organization
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string government_branch { get; set; }
        public string government_organization_type { get; set; }
        public bool is_org_foreign { get; set; }
        public string member_type { get; set; }
        public int org_id { get; set; }
        public string org_name { get; set; }
        public DateTime? org_reg_date { get; set; }
        public string org_status { get; set; }
        public int parent_org_id { get; set; }
        public string province { get; set; }
        public string region { get; set; }
        public string supplier_form_of_organization { get; set; }
        public string supplier_organization_type { get; set; }
        public string wbsite { get; set; }
        public string zip_code { get; set; }
    }

    public class Project
    {
        public int ref_no { get; set; }
        public double budget { get; set; }
        public bool is_amp { get; set; }
        public bool is_reAward { get; set; }
        public string item_description { get; set; }
        public string item_name { get; set; }
        public int previous_award_id { get; set; }
        public double approved_budget { get; set; }
        public string tender_title { get; set; }
        public string business_category { get; set; }
        public string classification { get; set; }
        public string client_agency_org { get; set; }
        public int client_agency_orgid { get; set; }
        public int org_id { get; set; }
        public string procurement_mode { get; set; }
        public string procuring_entity_org { get; set; }
        public int procuring_entity_org_id { get; set; }
        public string funding_source { get; set; }
        public string tender_status { get; set; }
        public string stage { get; set; }
        public DateTime? publish_date { get; set; }
        public string solicitation_no { get; set; }
        public DateTime? closing_date { get; set; }
        public int contract_duration { get; set; }
        public string description { get; set; }
        public DateTime? pre_bid_date { get; set; }
        public string pre_bid_venue { get; set; }
        public string reason { get; set; }
        public string contact_person { get; set; }
        public string contact_person_address { get; set; }
        public int ref_id { get; set; }

        public string LocationName { get; set; }
        public int LocationId { get; set; }

        public bool is_short_list { get; set; }
        public string award_reason { get; set; }
        public double contract_amt { get; set; }
        public string awardee { get; set; }
        public int awardee_id { get; set; }
        public DateTime? award_date { get; set; }
        public int award_id { get; set; }
        public string award_title { get; set; }
        public string award_type { get; set; }
        public DateTime? contract_end_date { get; set; }
        public int contract_no { get; set; }
        public DateTime? contract_start_date { get; set; }
        public DateTime? proceed_date { get; set; }
        //public DateTime? publish_date { get; set; }
        //public bool is_amp { get; set; }
        //public bool is_reAward { get; set; }
        //public int previous_award_id { get; set; }
    }

    //public class StageTrigger
    //{
    //    public int ref_no { get; set; }
    //    public DateTime? publish_date { get; set; }
    //    public bool is_short_list { get; set; }
    //}
}