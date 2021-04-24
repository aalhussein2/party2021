<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="clientSide.aspx.cs" Inherits="party.demo.clientSide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        // I moved all the javaScript to an external file and referenced it 
       </script>
    <style type="text/css">
        /* moved the style to external file  and referenced it*/
    </style>

        <table class="">
            <tr>
                <td class="" colspan="3">
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
                </td>
                <td class="" rowspan="5">
                    see the difference between client side and server side control.
                </td>
            </tr>
            <tr>
                <td class="">Name:</td>
                <td class="">&nbsp;</td>
                <td class=""> <input id="txtName" type="text" /></td>
            </tr>
            <tr>
                <td class="">Age</td>
                <td class="">&nbsp;</td>
                <td class=""><input id="txtAge" type="text" /> </td>
            </tr>
            <tr>
                <td class="">Dep</td>
                <td class="">&nbsp;</td>
                <td class=""><input id="txtDep" type="text" /></td>
            </tr>
            <tr>
                <td class="">
        <input id="btnSubmit" type="button" value="Submit via HTML tag" 
            onclick ="captureValues()"  /></td>
                <td class="">
                    &nbsp;</td>
                <td class="">
                    <asp:Button ID="btnCallClientCode" runat="server"   Text="CallClientCode via btn server control" 
                        OnClientClick="captureValues()" />
                </td>
            </tr>
        </table>
    <h2>Demo how to capture user input to a div or p</h2>
       <div id ="myDiv"></div>
    <p id="myP"></p>

    <div>
        <input type="button"    id="btnWireOnTheFly" value ="WireOnTheFly" />
        <input type ="text" id="txtSource"  value ="Ali move to target"/>
          <input type ="text" id="txtTarget" value="" />
        <h3>Remember</h3>
        <p> input type of blocks use .innerHTML, but input type of Text use .value</p>
    </div>
    <div style="background-color: #FF0000">
        <ol>
            <li>
                <input id="cb1" type="checkbox"  value="BMW" name="Cars" onclick="ChangeColor()"/></li>
            <li>
                <input id="cb2" type="checkbox"  value="Mazda" name="Cars"/></li>
            <li>
                <input id="cb3" type="checkbox"  value="Toyota" name="Cars" /></li>
            <li></li>
        </ol>
        <input id="Checkbox1" type="checkbox" />
    </div>

    <div></div>
    <header></header>
<nav>   </nav>
    <section>

    </section>
    <article></article>
    <aside></aside>
    <footer></footer>

    <br />
    <div class="myContentxx">
        <fieldset class="InputFormxx">
            <legend><strong>How to design your input form</strong></legend>
            <asp:Label ID="lblOutput2" runat="server" Text="" CssClass="myFormOutputxx"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblName" runat="server" Text=" Name:" CssClass="myFormCaption"></asp:Label>
            <asp:TextBox ID="txtName2" runat="server" CssClass="myFormInputControlsxx"></asp:TextBox><br />

            <asp:Label ID="lblAge" runat="server" Text=" Age:" CssClass="myFormCaption"></asp:Label>
            <asp:TextBox ID="txtAge2" runat="server" CssClass="myFormInputControlsxx"></asp:TextBox><br />

            <asp:Label ID="lblDep" runat="server" Text=" Department:" CssClass="myFormCaption"></asp:Label>
            <asp:TextBox ID="txtDep2" runat="server" CssClass="myFormInputControlsxx"></asp:TextBox><br />

            <input id="btnSubmit2" type="button" value="Submit via HTML tag" class="submitButton"
                onclick="captureValues()" />
               <asp:Button ID="btnSubmit3" runat="server"   Text="CallClientCode via btn server control" 
                      OnClientClick="captureValues()"  class="submitButton"/>
        </fieldset>
    </div>
    <div class="container"> continer</div>
    <div class="blue"> blue</div>
    <div class="yellow">yellow</div>
    <div class="orange">Orange</div>


    </asp:Content>
