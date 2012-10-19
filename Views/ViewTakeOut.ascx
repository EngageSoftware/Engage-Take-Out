<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ViewTakeOut.ascx.cs" Inherits="Engage.Dnn.TakeOut.ViewTakeOut" EnableViewState="false" %>
<%@ Import Namespace="Globals=DotNetNuke.Common.Globals" %>
<p class="dnnFormMessage dnnFormInfo"><%:LocalizeString("Intro") %></p>

<asp:Repeater ID="SettingsRepeater" runat="server" DataSource="<%#Model.PortalSettings.OrderBy(ps => ps.SettingName) %>">
    <HeaderTemplate><ul class="take-out-settings"></HeaderTemplate>
    <ItemTemplate>
        <li>
            <label>
                <input type="checkbox" name="<%=this.FormNamePrefix %><%#Globals.CreateValidID((string)Eval("SettingName")) %>" <%#(bool)Eval("Selected") ? "checked" : "" %> />
                <%#HttpUtility.HtmlEncode(LocalizeOrNot((string)Eval("SettingName"))) %>
            </label>
        </li>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>

<asp:Button runat="server" ResourceKey="Place Order" ToolTip='<%#LocalizeString("Place Order.ToolTip") %>' OnClick="PlaceOrderButton_Click" />

<script runat="server">
    private string LocalizeOrNot(string key)
    {
        var localizedText = this.LocalizeString(key);
        return string.IsNullOrEmpty(localizedText) ? key : localizedText;
    }
</script>