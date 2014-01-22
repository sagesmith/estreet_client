<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="estreet_client._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .results { font-size: 1.3em; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        URI<asp:RadioButtonList ID="rblURIs" runat="server">
            <asp:ListItem Selected="True" Value="https://electionstreet.com">https://electionstreet.com (cloud)</asp:ListItem>
            <asp:ListItem Value="http://estreet.boe.nyc.ny.us">http://estreet.boe.nyc.ny.us (behind BoE firewall)</asp:ListItem>
            <asp:ListItem Value="http://future.boe.nyc.ny.us">http://future.boe.nyc.ny.us (behind BoE firewall)</asp:ListItem>
            <asp:ListItem Value="http://city.boe.nyc.ny.us">http://city.boe.nyc.ny.us (behind BoE firewall)</asp:ListItem>
            <asp:ListItem Value="http://state.boe.nyc.ny.us">http://state.boe.nyc.ny.us (behind BoE firewall)</asp:ListItem>
            <asp:ListItem Value="http://congress.boe.nyc.ny.us">http://congress.boe.nyc.ny.us (behind BoE firewall)</asp:ListItem>
            <asp:ListItem Value="http://lastdecade.boe.nyc.ny.us">http://lastdecade.boe.nyc.ny.us (behind BoE firewall)</asp:ListItem>
        </asp:RadioButtonList>
        Referer<br />
        <asp:TextBox ID="txtReferer" runat="server"></asp:TextBox>
        <br />
        County<br />
        <asp:DropDownList ID="ddlCounty" runat="server">
            <asp:ListItem Selected="True">New York</asp:ListItem>
            <asp:ListItem>Bronx</asp:ListItem>
            <asp:ListItem>Kings</asp:ListItem>
            <asp:ListItem>Queens</asp:ListItem>
            <asp:ListItem>Richmond</asp:ListItem>
        </asp:DropDownList>
        <br />
        Street Number<br />
        <asp:TextBox ID="txtStreetNumber" runat="server"></asp:TextBox>
        <br />
        Street<br />
        <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lookup" />
        <br />
        <br />
        <br />
        <asp:Panel ID="pnlResults" runat="server" CssClass="results">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
