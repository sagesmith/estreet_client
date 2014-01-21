using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace estreet_client
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            pnlResults.Controls.Clear();

            var client = new RestClient(rblURIs.SelectedValue);
            var request = new RestRequest("api/nyc/addresses", Method.GET);

            request.AddHeader("referer", txtReferer.Text);
            
            request.AddParameter("county", ddlCounty.SelectedValue);
            request.AddParameter("streetnumber", txtStreetNumber.Text);
            request.AddParameter("streetname", txtStreet.Text);

            RestResponse<estreet> response = (RestResponse<estreet>)client.Execute<estreet>(request);
            
            if(response.Data==null)
            {
                Label error = new Label();
                error.Text = "There is an error with the estreet call.  Double check the Referer value. [Error: " + response.StatusDescription + "]";
                pnlResults.Controls.Add(error);
                return;

            }

            TreeView tvResults = new TreeView();
            
            TreeNode ss = new TreeNode("search status");
            ss.ChildNodes.Add(new TreeNode("contains warning: " + response.Data.searchStatus.containsWarning.ToString()));
            ss.ChildNodes.Add(new TreeNode("error: " + response.Data.searchStatus.error));
            ss.ChildNodes.Add(new TreeNode("return code: " + response.Data.searchStatus.returnCode));
            if (response.Data.searchStatus.streetSuggestions != null)
            {
                TreeNode s = new TreeNode("street suggestions");
                foreach (string ssug in response.Data.searchStatus.streetSuggestions)
                    s.ChildNodes.Add(new TreeNode(ssug));
                ss.ChildNodes.Add(s);
            }
            ss.ChildNodes.Add(new TreeNode("valid address: " + response.Data.searchStatus.validAddress.ToString()));
            ss.ChildNodes.Add(new TreeNode("warning: " + response.Data.searchStatus.warning));
            tvResults.Nodes.Add(ss);
            
            if(response.Data.standardizedAddress!=null)
            { 
                TreeNode sa = new TreeNode("standardized address");
                sa.ChildNodes.Add(new TreeNode("BoE preferred sort street name: " + response.Data.standardizedAddress.BoEPreferredSortStreetName));
                sa.ChildNodes.Add(new TreeNode("BoE preferred street name: " + response.Data.standardizedAddress.BoEPreferredStreetName));
                sa.ChildNodes.Add(new TreeNode("city: " + response.Data.standardizedAddress.city));
                sa.ChildNodes.Add(new TreeNode("postal code: " + response.Data.standardizedAddress.postalCode));
                sa.ChildNodes.Add(new TreeNode("state: " + response.Data.standardizedAddress.stateProvTerr));
                sa.ChildNodes.Add(new TreeNode("street name: " + response.Data.standardizedAddress.streetName));
                sa.ChildNodes.Add(new TreeNode("street number: " + response.Data.standardizedAddress.streetNumber));
                tvResults.Nodes.Add(sa);
            }

            if(response.Data.politicalLayer!=null)
            { 
                TreeNode pl = new TreeNode("political layer");
                pl.ChildNodes.Add(new TreeNode("assembly district: " + response.Data.politicalLayer.assemblyDistrict));
                pl.ChildNodes.Add(new TreeNode("city council district: " + response.Data.politicalLayer.cityCouncilDistrict));
                pl.ChildNodes.Add(new TreeNode("election district: " + response.Data.politicalLayer.electionDistrict));
                pl.ChildNodes.Add(new TreeNode("is split ed: " + response.Data.politicalLayer.isSplitED.ToString()));
                pl.ChildNodes.Add(new TreeNode("municiple court district: " + response.Data.politicalLayer.municipalCourtDistrict));
                pl.ChildNodes.Add(new TreeNode("state senate district: " + response.Data.politicalLayer.stateSenateDistrict));
                tvResults.Nodes.Add(pl);
            }

            tvResults.ExpandAll();
            pnlResults.Controls.Add(tvResults);

        }
    }
    public class estreet
    {
        public searchStatus searchStatus { get; set; }
        public standardizedAddress standardizedAddress { get; set; }
        public politicalLayer politicalLayer { get; set; }
    }
    public class searchStatus
    {
        public bool containsWarning { get; set; }
        public string error { get; set; }
        public string returnCode { get; set; }
        public List<string> streetSuggestions { get; set; }
        public bool validAddress { get; set; }
        public string warning { get; set; }
    }
    public class standardizedAddress
    {
        public string BoEPreferredSortStreetName { get; set; }
        public string BoEPreferredStreetName { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string stateProvTerr { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
    }
    public class politicalLayer
    {
        public string assemblyDistrict { get; set; }
        public string cityCouncilDistrict { get; set; }
        public string congressionalDistrict { get; set; }
        public string electionDistrict { get; set; }
        public bool isSplitED { get; set; }
        public string municipalCourtDistrict { get; set; }
        public string stateSenateDistrict { get; set; }
    }
}