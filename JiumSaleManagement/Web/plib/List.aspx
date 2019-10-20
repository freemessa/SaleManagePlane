﻿<%@ Page Title="plib" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Jium.Web.plib.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="id,pcode" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pcode" HeaderText="pcode" SortExpression="pcode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pname" HeaderText="pname" SortExpression="pname" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pdesc" HeaderText="pdesc" SortExpression="pdesc" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pleftcnt" HeaderText="pleftcnt" SortExpression="pleftcnt" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="plupdatetime" HeaderText="plupdatetime" SortExpression="plupdatetime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="psumcnt" HeaderText="psumcnt" SortExpression="psumcnt" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="psalecnt" HeaderText="psalecnt" SortExpression="psalecnt" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pls1" HeaderText="pls1" SortExpression="pls1" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pls2" HeaderText="pls2" SortExpression="pls2" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pls3" HeaderText="pls3" SortExpression="pls3" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pls4" HeaderText="pls4" SortExpression="pls4" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pls5" HeaderText="pls5" SortExpression="pls5" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pld1" HeaderText="pld1" SortExpression="pld1" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pld2" HeaderText="pld2" SortExpression="pld2" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pld3" HeaderText="pld3" SortExpression="pld3" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pld4" HeaderText="pld4" SortExpression="pld4" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="pld5" HeaderText="pld5" SortExpression="pld5" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="id,pcode" DataNavigateUrlFormatString="Show.aspx?id0={0}&id1={1}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="id,pcode" DataNavigateUrlFormatString="Modify.aspx?id0={0}&id1={1}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
