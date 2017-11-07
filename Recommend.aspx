<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recommend.aspx.cs" Inherits="Recommend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <LINK href="zengarden-sample.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <table class="initial">
           <tr>
                <td class="initial" colspan="2" align="center">
                    <asp:Label ID="capSubj" runat="server" Width="557px"
                        Text="Recommend Product" Font-Bold="True" 
                        ForeColor="#FF0066"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="initial" colspan="2" align="center">
                    <asp:Label ID="lblMessg" runat="server" Width="557px"
                        Text="" Font-Bold="True" 
                        ForeColor="#0066FF"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="style1">
                    <asp:Label ID="capFile" runat="server" Text="File of Products:"></asp:Label>
                </td>
                <td class="style1">
                    <asp:FileUpload ID="updFile" runat="server"></asp:FileUpload>
                </td>
            </tr>
             <tr>
                <td class="style1">
                    <asp:Label ID="capUrl" runat="server" Text="File of Urls:"></asp:Label>
                </td>
                <td class="style1">
                    <asp:FileUpload ID="updUrl" runat="server"></asp:FileUpload>
                </td>
            </tr>
           <tr>
                <td>
                    <asp:Label ID="capProd" runat="server" Text="Title of Product:"></asp:Label>
                </td>
               <td>
                   <asp:TextBox ID="txtProd" runat="server" Width="452px"></asp:TextBox>
               </td>
            </tr>
            
           <tr>
                <td colspan="2">
                    <asp:Label ID="capRecomm" runat="server" Text=""></asp:Label>
                </td>
              
            </tr>

          
            <tr>
               <td align="left" colspan="2">
                     <asp:Button ID="btnCheck" runat="server" Text="Recommend Products" 
                         EnableTheming="True" onclick="btnCheck_Click" />
                     <asp:Button ID="btnDist" runat="server" Text="Make Distinct" 
                         EnableTheming="True" onclick="btnDist_Click"  />
                     
                     
               </td>
            </tr>

            
        </table>
     
    </div>
    </form>
</body>
</html>
