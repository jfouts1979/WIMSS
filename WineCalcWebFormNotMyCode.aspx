using System.Data;

<table>  
        <tr>  
            <td colspan="4">  
                 </td>  
        </tr>  
        <tr>  
            <td colspan="4">  
                <asp:TextBox ID="DisplayTextBox1" runat="server" Height="45px" Width="375px"   
                    TextMode="MultiLine" Font-Bold="True" Font-Size="X-Large" ReadOnly="True"></asp:TextBox>  
            </td>  
        </tr>  
        <tr>  
            <td colspan="4" height="30px">  
                <asp:Label ID="Answer" runat="server" Font-Bold="True"   
                    Font-Size="X-Large"></asp:Label>  
            </td>  
        </tr>  
        <tr>  
            <td>  
                <asp:Button ID="Button21" runat="server" Height="50px" Text="("   
                    Width="95px" onclick="Button21_Click" />  
            </td>  
            <td>  
                <asp:Button ID="Button22" runat="server" Height="50px" Text=")"   
                    Width="95px" onclick="Button22_Click" />  
            </td>  
            <td>  
                <asp:Button ID="Button24" runat="server" Height="50px" Text="DEL"   
                    Width="95px" onclick="Button24_Click" />  
            </td>  
            <td>  
                <asp:Button ID="Button25" runat="server" Height="50px" Text="AC"   
                    Width="95px" onclick="Button25_Click" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                <asp:Button ID="ButtonNumber7" runat="server" Height="50px" Text="7"   
                    Width="95px" onclick="ButtonNumber7_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumber8" runat="server" Height="50px" Text="8"   
                    Width="95px" onclick="ButtonNumber8_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumber9" runat="server" Height="50px" Text="9"   
                    Width="95px" onclick="ButtonNumber9_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumberDevide" runat="server" Height="50px" Text="÷"   
                    Width="95px"  ForeColor="Black"   
                    onclick="ButtonNumberDevide_Click" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                <asp:Button ID="ButtonNumber4" runat="server" Height="50px" Text="4"   
                    Width="95px" onclick="ButtonNumber4_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumber5" runat="server" Height="50px" Text="5"   
                    Width="95px" onclick="ButtonNumber5_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumber6" runat="server" Height="50px" Text="6"   
                    Width="95px" onclick="ButtonNumber6_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumberMulti" runat="server" Height="50px" Text="X"   
                    Width="95px"  onclick="ButtonNumberMulti_Click" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                <asp:Button ID="ButtonNumber1" runat="server" Height="50px" Text="1"   
                    Width="95px" onclick="ButtonNumber1_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumber2" runat="server" Height="50px" Text="2"   
                    Width="95px" onclick="ButtonNumber2_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumber3" runat="server" Height="50px" Text="3"   
                    Width="95px" ClientIDMode="AutoID" onclick="ButtonNumber3_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumberMinus" runat="server" Height="50px" Text="_"   
                    Width="95px"  onclick="ButtonNumberMinus_Click" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                <asp:Button ID="ButtonNumber0" runat="server" Height="50px" Text="0"   
                    Width="95px" onclick="ButtonNumber0_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumberdot" runat="server" Height="50px" Text="."   
                    Width="95px" onclick="ButtonNumberdot_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumberEqual" runat="server" Height="50px" Text="="   
                    Width="95px"  onclick="ButtonNumberEqual_Click" />  
            </td>  
            <td>  
                <asp:Button ID="ButtonNumberPlus" runat="server" Height="50px" Text="+"   
                    Width="95px"  onclick="ButtonNumberPlus_Click" />  
            </td>  
        </tr>  
    </table>  